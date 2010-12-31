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
	/// This class is the base class for any <see cref="TraceChangeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TraceChangeProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.TraceChange, NDMSInvestigation.Entities.TraceChangeKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.TraceChangeKey key)
		{
			return Delete(transactionManager, key.TraceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_traceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _traceId)
		{
			return Delete(null, _traceId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _traceId);		
		
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
		public override NDMSInvestigation.Entities.TraceChange Get(TransactionManager transactionManager, NDMSInvestigation.Entities.TraceChangeKey key, int start, int pageLength)
		{
			return GetByTraceId(transactionManager, key.TraceId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TraceChange index.
		/// </summary>
		/// <param name="_traceId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TraceChange"/> class.</returns>
		public NDMSInvestigation.Entities.TraceChange GetByTraceId(System.Int32 _traceId)
		{
			int count = -1;
			return GetByTraceId(null,_traceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TraceChange index.
		/// </summary>
		/// <param name="_traceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TraceChange"/> class.</returns>
		public NDMSInvestigation.Entities.TraceChange GetByTraceId(System.Int32 _traceId, int start, int pageLength)
		{
			int count = -1;
			return GetByTraceId(null, _traceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TraceChange index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TraceChange"/> class.</returns>
		public NDMSInvestigation.Entities.TraceChange GetByTraceId(TransactionManager transactionManager, System.Int32 _traceId)
		{
			int count = -1;
			return GetByTraceId(transactionManager, _traceId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TraceChange index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TraceChange"/> class.</returns>
		public NDMSInvestigation.Entities.TraceChange GetByTraceId(TransactionManager transactionManager, System.Int32 _traceId, int start, int pageLength)
		{
			int count = -1;
			return GetByTraceId(transactionManager, _traceId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TraceChange index.
		/// </summary>
		/// <param name="_traceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TraceChange"/> class.</returns>
		public NDMSInvestigation.Entities.TraceChange GetByTraceId(System.Int32 _traceId, int start, int pageLength, out int count)
		{
			return GetByTraceId(null, _traceId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TraceChange index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.TraceChange"/> class.</returns>
		public abstract NDMSInvestigation.Entities.TraceChange GetByTraceId(TransactionManager transactionManager, System.Int32 _traceId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TraceChange&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TraceChange&gt;"/></returns>
		public static TList<TraceChange> Fill(IDataReader reader, TList<TraceChange> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.TraceChange c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TraceChange")
					.Append("|").Append((System.Int32)reader[((int)TraceChangeColumn.TraceId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TraceChange>(
					key.ToString(), // EntityTrackingKey
					"TraceChange",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.TraceChange();
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
					c.TraceId = (System.Int32)reader[((int)TraceChangeColumn.TraceId - 1)];
					c.NameOfTable = (reader.IsDBNull(((int)TraceChangeColumn.NameOfTable - 1)))?null:(System.String)reader[((int)TraceChangeColumn.NameOfTable - 1)];
					c.OldValue = (reader.IsDBNull(((int)TraceChangeColumn.OldValue - 1)))?null:(System.String)reader[((int)TraceChangeColumn.OldValue - 1)];
					c.NewValue = (reader.IsDBNull(((int)TraceChangeColumn.NewValue - 1)))?null:(System.String)reader[((int)TraceChangeColumn.NewValue - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)TraceChangeColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)TraceChangeColumn.CreatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.TraceChange"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.TraceChange"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.TraceChange entity)
		{
			if (!reader.Read()) return;
			
			entity.TraceId = (System.Int32)reader[((int)TraceChangeColumn.TraceId - 1)];
			entity.NameOfTable = (reader.IsDBNull(((int)TraceChangeColumn.NameOfTable - 1)))?null:(System.String)reader[((int)TraceChangeColumn.NameOfTable - 1)];
			entity.OldValue = (reader.IsDBNull(((int)TraceChangeColumn.OldValue - 1)))?null:(System.String)reader[((int)TraceChangeColumn.OldValue - 1)];
			entity.NewValue = (reader.IsDBNull(((int)TraceChangeColumn.NewValue - 1)))?null:(System.String)reader[((int)TraceChangeColumn.NewValue - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)TraceChangeColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)TraceChangeColumn.CreatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.TraceChange"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.TraceChange"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.TraceChange entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TraceId = (System.Int32)dataRow["TraceId"];
			entity.NameOfTable = Convert.IsDBNull(dataRow["NameOfTable"]) ? null : (System.String)dataRow["NameOfTable"];
			entity.OldValue = Convert.IsDBNull(dataRow["OldValue"]) ? null : (System.String)dataRow["OldValue"];
			entity.NewValue = Convert.IsDBNull(dataRow["NewValue"]) ? null : (System.String)dataRow["NewValue"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.TraceChange"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.TraceChange Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.TraceChange entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTraceId methods when available
			
			#region CompanyDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CompanyDetails>|CompanyDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CompanyDetailsCollection = DataRepository.CompanyDetailsProvider.GetByTraceChange(transactionManager, entity.TraceId);

				if (deep && entity.CompanyDetailsCollection.Count > 0)
				{
					deepHandles.Add("CompanyDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CompanyDetails>) DataRepository.CompanyDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.CompanyDetailsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.TraceChange object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.TraceChange instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.TraceChange Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.TraceChange entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<CompanyDetails>
				if (CanDeepSave(entity.CompanyDetailsCollection, "List<CompanyDetails>|CompanyDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CompanyDetails child in entity.CompanyDetailsCollection)
					{
						if(child.TraceChangeSource != null)
						{
							child.TraceChange = child.TraceChangeSource.TraceId;
						}
						else
						{
							child.TraceChange = entity.TraceId;
						}

					}

					if (entity.CompanyDetailsCollection.Count > 0 || entity.CompanyDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CompanyDetailsProvider.Save(transactionManager, entity.CompanyDetailsCollection);
						
						deepHandles.Add("CompanyDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CompanyDetails >) DataRepository.CompanyDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.CompanyDetailsCollection, deepSaveType, childTypes, innerList }
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
	
	#region TraceChangeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.TraceChange</c>
	///</summary>
	public enum TraceChangeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>TraceChange</c> as OneToMany for CompanyDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<CompanyDetails>))]
		CompanyDetailsCollection,
	}
	
	#endregion TraceChangeChildEntityTypes
	
	#region TraceChangeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TraceChangeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TraceChange"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TraceChangeFilterBuilder : SqlFilterBuilder<TraceChangeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TraceChangeFilterBuilder class.
		/// </summary>
		public TraceChangeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TraceChangeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TraceChangeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TraceChangeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TraceChangeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TraceChangeFilterBuilder
	
	#region TraceChangeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TraceChangeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TraceChange"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TraceChangeParameterBuilder : ParameterizedSqlFilterBuilder<TraceChangeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TraceChangeParameterBuilder class.
		/// </summary>
		public TraceChangeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TraceChangeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TraceChangeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TraceChangeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TraceChangeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TraceChangeParameterBuilder
	
	#region TraceChangeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TraceChangeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TraceChange"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TraceChangeSortBuilder : SqlSortBuilder<TraceChangeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TraceChangeSqlSortBuilder class.
		/// </summary>
		public TraceChangeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TraceChangeSortBuilder
	
} // end namespace
