

#region Using directives

using System;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Data.Bases;

#endregion

namespace NDMSInvestigation.Data.WebServiceClient
{
	/// <summary>
	/// The WebService client data provider.
	/// </summary>
	public sealed class WsNetTiersProvider : NDMSInvestigation.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
		private string url;
        
		/// <summary>
		/// Initializes a new instance of the <see cref="WsNetTiersProvider"/> class.
		///</summary>
		public WsNetTiersProvider()
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


            #region Initialize Url
            string url  = config["url"];
           	if (string.IsNullOrEmpty(url))
            {
                throw new ProviderException("Empty or missing url");
            }
            this.url = url;
            config.Remove("url");
            #endregion

        }
        
		/// <summary>
		/// Current Url for WebService EndPoint
		/// </summary>
        public string Url
        {
        	get {return this.url;}
        	set {this.url = value;}
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			throw new NotSupportedException("Transactions are not supported by the webservice client.");
		}
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return false;
			}
		}

			
		private WsQuestionGroupProvider innerQuestionGroupProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionGroupProviderBase QuestionGroupProvider
		{
			get
			{
				if (innerQuestionGroupProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerQuestionGroupProvider == null)
						{
							this.innerQuestionGroupProvider = new WsQuestionGroupProvider(this.url);
						}
					}
				}
				return innerQuestionGroupProvider;
			}
		}
		
			
		private WsAnswerDetailsProvider innerAnswerDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AnswerDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AnswerDetailsProviderBase AnswerDetailsProvider
		{
			get
			{
				if (innerAnswerDetailsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAnswerDetailsProvider == null)
						{
							this.innerAnswerDetailsProvider = new WsAnswerDetailsProvider(this.url);
						}
					}
				}
				return innerAnswerDetailsProvider;
			}
		}
		
			
		private WsAspnetWebEventEventsProvider innerAspnetWebEventEventsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetWebEventEvents"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetWebEventEventsProviderBase AspnetWebEventEventsProvider
		{
			get
			{
				if (innerAspnetWebEventEventsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetWebEventEventsProvider == null)
						{
							this.innerAspnetWebEventEventsProvider = new WsAspnetWebEventEventsProvider(this.url);
						}
					}
				}
				return innerAspnetWebEventEventsProvider;
			}
		}
		
			
		private WsAspnetUsersInRolesProvider innerAspnetUsersInRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetUsersInRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetUsersInRolesProviderBase AspnetUsersInRolesProvider
		{
			get
			{
				if (innerAspnetUsersInRolesProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetUsersInRolesProvider == null)
						{
							this.innerAspnetUsersInRolesProvider = new WsAspnetUsersInRolesProvider(this.url);
						}
					}
				}
				return innerAspnetUsersInRolesProvider;
			}
		}
		
			
		private WsResultProvider innerResultProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Result"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ResultProviderBase ResultProvider
		{
			get
			{
				if (innerResultProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerResultProvider == null)
						{
							this.innerResultProvider = new WsResultProvider(this.url);
						}
					}
				}
				return innerResultProvider;
			}
		}
		
			
		private WsQuestionDetailsProvider innerQuestionDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionDetailsProviderBase QuestionDetailsProvider
		{
			get
			{
				if (innerQuestionDetailsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerQuestionDetailsProvider == null)
						{
							this.innerQuestionDetailsProvider = new WsQuestionDetailsProvider(this.url);
						}
					}
				}
				return innerQuestionDetailsProvider;
			}
		}
		
			
		private WsQuestionAnswerProvider innerQuestionAnswerProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="QuestionAnswer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override QuestionAnswerProviderBase QuestionAnswerProvider
		{
			get
			{
				if (innerQuestionAnswerProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerQuestionAnswerProvider == null)
						{
							this.innerQuestionAnswerProvider = new WsQuestionAnswerProvider(this.url);
						}
					}
				}
				return innerQuestionAnswerProvider;
			}
		}
		
			
		private WsAspnetUsersProvider innerAspnetUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetUsersProviderBase AspnetUsersProvider
		{
			get
			{
				if (innerAspnetUsersProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetUsersProvider == null)
						{
							this.innerAspnetUsersProvider = new WsAspnetUsersProvider(this.url);
						}
					}
				}
				return innerAspnetUsersProvider;
			}
		}
		
			
		private WsAspnetSchemaVersionsProvider innerAspnetSchemaVersionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetSchemaVersions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetSchemaVersionsProviderBase AspnetSchemaVersionsProvider
		{
			get
			{
				if (innerAspnetSchemaVersionsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetSchemaVersionsProvider == null)
						{
							this.innerAspnetSchemaVersionsProvider = new WsAspnetSchemaVersionsProvider(this.url);
						}
					}
				}
				return innerAspnetSchemaVersionsProvider;
			}
		}
		
			
		private WsAspnetApplicationsProvider innerAspnetApplicationsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetApplications"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetApplicationsProviderBase AspnetApplicationsProvider
		{
			get
			{
				if (innerAspnetApplicationsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetApplicationsProvider == null)
						{
							this.innerAspnetApplicationsProvider = new WsAspnetApplicationsProvider(this.url);
						}
					}
				}
				return innerAspnetApplicationsProvider;
			}
		}
		
			
		private WsAspnetRolesProvider innerAspnetRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetRolesProviderBase AspnetRolesProvider
		{
			get
			{
				if (innerAspnetRolesProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetRolesProvider == null)
						{
							this.innerAspnetRolesProvider = new WsAspnetRolesProvider(this.url);
						}
					}
				}
				return innerAspnetRolesProvider;
			}
		}
		
			
		private WsAspnetMembershipProvider innerAspnetMembershipProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetMembership"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetMembershipProviderBase AspnetMembershipProvider
		{
			get
			{
				if (innerAspnetMembershipProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetMembershipProvider == null)
						{
							this.innerAspnetMembershipProvider = new WsAspnetMembershipProvider(this.url);
						}
					}
				}
				return innerAspnetMembershipProvider;
			}
		}
		
			
		private WsAspnetPathsProvider innerAspnetPathsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetPaths"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetPathsProviderBase AspnetPathsProvider
		{
			get
			{
				if (innerAspnetPathsProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetPathsProvider == null)
						{
							this.innerAspnetPathsProvider = new WsAspnetPathsProvider(this.url);
						}
					}
				}
				return innerAspnetPathsProvider;
			}
		}
		
			
		private WsAspnetProfileProvider innerAspnetProfileProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetProfile"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetProfileProviderBase AspnetProfileProvider
		{
			get
			{
				if (innerAspnetProfileProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetProfileProvider == null)
						{
							this.innerAspnetProfileProvider = new WsAspnetProfileProvider(this.url);
						}
					}
				}
				return innerAspnetProfileProvider;
			}
		}
		
			
		private WsAspnetPersonalizationAllUsersProvider innerAspnetPersonalizationAllUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetPersonalizationAllUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetPersonalizationAllUsersProviderBase AspnetPersonalizationAllUsersProvider
		{
			get
			{
				if (innerAspnetPersonalizationAllUsersProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetPersonalizationAllUsersProvider == null)
						{
							this.innerAspnetPersonalizationAllUsersProvider = new WsAspnetPersonalizationAllUsersProvider(this.url);
						}
					}
				}
				return innerAspnetPersonalizationAllUsersProvider;
			}
		}
		
			
		private WsUserProvider innerUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="User"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserProviderBase UserProvider
		{
			get
			{
				if (innerUserProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerUserProvider == null)
						{
							this.innerUserProvider = new WsUserProvider(this.url);
						}
					}
				}
				return innerUserProvider;
			}
		}
		
			
		private WsAspnetPersonalizationPerUserProvider innerAspnetPersonalizationPerUserProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AspnetPersonalizationPerUser"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AspnetPersonalizationPerUserProviderBase AspnetPersonalizationPerUserProvider
		{
			get
			{
				if (innerAspnetPersonalizationPerUserProvider == null) 
				{
					lock (syncRoot)
					{
						if (innerAspnetPersonalizationPerUserProvider == null)
						{
							this.innerAspnetPersonalizationPerUserProvider = new WsAspnetPersonalizationPerUserProvider(this.url);
						}
					}
				}
				return innerAspnetPersonalizationPerUserProvider;
			}
		}
		
		
		
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
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = this.url;
			return proxy.ExecuteNonQuery(storedProcedureName, parameterValues);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = this.url;
			return proxy.ExecuteNonQuery((WsProxy.CommandType)Enum.Parse(typeof(WsProxy.CommandType), commandType.ToString(), false), commandText);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
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
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
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
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
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
			throw new NotSupportedException("ExecuteReader methods are not supported by the WebService provider.");
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
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = this.url;
			return proxy.ExecuteDataSet(storedProcedureName, parameterValues);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = this.url;
			return proxy.ExecuteDataSet((WsProxy.CommandType)Enum.Parse(typeof(WsProxy.CommandType), commandType.ToString(), false), commandText);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");			
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
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = this.url;
			return proxy.ExecuteScalar(storedProcedureName, parameterValues);
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			throw new NotSupportedException("DBCommandWrapper overloads are not supported by the WebService provider.");
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = this.url;
			return proxy.ExecuteScalar((WsProxy.CommandType)Enum.Parse(typeof(WsProxy.CommandType), commandType.ToString(), false), commandText);	
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
			throw new NotSupportedException("TransactionManager overloads are not supported by the WebService provider.");		
		}
		#endregion

		#endregion
	}
}
