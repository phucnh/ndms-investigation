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
	/// This class is the base class for any <see cref="AspnetPersonalizationAllUsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetPersonalizationAllUsersProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetPersonalizationAllUsers, NDMSInvestigation.Entities.AspnetPersonalizationAllUsersKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationAllUsersKey key)
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
		public override NDMSInvestigation.Entities.AspnetPersonalizationAllUsers Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationAllUsersKey key, int start, int pageLength)
		{
			return GetByPathId(transactionManager, key.PathId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Personali__4AB81AF0 index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationAllUsers GetByPathId(System.Guid _pathId)
		{
			int count = -1;
			return GetByPathId(null,_pathId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4AB81AF0 index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationAllUsers GetByPathId(System.Guid _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathId(null, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4AB81AF0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationAllUsers GetByPathId(TransactionManager transactionManager, System.Guid _pathId)
		{
			int count = -1;
			return GetByPathId(transactionManager, _pathId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4AB81AF0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationAllUsers GetByPathId(TransactionManager transactionManager, System.Guid _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathId(transactionManager, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4AB81AF0 index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationAllUsers GetByPathId(System.Guid _pathId, int start, int pageLength, out int count)
		{
			return GetByPathId(null, _pathId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4AB81AF0 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetPersonalizationAllUsers GetByPathId(TransactionManager transactionManager, System.Guid _pathId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetPersonalizationAllUsers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetPersonalizationAllUsers&gt;"/></returns>
		public static TList<AspnetPersonalizationAllUsers> Fill(IDataReader reader, TList<AspnetPersonalizationAllUsers> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetPersonalizationAllUsers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetPersonalizationAllUsers")
					.Append("|").Append((System.Guid)reader[((int)AspnetPersonalizationAllUsersColumn.PathId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetPersonalizationAllUsers>(
					key.ToString(), // EntityTrackingKey
					"AspnetPersonalizationAllUsers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetPersonalizationAllUsers();
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
					c.PathId = (System.Guid)reader[((int)AspnetPersonalizationAllUsersColumn.PathId - 1)];
					c.OriginalPathId = c.PathId;
					c.PageSettings = (System.Byte[])reader[((int)AspnetPersonalizationAllUsersColumn.PageSettings - 1)];
					c.LastUpdatedDate = (System.DateTime)reader[((int)AspnetPersonalizationAllUsersColumn.LastUpdatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetPersonalizationAllUsers entity)
		{
			if (!reader.Read()) return;
			
			entity.PathId = (System.Guid)reader[((int)AspnetPersonalizationAllUsersColumn.PathId - 1)];
			entity.OriginalPathId = (System.Guid)reader["PathId"];
			entity.PageSettings = (System.Byte[])reader[((int)AspnetPersonalizationAllUsersColumn.PageSettings - 1)];
			entity.LastUpdatedDate = (System.DateTime)reader[((int)AspnetPersonalizationAllUsersColumn.LastUpdatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetPersonalizationAllUsers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PathId = (System.Guid)dataRow["PathId"];
			entity.OriginalPathId = (System.Guid)dataRow["PathId"];
			entity.PageSettings = (System.Byte[])dataRow["PageSettings"];
			entity.LastUpdatedDate = (System.DateTime)dataRow["LastUpdatedDate"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPersonalizationAllUsers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetPersonalizationAllUsers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationAllUsers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region PathIdSource	
			if (CanDeepLoad(entity, "AspnetPaths|PathIdSource", deepLoadType, innerList) 
				&& entity.PathIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PathId;
				AspnetPaths tmpEntity = EntityManager.LocateEntity<AspnetPaths>(EntityLocator.ConstructKeyFromPkItems(typeof(AspnetPaths), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PathIdSource = tmpEntity;
				else
					entity.PathIdSource = DataRepository.AspnetPathsProvider.GetByPathId(transactionManager, entity.PathId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PathIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PathIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AspnetPathsProvider.DeepLoad(transactionManager, entity.PathIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PathIdSource
			
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetPersonalizationAllUsers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetPersonalizationAllUsers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetPersonalizationAllUsers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationAllUsers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PathIdSource
			if (CanDeepSave(entity, "AspnetPaths|PathIdSource", deepSaveType, innerList) 
				&& entity.PathIdSource != null)
			{
				DataRepository.AspnetPathsProvider.Save(transactionManager, entity.PathIdSource);
				entity.PathId = entity.PathIdSource.PathId;
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
	
	#region AspnetPersonalizationAllUsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetPersonalizationAllUsers</c>
	///</summary>
	public enum AspnetPersonalizationAllUsersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetPaths</c> at PathIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetPaths))]
		AspnetPaths,
		}
	
	#endregion AspnetPersonalizationAllUsersChildEntityTypes
	
	#region AspnetPersonalizationAllUsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetPersonalizationAllUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersFilterBuilder : SqlFilterBuilder<AspnetPersonalizationAllUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersFilterBuilder class.
		/// </summary>
		public AspnetPersonalizationAllUsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationAllUsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationAllUsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationAllUsersFilterBuilder
	
	#region AspnetPersonalizationAllUsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetPersonalizationAllUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersParameterBuilder : ParameterizedSqlFilterBuilder<AspnetPersonalizationAllUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersParameterBuilder class.
		/// </summary>
		public AspnetPersonalizationAllUsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationAllUsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationAllUsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationAllUsersParameterBuilder
	
	#region AspnetPersonalizationAllUsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetPersonalizationAllUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetPersonalizationAllUsersSortBuilder : SqlSortBuilder<AspnetPersonalizationAllUsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersSqlSortBuilder class.
		/// </summary>
		public AspnetPersonalizationAllUsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetPersonalizationAllUsersSortBuilder
	
} // end namespace
