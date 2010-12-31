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
	/// This class is the base class for any <see cref="QuestionGroupsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class QuestionGroupsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.QuestionGroups, NDMSInvestigation.Entities.QuestionGroupsKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByUserIdFromResults
		
		/// <summary>
		///		Gets QuestionGroups objects from the datasource by UserId in the
		///		Results table. Table QuestionGroups is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of QuestionGroups objects.</returns>
		public TList<QuestionGroups> GetByUserIdFromResults(System.Guid _userId)
		{
			int count = -1;
			return GetByUserIdFromResults(null,_userId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.QuestionGroups objects from the datasource by UserId in the
		///		Results table. Table QuestionGroups is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of QuestionGroups objects.</returns>
		public TList<QuestionGroups> GetByUserIdFromResults(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromResults(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets QuestionGroups objects from the datasource by UserId in the
		///		Results table. Table QuestionGroups is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionGroups objects.</returns>
		public TList<QuestionGroups> GetByUserIdFromResults(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserIdFromResults(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets QuestionGroups objects from the datasource by UserId in the
		///		Results table. Table QuestionGroups is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionGroups objects.</returns>
		public TList<QuestionGroups> GetByUserIdFromResults(TransactionManager transactionManager, System.Guid _userId,int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromResults(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets QuestionGroups objects from the datasource by UserId in the
		///		Results table. Table QuestionGroups is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of QuestionGroups objects.</returns>
		public TList<QuestionGroups> GetByUserIdFromResults(System.Guid _userId,int start, int pageLength, out int count)
		{
			
			return GetByUserIdFromResults(null, _userId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets QuestionGroups objects from the datasource by UserId in the
		///		Results table. Table QuestionGroups is related to table aspnet_Users
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of QuestionGroups objects.</returns>
		public abstract TList<QuestionGroups> GetByUserIdFromResults(TransactionManager transactionManager,System.Guid _userId, int start, int pageLength, out int count);
		
		#endregion GetByUserIdFromResults
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroupsKey key)
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
		public override NDMSInvestigation.Entities.QuestionGroups Get(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroupsKey key, int start, int pageLength)
		{
			return GetByGroupId(transactionManager, key.GroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_QuestionGroup index.
		/// </summary>
		/// <param name="_orderNumber"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByOrderNumber(System.Int32? _orderNumber)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByOrderNumber(System.Int32? _orderNumber, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByOrderNumber(TransactionManager transactionManager, System.Int32? _orderNumber)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByOrderNumber(TransactionManager transactionManager, System.Int32? _orderNumber, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByOrderNumber(System.Int32? _orderNumber, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionGroups GetByOrderNumber(TransactionManager transactionManager, System.Int32? _orderNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_QuestionGroup index.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByGroupId(System.Int32 _groupId)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByGroupId(System.Int32 _groupId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public NDMSInvestigation.Entities.QuestionGroups GetByGroupId(System.Int32 _groupId, int start, int pageLength, out int count)
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
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> class.</returns>
		public abstract NDMSInvestigation.Entities.QuestionGroups GetByGroupId(TransactionManager transactionManager, System.Int32 _groupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;QuestionGroups&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;QuestionGroups&gt;"/></returns>
		public static TList<QuestionGroups> Fill(IDataReader reader, TList<QuestionGroups> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.QuestionGroups c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("QuestionGroups")
					.Append("|").Append((System.Int32)reader[((int)QuestionGroupsColumn.GroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<QuestionGroups>(
					key.ToString(), // EntityTrackingKey
					"QuestionGroups",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.QuestionGroups();
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
					c.GroupId = (System.Int32)reader[((int)QuestionGroupsColumn.GroupId - 1)];
					c.GroupName = (reader.IsDBNull(((int)QuestionGroupsColumn.GroupName - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.GroupName - 1)];
					c.GroupDescription = (reader.IsDBNull(((int)QuestionGroupsColumn.GroupDescription - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.GroupDescription - 1)];
					c.OrderNumber = (reader.IsDBNull(((int)QuestionGroupsColumn.OrderNumber - 1)))?null:(System.Int32?)reader[((int)QuestionGroupsColumn.OrderNumber - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)QuestionGroupsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionGroupsColumn.CreatedDate - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)QuestionGroupsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.CreatedBy - 1)];
					c.UpdatedDate = (reader.IsDBNull(((int)QuestionGroupsColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionGroupsColumn.UpdatedDate - 1)];
					c.UpdatedBy = (reader.IsDBNull(((int)QuestionGroupsColumn.UpdatedBy - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.UpdatedBy - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionGroups"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.QuestionGroups entity)
		{
			if (!reader.Read()) return;
			
			entity.GroupId = (System.Int32)reader[((int)QuestionGroupsColumn.GroupId - 1)];
			entity.GroupName = (reader.IsDBNull(((int)QuestionGroupsColumn.GroupName - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.GroupName - 1)];
			entity.GroupDescription = (reader.IsDBNull(((int)QuestionGroupsColumn.GroupDescription - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.GroupDescription - 1)];
			entity.OrderNumber = (reader.IsDBNull(((int)QuestionGroupsColumn.OrderNumber - 1)))?null:(System.Int32?)reader[((int)QuestionGroupsColumn.OrderNumber - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)QuestionGroupsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionGroupsColumn.CreatedDate - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)QuestionGroupsColumn.CreatedBy - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.CreatedBy - 1)];
			entity.UpdatedDate = (reader.IsDBNull(((int)QuestionGroupsColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)QuestionGroupsColumn.UpdatedDate - 1)];
			entity.UpdatedBy = (reader.IsDBNull(((int)QuestionGroupsColumn.UpdatedBy - 1)))?null:(System.String)reader[((int)QuestionGroupsColumn.UpdatedBy - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.QuestionGroups"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionGroups"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.QuestionGroups entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.GroupId = (System.Int32)dataRow["GroupId"];
			entity.GroupName = Convert.IsDBNull(dataRow["GroupName"]) ? null : (System.String)dataRow["GroupName"];
			entity.GroupDescription = Convert.IsDBNull(dataRow["GroupDescription"]) ? null : (System.String)dataRow["GroupDescription"];
			entity.OrderNumber = Convert.IsDBNull(dataRow["OrderNumber"]) ? null : (System.Int32?)dataRow["OrderNumber"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["CreatedBy"]) ? null : (System.String)dataRow["CreatedBy"];
			entity.UpdatedDate = Convert.IsDBNull(dataRow["UpdatedDate"]) ? null : (System.DateTime?)dataRow["UpdatedDate"];
			entity.UpdatedBy = Convert.IsDBNull(dataRow["UpdatedBy"]) ? null : (System.String)dataRow["UpdatedBy"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.QuestionGroups"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionGroups Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroups entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			
			
			#region UserIdAspnetUsersCollection_From_Results
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AspnetUsers>|UserIdAspnetUsersCollection_From_Results", deepLoadType, innerList))
			{
				entity.UserIdAspnetUsersCollection_From_Results = DataRepository.AspnetUsersProvider.GetByGroupIdFromResults(transactionManager, entity.GroupId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdAspnetUsersCollection_From_Results' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdAspnetUsersCollection_From_Results != null)
				{
					deepHandles.Add("UserIdAspnetUsersCollection_From_Results",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AspnetUsers >) DataRepository.AspnetUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.UserIdAspnetUsersCollection_From_Results, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region ResultsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Results>|ResultsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ResultsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ResultsCollection = DataRepository.ResultsProvider.GetByGroupId(transactionManager, entity.GroupId);

				if (deep && entity.ResultsCollection.Count > 0)
				{
					deepHandles.Add("ResultsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Results>) DataRepository.ResultsProvider.DeepLoad,
						new object[] { transactionManager, entity.ResultsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.QuestionGroups object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.QuestionGroups instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.QuestionGroups Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.QuestionGroups entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region UserIdAspnetUsersCollection_From_Results>
			if (CanDeepSave(entity.UserIdAspnetUsersCollection_From_Results, "List<AspnetUsers>|UserIdAspnetUsersCollection_From_Results", deepSaveType, innerList))
			{
				if (entity.UserIdAspnetUsersCollection_From_Results.Count > 0 || entity.UserIdAspnetUsersCollection_From_Results.DeletedItems.Count > 0)
				{
					DataRepository.AspnetUsersProvider.Save(transactionManager, entity.UserIdAspnetUsersCollection_From_Results); 
					deepHandles.Add("UserIdAspnetUsersCollection_From_Results",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<AspnetUsers>) DataRepository.AspnetUsersProvider.DeepSave,
						new object[] { transactionManager, entity.UserIdAspnetUsersCollection_From_Results, deepSaveType, childTypes, innerList }
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
				
	
			#region List<Results>
				if (CanDeepSave(entity.ResultsCollection, "List<Results>|ResultsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Results child in entity.ResultsCollection)
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

					if (entity.ResultsCollection.Count > 0 || entity.ResultsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ResultsProvider.Save(transactionManager, entity.ResultsCollection);
						
						deepHandles.Add("ResultsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Results >) DataRepository.ResultsProvider.DeepSave,
							new object[] { transactionManager, entity.ResultsCollection, deepSaveType, childTypes, innerList }
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
	
	#region QuestionGroupsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.QuestionGroups</c>
	///</summary>
	public enum QuestionGroupsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>QuestionGroups</c> as OneToMany for QuestionDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<QuestionDetails>))]
		QuestionDetailsCollection,

		///<summary>
		/// Collection of <c>QuestionGroups</c> as ManyToMany for AspnetUsersCollection_From_Results
		///</summary>
		[ChildEntityType(typeof(TList<AspnetUsers>))]
		UserIdAspnetUsersCollection_From_Results,

		///<summary>
		/// Collection of <c>QuestionGroups</c> as OneToMany for ResultsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Results>))]
		ResultsCollection,
	}
	
	#endregion QuestionGroupsChildEntityTypes
	
	#region QuestionGroupsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;QuestionGroupsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupsFilterBuilder : SqlFilterBuilder<QuestionGroupsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsFilterBuilder class.
		/// </summary>
		public QuestionGroupsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupsFilterBuilder
	
	#region QuestionGroupsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;QuestionGroupsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupsParameterBuilder : ParameterizedSqlFilterBuilder<QuestionGroupsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsParameterBuilder class.
		/// </summary>
		public QuestionGroupsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public QuestionGroupsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public QuestionGroupsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion QuestionGroupsParameterBuilder
	
	#region QuestionGroupsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;QuestionGroupsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroups"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class QuestionGroupsSortBuilder : SqlSortBuilder<QuestionGroupsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsSqlSortBuilder class.
		/// </summary>
		public QuestionGroupsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion QuestionGroupsSortBuilder
	
} // end namespace
