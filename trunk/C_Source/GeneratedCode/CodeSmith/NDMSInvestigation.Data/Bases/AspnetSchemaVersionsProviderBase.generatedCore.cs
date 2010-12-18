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
	/// This class is the base class for any <see cref="AspnetSchemaVersionsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetSchemaVersionsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetSchemaVersions, NDMSInvestigation.Entities.AspnetSchemaVersionsKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetSchemaVersionsKey key)
		{
			return Delete(transactionManager, key.Feature, key.CompatibleSchemaVersion);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_feature">. Primary Key.</param>
		/// <param name="_compatibleSchemaVersion">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _feature, System.String _compatibleSchemaVersion)
		{
			return Delete(null, _feature, _compatibleSchemaVersion);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_feature">. Primary Key.</param>
		/// <param name="_compatibleSchemaVersion">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _feature, System.String _compatibleSchemaVersion);		
		
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
		public override NDMSInvestigation.Entities.AspnetSchemaVersions Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetSchemaVersionsKey key, int start, int pageLength)
		{
			return GetByFeatureCompatibleSchemaVersion(transactionManager, key.Feature, key.CompatibleSchemaVersion, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_SchemaVer__08EA5793 index.
		/// </summary>
		/// <param name="_feature"></param>
		/// <param name="_compatibleSchemaVersion"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetSchemaVersions GetByFeatureCompatibleSchemaVersion(System.String _feature, System.String _compatibleSchemaVersion)
		{
			int count = -1;
			return GetByFeatureCompatibleSchemaVersion(null,_feature, _compatibleSchemaVersion, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_SchemaVer__08EA5793 index.
		/// </summary>
		/// <param name="_feature"></param>
		/// <param name="_compatibleSchemaVersion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetSchemaVersions GetByFeatureCompatibleSchemaVersion(System.String _feature, System.String _compatibleSchemaVersion, int start, int pageLength)
		{
			int count = -1;
			return GetByFeatureCompatibleSchemaVersion(null, _feature, _compatibleSchemaVersion, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_SchemaVer__08EA5793 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_feature"></param>
		/// <param name="_compatibleSchemaVersion"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetSchemaVersions GetByFeatureCompatibleSchemaVersion(TransactionManager transactionManager, System.String _feature, System.String _compatibleSchemaVersion)
		{
			int count = -1;
			return GetByFeatureCompatibleSchemaVersion(transactionManager, _feature, _compatibleSchemaVersion, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_SchemaVer__08EA5793 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_feature"></param>
		/// <param name="_compatibleSchemaVersion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetSchemaVersions GetByFeatureCompatibleSchemaVersion(TransactionManager transactionManager, System.String _feature, System.String _compatibleSchemaVersion, int start, int pageLength)
		{
			int count = -1;
			return GetByFeatureCompatibleSchemaVersion(transactionManager, _feature, _compatibleSchemaVersion, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_SchemaVer__08EA5793 index.
		/// </summary>
		/// <param name="_feature"></param>
		/// <param name="_compatibleSchemaVersion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetSchemaVersions GetByFeatureCompatibleSchemaVersion(System.String _feature, System.String _compatibleSchemaVersion, int start, int pageLength, out int count)
		{
			return GetByFeatureCompatibleSchemaVersion(null, _feature, _compatibleSchemaVersion, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_SchemaVer__08EA5793 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_feature"></param>
		/// <param name="_compatibleSchemaVersion"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetSchemaVersions GetByFeatureCompatibleSchemaVersion(TransactionManager transactionManager, System.String _feature, System.String _compatibleSchemaVersion, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetSchemaVersions&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetSchemaVersions&gt;"/></returns>
		public static TList<AspnetSchemaVersions> Fill(IDataReader reader, TList<AspnetSchemaVersions> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetSchemaVersions c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetSchemaVersions")
					.Append("|").Append((System.String)reader[((int)AspnetSchemaVersionsColumn.Feature - 1)])
					.Append("|").Append((System.String)reader[((int)AspnetSchemaVersionsColumn.CompatibleSchemaVersion - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetSchemaVersions>(
					key.ToString(), // EntityTrackingKey
					"AspnetSchemaVersions",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetSchemaVersions();
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
					c.Feature = (System.String)reader[((int)AspnetSchemaVersionsColumn.Feature - 1)];
					c.OriginalFeature = c.Feature;
					c.CompatibleSchemaVersion = (System.String)reader[((int)AspnetSchemaVersionsColumn.CompatibleSchemaVersion - 1)];
					c.OriginalCompatibleSchemaVersion = c.CompatibleSchemaVersion;
					c.IsCurrentVersion = (System.Boolean)reader[((int)AspnetSchemaVersionsColumn.IsCurrentVersion - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetSchemaVersions entity)
		{
			if (!reader.Read()) return;
			
			entity.Feature = (System.String)reader[((int)AspnetSchemaVersionsColumn.Feature - 1)];
			entity.OriginalFeature = (System.String)reader["Feature"];
			entity.CompatibleSchemaVersion = (System.String)reader[((int)AspnetSchemaVersionsColumn.CompatibleSchemaVersion - 1)];
			entity.OriginalCompatibleSchemaVersion = (System.String)reader["CompatibleSchemaVersion"];
			entity.IsCurrentVersion = (System.Boolean)reader[((int)AspnetSchemaVersionsColumn.IsCurrentVersion - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetSchemaVersions entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Feature = (System.String)dataRow["Feature"];
			entity.OriginalFeature = (System.String)dataRow["Feature"];
			entity.CompatibleSchemaVersion = (System.String)dataRow["CompatibleSchemaVersion"];
			entity.OriginalCompatibleSchemaVersion = (System.String)dataRow["CompatibleSchemaVersion"];
			entity.IsCurrentVersion = (System.Boolean)dataRow["IsCurrentVersion"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetSchemaVersions"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetSchemaVersions Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetSchemaVersions entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetSchemaVersions object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetSchemaVersions instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetSchemaVersions Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetSchemaVersions entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AspnetSchemaVersionsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetSchemaVersions</c>
	///</summary>
	public enum AspnetSchemaVersionsChildEntityTypes
	{
	}
	
	#endregion AspnetSchemaVersionsChildEntityTypes
	
	#region AspnetSchemaVersionsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetSchemaVersionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsFilterBuilder : SqlFilterBuilder<AspnetSchemaVersionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsFilterBuilder class.
		/// </summary>
		public AspnetSchemaVersionsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetSchemaVersionsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetSchemaVersionsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetSchemaVersionsFilterBuilder
	
	#region AspnetSchemaVersionsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetSchemaVersionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsParameterBuilder : ParameterizedSqlFilterBuilder<AspnetSchemaVersionsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsParameterBuilder class.
		/// </summary>
		public AspnetSchemaVersionsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetSchemaVersionsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetSchemaVersionsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetSchemaVersionsParameterBuilder
	
	#region AspnetSchemaVersionsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetSchemaVersionsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetSchemaVersionsSortBuilder : SqlSortBuilder<AspnetSchemaVersionsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsSqlSortBuilder class.
		/// </summary>
		public AspnetSchemaVersionsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetSchemaVersionsSortBuilder
	
} // end namespace
