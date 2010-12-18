#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;
using NDMSInvestigation.Data.Bases;

#endregion

namespace NDMSInvestigation.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("NDMSInvestigation.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region QuestionGroupProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionGroupProviderBase QuestionGroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionGroupProvider;
			}
		}
		
		#endregion
		
		#region AnswerDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AnswerDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AnswerDetailsProviderBase AnswerDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AnswerDetailsProvider;
			}
		}
		
		#endregion
		
		#region AspnetWebEventEventsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetWebEventEvents"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetWebEventEventsProviderBase AspnetWebEventEventsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetWebEventEventsProvider;
			}
		}
		
		#endregion
		
		#region AspnetUsersInRolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetUsersInRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetUsersInRolesProviderBase AspnetUsersInRolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetUsersInRolesProvider;
			}
		}
		
		#endregion
		
		#region ResultProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Result"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ResultProviderBase ResultProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ResultProvider;
			}
		}
		
		#endregion
		
		#region QuestionDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionDetailsProviderBase QuestionDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionDetailsProvider;
			}
		}
		
		#endregion
		
		#region QuestionAnswerProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="QuestionAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static QuestionAnswerProviderBase QuestionAnswerProvider
		{
			get 
			{
				LoadProviders();
				return _provider.QuestionAnswerProvider;
			}
		}
		
		#endregion
		
		#region AspnetUsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetUsersProviderBase AspnetUsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetUsersProvider;
			}
		}
		
		#endregion
		
		#region AspnetSchemaVersionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetSchemaVersions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetSchemaVersionsProviderBase AspnetSchemaVersionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetSchemaVersionsProvider;
			}
		}
		
		#endregion
		
		#region AspnetApplicationsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetApplications"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetApplicationsProviderBase AspnetApplicationsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetApplicationsProvider;
			}
		}
		
		#endregion
		
		#region AspnetRolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetRolesProviderBase AspnetRolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetRolesProvider;
			}
		}
		
		#endregion
		
		#region AspnetMembershipProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetMembership"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetMembershipProviderBase AspnetMembershipProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetMembershipProvider;
			}
		}
		
		#endregion
		
		#region AspnetPathsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetPaths"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetPathsProviderBase AspnetPathsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetPathsProvider;
			}
		}
		
		#endregion
		
		#region AspnetProfileProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetProfile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetProfileProviderBase AspnetProfileProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetProfileProvider;
			}
		}
		
		#endregion
		
		#region AspnetPersonalizationAllUsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetPersonalizationAllUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetPersonalizationAllUsersProviderBase AspnetPersonalizationAllUsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetPersonalizationAllUsersProvider;
			}
		}
		
		#endregion
		
		#region UserProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserProviderBase UserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserProvider;
			}
		}
		
		#endregion
		
		#region AspnetPersonalizationPerUserProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AspnetPersonalizationPerUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AspnetPersonalizationPerUserProviderBase AspnetPersonalizationPerUserProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AspnetPersonalizationPerUserProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region QuestionGroupFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupFilters : QuestionGroupFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilters class.
		/// </summary>
		public QuestionGroupFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupFilters
	
	#region QuestionGroupQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionGroupParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupQuery : QuestionGroupParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupQuery class.
		/// </summary>
		public QuestionGroupQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupQuery
		
	#region AnswerDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsFilters : AnswerDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsFilters class.
		/// </summary>
		public AnswerDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AnswerDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AnswerDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AnswerDetailsFilters
	
	#region AnswerDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AnswerDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsQuery : AnswerDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsQuery class.
		/// </summary>
		public AnswerDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AnswerDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AnswerDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AnswerDetailsQuery
		
	#region AspnetWebEventEventsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsFilters : AspnetWebEventEventsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsFilters class.
		/// </summary>
		public AspnetWebEventEventsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetWebEventEventsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetWebEventEventsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetWebEventEventsFilters
	
	#region AspnetWebEventEventsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetWebEventEventsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsQuery : AspnetWebEventEventsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsQuery class.
		/// </summary>
		public AspnetWebEventEventsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetWebEventEventsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetWebEventEventsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetWebEventEventsQuery
		
	#region AspnetUsersInRolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsersInRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersInRolesFilters : AspnetUsersInRolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesFilters class.
		/// </summary>
		public AspnetUsersInRolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetUsersInRolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetUsersInRolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetUsersInRolesFilters
	
	#region AspnetUsersInRolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetUsersInRolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetUsersInRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersInRolesQuery : AspnetUsersInRolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesQuery class.
		/// </summary>
		public AspnetUsersInRolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetUsersInRolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetUsersInRolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetUsersInRolesQuery
		
	#region ResultFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultFilters : ResultFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultFilters class.
		/// </summary>
		public ResultFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResultFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResultFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResultFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResultFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResultFilters
	
	#region ResultQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ResultParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultQuery : ResultParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultQuery class.
		/// </summary>
		public ResultQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResultQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResultQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResultQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResultQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResultQuery
		
	#region QuestionDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsFilters : QuestionDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsFilters class.
		/// </summary>
		public QuestionDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionDetailsFilters
	
	#region QuestionDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsQuery : QuestionDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsQuery class.
		/// </summary>
		public QuestionDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionDetailsQuery
		
	#region QuestionAnswerFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerFilters : QuestionAnswerFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerFilters class.
		/// </summary>
		public QuestionAnswerFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionAnswerFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionAnswerFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionAnswerFilters
	
	#region QuestionAnswerQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="QuestionAnswerParameterBuilder"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerQuery : QuestionAnswerParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerQuery class.
		/// </summary>
		public QuestionAnswerQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionAnswerQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionAnswerQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionAnswerQuery
		
	#region AspnetUsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersFilters : AspnetUsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersFilters class.
		/// </summary>
		public AspnetUsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetUsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetUsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetUsersFilters
	
	#region AspnetUsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetUsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersQuery : AspnetUsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersQuery class.
		/// </summary>
		public AspnetUsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetUsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetUsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetUsersQuery
		
	#region AspnetSchemaVersionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsFilters : AspnetSchemaVersionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsFilters class.
		/// </summary>
		public AspnetSchemaVersionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetSchemaVersionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetSchemaVersionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetSchemaVersionsFilters
	
	#region AspnetSchemaVersionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetSchemaVersionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsQuery : AspnetSchemaVersionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsQuery class.
		/// </summary>
		public AspnetSchemaVersionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetSchemaVersionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetSchemaVersionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetSchemaVersionsQuery
		
	#region AspnetApplicationsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsFilters : AspnetApplicationsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsFilters class.
		/// </summary>
		public AspnetApplicationsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetApplicationsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetApplicationsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetApplicationsFilters
	
	#region AspnetApplicationsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetApplicationsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsQuery : AspnetApplicationsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsQuery class.
		/// </summary>
		public AspnetApplicationsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetApplicationsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetApplicationsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetApplicationsQuery
		
	#region AspnetRolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesFilters : AspnetRolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesFilters class.
		/// </summary>
		public AspnetRolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetRolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetRolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetRolesFilters
	
	#region AspnetRolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetRolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesQuery : AspnetRolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesQuery class.
		/// </summary>
		public AspnetRolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetRolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetRolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetRolesQuery
		
	#region AspnetMembershipFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipFilters : AspnetMembershipFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipFilters class.
		/// </summary>
		public AspnetMembershipFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetMembershipFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetMembershipFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetMembershipFilters
	
	#region AspnetMembershipQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetMembershipParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipQuery : AspnetMembershipParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipQuery class.
		/// </summary>
		public AspnetMembershipQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetMembershipQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetMembershipQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetMembershipQuery
		
	#region AspnetPathsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsFilters : AspnetPathsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsFilters class.
		/// </summary>
		public AspnetPathsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPathsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPathsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPathsFilters
	
	#region AspnetPathsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetPathsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsQuery : AspnetPathsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsQuery class.
		/// </summary>
		public AspnetPathsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPathsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPathsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPathsQuery
		
	#region AspnetProfileFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetProfile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetProfileFilters : AspnetProfileFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetProfileFilters class.
		/// </summary>
		public AspnetProfileFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetProfileFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetProfileFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetProfileFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetProfileFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetProfileFilters
	
	#region AspnetProfileQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetProfileParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetProfile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetProfileQuery : AspnetProfileParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetProfileQuery class.
		/// </summary>
		public AspnetProfileQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetProfileQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetProfileQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetProfileQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetProfileQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetProfileQuery
		
	#region AspnetPersonalizationAllUsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersFilters : AspnetPersonalizationAllUsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersFilters class.
		/// </summary>
		public AspnetPersonalizationAllUsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationAllUsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationAllUsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationAllUsersFilters
	
	#region AspnetPersonalizationAllUsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetPersonalizationAllUsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersQuery : AspnetPersonalizationAllUsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersQuery class.
		/// </summary>
		public AspnetPersonalizationAllUsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationAllUsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationAllUsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationAllUsersQuery
		
	#region UserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilters : UserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		public UserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilters
	
	#region UserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserQuery : UserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		public UserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserQuery
		
	#region AspnetPersonalizationPerUserFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserFilters : AspnetPersonalizationPerUserFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserFilters class.
		/// </summary>
		public AspnetPersonalizationPerUserFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationPerUserFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationPerUserFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationPerUserFilters
	
	#region AspnetPersonalizationPerUserQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AspnetPersonalizationPerUserParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserQuery : AspnetPersonalizationPerUserParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserQuery class.
		/// </summary>
		public AspnetPersonalizationPerUserQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationPerUserQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationPerUserQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationPerUserQuery
	#endregion

	
}
