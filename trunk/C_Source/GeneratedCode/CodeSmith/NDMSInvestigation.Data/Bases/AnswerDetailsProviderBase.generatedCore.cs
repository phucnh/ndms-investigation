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
	/// This class is the base class for any <see cref="AnswerDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AnswerDetailsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AnswerDetails, NDMSInvestigation.Entities.AnswerDetailsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByQuestionIdFromQuestionAnswer
		
		/// <summary>
		///		Gets AnswerDetails objects from the datasource by QuestionId in the
		///		QuestionAnswer table. Table AnswerDetails is related to table QuestionDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <returns>Returns a typed collection of AnswerDetails objects.</returns>
		public TList<AnswerDetails> GetByQuestionIdFromQuestionAnswer(System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionIdFromQuestionAnswer(null,_questionId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.AnswerDetails objects from the datasource by QuestionId in the
		///		QuestionAnswer table. Table AnswerDetails is related to table QuestionDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AnswerDetails objects.</returns>
		public TList<AnswerDetails> GetByQuestionIdFromQuestionAnswer(System.Int32 _questionId, int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionIdFromQuestionAnswer(null, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AnswerDetails objects from the datasource by QuestionId in the
		///		QuestionAnswer table. Table AnswerDetails is related to table QuestionDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AnswerDetails objects.</returns>
		public TList<AnswerDetails> GetByQuestionIdFromQuestionAnswer(TransactionManager transactionManager, System.Int32 _questionId)
		{
			int count = -1;
			return GetByQuestionIdFromQuestionAnswer(transactionManager, _questionId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AnswerDetails objects from the datasource by QuestionId in the
		///		QuestionAnswer table. Table AnswerDetails is related to table QuestionDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AnswerDetails objects.</returns>
		public TList<AnswerDetails> GetByQuestionIdFromQuestionAnswer(TransactionManager transactionManager, System.Int32 _questionId,int start, int pageLength)
		{
			int count = -1;
			return GetByQuestionIdFromQuestionAnswer(transactionManager, _questionId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AnswerDetails objects from the datasource by QuestionId in the
		///		QuestionAnswer table. Table AnswerDetails is related to table QuestionDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="_questionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AnswerDetails objects.</returns>
		public TList<AnswerDetails> GetByQuestionIdFromQuestionAnswer(System.Int32 _questionId,int start, int pageLength, out int count)
		{
			
			return GetByQuestionIdFromQuestionAnswer(null, _questionId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets AnswerDetails objects from the datasource by QuestionId in the
		///		QuestionAnswer table. Table AnswerDetails is related to table QuestionDetails
		///		through the (M:N) relationship defined in the QuestionAnswer table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_questionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AnswerDetails objects.</returns>
		public abstract TList<AnswerDetails> GetByQuestionIdFromQuestionAnswer(TransactionManager transactionManager,System.Int32 _questionId, int start, int pageLength, out int count);
		
		#endregion GetByQuestionIdFromQuestionAnswer
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AnswerDetailsKey key)
		{
			return Delete(transactionManager, key.AnswerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_answerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _answerId)
		{
			return Delete(null, _answerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _answerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
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
		public override NDMSInvestigation.Entities.AnswerDetails Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AnswerDetailsKey key, int start, int pageLength)
		{
			return GetByAnswerId(transactionManager, key.AnswerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_AnswerDetails index.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> class.</returns>
		public NDMSInvestigation.Entities.AnswerDetails GetByAnswerId(System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerId(null,_answerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AnswerDetails index.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> class.</returns>
		public NDMSInvestigation.Entities.AnswerDetails GetByAnswerId(System.Int32 _answerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerId(null, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AnswerDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> class.</returns>
		public NDMSInvestigation.Entities.AnswerDetails GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId)
		{
			int count = -1;
			return GetByAnswerId(transactionManager, _answerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AnswerDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> class.</returns>
		public NDMSInvestigation.Entities.AnswerDetails GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId, int start, int pageLength)
		{
			int count = -1;
			return GetByAnswerId(transactionManager, _answerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AnswerDetails index.
		/// </summary>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> class.</returns>
		public NDMSInvestigation.Entities.AnswerDetails GetByAnswerId(System.Int32 _answerId, int start, int pageLength, out int count)
		{
			return GetByAnswerId(null, _answerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_AnswerDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_answerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AnswerDetails GetByAnswerId(TransactionManager transactionManager, System.Int32 _answerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AnswerDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AnswerDetails&gt;"/></returns>
		public static TList<AnswerDetails> Fill(IDataReader reader, TList<AnswerDetails> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AnswerDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AnswerDetails")
					.Append("|").Append((System.Int32)reader[((int)AnswerDetailsColumn.AnswerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AnswerDetails>(
					key.ToString(), // EntityTrackingKey
					"AnswerDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AnswerDetails();
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
					c.AnswerId = (System.Int32)reader[((int)AnswerDetailsColumn.AnswerId - 1)];
					c.AnswerContent = (System.String)reader[((int)AnswerDetailsColumn.AnswerContent - 1)];
					c.AnswerMark = (reader.IsDBNull(((int)AnswerDetailsColumn.AnswerMark - 1)))?null:(System.Int32?)reader[((int)AnswerDetailsColumn.AnswerMark - 1)];
					c.AnswerDescription = (reader.IsDBNull(((int)AnswerDetailsColumn.AnswerDescription - 1)))?null:(System.String)reader[((int)AnswerDetailsColumn.AnswerDescription - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)AnswerDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)AnswerDetailsColumn.CreatedDate - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)AnswerDetailsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)AnswerDetailsColumn.CreatedBy - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)AnswerDetailsColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)AnswerDetailsColumn.UpdateDate - 1)];
					c.UpdateBy = (reader.IsDBNull(((int)AnswerDetailsColumn.UpdateBy - 1)))?null:(System.String)reader[((int)AnswerDetailsColumn.UpdateBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AnswerDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AnswerDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.AnswerId = (System.Int32)reader[((int)AnswerDetailsColumn.AnswerId - 1)];
			entity.AnswerContent = (System.String)reader[((int)AnswerDetailsColumn.AnswerContent - 1)];
			entity.AnswerMark = (reader.IsDBNull(((int)AnswerDetailsColumn.AnswerMark - 1)))?null:(System.Int32?)reader[((int)AnswerDetailsColumn.AnswerMark - 1)];
			entity.AnswerDescription = (reader.IsDBNull(((int)AnswerDetailsColumn.AnswerDescription - 1)))?null:(System.String)reader[((int)AnswerDetailsColumn.AnswerDescription - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)AnswerDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)AnswerDetailsColumn.CreatedDate - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)AnswerDetailsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)AnswerDetailsColumn.CreatedBy - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)AnswerDetailsColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)AnswerDetailsColumn.UpdateDate - 1)];
			entity.UpdateBy = (reader.IsDBNull(((int)AnswerDetailsColumn.UpdateBy - 1)))?null:(System.String)reader[((int)AnswerDetailsColumn.UpdateBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AnswerDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AnswerDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AnswerDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.AnswerId = (System.Int32)dataRow["AnswerId"];
			entity.AnswerContent = (System.String)dataRow["AnswerContent"];
			entity.AnswerMark = Convert.IsDBNull(dataRow["AnswerMark"]) ? null : (System.Int32?)dataRow["AnswerMark"];
			entity.AnswerDescription = Convert.IsDBNull(dataRow["AnswerDescription"]) ? null : (System.String)dataRow["AnswerDescription"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["CreatedBy"]) ? null : (System.String)dataRow["CreatedBy"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.UpdateBy = Convert.IsDBNull(dataRow["UpdateBy"]) ? null : (System.String)dataRow["UpdateBy"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AnswerDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AnswerDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AnswerDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByAnswerId methods when available
			
			#region QuestionAnswerCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionAnswer>|QuestionAnswerCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionAnswerCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionAnswerCollection = DataRepository.QuestionAnswerProvider.GetByAnswerId(transactionManager, entity.AnswerId);

				if (deep && entity.QuestionAnswerCollection.Count > 0)
				{
					deepHandles.Add("QuestionAnswerCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionAnswer>) DataRepository.QuestionAnswerProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionAnswerCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region QuestionIdQuestionDetailsCollection_From_QuestionAnswer
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<QuestionDetails>|QuestionIdQuestionDetailsCollection_From_QuestionAnswer", deepLoadType, innerList))
			{
				entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer = DataRepository.QuestionDetailsProvider.GetByAnswerIdFromQuestionAnswer(transactionManager, entity.AnswerId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionIdQuestionDetailsCollection_From_QuestionAnswer' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer != null)
				{
					deepHandles.Add("QuestionIdQuestionDetailsCollection_From_QuestionAnswer",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< QuestionDetails >) DataRepository.QuestionDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AnswerDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AnswerDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AnswerDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AnswerDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region QuestionIdQuestionDetailsCollection_From_QuestionAnswer>
			if (CanDeepSave(entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer, "List<QuestionDetails>|QuestionIdQuestionDetailsCollection_From_QuestionAnswer", deepSaveType, innerList))
			{
				if (entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer.Count > 0 || entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer.DeletedItems.Count > 0)
				{
					DataRepository.QuestionDetailsProvider.Save(transactionManager, entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer); 
					deepHandles.Add("QuestionIdQuestionDetailsCollection_From_QuestionAnswer",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<QuestionDetails>) DataRepository.QuestionDetailsProvider.DeepSave,
						new object[] { transactionManager, entity.QuestionIdQuestionDetailsCollection_From_QuestionAnswer, deepSaveType, childTypes, innerList }
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
						if(child.AnswerIdSource != null)
						{
								child.AnswerId = child.AnswerIdSource.AnswerId;
						}

						if(child.QuestionIdSource != null)
						{
								child.QuestionId = child.QuestionIdSource.QuestionId;
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
	
	#region AnswerDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AnswerDetails</c>
	///</summary>
	public enum AnswerDetailsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AnswerDetails</c> as OneToMany for QuestionAnswerCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionAnswer>))]
		QuestionAnswerCollection,

		///<summary>
		/// Collection of <c>AnswerDetails</c> as ManyToMany for QuestionDetailsCollection_From_QuestionAnswer
		///</summary>
		[ChildEntityType(typeof(TList<QuestionDetails>))]
		QuestionIdQuestionDetailsCollection_From_QuestionAnswer,
	}
	
	#endregion AnswerDetailsChildEntityTypes
	
	#region AnswerDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AnswerDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsFilterBuilder : SqlFilterBuilder<AnswerDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsFilterBuilder class.
		/// </summary>
		public AnswerDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AnswerDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AnswerDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AnswerDetailsFilterBuilder
	
	#region AnswerDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AnswerDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsParameterBuilder : ParameterizedSqlFilterBuilder<AnswerDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsParameterBuilder class.
		/// </summary>
		public AnswerDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AnswerDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AnswerDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AnswerDetailsParameterBuilder
	
	#region AnswerDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AnswerDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AnswerDetailsSortBuilder : SqlSortBuilder<AnswerDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsSqlSortBuilder class.
		/// </summary>
		public AnswerDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AnswerDetailsSortBuilder
	
} // end namespace
