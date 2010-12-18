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
	/// This class is the base class for any <see cref="QuestionAnswerProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionAnswerProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.QuestionAnswer, NDMSInvestigation.Entities.QuestionAnswerKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionAnswerKey key)
		{
			return Delete(transactionManager, key.QuestionAnswerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_questionAnswerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _questionAnswerId)
		{
			return Delete(null, _questionAnswerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionAnswerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _questionAnswerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_AnswerDetails key.
		///		FK_Question_Answer_AnswerDetails Description: 
		/// </summary>
		/// <param name="_answerId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByAnswerId(System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerId(_answerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_AnswerDetails key.
		///		FK_Question_Answer_AnswerDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		/// <remarks></remarks>
		public TList<QuestionAnswer> GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerId(transactionManager, _answerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_AnswerDetails key.
		///		FK_Question_Answer_AnswerDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerId(transactionManager, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_AnswerDetails key.
		///		fkQuestionAnswerAnswerDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_answerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByAnswerId(System.Int32 _answerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAnswerId(null, _answerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_AnswerDetails key.
		///		fkQuestionAnswerAnswerDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_answerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByAnswerId(System.Int32 _answerId, int start, int pageLength,out int count)
		{
			return GetByAnswerId(null, _answerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_AnswerDetails key.
		///		FK_Question_Answer_AnswerDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public abstract TList<QuestionAnswer> GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_QuestionDetails key.
		///		FK_Question_Answer_QuestionDetails Description: 
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByQuestionId(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(_questionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_QuestionDetails key.
		///		FK_Question_Answer_QuestionDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		/// <remarks></remarks>
		public TList<QuestionAnswer> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_QuestionDetails key.
		///		FK_Question_Answer_QuestionDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionId(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_QuestionDetails key.
		///		fkQuestionAnswerQuestionDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByQuestionId(System.Int32 _questionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByQuestionId(null, _questionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_QuestionDetails key.
		///		fkQuestionAnswerQuestionDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public TList<QuestionAnswer> GetByQuestionId(System.Int32 _questionId, int start, int pageLength,out int count)
		{
			return GetByQuestionId(null, _questionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Question_Answer_QuestionDetails key.
		///		FK_Question_Answer_QuestionDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.QuestionAnswer objects.</returns>
		public abstract TList<QuestionAnswer> GetByQuestionId(TransactionManager transactionManager, System.Int32 _questionId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.QuestionAnswer Get(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionAnswerKey key, int start, int pageLength)
		{
			return GetByQuestionAnswerId(transactionManager, key.QuestionAnswerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Question_Answer index.
		/// </summary>
		/// <param name="_questionAnswerId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionAnswer GetByQuestionAnswerId(System.Int32 _questionAnswerId)
		{
			int count = -1;
			return GetByQuestionAnswerId(null,_questionAnswerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Answer index.
		/// </summary>
		/// <param name="_questionAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionAnswer GetByQuestionAnswerId(System.Int32 _questionAnswerId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionAnswerId(null, _questionAnswerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Answer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionAnswerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionAnswer GetByQuestionAnswerId(TransactionManager transactionManager, System.Int32 _questionAnswerId)
		{
			int count = -1;
			return GetByQuestionAnswerId(transactionManager, _questionAnswerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Answer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionAnswer GetByQuestionAnswerId(TransactionManager transactionManager, System.Int32 _questionAnswerId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionAnswerId(transactionManager, _questionAnswerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Answer index.
		/// </summary>
		/// <param name="_questionAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionAnswer GetByQuestionAnswerId(System.Int32 _questionAnswerId, int start, int pageLength, out int count)
		{
			return GetByQuestionAnswerId(null, _questionAnswerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Question_Answer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionAnswerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionAnswer GetByQuestionAnswerId(TransactionManager transactionManager, System.Int32 _questionAnswerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionAnswer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionAnswer&gt;"/></returns>
		public static TList<QuestionAnswer> Fill(IDataReader reader, TList<QuestionAnswer> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.QuestionAnswer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionAnswer")
					.Append("|").Append((System.Int32)reader[((int)QuestionAnswerColumn.QuestionAnswerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionAnswer>(
					key.ToString(), // EntityTrackingKey
					"QuestionAnswer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.QuestionAnswer();
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
					c.QuestionId = (System.Int32)reader[((int)QuestionAnswerColumn.QuestionId - 1)];
					c.AnswerId = (System.Int32)reader[((int)QuestionAnswerColumn.AnswerId - 1)];
					c.Mark = (reader.IsDBNull(((int)QuestionAnswerColumn.Mark - 1)))?null:(System.Int32?)reader[((int)QuestionAnswerColumn.Mark - 1)];
					c.QuestionAnswerId = (System.Int32)reader[((int)QuestionAnswerColumn.QuestionAnswerId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.QuestionAnswer entity)
		{
			if (!reader.Read()) return;
			
			entity.QuestionId = (System.Int32)reader[((int)QuestionAnswerColumn.QuestionId - 1)];
			entity.AnswerId = (System.Int32)reader[((int)QuestionAnswerColumn.AnswerId - 1)];
			entity.Mark = (reader.IsDBNull(((int)QuestionAnswerColumn.Mark - 1)))?null:(System.Int32?)reader[((int)QuestionAnswerColumn.Mark - 1)];
			entity.QuestionAnswerId = (System.Int32)reader[((int)QuestionAnswerColumn.QuestionAnswerId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.QuestionAnswer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.QuestionId = (System.Int32)dataRow["QuestionId"];
			entity.AnswerId = (System.Int32)dataRow["AnswerId"];
			entity.Mark = Convert.IsDBNull(dataRow["Mark"]) ? null : (System.Int32?)dataRow["Mark"];
			entity.QuestionAnswerId = (System.Int32)dataRow["Question_AnswerId"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionAnswer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionAnswer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionAnswer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region AnswerIdSource	
			if (CanDeepLoad(entity, "AnswerDetails|AnswerIdSource", deepLoadType, innerList) 
				&& entity.AnswerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AnswerId;
				AnswerDetails tmpEntity = EntityManager.LocateEntity<AnswerDetails>(EntityLocator.ConstructKeyFromPkItems(typeof(AnswerDetails), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AnswerIdSource = tmpEntity;
				else
					entity.AnswerIdSource = DataRepository.AnswerDetailsProvider.GetByAnswerId(transactionManager, entity.AnswerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AnswerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.AnswerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AnswerDetailsProvider.DeepLoad(transactionManager, entity.AnswerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion AnswerIdSource

			#region QuestionIdSource	
			if (CanDeepLoad(entity, "QuestionDetails|QuestionIdSource", deepLoadType, innerList) 
				&& entity.QuestionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.QuestionId;
				QuestionDetails tmpEntity = EntityManager.LocateEntity<QuestionDetails>(EntityLocator.ConstructKeyFromPkItems(typeof(QuestionDetails), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.QuestionIdSource = tmpEntity;
				else
					entity.QuestionIdSource = DataRepository.QuestionDetailsProvider.GetByQuestionId(transactionManager, entity.QuestionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.QuestionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuestionDetailsProvider.DeepLoad(transactionManager, entity.QuestionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion QuestionIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.QuestionAnswer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.QuestionAnswer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionAnswer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionAnswer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AnswerIdSource
			if (CanDeepSave(entity, "AnswerDetails|AnswerIdSource", deepSaveType, innerList) 
				&& entity.AnswerIdSource != null)
			{
				DataRepository.AnswerDetailsProvider.Save(transactionManager, entity.AnswerIdSource);
				entity.AnswerId = entity.AnswerIdSource.AnswerId;
			}
			#endregion 
			
			#region QuestionIdSource
			if (CanDeepSave(entity, "QuestionDetails|QuestionIdSource", deepSaveType, innerList) 
				&& entity.QuestionIdSource != null)
			{
				DataRepository.QuestionDetailsProvider.Save(transactionManager, entity.QuestionIdSource);
				entity.QuestionId = entity.QuestionIdSource.QuestionId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region QuestionAnswerChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.QuestionAnswer</c>
	///</summary>
	public enum QuestionAnswerChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AnswerDetails</c> at AnswerIdSource
		///</summary>
		[ChildEntityType(typeof(AnswerDetails))]
		AnswerDetails,
			
		///<summary>
		/// Composite Property for <c>QuestionDetails</c> at QuestionIdSource
		///</summary>
		[ChildEntityType(typeof(QuestionDetails))]
		QuestionDetails,
		}
	
	#endregion QuestionAnswerChildEntityTypes
	
	#region QuestionAnswerFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerFilterBuilder : SqlFilterBuilder<QuestionAnswerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerFilterBuilder class.
		/// </summary>
		public QuestionAnswerFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionAnswerFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionAnswerFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionAnswerFilterBuilder
	
	#region QuestionAnswerParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerParameterBuilder : ParameterizedSqlFilterBuilder<QuestionAnswerColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerParameterBuilder class.
		/// </summary>
		public QuestionAnswerParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionAnswerParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionAnswerParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionAnswerParameterBuilder
	
	#region QuestionAnswerSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionAnswerColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionAnswerSortBuilder : SqlSortBuilder<QuestionAnswerColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerSqlSortBuilder class.
		/// </summary>
		public QuestionAnswerSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionAnswerSortBuilder
	
} // end namespace
