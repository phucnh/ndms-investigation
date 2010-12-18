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
	/// This class is the base class for any <see cref="QuestionGroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionGroupProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.QuestionGroup, NDMSInvestigation.Entities.QuestionGroupKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByUserIdFromResult
		
		/// <summary>
		///		Gets QuestionGroup objects from the datasource by UserId in the
		///		Result table. Table QuestionGroup is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByUserIdFromResult(System.Guid _userId)
		{
			int count = -1;
			return GetByUserIdFromResult(null,_userId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.QuestionGroup objects from the datasource by UserId in the
		///		Result table. Table QuestionGroup is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByUserIdFromResult(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromResult(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets QuestionGroup objects from the datasource by UserId in the
		///		Result table. Table QuestionGroup is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByUserIdFromResult(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserIdFromResult(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets QuestionGroup objects from the datasource by UserId in the
		///		Result table. Table QuestionGroup is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByUserIdFromResult(TransactionManager transactionManager, System.Guid _userId,int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromResult(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets QuestionGroup objects from the datasource by UserId in the
		///		Result table. Table QuestionGroup is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionGroup objects.</returns>
		public TList<QuestionGroup> GetByUserIdFromResult(System.Guid _userId,int start, int pageLength, out int count)
		{
			
			return GetByUserIdFromResult(null, _userId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets QuestionGroup objects from the datasource by UserId in the
		///		Result table. Table QuestionGroup is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Result table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of QuestionGroup objects.</returns>
		public abstract TList<QuestionGroup> GetByUserIdFromResult(TransactionManager transactionManager,System.Guid _userId, int start, int pageLength, out int count);
		
		#endregion GetByUserIdFromResult
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroupKey key)
		{
			return Delete(transactionManager, key.GroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _groupId)
		{
			return Delete(null, _groupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _groupId);		
		
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
		public override NDMSInvestigation.Entities.QuestionGroup Get(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroupKey key, int start, int pageLength)
		{
			return GetByGroupId(transactionManager, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_QuestionGroup index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByOrderNumber(System.Int32? _orderNumber)
		{
			int count = -1;
			return GetByOrderNumber(null,_orderNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionGroup index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByOrderNumber(System.Int32? _orderNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderNumber(null, _orderNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderNumber"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByOrderNumber(TransactionManager transactionManager, System.Int32? _orderNumber)
		{
			int count = -1;
			return GetByOrderNumber(transactionManager, _orderNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByOrderNumber(TransactionManager transactionManager, System.Int32? _orderNumber, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderNumber(transactionManager, _orderNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionGroup index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByOrderNumber(System.Int32? _orderNumber, int start, int pageLength, out int count)
		{
			return GetByOrderNumber(null, _orderNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderNumber"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionGroup GetByOrderNumber(TransactionManager transactionManager, System.Int32? _orderNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByGroupId(System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(null,_groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroup GetByGroupId(System.Int32 _groupId, int start, int pageLength, out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_QuestionGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionGroup GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionGroup&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionGroup&gt;"/></returns>
		public static TList<QuestionGroup> Fill(IDataReader reader, TList<QuestionGroup> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.QuestionGroup c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionGroup")
					.Append("|").Append((System.Int32)reader[((int)QuestionGroupColumn.GroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionGroup>(
					key.ToString(), // EntityTrackingKey
					"QuestionGroup",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.QuestionGroup();
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
					c.GroupId = (System.Int32)reader[((int)QuestionGroupColumn.GroupId - 1)];
					c.GroupName = (reader.IsDBNull(((int)QuestionGroupColumn.GroupName - 1)))?null:(System.String)reader[((int)QuestionGroupColumn.GroupName - 1)];
					c.GroupDescription = (reader.IsDBNull(((int)QuestionGroupColumn.GroupDescription - 1)))?null:(System.String)reader[((int)QuestionGroupColumn.GroupDescription - 1)];
					c.OrderNumber = (reader.IsDBNull(((int)QuestionGroupColumn.OrderNumber - 1)))?null:(System.Int32?)reader[((int)QuestionGroupColumn.OrderNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionGroup"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.QuestionGroup entity)
		{
			if (!reader.Read()) return;
			
			entity.GroupId = (System.Int32)reader[((int)QuestionGroupColumn.GroupId - 1)];
			entity.GroupName = (reader.IsDBNull(((int)QuestionGroupColumn.GroupName - 1)))?null:(System.String)reader[((int)QuestionGroupColumn.GroupName - 1)];
			entity.GroupDescription = (reader.IsDBNull(((int)QuestionGroupColumn.GroupDescription - 1)))?null:(System.String)reader[((int)QuestionGroupColumn.GroupDescription - 1)];
			entity.OrderNumber = (reader.IsDBNull(((int)QuestionGroupColumn.OrderNumber - 1)))?null:(System.Int32?)reader[((int)QuestionGroupColumn.OrderNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionGroup"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionGroup"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.QuestionGroup entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GroupId = (System.Int32)dataRow["GroupId"];
			entity.GroupName = Convert.IsDBNull(dataRow["GroupName"]) ? null : (System.String)dataRow["GroupName"];
			entity.GroupDescription = Convert.IsDBNull(dataRow["GroupDescription"]) ? null : (System.String)dataRow["GroupDescription"];
			entity.OrderNumber = Convert.IsDBNull(dataRow["OrderNumber"]) ? null : (System.Int32?)dataRow["OrderNumber"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionGroup"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionGroup Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroup entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByGroupId methods when available
			
			#region QuestionDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<QuestionDetails>|QuestionDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'QuestionDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.QuestionDetailsCollection = DataRepository.QuestionDetailsProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.QuestionDetailsCollection.Count > 0)
				{
					deepHandles.Add("QuestionDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<QuestionDetails>) DataRepository.QuestionDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.QuestionDetailsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ResultCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Result>|ResultCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ResultCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ResultCollection = DataRepository.ResultProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.ResultCollection.Count > 0)
				{
					deepHandles.Add("ResultCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Result>) DataRepository.ResultProvider.DeepLoad,
						new object[] { transactionManager, entity.ResultCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region UserIdAspnetUsersCollection_From_Result
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AspnetUsers>|UserIdAspnetUsersCollection_From_Result", deepLoadType, innerList))
			{
				entity.UserIdAspnetUsersCollection_From_Result = DataRepository.AspnetUsersProvider.GetByGroupIdFromResult(transactionManager, entity.GroupId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdAspnetUsersCollection_From_Result' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdAspnetUsersCollection_From_Result != null)
				{
					deepHandles.Add("UserIdAspnetUsersCollection_From_Result",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AspnetUsers >) DataRepository.AspnetUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.UserIdAspnetUsersCollection_From_Result, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.QuestionGroup object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.QuestionGroup instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionGroup Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroup entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region UserIdAspnetUsersCollection_From_Result>
			if (CanDeepSave(entity.UserIdAspnetUsersCollection_From_Result, "List<AspnetUsers>|UserIdAspnetUsersCollection_From_Result", deepSaveType, innerList))
			{
				if (entity.UserIdAspnetUsersCollection_From_Result.Count > 0 || entity.UserIdAspnetUsersCollection_From_Result.DeletedItems.Count > 0)
				{
					DataRepository.AspnetUsersProvider.Save(transactionManager, entity.UserIdAspnetUsersCollection_From_Result); 
					deepHandles.Add("UserIdAspnetUsersCollection_From_Result",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<AspnetUsers>) DataRepository.AspnetUsersProvider.DeepSave,
						new object[] { transactionManager, entity.UserIdAspnetUsersCollection_From_Result, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<QuestionDetails>
				if (CanDeepSave(entity.QuestionDetailsCollection, "List<QuestionDetails>|QuestionDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(QuestionDetails child in entity.QuestionDetailsCollection)
					{
						if(child.GroupIdSource != null)
						{
							child.GroupId = child.GroupIdSource.GroupId;
						}
						else
						{
							child.GroupId = entity.GroupId;
						}

					}

					if (entity.QuestionDetailsCollection.Count > 0 || entity.QuestionDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.QuestionDetailsProvider.Save(transactionManager, entity.QuestionDetailsCollection);
						
						deepHandles.Add("QuestionDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< QuestionDetails >) DataRepository.QuestionDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.QuestionDetailsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<Result>
				if (CanDeepSave(entity.ResultCollection, "List<Result>|ResultCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Result child in entity.ResultCollection)
					{
						if(child.GroupIdSource != null)
						{
								child.GroupId = child.GroupIdSource.GroupId;
						}

						if(child.UserIdSource != null)
						{
								child.UserId = child.UserIdSource.UserId;
						}

					}

					if (entity.ResultCollection.Count > 0 || entity.ResultCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ResultProvider.Save(transactionManager, entity.ResultCollection);
						
						deepHandles.Add("ResultCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Result >) DataRepository.ResultProvider.DeepSave,
							new object[] { transactionManager, entity.ResultCollection, deepSaveType, childTypes, innerList }
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
	
	#region QuestionGroupChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.QuestionGroup</c>
	///</summary>
	public enum QuestionGroupChildEntityTypes
	{

		///<summary>
		/// Collection of <c>QuestionGroup</c> as OneToMany for QuestionDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionDetails>))]
		QuestionDetailsCollection,

		///<summary>
		/// Collection of <c>QuestionGroup</c> as OneToMany for ResultCollection
		///</summary>
		[ChildEntityType(typeof(TList<Result>))]
		ResultCollection,

		///<summary>
		/// Collection of <c>QuestionGroup</c> as ManyToMany for AspnetUsersCollection_From_Result
		///</summary>
		[ChildEntityType(typeof(TList<AspnetUsers>))]
		UserIdAspnetUsersCollection_From_Result,
	}
	
	#endregion QuestionGroupChildEntityTypes
	
	#region QuestionGroupFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupFilterBuilder : SqlFilterBuilder<QuestionGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilterBuilder class.
		/// </summary>
		public QuestionGroupFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupFilterBuilder
	
	#region QuestionGroupParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupParameterBuilder : ParameterizedSqlFilterBuilder<QuestionGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupParameterBuilder class.
		/// </summary>
		public QuestionGroupParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupParameterBuilder
	
	#region QuestionGroupSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionGroupSortBuilder : SqlSortBuilder<QuestionGroupColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupSqlSortBuilder class.
		/// </summary>
		public QuestionGroupSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionGroupSortBuilder
	
} // end namespace
