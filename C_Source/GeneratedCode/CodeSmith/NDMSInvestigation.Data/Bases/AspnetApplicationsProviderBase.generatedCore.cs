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
	/// This class is the base class for any <see cref="AspnetApplicationsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetApplicationsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetApplications, NDMSInvestigation.Entities.AspnetApplicationsKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetApplicationsKey key)
		{
			return Delete(transactionManager, key.ApplicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_applicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _applicationId)
		{
			return Delete(null, _applicationId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _applicationId);		
		
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
		public override NDMSInvestigation.Entities.AspnetApplications Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetApplicationsKey key, int start, int pageLength)
		{
			return GetByApplicationId(transactionManager, key.ApplicationId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_Applications_Index index.
		/// </summary>
		/// <param name="_loweredApplicationName"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetApplications&gt;"/> class.</returns>
		public TList<AspnetApplications> GetByLoweredApplicationName(System.String _loweredApplicationName)
		{
			int count = -1;
			return GetByLoweredApplicationName(null,_loweredApplicationName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Applications_Index index.
		/// </summary>
		/// <param name="_loweredApplicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetApplications&gt;"/> class.</returns>
		public TList<AspnetApplications> GetByLoweredApplicationName(System.String _loweredApplicationName, int start, int pageLength)
		{
			int count = -1;
			return GetByLoweredApplicationName(null, _loweredApplicationName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Applications_Index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_loweredApplicationName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetApplications&gt;"/> class.</returns>
		public TList<AspnetApplications> GetByLoweredApplicationName(TransactionManager transactionManager, System.String _loweredApplicationName)
		{
			int count = -1;
			return GetByLoweredApplicationName(transactionManager, _loweredApplicationName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Applications_Index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_loweredApplicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetApplications&gt;"/> class.</returns>
		public TList<AspnetApplications> GetByLoweredApplicationName(TransactionManager transactionManager, System.String _loweredApplicationName, int start, int pageLength)
		{
			int count = -1;
			return GetByLoweredApplicationName(transactionManager, _loweredApplicationName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Applications_Index index.
		/// </summary>
		/// <param name="_loweredApplicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetApplications&gt;"/> class.</returns>
		public TList<AspnetApplications> GetByLoweredApplicationName(System.String _loweredApplicationName, int start, int pageLength, out int count)
		{
			return GetByLoweredApplicationName(null, _loweredApplicationName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Applications_Index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_loweredApplicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetApplications&gt;"/> class.</returns>
		public abstract TList<AspnetApplications> GetByLoweredApplicationName(TransactionManager transactionManager, System.String _loweredApplicationName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Applicati__7E6CC920 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationId(System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(null,_applicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Applicati__7E6CC920 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationId(System.Guid _applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(null, _applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Applicati__7E6CC920 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Applicati__7E6CC920 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Applicati__7E6CC920 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationId(System.Guid _applicationId, int start, int pageLength, out int count)
		{
			return GetByApplicationId(null, _applicationId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Applicati__7E6CC920 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetApplications GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key UQ__aspnet_Applicati__00551192 index.
		/// </summary>
		/// <param name="_applicationName"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationName(System.String _applicationName)
		{
			int count = -1;
			return GetByApplicationName(null,_applicationName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__aspnet_Applicati__00551192 index.
		/// </summary>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationName(System.String _applicationName, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationName(null, _applicationName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__aspnet_Applicati__00551192 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationName(TransactionManager transactionManager, System.String _applicationName)
		{
			int count = -1;
			return GetByApplicationName(transactionManager, _applicationName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__aspnet_Applicati__00551192 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationName(TransactionManager transactionManager, System.String _applicationName, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationName(transactionManager, _applicationName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__aspnet_Applicati__00551192 index.
		/// </summary>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetApplications GetByApplicationName(System.String _applicationName, int start, int pageLength, out int count)
		{
			return GetByApplicationName(null, _applicationName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the UQ__aspnet_Applicati__00551192 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetApplications GetByApplicationName(TransactionManager transactionManager, System.String _applicationName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetApplications&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetApplications&gt;"/></returns>
		public static TList<AspnetApplications> Fill(IDataReader reader, TList<AspnetApplications> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetApplications c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetApplications")
					.Append("|").Append((System.Guid)reader[((int)AspnetApplicationsColumn.ApplicationId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetApplications>(
					key.ToString(), // EntityTrackingKey
					"AspnetApplications",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetApplications();
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
					c.ApplicationName = (System.String)reader[((int)AspnetApplicationsColumn.ApplicationName - 1)];
					c.LoweredApplicationName = (System.String)reader[((int)AspnetApplicationsColumn.LoweredApplicationName - 1)];
					c.ApplicationId = (System.Guid)reader[((int)AspnetApplicationsColumn.ApplicationId - 1)];
					c.Description = (reader.IsDBNull(((int)AspnetApplicationsColumn.Description - 1)))?null:(System.String)reader[((int)AspnetApplicationsColumn.Description - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetApplications"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetApplications entity)
		{
			if (!reader.Read()) return;
			
			entity.ApplicationName = (System.String)reader[((int)AspnetApplicationsColumn.ApplicationName - 1)];
			entity.LoweredApplicationName = (System.String)reader[((int)AspnetApplicationsColumn.LoweredApplicationName - 1)];
			entity.ApplicationId = (System.Guid)reader[((int)AspnetApplicationsColumn.ApplicationId - 1)];
			entity.Description = (reader.IsDBNull(((int)AspnetApplicationsColumn.Description - 1)))?null:(System.String)reader[((int)AspnetApplicationsColumn.Description - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetApplications"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetApplications"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetApplications entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ApplicationName = (System.String)dataRow["ApplicationName"];
			entity.LoweredApplicationName = (System.String)dataRow["LoweredApplicationName"];
			entity.ApplicationId = (System.Guid)dataRow["ApplicationId"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetApplications"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetApplications Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetApplications entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByApplicationId methods when available
			
			#region AspnetPathsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetPaths>|AspnetPathsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetPathsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetPathsCollection = DataRepository.AspnetPathsProvider.GetByApplicationId(transactionManager, entity.ApplicationId);

				if (deep && entity.AspnetPathsCollection.Count > 0)
				{
					deepHandles.Add("AspnetPathsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetPaths>) DataRepository.AspnetPathsProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetPathsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AspnetMembershipCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetMembership>|AspnetMembershipCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetMembershipCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetMembershipCollection = DataRepository.AspnetMembershipProvider.GetByApplicationId(transactionManager, entity.ApplicationId);

				if (deep && entity.AspnetMembershipCollection.Count > 0)
				{
					deepHandles.Add("AspnetMembershipCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetMembership>) DataRepository.AspnetMembershipProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetMembershipCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AspnetUsersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetUsers>|AspnetUsersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetUsersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetUsersCollection = DataRepository.AspnetUsersProvider.GetByApplicationId(transactionManager, entity.ApplicationId);

				if (deep && entity.AspnetUsersCollection.Count > 0)
				{
					deepHandles.Add("AspnetUsersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetUsers>) DataRepository.AspnetUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetUsersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AspnetRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetRoles>|AspnetRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetRolesCollection = DataRepository.AspnetRolesProvider.GetByApplicationId(transactionManager, entity.ApplicationId);

				if (deep && entity.AspnetRolesCollection.Count > 0)
				{
					deepHandles.Add("AspnetRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetRoles>) DataRepository.AspnetRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetRolesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetApplications object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetApplications instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetApplications Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetApplications entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<AspnetPaths>
				if (CanDeepSave(entity.AspnetPathsCollection, "List<AspnetPaths>|AspnetPathsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetPaths child in entity.AspnetPathsCollection)
					{
						if(child.ApplicationIdSource != null)
						{
							child.ApplicationId = child.ApplicationIdSource.ApplicationId;
						}
						else
						{
							child.ApplicationId = entity.ApplicationId;
						}

					}

					if (entity.AspnetPathsCollection.Count > 0 || entity.AspnetPathsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AspnetPathsProvider.Save(transactionManager, entity.AspnetPathsCollection);
						
						deepHandles.Add("AspnetPathsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AspnetPaths >) DataRepository.AspnetPathsProvider.DeepSave,
							new object[] { transactionManager, entity.AspnetPathsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AspnetMembership>
				if (CanDeepSave(entity.AspnetMembershipCollection, "List<AspnetMembership>|AspnetMembershipCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetMembership child in entity.AspnetMembershipCollection)
					{
						if(child.ApplicationIdSource != null)
						{
							child.ApplicationId = child.ApplicationIdSource.ApplicationId;
						}
						else
						{
							child.ApplicationId = entity.ApplicationId;
						}

					}

					if (entity.AspnetMembershipCollection.Count > 0 || entity.AspnetMembershipCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AspnetMembershipProvider.Save(transactionManager, entity.AspnetMembershipCollection);
						
						deepHandles.Add("AspnetMembershipCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AspnetMembership >) DataRepository.AspnetMembershipProvider.DeepSave,
							new object[] { transactionManager, entity.AspnetMembershipCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AspnetUsers>
				if (CanDeepSave(entity.AspnetUsersCollection, "List<AspnetUsers>|AspnetUsersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetUsers child in entity.AspnetUsersCollection)
					{
						if(child.ApplicationIdSource != null)
						{
							child.ApplicationId = child.ApplicationIdSource.ApplicationId;
						}
						else
						{
							child.ApplicationId = entity.ApplicationId;
						}

					}

					if (entity.AspnetUsersCollection.Count > 0 || entity.AspnetUsersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AspnetUsersProvider.Save(transactionManager, entity.AspnetUsersCollection);
						
						deepHandles.Add("AspnetUsersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AspnetUsers >) DataRepository.AspnetUsersProvider.DeepSave,
							new object[] { transactionManager, entity.AspnetUsersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<AspnetRoles>
				if (CanDeepSave(entity.AspnetRolesCollection, "List<AspnetRoles>|AspnetRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetRoles child in entity.AspnetRolesCollection)
					{
						if(child.ApplicationIdSource != null)
						{
							child.ApplicationId = child.ApplicationIdSource.ApplicationId;
						}
						else
						{
							child.ApplicationId = entity.ApplicationId;
						}

					}

					if (entity.AspnetRolesCollection.Count > 0 || entity.AspnetRolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AspnetRolesProvider.Save(transactionManager, entity.AspnetRolesCollection);
						
						deepHandles.Add("AspnetRolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AspnetRoles >) DataRepository.AspnetRolesProvider.DeepSave,
							new object[] { transactionManager, entity.AspnetRolesCollection, deepSaveType, childTypes, innerList }
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
	
	#region AspnetApplicationsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetApplications</c>
	///</summary>
	public enum AspnetApplicationsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>AspnetApplications</c> as OneToMany for AspnetPathsCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetPaths>))]
		AspnetPathsCollection,

		///<summary>
		/// Collection of <c>AspnetApplications</c> as OneToMany for AspnetMembershipCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetMembership>))]
		AspnetMembershipCollection,

		///<summary>
		/// Collection of <c>AspnetApplications</c> as OneToMany for AspnetUsersCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetUsers>))]
		AspnetUsersCollection,

		///<summary>
		/// Collection of <c>AspnetApplications</c> as OneToMany for AspnetRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetRoles>))]
		AspnetRolesCollection,
	}
	
	#endregion AspnetApplicationsChildEntityTypes
	
	#region AspnetApplicationsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetApplicationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsFilterBuilder : SqlFilterBuilder<AspnetApplicationsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsFilterBuilder class.
		/// </summary>
		public AspnetApplicationsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetApplicationsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetApplicationsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetApplicationsFilterBuilder
	
	#region AspnetApplicationsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetApplicationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsParameterBuilder : ParameterizedSqlFilterBuilder<AspnetApplicationsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsParameterBuilder class.
		/// </summary>
		public AspnetApplicationsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetApplicationsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetApplicationsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetApplicationsParameterBuilder
	
	#region AspnetApplicationsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetApplicationsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetApplicationsSortBuilder : SqlSortBuilder<AspnetApplicationsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsSqlSortBuilder class.
		/// </summary>
		public AspnetApplicationsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetApplicationsSortBuilder
	
} // end namespace
