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
	/// This class is the base class for any <see cref="AspnetPathsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetPathsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetPaths, NDMSInvestigation.Entities.AspnetPathsKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPathsKey key)
		{
			return Delete(transactionManager, key.PathId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_pathId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _pathId)
		{
			return Delete(null, _pathId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _pathId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pa__Appli__45F365D3 key.
		///		FK__aspnet_Pa__Appli__45F365D3 Description: 
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPaths objects.</returns>
		public TList<AspnetPaths> GetByApplicationId(System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(_applicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pa__Appli__45F365D3 key.
		///		FK__aspnet_Pa__Appli__45F365D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPaths objects.</returns>
		/// <remarks></remarks>
		public TList<AspnetPaths> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pa__Appli__45F365D3 key.
		///		FK__aspnet_Pa__Appli__45F365D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPaths objects.</returns>
		public TList<AspnetPaths> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pa__Appli__45F365D3 key.
		///		fkAspnetPaAppli45f365d3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPaths objects.</returns>
		public TList<AspnetPaths> GetByApplicationId(System.Guid _applicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByApplicationId(null, _applicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pa__Appli__45F365D3 key.
		///		fkAspnetPaAppli45f365d3 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPaths objects.</returns>
		public TList<AspnetPaths> GetByApplicationId(System.Guid _applicationId, int start, int pageLength,out int count)
		{
			return GetByApplicationId(null, _applicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pa__Appli__45F365D3 key.
		///		FK__aspnet_Pa__Appli__45F365D3 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPaths objects.</returns>
		public abstract TList<AspnetPaths> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.AspnetPaths Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPathsKey key, int start, int pageLength)
		{
			return GetByPathId(transactionManager, key.PathId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_Paths_index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredPath"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByApplicationIdLoweredPath(System.Guid _applicationId, System.String _loweredPath)
		{
			int count = -1;
			return GetByApplicationIdLoweredPath(null,_applicationId, _loweredPath, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Paths_index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredPath"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByApplicationIdLoweredPath(System.Guid _applicationId, System.String _loweredPath, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredPath(null, _applicationId, _loweredPath, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Paths_index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredPath"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByApplicationIdLoweredPath(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredPath)
		{
			int count = -1;
			return GetByApplicationIdLoweredPath(transactionManager, _applicationId, _loweredPath, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Paths_index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredPath"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByApplicationIdLoweredPath(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredPath, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredPath(transactionManager, _applicationId, _loweredPath, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Paths_index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredPath"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByApplicationIdLoweredPath(System.Guid _applicationId, System.String _loweredPath, int start, int pageLength, out int count)
		{
			return GetByApplicationIdLoweredPath(null, _applicationId, _loweredPath, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Paths_index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredPath"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetPaths GetByApplicationIdLoweredPath(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredPath, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Paths__44FF419A index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByPathId(System.Guid _pathId)
		{
			int count = -1;
			return GetByPathId(null,_pathId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Paths__44FF419A index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByPathId(System.Guid _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathId(null, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Paths__44FF419A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByPathId(TransactionManager transactionManager, System.Guid _pathId)
		{
			int count = -1;
			return GetByPathId(transactionManager, _pathId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Paths__44FF419A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByPathId(TransactionManager transactionManager, System.Guid _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathId(transactionManager, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Paths__44FF419A index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPaths GetByPathId(System.Guid _pathId, int start, int pageLength, out int count)
		{
			return GetByPathId(null, _pathId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Paths__44FF419A index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetPaths GetByPathId(TransactionManager transactionManager, System.Guid _pathId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetPaths&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetPaths&gt;"/></returns>
		public static TList<AspnetPaths> Fill(IDataReader reader, TList<AspnetPaths> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetPaths c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetPaths")
					.Append("|").Append((System.Guid)reader[((int)AspnetPathsColumn.PathId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetPaths>(
					key.ToString(), // EntityTrackingKey
					"AspnetPaths",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetPaths();
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
					c.ApplicationId = (System.Guid)reader[((int)AspnetPathsColumn.ApplicationId - 1)];
					c.PathId = (System.Guid)reader[((int)AspnetPathsColumn.PathId - 1)];
					c.OriginalPathId = c.PathId;
					c.Path = (System.String)reader[((int)AspnetPathsColumn.Path - 1)];
					c.LoweredPath = (System.String)reader[((int)AspnetPathsColumn.LoweredPath - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPaths"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetPaths entity)
		{
			if (!reader.Read()) return;
			
			entity.ApplicationId = (System.Guid)reader[((int)AspnetPathsColumn.ApplicationId - 1)];
			entity.PathId = (System.Guid)reader[((int)AspnetPathsColumn.PathId - 1)];
			entity.OriginalPathId = (System.Guid)reader["PathId"];
			entity.Path = (System.String)reader[((int)AspnetPathsColumn.Path - 1)];
			entity.LoweredPath = (System.String)reader[((int)AspnetPathsColumn.LoweredPath - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetPaths"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPaths"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetPaths entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ApplicationId = (System.Guid)dataRow["ApplicationId"];
			entity.PathId = (System.Guid)dataRow["PathId"];
			entity.OriginalPathId = (System.Guid)dataRow["PathId"];
			entity.Path = (System.String)dataRow["Path"];
			entity.LoweredPath = (System.String)dataRow["LoweredPath"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPaths"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetPaths Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPaths entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ApplicationIdSource	
			if (CanDeepLoad(entity, "AspnetApplications|ApplicationIdSource", deepLoadType, innerList) 
				&& entity.ApplicationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ApplicationId;
				AspnetApplications tmpEntity = EntityManager.LocateEntity<AspnetApplications>(EntityLocator.ConstructKeyFromPkItems(typeof(AspnetApplications), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ApplicationIdSource = tmpEntity;
				else
					entity.ApplicationIdSource = DataRepository.AspnetApplicationsProvider.GetByApplicationId(transactionManager, entity.ApplicationId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ApplicationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ApplicationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AspnetApplicationsProvider.DeepLoad(transactionManager, entity.ApplicationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ApplicationIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByPathId methods when available
			
			#region AspnetPersonalizationPerUserCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetPersonalizationPerUser>|AspnetPersonalizationPerUserCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetPersonalizationPerUserCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetPersonalizationPerUserCollection = DataRepository.AspnetPersonalizationPerUserProvider.GetByPathId(transactionManager, entity.PathId);

				if (deep && entity.AspnetPersonalizationPerUserCollection.Count > 0)
				{
					deepHandles.Add("AspnetPersonalizationPerUserCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetPersonalizationPerUser>) DataRepository.AspnetPersonalizationPerUserProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetPersonalizationPerUserCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AspnetPersonalizationAllUsers
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "AspnetPersonalizationAllUsers|AspnetPersonalizationAllUsers", deepLoadType, innerList))
			{
				entity.AspnetPersonalizationAllUsers = DataRepository.AspnetPersonalizationAllUsersProvider.GetByPathId(transactionManager, entity.PathId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetPersonalizationAllUsers' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.AspnetPersonalizationAllUsers != null)
				{
					deepHandles.Add("AspnetPersonalizationAllUsers",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< AspnetPersonalizationAllUsers >) DataRepository.AspnetPersonalizationAllUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetPersonalizationAllUsers, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetPaths object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetPaths instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetPaths Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPaths entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ApplicationIdSource
			if (CanDeepSave(entity, "AspnetApplications|ApplicationIdSource", deepSaveType, innerList) 
				&& entity.ApplicationIdSource != null)
			{
				DataRepository.AspnetApplicationsProvider.Save(transactionManager, entity.ApplicationIdSource);
				entity.ApplicationId = entity.ApplicationIdSource.ApplicationId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region AspnetPersonalizationAllUsers
			if (CanDeepSave(entity.AspnetPersonalizationAllUsers, "AspnetPersonalizationAllUsers|AspnetPersonalizationAllUsers", deepSaveType, innerList))
			{

				if (entity.AspnetPersonalizationAllUsers != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.AspnetPersonalizationAllUsers.PathId = entity.PathId;
					//DataRepository.AspnetPersonalizationAllUsersProvider.Save(transactionManager, entity.AspnetPersonalizationAllUsers);
					deepHandles.Add("AspnetPersonalizationAllUsers",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< AspnetPersonalizationAllUsers >) DataRepository.AspnetPersonalizationAllUsersProvider.DeepSave,
						new object[] { transactionManager, entity.AspnetPersonalizationAllUsers, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 
	
			#region List<AspnetPersonalizationPerUser>
				if (CanDeepSave(entity.AspnetPersonalizationPerUserCollection, "List<AspnetPersonalizationPerUser>|AspnetPersonalizationPerUserCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetPersonalizationPerUser child in entity.AspnetPersonalizationPerUserCollection)
					{
						if(child.PathIdSource != null)
						{
							child.PathId = child.PathIdSource.PathId;
						}
						else
						{
							child.PathId = entity.PathId;
						}

					}

					if (entity.AspnetPersonalizationPerUserCollection.Count > 0 || entity.AspnetPersonalizationPerUserCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AspnetPersonalizationPerUserProvider.Save(transactionManager, entity.AspnetPersonalizationPerUserCollection);
						
						deepHandles.Add("AspnetPersonalizationPerUserCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AspnetPersonalizationPerUser >) DataRepository.AspnetPersonalizationPerUserProvider.DeepSave,
							new object[] { transactionManager, entity.AspnetPersonalizationPerUserCollection, deepSaveType, childTypes, innerList }
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
	
	#region AspnetPathsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetPaths</c>
	///</summary>
	public enum AspnetPathsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetApplications</c> at ApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetApplications))]
		AspnetApplications,
	
		///<summary>
		/// Collection of <c>AspnetPaths</c> as OneToMany for AspnetPersonalizationPerUserCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetPersonalizationPerUser>))]
		AspnetPersonalizationPerUserCollection,
		///<summary>
		/// Entity <c>AspnetPersonalizationAllUsers</c> as OneToOne for AspnetPersonalizationAllUsers
		///</summary>
		[ChildEntityType(typeof(AspnetPersonalizationAllUsers))]
		AspnetPersonalizationAllUsers,
	}
	
	#endregion AspnetPathsChildEntityTypes
	
	#region AspnetPathsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetPathsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsFilterBuilder : SqlFilterBuilder<AspnetPathsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsFilterBuilder class.
		/// </summary>
		public AspnetPathsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPathsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPathsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPathsFilterBuilder
	
	#region AspnetPathsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetPathsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsParameterBuilder : ParameterizedSqlFilterBuilder<AspnetPathsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsParameterBuilder class.
		/// </summary>
		public AspnetPathsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPathsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPathsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPathsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPathsParameterBuilder
	
	#region AspnetPathsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetPathsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetPathsSortBuilder : SqlSortBuilder<AspnetPathsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsSqlSortBuilder class.
		/// </summary>
		public AspnetPathsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetPathsSortBuilder
	
} // end namespace
