﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file NDMSInvestigation.Entities.Result.cs instead.
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
	/// This class is the webservice client implementation that exposes CRUD methods for NDMSInvestigation.Entities.Result objects.
	///</summary>
	public abstract partial class WsResultProviderBase : ResultProviderBase
	{
		#region Declarations	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion Declarations
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsResultProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsResultProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsResultProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsResultProviderBase(string url)
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
		public static NDMSInvestigation.Entities.TList<Result> Convert(WsProxy.Result[] items)
		{
			NDMSInvestigation.Entities.TList<Result> outItems = new NDMSInvestigation.Entities.TList<Result>();
			foreach(WsProxy.Result item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static NDMSInvestigation.Entities.Result Convert(WsProxy.Result item)
		{	
			NDMSInvestigation.Entities.Result outItem = item == null ? null : new NDMSInvestigation.Entities.Result();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static NDMSInvestigation.Entities.Result Convert(NDMSInvestigation.Entities.Result outItem , WsProxy.Result item)
		{	
			if (item != null && outItem != null)
			{
				outItem.UserId = item.UserId;
				outItem.GroupId = item.GroupId;
				outItem.GroupMark = item.GroupMark;
				outItem.UpdateDay = item.UpdateDay;
				
				outItem.OriginalUserId = item.UserId;
				outItem.OriginalGroupId = item.GroupId;
				outItem.AcceptChanges();			
			}
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.Result Convert(NDMSInvestigation.Entities.Result item)
		{			
			WsProxy.Result outItem = new WsProxy.Result();			
			outItem.UserId = item.UserId;
			outItem.GroupId = item.GroupId;
			outItem.GroupMark = item.GroupMark;
			outItem.UpdateDay = item.UpdateDay;

			outItem.OriginalUserId = item.OriginalUserId;
			outItem.OriginalGroupId = item.OriginalGroupId;
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.Result[] Convert(NDMSInvestigation.Entities.TList<Result> items)
		{
			WsProxy.Result[] outItems = new WsProxy.Result[items.Count];
			int count = 0;
		
			foreach (NDMSInvestigation.Entities.Result item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}

		
		#endregion
		
		#region Get from  Many To Many Relationship Functions
		#endregion	
		
		
		#region Delete Methods
			
			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="_userId">. Primary Key.</param>	
			/// <param name="_groupId">. Primary Key.</param>	
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Guid _userId, System.Int32 _groupId)
			{
				try
				{
				// call the proxy
				WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
				proxy.Url = Url;
				
				bool result = proxy.ResultProvider_Delete(_userId, _groupId);				
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
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public override NDMSInvestigation.Entities.TList<Result> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			WsProxy.Result[] items = proxy.ResultProvider_Find(whereClause, start, pagelen, out count);
			
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
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public override NDMSInvestigation.Entities.TList<Result> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
				
			WsProxy.Result[] items = proxy.ResultProvider_GetAll(start, pageLength, out count);
			
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
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public override NDMSInvestigation.Entities.TList<Result> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			whereClause = whereClause ?? string.Empty;
			orderBy = orderBy ?? string.Empty;
			
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			WsProxy.Result[] items = proxy.ResultProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		FK_Result_aspnet_Users Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public override NDMSInvestigation.Entities.TList<Result> GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.Result[] items = proxy.ResultProvider_GetByUserId(_userId, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		FK_Result_QuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public override NDMSInvestigation.Entities.TList<Result> GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.Result[] items = proxy.ResultProvider_GetByGroupId(_groupId, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the PK_Result index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public override NDMSInvestigation.Entities.Result GetByUserIdGroupId(TransactionManager transactionManager, System.Guid _userId, System.Int32 _groupId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.Result items = proxy.ResultProvider_GetByUserIdGroupId(_userId, _groupId, start, pageLength, out count);
			
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
		/// 	Inserts a NDMSInvestigation.Entities.Result object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">NDMSInvestigation.Entities.Result object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, NDMSInvestigation.Entities.Result entity)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.Result result = proxy.ResultProvider_Insert(Convert(entity));
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
		/// After inserting into the datasource, the NDMSInvestigation.Entities.Result object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, NDMSInvestigation.Entities.TList<Result> entityList)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			try
			{
				proxy.ResultProvider_BulkInsert(Convert(entityList));
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
		/// <param name="entity">NDMSInvestigation.Entities.Result object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, NDMSInvestigation.Entities.Result entity)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.Result result = proxy.ResultProvider_Update(Convert(entity));
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