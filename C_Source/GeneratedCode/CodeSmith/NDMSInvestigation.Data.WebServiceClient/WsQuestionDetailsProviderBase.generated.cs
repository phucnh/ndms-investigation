﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file NDMSInvestigation.Entities.QuestionDetails.cs instead.
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
	/// This class is the webservice client implementation that exposes CRUD methods for NDMSInvestigation.Entities.QuestionDetails objects.
	///</summary>
	public abstract partial class WsQuestionDetailsProviderBase : QuestionDetailsProviderBase
	{
		#region Declarations	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion Declarations
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsQuestionDetailsProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsQuestionDetailsProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsQuestionDetailsProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsQuestionDetailsProviderBase(string url)
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
		public static NDMSInvestigation.Entities.TList<QuestionDetails> Convert(WsProxy.QuestionDetails[] items)
		{
			NDMSInvestigation.Entities.TList<QuestionDetails> outItems = new NDMSInvestigation.Entities.TList<QuestionDetails>();
			foreach(WsProxy.QuestionDetails item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static NDMSInvestigation.Entities.QuestionDetails Convert(WsProxy.QuestionDetails item)
		{	
			NDMSInvestigation.Entities.QuestionDetails outItem = item == null ? null : new NDMSInvestigation.Entities.QuestionDetails();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static NDMSInvestigation.Entities.QuestionDetails Convert(NDMSInvestigation.Entities.QuestionDetails outItem , WsProxy.QuestionDetails item)
		{	
			if (item != null && outItem != null)
			{
				outItem.QuestionId = item.QuestionId;
				outItem.QuestionContent = item.QuestionContent;
				outItem.QuestionSuggest = item.QuestionSuggest;
				outItem.QuestionDescription = item.QuestionDescription;
				outItem.GroupId = item.GroupId;
				outItem.OrderNumber = item.OrderNumber;
				
				outItem.AcceptChanges();			
			}
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.QuestionDetails Convert(NDMSInvestigation.Entities.QuestionDetails item)
		{			
			WsProxy.QuestionDetails outItem = new WsProxy.QuestionDetails();			
			outItem.QuestionId = item.QuestionId;
			outItem.QuestionContent = item.QuestionContent;
			outItem.QuestionSuggest = item.QuestionSuggest;
			outItem.QuestionDescription = item.QuestionDescription;
			outItem.GroupId = item.GroupId;
			outItem.OrderNumber = item.OrderNumber;

							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.QuestionDetails[] Convert(NDMSInvestigation.Entities.TList<QuestionDetails> items)
		{
			WsProxy.QuestionDetails[] outItems = new WsProxy.QuestionDetails[items.Count];
			int count = 0;
		
			foreach (NDMSInvestigation.Entities.QuestionDetails item in items)
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
			/// <param name="_questionId">. Primary Key.</param>	
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Int32 _questionId)
			{
				try
				{
				// call the proxy
				WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
				proxy.Url = Url;
				
				bool result = proxy.QuestionDetailsProvider_Delete(_questionId);				
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
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public override NDMSInvestigation.Entities.TList<QuestionDetails> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			WsProxy.QuestionDetails[] items = proxy.QuestionDetailsProvider_Find(whereClause, start, pagelen, out count);
			
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
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public override NDMSInvestigation.Entities.TList<QuestionDetails> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
				
			WsProxy.QuestionDetails[] items = proxy.QuestionDetailsProvider_GetAll(start, pageLength, out count);
			
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
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public override NDMSInvestigation.Entities.TList<QuestionDetails> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			whereClause = whereClause ?? string.Empty;
			orderBy = orderBy ?? string.Empty;
			
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			WsProxy.QuestionDetails[] items = proxy.QuestionDetailsProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		FK_QuestionDetails_QuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public override NDMSInvestigation.Entities.TList<QuestionDetails> GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.QuestionDetails[] items = proxy.QuestionDetailsProvider_GetByGroupId(_groupId, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the IX_QuestionDetails index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="_orderNumber"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public override NDMSInvestigation.Entities.QuestionDetails GetByGroupIdOrderNumber(TransactionManager transactionManager, System.Int32 _groupId, System.Int32? _orderNumber, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.QuestionDetails items = proxy.QuestionDetailsProvider_GetByGroupIdOrderNumber(_groupId, _orderNumber, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the PK_QuestionDetails_1 index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public override NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			WsProxy.QuestionDetails items = proxy.QuestionDetailsProvider_GetByQuestionId(_questionId, start, pageLength, out count);
			
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
		/// 	Inserts a NDMSInvestigation.Entities.QuestionDetails object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">NDMSInvestigation.Entities.QuestionDetails object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionDetails entity)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.QuestionDetails result = proxy.QuestionDetailsProvider_Insert(Convert(entity));
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
		/// After inserting into the datasource, the NDMSInvestigation.Entities.QuestionDetails object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, NDMSInvestigation.Entities.TList<QuestionDetails> entityList)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			try
			{
				proxy.QuestionDetailsProvider_BulkInsert(Convert(entityList));
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
		/// <param name="entity">NDMSInvestigation.Entities.QuestionDetails object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionDetails entity)
		{
			WsProxy.NDMSInvestigationServices proxy = new WsProxy.NDMSInvestigationServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.QuestionDetails result = proxy.QuestionDetailsProvider_Update(Convert(entity));
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
