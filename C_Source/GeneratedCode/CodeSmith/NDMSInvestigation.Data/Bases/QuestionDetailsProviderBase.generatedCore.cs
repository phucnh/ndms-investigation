#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;

#endregion

namespace NDMSInvestigation.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="QuestionDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionDetailsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.QuestionDetails, NDMSInvestigation.Entities.QuestionDetailsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByAnswerIdFromQuestionAnswer
		
		/// <summary>
		///		Gets QuestionDetails objects from the datasource by AnswerId in the
		///		QuestionAnswer table. Table QuestionDetails is related to table AnswerDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <returns>Returns a typed collection of QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByAnswerIdFromQuestionAnswer(System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerIdFromQuestionAnswer(null,_answerId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.QuestionDetails objects from the datasource by AnswerId in the
		///		QuestionAnswer table. Table QuestionDetails is related to table AnswerDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_answerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByAnswerIdFromQuestionAnswer(System.Int32 _answerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerIdFromQuestionAnswer(null, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets QuestionDetails objects from the datasource by AnswerId in the
		///		QuestionAnswer table. Table QuestionDetails is related to table AnswerDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByAnswerIdFromQuestionAnswer(TransactionManager transactionManager, System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerIdFromQuestionAnswer(transactionManager, _answerId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets QuestionDetails objects from the datasource by AnswerId in the
		///		QuestionAnswer table. Table QuestionDetails is related to table AnswerDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByAnswerIdFromQuestionAnswer(TransactionManager transactionManager, System.Int32 _answerId,int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerIdFromQuestionAnswer(transactionManager, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets QuestionDetails objects from the datasource by AnswerId in the
		///		QuestionAnswer table. Table QuestionDetails is related to table AnswerDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByAnswerIdFromQuestionAnswer(System.Int32 _answerId,int start, int pageLength, out int count)
		{
			
			return GetByAnswerIdFromQuestionAnswer(null, _answerId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets QuestionDetails objects from the datasource by AnswerId in the
		///		QuestionAnswer table. Table QuestionDetails is related to table AnswerDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_answerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of QuestionDetails objects.</returns>
		public abstract TList<QuestionDetails> GetByAnswerIdFromQuestionAnswer(TransactionManager transactionManager,System.Int32 _answerId, int start, int pageLength, out int count);
		
		#endregion GetByAnswerIdFromQuestionAnswer
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionDetailsKey key)
		{
			return Delete(transactionManager, key.QuestionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_questionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _questionId)
		{
			return Delete(null, _questionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _questionId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		FK_QuestionDetails_QuestionGroup Description: 
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByGroupId(System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(_groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		FK_QuestionDetails_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		/// <remarks></remarks>
		public TList<QuestionDetails> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		FK_QuestionDetails_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		fkQuestionDetailsQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByGroupId(System.Int32? _groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, _groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		fkQuestionDetailsQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public TList<QuestionDetails> GetByGroupId(System.Int32? _groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_QuestionDetails_QuestionGroup key.
		///		FK_QuestionDetails_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionDetails objects.</returns>
		public abstract TList<QuestionDetails> GetByGroupId(TransactionManager transactionManager, System.Int32? _groupId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override NDMSInvestigation.Entities.QuestionDetails Get(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionDetailsKey key, int start, int pageLength)
		{
			return GetByQuestionId(transactionManager, key.QuestionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_QuestionDetails index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByOrderNumberGroupId(System.Int32? _orderNumber, System.Int32? _groupId)
		{
			int count = -1;
			return GetByOrderNumberGroupId(null,_orderNumber, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionDetails index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByOrderNumberGroupId(System.Int32? _orderNumber, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderNumberGroupId(null, _orderNumber, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderNumber"></param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByOrderNumberGroupId(TransactionManager transactionManager, System.Int32? _orderNumber, System.Int32? _groupId)
		{
			int count = -1;
			return GetByOrderNumberGroupId(transactionManager, _orderNumber, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderNumber"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByOrderNumberGroupId(TransactionManager transactionManager, System.Int32? _orderNumber, System.Int32? _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderNumberGroupId(transactionManager, _orderNumber, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionDetails index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByOrderNumberGroupId(System.Int32? _orderNumber, System.Int32? _groupId, int start, int pageLength, out int count)
		{
			return GetByOrderNumberGroupId(null, _orderNumber, _groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderNumber"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionDetails GetByOrderNumberGroupId(TransactionManager transactionManager, System.Int32? _orderNumber, System.Int32? _groupId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuestionDetails index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(null,_questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionDetails index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionDetails index.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(System.Int32 _questionId, int start, int pageLength, out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionDetails GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionDetails&gt;"/></returns>
		public static TList<QuestionDetails> Fill(IDataReader reader, TList<QuestionDetails> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				NDMSInvestigation.Entities.QuestionDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionDetails")
					.Append("|").Append((System.Int32)reader[((int)QuestionDetailsColumn.QuestionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionDetails>(
					key.ToString(), // EntityTrackingKey
					"QuestionDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.QuestionDetails();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.QuestionId = (System.Int32)reader[((int)QuestionDetailsColumn.QuestionId - 1)];
					c.QuestionContent = (System.String)reader[((int)QuestionDetailsColumn.QuestionContent - 1)];
					c.QuestionSuggest = (reader.IsDBNull(((int)QuestionDetailsColumn.QuestionSuggest - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.QuestionSuggest - 1)];
					c.QuestionDescription = (reader.IsDBNull(((int)QuestionDetailsColumn.QuestionDescription - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.QuestionDescription - 1)];
					c.OrderNumber = (reader.IsDBNull(((int)QuestionDetailsColumn.OrderNumber - 1)))?null:(System.Int32?)reader[((int)QuestionDetailsColumn.OrderNumber - 1)];
					c.GroupId = (reader.IsDBNull(((int)QuestionDetailsColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)QuestionDetailsColumn.GroupId - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)QuestionDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionDetailsColumn.CreatedDate - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)QuestionDetailsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.CreatedBy - 1)];
					c.UpdatedDate = (reader.IsDBNull(((int)QuestionDetailsColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionDetailsColumn.UpdatedDate - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)QuestionDetailsColumn.UpdatedBy - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.UpdatedBy - 1)];
					c.QuestionTitle = (reader.IsDBNull(((int)QuestionDetailsColumn.QuestionTitle - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.QuestionTitle - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.QuestionDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)QuestionDetailsColumn.QuestionId - 1)];
			entity.QuestionContent = (System.String)reader[((int)QuestionDetailsColumn.QuestionContent - 1)];
			entity.QuestionSuggest = (reader.IsDBNull(((int)QuestionDetailsColumn.QuestionSuggest - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.QuestionSuggest - 1)];
			entity.QuestionDescription = (reader.IsDBNull(((int)QuestionDetailsColumn.QuestionDescription - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.QuestionDescription - 1)];
			entity.OrderNumber = (reader.IsDBNull(((int)QuestionDetailsColumn.OrderNumber - 1)))?null:(System.Int32?)reader[((int)QuestionDetailsColumn.OrderNumber - 1)];
			entity.GroupId = (reader.IsDBNull(((int)QuestionDetailsColumn.GroupId - 1)))?null:(System.Int32?)reader[((int)QuestionDetailsColumn.GroupId - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)QuestionDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionDetailsColumn.CreatedDate - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)QuestionDetailsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.CreatedBy - 1)];
			entity.UpdatedDate = (reader.IsDBNull(((int)QuestionDetailsColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionDetailsColumn.UpdatedDate - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)QuestionDetailsColumn.UpdatedBy - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.UpdatedBy - 1)];
			entity.QuestionTitle = (reader.IsDBNull(((int)QuestionDetailsColumn.QuestionTitle - 1)))?null:(System.String)reader[((int)QuestionDetailsColumn.QuestionTitle - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.QuestionDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionId"];
			entity.QuestionContent = (System.String)dataRow["QuestionContent"];
			entity.QuestionSuggest = Convert.IsDBNull(dataRow["QuestionSuggest"]) ? null : (System.String)dataRow["QuestionSuggest"];
			entity.QuestionDescription = Convert.IsDBNull(dataRow["QuestionDescription"]) ? null : (System.String)dataRow["QuestionDescription"];
			entity.OrderNumber = Convert.IsDBNull(dataRow["OrderNumber"]) ? null : (System.Int32?)dataRow["OrderNumber"];
			entity.GroupId = Convert.IsDBNull(dataRow["GroupId"]) ? null : (System.Int32?)dataRow["GroupId"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["CreatedBy"]) ? null : (System.String)dataRow["CreatedBy"];
			entity.UpdatedDate = Convert.IsDBNull(dataRow["UpdatedDate"]) ? null : (System.DateTime?)dataRow["UpdatedDate"];
			entity.UpdatedBy = Convert.IsDBNull(dataRow["UpdatedBy"]) ? null : (System.String)dataRow["UpdatedBy"];
			entity.QuestionTitle = Convert.IsDBNull(dataRow["QuestionTitle"]) ? null : (System.String)dataRow["QuestionTitle"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region GroupIdSource	
			if (CanDeepLoad(entity, "QuestionGroups|GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.GroupId ?? (int)0);
				QuestionGroups tmpEntity = EntityManager.LocateEntity<QuestionGroups>(EntityLocator.ConstructKeyFromPkItems(typeof(QuestionGroups), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.QuestionGroupsProvider.GetByGroupId(transactionManager, (entity.GroupId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GroupIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GroupIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuestionGroupsProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GroupIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByQuestionId methods when available
			
			#region QuestionAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionAnswer>|QuestionAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionAnswerCollection = DataRepository.QuestionAnswerProvider.GetByQuestionId(transactionManager, entity.QuestionId);

				if (deep && entity.QuestionAnswerCollection.Count > 0)
				{
					deepHandles.Add("QuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionAnswer>) DataRepository.QuestionAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionAnswerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AnswerIdAnswerDetailsCollection_From_QuestionAnswer
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AnswerDetails>|AnswerIdAnswerDetailsCollection_From_QuestionAnswer", deepLoadType, innerList))
			{
				entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer = DataRepository.AnswerDetailsProvider.GetByQuestionIdFromQuestionAnswer(transactionManager, entity.QuestionId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AnswerIdAnswerDetailsCollection_From_QuestionAnswer' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer != null)
				{
					deepHandles.Add("AnswerIdAnswerDetailsCollection_From_QuestionAnswer",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AnswerDetails >) DataRepository.AnswerDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.QuestionDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.QuestionDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GroupIdSource
			if (CanDeepSave(entity, "QuestionGroups|GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.QuestionGroupsProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region AnswerIdAnswerDetailsCollection_From_QuestionAnswer>
			if (CanDeepSave(entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer, "List<AnswerDetails>|AnswerIdAnswerDetailsCollection_From_QuestionAnswer", deepSaveType, innerList))
			{
				if (entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer.Count > 0 || entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer.DeletedItems.Count > 0)
				{
					DataRepository.AnswerDetailsProvider.Save(transactionManager, entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer); 
					deepHandles.Add("AnswerIdAnswerDetailsCollection_From_QuestionAnswer",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<AnswerDetails>) DataRepository.AnswerDetailsProvider.DeepSave,
						new object[] { transactionManager, entity.AnswerIdAnswerDetailsCollection_From_QuestionAnswer, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<QuestionAnswer>
				if (CanDeepSave(entity.QuestionAnswerCollection, "List<QuestionAnswer>|QuestionAnswerCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionAnswer child in entity.QuestionAnswerCollection)
					{
						if(child.QuestionIdSource != null)
						{
								child.QuestionId = child.QuestionIdSource.QuestionId;
						}

						if(child.AnswerIdSource != null)
						{
								child.AnswerId = child.AnswerIdSource.AnswerId;
						}

					}

					if (entity.QuestionAnswerCollection.Count > 0 || entity.QuestionAnswerCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionAnswerProvider.Save(transactionManager, entity.QuestionAnswerCollection);
						
						deepHandles.Add("QuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionAnswer >) DataRepository.QuestionAnswerProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionAnswerCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region QuestionDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.QuestionDetails</c>
	///</summary>
	public enum QuestionDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>QuestionGroups</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(QuestionGroups))]
		QuestionGroups,
	
		///<summary>
		/// Collection of <c>QuestionDetails</c> as OneToMany for QuestionAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionAnswer>))]
		QuestionAnswerCollection,

		///<summary>
		/// Collection of <c>QuestionDetails</c> as ManyToMany for AnswerDetailsCollection_From_QuestionAnswer
		///</summary>
		[ChildEntityType(typeof(TList<AnswerDetails>))]
		AnswerIdAnswerDetailsCollection_From_QuestionAnswer,
	}
	
	#endregion QuestionDetailsChildEntityTypes
	
	#region QuestionDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsFilterBuilder : SqlFilterBuilder<QuestionDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsFilterBuilder class.
		/// </summary>
		public QuestionDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionDetailsFilterBuilder
	
	#region QuestionDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsParameterBuilder : ParameterizedSqlFilterBuilder<QuestionDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsParameterBuilder class.
		/// </summary>
		public QuestionDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionDetailsParameterBuilder
	
	#region QuestionDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionDetailsSortBuilder : SqlSortBuilder<QuestionDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsSqlSortBuilder class.
		/// </summary>
		public QuestionDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionDetailsSortBuilder
	
} // end namespace
