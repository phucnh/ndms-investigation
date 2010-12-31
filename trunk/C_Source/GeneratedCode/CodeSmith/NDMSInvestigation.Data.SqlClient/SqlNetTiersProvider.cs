
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;
using NDMSInvestigation.Data.Bases;

#endregion

namespace NDMSInvestigation.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : NDMSInvestigation.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "CompanyDetailsProvider"
			
		private SqlCompanyDetailsProvider innerSqlCompanyDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CompanyDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CompanyDetailsProviderBase CompanyDetailsProvider
		{
			get
			{
				if (innerSqlCompanyDetailsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCompanyDetailsProvider == null)
						{
							this.innerSqlCompanyDetailsProvider = new SqlCompanyDetailsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCompanyDetailsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCompanyDetailsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCompanyDetailsProvider SqlCompanyDetailsProvider
		{
			get {return CompanyDetailsProvider as SqlCompanyDetailsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetUsersInRolesProvider"
			
		private SqlAspnetUsersInRolesProvider innerSqlAspnetUsersInRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetUsersInRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetUsersInRolesProviderBase AspnetUsersInRolesProvider
		{
			get
			{
				if (innerSqlAspnetUsersInRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetUsersInRolesProvider == null)
						{
							this.innerSqlAspnetUsersInRolesProvider = new SqlAspnetUsersInRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetUsersInRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetUsersInRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetUsersInRolesProvider SqlAspnetUsersInRolesProvider
		{
			get {return AspnetUsersInRolesProvider as SqlAspnetUsersInRolesProvider;}
		}
		
		#endregion
		
		
		#region "AnswerDetailsProvider"
			
		private SqlAnswerDetailsProvider innerSqlAnswerDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AnswerDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AnswerDetailsProviderBase AnswerDetailsProvider
		{
			get
			{
				if (innerSqlAnswerDetailsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAnswerDetailsProvider == null)
						{
							this.innerSqlAnswerDetailsProvider = new SqlAnswerDetailsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAnswerDetailsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAnswerDetailsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAnswerDetailsProvider SqlAnswerDetailsProvider
		{
			get {return AnswerDetailsProvider as SqlAnswerDetailsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetWebEventEventsProvider"
			
		private SqlAspnetWebEventEventsProvider innerSqlAspnetWebEventEventsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetWebEventEvents"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetWebEventEventsProviderBase AspnetWebEventEventsProvider
		{
			get
			{
				if (innerSqlAspnetWebEventEventsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetWebEventEventsProvider == null)
						{
							this.innerSqlAspnetWebEventEventsProvider = new SqlAspnetWebEventEventsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetWebEventEventsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetWebEventEventsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetWebEventEventsProvider SqlAspnetWebEventEventsProvider
		{
			get {return AspnetWebEventEventsProvider as SqlAspnetWebEventEventsProvider;}
		}
		
		#endregion
		
		
		#region "QuestionGroupsProvider"
			
		private SqlQuestionGroupsProvider innerSqlQuestionGroupsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionGroups"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionGroupsProviderBase QuestionGroupsProvider
		{
			get
			{
				if (innerSqlQuestionGroupsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionGroupsProvider == null)
						{
							this.innerSqlQuestionGroupsProvider = new SqlQuestionGroupsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionGroupsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuestionGroupsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionGroupsProvider SqlQuestionGroupsProvider
		{
			get {return QuestionGroupsProvider as SqlQuestionGroupsProvider;}
		}
		
		#endregion
		
		
		#region "QuestionDetailsProvider"
			
		private SqlQuestionDetailsProvider innerSqlQuestionDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionDetailsProviderBase QuestionDetailsProvider
		{
			get
			{
				if (innerSqlQuestionDetailsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionDetailsProvider == null)
						{
							this.innerSqlQuestionDetailsProvider = new SqlQuestionDetailsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionDetailsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuestionDetailsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionDetailsProvider SqlQuestionDetailsProvider
		{
			get {return QuestionDetailsProvider as SqlQuestionDetailsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetUsersProvider"
			
		private SqlAspnetUsersProvider innerSqlAspnetUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetUsersProviderBase AspnetUsersProvider
		{
			get
			{
				if (innerSqlAspnetUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetUsersProvider == null)
						{
							this.innerSqlAspnetUsersProvider = new SqlAspnetUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetUsersProvider SqlAspnetUsersProvider
		{
			get {return AspnetUsersProvider as SqlAspnetUsersProvider;}
		}
		
		#endregion
		
		
		#region "QuestionAnswerProvider"
			
		private SqlQuestionAnswerProvider innerSqlQuestionAnswerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionAnswerProviderBase QuestionAnswerProvider
		{
			get
			{
				if (innerSqlQuestionAnswerProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlQuestionAnswerProvider == null)
						{
							this.innerSqlQuestionAnswerProvider = new SqlQuestionAnswerProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlQuestionAnswerProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlQuestionAnswerProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlQuestionAnswerProvider SqlQuestionAnswerProvider
		{
			get {return QuestionAnswerProvider as SqlQuestionAnswerProvider;}
		}
		
		#endregion
		
		
		#region "ResultsProvider"
			
		private SqlResultsProvider innerSqlResultsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Results"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ResultsProviderBase ResultsProvider
		{
			get
			{
				if (innerSqlResultsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlResultsProvider == null)
						{
							this.innerSqlResultsProvider = new SqlResultsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlResultsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlResultsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlResultsProvider SqlResultsProvider
		{
			get {return ResultsProvider as SqlResultsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetSchemaVersionsProvider"
			
		private SqlAspnetSchemaVersionsProvider innerSqlAspnetSchemaVersionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetSchemaVersions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetSchemaVersionsProviderBase AspnetSchemaVersionsProvider
		{
			get
			{
				if (innerSqlAspnetSchemaVersionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetSchemaVersionsProvider == null)
						{
							this.innerSqlAspnetSchemaVersionsProvider = new SqlAspnetSchemaVersionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetSchemaVersionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetSchemaVersionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetSchemaVersionsProvider SqlAspnetSchemaVersionsProvider
		{
			get {return AspnetSchemaVersionsProvider as SqlAspnetSchemaVersionsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetApplicationsProvider"
			
		private SqlAspnetApplicationsProvider innerSqlAspnetApplicationsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetApplications"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetApplicationsProviderBase AspnetApplicationsProvider
		{
			get
			{
				if (innerSqlAspnetApplicationsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetApplicationsProvider == null)
						{
							this.innerSqlAspnetApplicationsProvider = new SqlAspnetApplicationsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetApplicationsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetApplicationsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetApplicationsProvider SqlAspnetApplicationsProvider
		{
			get {return AspnetApplicationsProvider as SqlAspnetApplicationsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetMembershipProvider"
			
		private SqlAspnetMembershipProvider innerSqlAspnetMembershipProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetMembership"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetMembershipProviderBase AspnetMembershipProvider
		{
			get
			{
				if (innerSqlAspnetMembershipProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetMembershipProvider == null)
						{
							this.innerSqlAspnetMembershipProvider = new SqlAspnetMembershipProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetMembershipProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetMembershipProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetMembershipProvider SqlAspnetMembershipProvider
		{
			get {return AspnetMembershipProvider as SqlAspnetMembershipProvider;}
		}
		
		#endregion
		
		
		#region "AspnetPathsProvider"
			
		private SqlAspnetPathsProvider innerSqlAspnetPathsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetPaths"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetPathsProviderBase AspnetPathsProvider
		{
			get
			{
				if (innerSqlAspnetPathsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetPathsProvider == null)
						{
							this.innerSqlAspnetPathsProvider = new SqlAspnetPathsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetPathsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetPathsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetPathsProvider SqlAspnetPathsProvider
		{
			get {return AspnetPathsProvider as SqlAspnetPathsProvider;}
		}
		
		#endregion
		
		
		#region "AspnetPersonalizationAllUsersProvider"
			
		private SqlAspnetPersonalizationAllUsersProvider innerSqlAspnetPersonalizationAllUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetPersonalizationAllUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetPersonalizationAllUsersProviderBase AspnetPersonalizationAllUsersProvider
		{
			get
			{
				if (innerSqlAspnetPersonalizationAllUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetPersonalizationAllUsersProvider == null)
						{
							this.innerSqlAspnetPersonalizationAllUsersProvider = new SqlAspnetPersonalizationAllUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetPersonalizationAllUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetPersonalizationAllUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetPersonalizationAllUsersProvider SqlAspnetPersonalizationAllUsersProvider
		{
			get {return AspnetPersonalizationAllUsersProvider as SqlAspnetPersonalizationAllUsersProvider;}
		}
		
		#endregion
		
		
		#region "AspnetRolesProvider"
			
		private SqlAspnetRolesProvider innerSqlAspnetRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetRolesProviderBase AspnetRolesProvider
		{
			get
			{
				if (innerSqlAspnetRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetRolesProvider == null)
						{
							this.innerSqlAspnetRolesProvider = new SqlAspnetRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetRolesProvider SqlAspnetRolesProvider
		{
			get {return AspnetRolesProvider as SqlAspnetRolesProvider;}
		}
		
		#endregion
		
		
		#region "AspnetPersonalizationPerUserProvider"
			
		private SqlAspnetPersonalizationPerUserProvider innerSqlAspnetPersonalizationPerUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetPersonalizationPerUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetPersonalizationPerUserProviderBase AspnetPersonalizationPerUserProvider
		{
			get
			{
				if (innerSqlAspnetPersonalizationPerUserProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetPersonalizationPerUserProvider == null)
						{
							this.innerSqlAspnetPersonalizationPerUserProvider = new SqlAspnetPersonalizationPerUserProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetPersonalizationPerUserProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetPersonalizationPerUserProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetPersonalizationPerUserProvider SqlAspnetPersonalizationPerUserProvider
		{
			get {return AspnetPersonalizationPerUserProvider as SqlAspnetPersonalizationPerUserProvider;}
		}
		
		#endregion
		
		
		#region "TraceChangeProvider"
			
		private SqlTraceChangeProvider innerSqlTraceChangeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="TraceChange"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override TraceChangeProviderBase TraceChangeProvider
		{
			get
			{
				if (innerSqlTraceChangeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlTraceChangeProvider == null)
						{
							this.innerSqlTraceChangeProvider = new SqlTraceChangeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlTraceChangeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlTraceChangeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlTraceChangeProvider SqlTraceChangeProvider
		{
			get {return TraceChangeProvider as SqlTraceChangeProvider;}
		}
		
		#endregion
		
		
		#region "AspnetProfileProvider"
			
		private SqlAspnetProfileProvider innerSqlAspnetProfileProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetProfile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetProfileProviderBase AspnetProfileProvider
		{
			get
			{
				if (innerSqlAspnetProfileProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAspnetProfileProvider == null)
						{
							this.innerSqlAspnetProfileProvider = new SqlAspnetProfileProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAspnetProfileProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAspnetProfileProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAspnetProfileProvider SqlAspnetProfileProvider
		{
			get {return AspnetProfileProvider as SqlAspnetProfileProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
