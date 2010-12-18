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
	/// This class is the base class for any <see cref="ResultProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ResultProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.Result, NDMSInvestigation.Entities.ResultKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.ResultKey key)
		{
			return Delete(transactionManager, key.UserId, key.GroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userId">. Primary Key.</param>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _userId, System.Int32 _groupId)
		{
			return Delete(null, _userId, _groupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <param name="_groupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _userId, System.Int32 _groupId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		FK_Result_aspnet_Users Description: 
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByUserId(System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(_userId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		FK_Result_aspnet_Users Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		/// <remarks></remarks>
		public TList<Result> GetByUserId(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		FK_Result_aspnet_Users Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		fkResultAspnetUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByUserId(System.Guid _userId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserId(null, _userId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		fkResultAspnetUsers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByUserId(System.Guid _userId, int start, int pageLength,out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_aspnet_Users key.
		///		FK_Result_aspnet_Users Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public abstract TList<Result> GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		FK_Result_QuestionGroup Description: 
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByGroupId(System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(_groupId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		FK_Result_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		/// <remarks></remarks>
		public TList<Result> GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		FK_Result_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupId(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		fkResultQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByGroupId(System.Int32 _groupId, int start, int pageLength)
		{
			int count =  -1;
			return GetByGroupId(null, _groupId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		fkResultQuestionGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public TList<Result> GetByGroupId(System.Int32 _groupId, int start, int pageLength,out int count)
		{
			return GetByGroupId(null, _groupId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Result_QuestionGroup key.
		///		FK_Result_QuestionGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.Result objects.</returns>
		public abstract TList<Result> GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.Result Get(TransactionManager transactionManager, NDMSInvestigation.Entities.ResultKey key, int start, int pageLength)
		{
			return GetByUserIdGroupId(transactionManager, key.UserId, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Result index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public NDMSInvestigation.Entities.Result GetByUserIdGroupId(System.Guid _userId, System.Int32 _groupId)
		{
			int count = -1;
			return GetByUserIdGroupId(null,_userId, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Result index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public NDMSInvestigation.Entities.Result GetByUserIdGroupId(System.Guid _userId, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdGroupId(null, _userId, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Result index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public NDMSInvestigation.Entities.Result GetByUserIdGroupId(TransactionManager transactionManager, System.Guid _userId, System.Int32 _groupId)
		{
			int count = -1;
			return GetByUserIdGroupId(transactionManager, _userId, _groupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Result index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public NDMSInvestigation.Entities.Result GetByUserIdGroupId(TransactionManager transactionManager, System.Guid _userId, System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdGroupId(transactionManager, _userId, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Result index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public NDMSInvestigation.Entities.Result GetByUserIdGroupId(System.Guid _userId, System.Int32 _groupId, int start, int pageLength, out int count)
		{
			return GetByUserIdGroupId(null, _userId, _groupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Result index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.Result"/> class.</returns>
		public abstract NDMSInvestigation.Entities.Result GetByUserIdGroupId(TransactionManager transactionManager, System.Guid _userId, System.Int32 _groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Result&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Result&gt;"/></returns>
		public static TList<Result> Fill(IDataReader reader, TList<Result> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.Result c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Result")
					.Append("|").Append((System.Guid)reader[((int)ResultColumn.UserId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ResultColumn.GroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Result>(
					key.ToString(), // EntityTrackingKey
					"Result",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.Result();
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
					c.UserId = (System.Guid)reader[((int)ResultColumn.UserId - 1)];
					c.OriginalUserId = c.UserId;
					c.GroupId = (System.Int32)reader[((int)ResultColumn.GroupId - 1)];
					c.OriginalGroupId = c.GroupId;
					c.GroupMark = (reader.IsDBNull(((int)ResultColumn.GroupMark - 1)))?null:(System.Int32?)reader[((int)ResultColumn.GroupMark - 1)];
					c.UpdateDay = (reader.IsDBNull(((int)ResultColumn.UpdateDay - 1)))?null:(System.DateTime?)reader[((int)ResultColumn.UpdateDay - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.Result"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.Result"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.Result entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Guid)reader[((int)ResultColumn.UserId - 1)];
			entity.OriginalUserId = (System.Guid)reader["UserId"];
			entity.GroupId = (System.Int32)reader[((int)ResultColumn.GroupId - 1)];
			entity.OriginalGroupId = (System.Int32)reader["GroupId"];
			entity.GroupMark = (reader.IsDBNull(((int)ResultColumn.GroupMark - 1)))?null:(System.Int32?)reader[((int)ResultColumn.GroupMark - 1)];
			entity.UpdateDay = (reader.IsDBNull(((int)ResultColumn.UpdateDay - 1)))?null:(System.DateTime?)reader[((int)ResultColumn.UpdateDay - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.Result"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.Result"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.Result entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Guid)dataRow["UserId"];
			entity.OriginalUserId = (System.Guid)dataRow["UserId"];
			entity.GroupId = (System.Int32)dataRow["GroupId"];
			entity.OriginalGroupId = (System.Int32)dataRow["GroupId"];
			entity.GroupMark = Convert.IsDBNull(dataRow["GroupMark"]) ? null : (System.Int32?)dataRow["GroupMark"];
			entity.UpdateDay = Convert.IsDBNull(dataRow["UpdateDay"]) ? null : (System.DateTime?)dataRow["UpdateDay"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.Result"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.Result Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.Result entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region UserIdSource	
			if (CanDeepLoad(entity, "AspnetUsers|UserIdSource", deepLoadType, innerList) 
				&& entity.UserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.UserId;
				AspnetUsers tmpEntity = EntityManager.LocateEntity<AspnetUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AspnetUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserIdSource = tmpEntity;
				else
					entity.UserIdSource = DataRepository.AspnetUsersProvider.GetByUserId(transactionManager, entity.UserId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AspnetUsersProvider.DeepLoad(transactionManager, entity.UserIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UserIdSource

			#region GroupIdSource	
			if (CanDeepLoad(entity, "QuestionGroup|GroupIdSource", deepLoadType, innerList) 
				&& entity.GroupIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.GroupId;
				QuestionGroup tmpEntity = EntityManager.LocateEntity<QuestionGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(QuestionGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GroupIdSource = tmpEntity;
				else
					entity.GroupIdSource = DataRepository.QuestionGroupProvider.GetByGroupId(transactionManager, entity.GroupId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GroupIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GroupIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.QuestionGroupProvider.DeepLoad(transactionManager, entity.GroupIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GroupIdSource
			
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.Result object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.Result instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.Result Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.Result entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region UserIdSource
			if (CanDeepSave(entity, "AspnetUsers|UserIdSource", deepSaveType, innerList) 
				&& entity.UserIdSource != null)
			{
				DataRepository.AspnetUsersProvider.Save(transactionManager, entity.UserIdSource);
				entity.UserId = entity.UserIdSource.UserId;
			}
			#endregion 
			
			#region GroupIdSource
			if (CanDeepSave(entity, "QuestionGroup|GroupIdSource", deepSaveType, innerList) 
				&& entity.GroupIdSource != null)
			{
				DataRepository.QuestionGroupProvider.Save(transactionManager, entity.GroupIdSource);
				entity.GroupId = entity.GroupIdSource.GroupId;
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
	
	#region ResultChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.Result</c>
	///</summary>
	public enum ResultChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetUsers</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetUsers))]
		AspnetUsers,
			
		///<summary>
		/// Composite Property for <c>QuestionGroup</c> at GroupIdSource
		///</summary>
		[ChildEntityType(typeof(QuestionGroup))]
		QuestionGroup,
		}
	
	#endregion ResultChildEntityTypes
	
	#region ResultFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ResultColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultFilterBuilder : SqlFilterBuilder<ResultColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultFilterBuilder class.
		/// </summary>
		public ResultFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResultFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResultFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResultFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResultFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResultFilterBuilder
	
	#region ResultParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ResultColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultParameterBuilder : ParameterizedSqlFilterBuilder<ResultColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultParameterBuilder class.
		/// </summary>
		public ResultParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ResultParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ResultParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ResultParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ResultParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ResultParameterBuilder
	
	#region ResultSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ResultColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ResultSortBuilder : SqlSortBuilder<ResultColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultSqlSortBuilder class.
		/// </summary>
		public ResultSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ResultSortBuilder
	
} // end namespace
