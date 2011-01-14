﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file NDMSInvestigation.Entities.AspnetUsers.cs instead.
*/

#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Web.Services.Protocols;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Data.Bases;

#endregion

namespace NDMSInvestigation.Data.WebServiceClient
{

	///<summary>
	/// This class is the webservice client implementation that exposes CRUD methods for NDMSInvestigation.Entities.AspnetUsers objects.
	///</summary>
	public abstract partial class WsAspnetUsersProviderBase : AspnetUsersProviderBase
	{
		#region Declarations	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion Declarations
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsAspnetUsersProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsAspnetUsersProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsAspnetUsersProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsAspnetUsersProviderBase(string url)
		{
			this.Url = url;
		}
			
		#endregion Constructors
		
		#region Url
		///<summary>
		/// Current URL for webservice endpoint. 
		///</summary>
		public string Url
        {
        	get {return url;}
        	set {url = value;}
        }
		#endregion 
		
		#region Convertion utility
		
		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static NDMSInvestigation.Entities.TList<AspnetUsers> Convert(WsProxy.AspnetUsers[] items)
		{
			NDMSInvestigation.Entities.TList<AspnetUsers> outItems = new NDMSInvestigation.Entities.TList<AspnetUsers>();
			foreach(WsProxy.AspnetUsers item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static NDMSInvestigation.Entities.AspnetUsers Convert(WsProxy.AspnetUsers item)
		{	
			NDMSInvestigation.Entities.AspnetUsers outItem = item == null ? null : new NDMSInvestigation.Entities.AspnetUsers();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static NDMSInvestigation.Entities.AspnetUsers Convert(NDMSInvestigation.Entities.AspnetUsers outItem , WsProxy.AspnetUsers item)
		{	
			if (item != null && outItem != null)
			{
				outItem.ApplicationId = item.ApplicationId;
				outItem.UserId = item.UserId;
				outItem.UserName = item.UserName;
				outItem.LoweredUserName = item.LoweredUserName;
				outItem.MobileAlias = item.MobileAlias;
				outItem.IsAnonymous = item.IsAnonymous;
				outItem.LastActivityDate = item.LastActivityDate;
				
				outItem.AcceptChanges();			
			}
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.AspnetUsers Convert(NDMSInvestigation.Entities.AspnetUsers item)
		{			
			WsProxy.AspnetUsers outItem = new WsProxy.AspnetUsers();			
			outItem.ApplicationId = item.ApplicationId;
			outItem.UserId = item.UserId;
			outItem.UserName = item.UserName;
			outItem.LoweredUserName = item.LoweredUserName;
			outItem.MobileAlias = item.MobileAlias;
			outItem.IsAnonymous = item.IsAnonymous;
			outItem.LastActivityDate = item.LastActivityDate;

							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.AspnetUsers[] Convert(NDMSInvestigation.Entities.TList<AspnetUsers> items)
		{
			WsProxy.AspnetUsers[] outItems = new WsProxy.AspnetUsers[items.Count];
			int count = 0;
		
			foreach (NDMSInvestigation.Entities.AspnetUsers item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}

		
		#endregion
		
		#region Get from  Many To Many Relationship Functions
		#region GetByRoleIdFromAspnetUsersInRoles
		
		/// <summary>
		///		Gets aspnet_Users objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="_roleId"></param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public override TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(TransactionManager transactionManager, System.Guid _roleId, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
				
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_GetByRoleIdFromAspnetUsersInRoles(_roleId, start, pagelen, out count);
	
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetByRoleIdFromAspnetUsersInRoles
		
		#region GetByGroupIdFromResult
		
		/// <summary>
		///		Gets aspnet_Users objects from the datasource by GroupId in the
		///		Result table. Table aspnet_Users is related to table QuestionGroup
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public override TList<AspnetUsers> GetByGroupIdFromResult(TransactionManager transactionManager, System.Int32 _groupId, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
				
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_GetByGroupIdFromResult(_groupId, start, pagelen, out count);
	
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetByGroupIdFromResult
		
		#endregion	
		
		
		#region Delete Methods
			
			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="_userId">. Primary Key.</param>	
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Guid _userId)
			{
				try
				{
				// call the proxy
				WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
				proxy.Url = Url;
				
				bool result = proxy.AspnetUsersProvider_Delete(_userId);				
				return result;
				}
				catch(SoapException soex)
				{
					System.Diagnostics.Debug.WriteLine(soex);
					throw soex;
				}
				catch(Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex);
					throw ex;
				}
			}
			
			#endregion Delete Methods
	
		
		#region Find Methods
		
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public override NDMSInvestigation.Entities.TList<AspnetUsers> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_Find(whereClause, start, pagelen, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Find Methods
		
		
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>			
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public override NDMSInvestigation.Entities.TList<AspnetUsers> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
				
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_GetAll(start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetAll Methods
		
		#region GetPaged Methods
						
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public override NDMSInvestigation.Entities.TList<AspnetUsers> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			whereClause = whereClause ?? string.Empty;
			orderBy = orderBy ?? string.Empty;
			
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
			// Create a collection and fill it with the dataset
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetPaged Methods
	
		
		#region Get By Foreign Key Functions
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		FK__aspnet_Us__Appli__0425A276 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public override NDMSInvestigation.Entities.TList<AspnetUsers> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_GetByApplicationId(_applicationId, start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
			
		#endregion
		
		
		#region Get By Index Functions
					
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public override NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredUserName, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.AspnetUsers items = proxy.AspnetUsersProvider_GetByApplicationIdLoweredUserName(_applicationId, _loweredUserName, start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
					
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TList&lt;AspnetUsers&gt;"/> class.</returns>
		public override NDMSInvestigation.Entities.TList<AspnetUsers> GetByApplicationIdLastActivityDate(TransactionManager transactionManager, System.Guid _applicationId, System.DateTime _lastActivityDate, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.AspnetUsers[] items = proxy.AspnetUsersProvider_GetByApplicationIdLastActivityDate(_applicationId, _lastActivityDate, start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public override NDMSInvestigation.Entities.AspnetUsers GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.AspnetUsers items = proxy.AspnetUsersProvider_GetByUserId(_userId, start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Get By Index Functions
	
	
		#region Insert Methods
		/// <summary>
		/// 	Inserts a NDMSInvestigation.Entities.AspnetUsers object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetUsers object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetUsers entity)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.AspnetUsers result = proxy.AspnetUsersProvider_Insert(Convert(entity));
				Convert(entity, result);
				return true;
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
	
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">NOTE: The transaction manager should be null for the web service client implementation.</param>
		/// <param name="entityList">The entities.</param>
		/// <remarks>
		/// After inserting into the datasource, the NDMSInvestigation.Entities.AspnetUsers object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, NDMSInvestigation.Entities.TList<AspnetUsers> entityList)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			try
			{
				proxy.AspnetUsersProvider_BulkInsert(Convert(entityList));
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch (Exception ex)
			{	
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion Insert Methods
	
	
		#region Update Methods
						
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetUsers object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetUsers entity)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.AspnetUsers result = proxy.AspnetUsersProvider_Update(Convert(entity));
				Convert(entity, result);
				entity.AcceptChanges();
				return true;
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Update Methods
			
		#region Custom Methods
		
		
		#endregion
					
	}//end class
} // end namespace