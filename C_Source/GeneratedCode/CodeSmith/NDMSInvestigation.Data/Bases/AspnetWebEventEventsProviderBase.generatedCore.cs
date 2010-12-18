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
	/// This class is the base class for any <see cref="AspnetWebEventEventsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetWebEventEventsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetWebEventEvents, NDMSInvestigation.Entities.AspnetWebEventEventsKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetWebEventEventsKey key)
		{
			return Delete(transactionManager, key.EventId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_eventId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _eventId)
		{
			return Delete(null, _eventId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_eventId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _eventId);		
		
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
		public override NDMSInvestigation.Entities.AspnetWebEventEvents Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetWebEventEventsKey key, int start, int pageLength)
		{
			return GetByEventId(transactionManager, key.EventId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_WebEvent___5FB337D6 index.
		/// </summary>
		/// <param name="_eventId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetWebEventEvents GetByEventId(System.String _eventId)
		{
			int count = -1;
			return GetByEventId(null,_eventId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_WebEvent___5FB337D6 index.
		/// </summary>
		/// <param name="_eventId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetWebEventEvents GetByEventId(System.String _eventId, int start, int pageLength)
		{
			int count = -1;
			return GetByEventId(null, _eventId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_WebEvent___5FB337D6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_eventId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetWebEventEvents GetByEventId(TransactionManager transactionManager, System.String _eventId)
		{
			int count = -1;
			return GetByEventId(transactionManager, _eventId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_WebEvent___5FB337D6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_eventId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetWebEventEvents GetByEventId(TransactionManager transactionManager, System.String _eventId, int start, int pageLength)
		{
			int count = -1;
			return GetByEventId(transactionManager, _eventId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_WebEvent___5FB337D6 index.
		/// </summary>
		/// <param name="_eventId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetWebEventEvents GetByEventId(System.String _eventId, int start, int pageLength, out int count)
		{
			return GetByEventId(null, _eventId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_WebEvent___5FB337D6 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_eventId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetWebEventEvents GetByEventId(TransactionManager transactionManager, System.String _eventId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetWebEventEvents&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetWebEventEvents&gt;"/></returns>
		public static TList<AspnetWebEventEvents> Fill(IDataReader reader, TList<AspnetWebEventEvents> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetWebEventEvents c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetWebEventEvents")
					.Append("|").Append((System.String)reader[((int)AspnetWebEventEventsColumn.EventId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetWebEventEvents>(
					key.ToString(), // EntityTrackingKey
					"AspnetWebEventEvents",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetWebEventEvents();
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
					c.EventId = (System.String)reader[((int)AspnetWebEventEventsColumn.EventId - 1)];
					c.OriginalEventId = c.EventId;
					c.EventTimeUtc = (System.DateTime)reader[((int)AspnetWebEventEventsColumn.EventTimeUtc - 1)];
					c.EventTime = (System.DateTime)reader[((int)AspnetWebEventEventsColumn.EventTime - 1)];
					c.EventType = (System.String)reader[((int)AspnetWebEventEventsColumn.EventType - 1)];
					c.EventSequence = (System.Decimal)reader[((int)AspnetWebEventEventsColumn.EventSequence - 1)];
					c.EventOccurrence = (System.Decimal)reader[((int)AspnetWebEventEventsColumn.EventOccurrence - 1)];
					c.EventCode = (System.Int32)reader[((int)AspnetWebEventEventsColumn.EventCode - 1)];
					c.EventDetailCode = (System.Int32)reader[((int)AspnetWebEventEventsColumn.EventDetailCode - 1)];
					c.Message = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.Message - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.Message - 1)];
					c.ApplicationPath = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.ApplicationPath - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.ApplicationPath - 1)];
					c.ApplicationVirtualPath = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.ApplicationVirtualPath - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.ApplicationVirtualPath - 1)];
					c.MachineName = (System.String)reader[((int)AspnetWebEventEventsColumn.MachineName - 1)];
					c.RequestUrl = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.RequestUrl - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.RequestUrl - 1)];
					c.ExceptionType = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.ExceptionType - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.ExceptionType - 1)];
					c.Details = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.Details - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.Details - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetWebEventEvents entity)
		{
			if (!reader.Read()) return;
			
			entity.EventId = (System.String)reader[((int)AspnetWebEventEventsColumn.EventId - 1)];
			entity.OriginalEventId = (System.String)reader["EventId"];
			entity.EventTimeUtc = (System.DateTime)reader[((int)AspnetWebEventEventsColumn.EventTimeUtc - 1)];
			entity.EventTime = (System.DateTime)reader[((int)AspnetWebEventEventsColumn.EventTime - 1)];
			entity.EventType = (System.String)reader[((int)AspnetWebEventEventsColumn.EventType - 1)];
			entity.EventSequence = (System.Decimal)reader[((int)AspnetWebEventEventsColumn.EventSequence - 1)];
			entity.EventOccurrence = (System.Decimal)reader[((int)AspnetWebEventEventsColumn.EventOccurrence - 1)];
			entity.EventCode = (System.Int32)reader[((int)AspnetWebEventEventsColumn.EventCode - 1)];
			entity.EventDetailCode = (System.Int32)reader[((int)AspnetWebEventEventsColumn.EventDetailCode - 1)];
			entity.Message = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.Message - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.Message - 1)];
			entity.ApplicationPath = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.ApplicationPath - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.ApplicationPath - 1)];
			entity.ApplicationVirtualPath = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.ApplicationVirtualPath - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.ApplicationVirtualPath - 1)];
			entity.MachineName = (System.String)reader[((int)AspnetWebEventEventsColumn.MachineName - 1)];
			entity.RequestUrl = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.RequestUrl - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.RequestUrl - 1)];
			entity.ExceptionType = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.ExceptionType - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.ExceptionType - 1)];
			entity.Details = (reader.IsDBNull(((int)AspnetWebEventEventsColumn.Details - 1)))?null:(System.String)reader[((int)AspnetWebEventEventsColumn.Details - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetWebEventEvents entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.EventId = (System.String)dataRow["EventId"];
			entity.OriginalEventId = (System.String)dataRow["EventId"];
			entity.EventTimeUtc = (System.DateTime)dataRow["EventTimeUtc"];
			entity.EventTime = (System.DateTime)dataRow["EventTime"];
			entity.EventType = (System.String)dataRow["EventType"];
			entity.EventSequence = (System.Decimal)dataRow["EventSequence"];
			entity.EventOccurrence = (System.Decimal)dataRow["EventOccurrence"];
			entity.EventCode = (System.Int32)dataRow["EventCode"];
			entity.EventDetailCode = (System.Int32)dataRow["EventDetailCode"];
			entity.Message = Convert.IsDBNull(dataRow["Message"]) ? null : (System.String)dataRow["Message"];
			entity.ApplicationPath = Convert.IsDBNull(dataRow["ApplicationPath"]) ? null : (System.String)dataRow["ApplicationPath"];
			entity.ApplicationVirtualPath = Convert.IsDBNull(dataRow["ApplicationVirtualPath"]) ? null : (System.String)dataRow["ApplicationVirtualPath"];
			entity.MachineName = (System.String)dataRow["MachineName"];
			entity.RequestUrl = Convert.IsDBNull(dataRow["RequestUrl"]) ? null : (System.String)dataRow["RequestUrl"];
			entity.ExceptionType = Convert.IsDBNull(dataRow["ExceptionType"]) ? null : (System.String)dataRow["ExceptionType"];
			entity.Details = Convert.IsDBNull(dataRow["Details"]) ? null : (System.String)dataRow["Details"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetWebEventEvents"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetWebEventEvents Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetWebEventEvents entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetWebEventEvents object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetWebEventEvents instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetWebEventEvents Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetWebEventEvents entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AspnetWebEventEventsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetWebEventEvents</c>
	///</summary>
	public enum AspnetWebEventEventsChildEntityTypes
	{
	}
	
	#endregion AspnetWebEventEventsChildEntityTypes
	
	#region AspnetWebEventEventsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetWebEventEventsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsFilterBuilder : SqlFilterBuilder<AspnetWebEventEventsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsFilterBuilder class.
		/// </summary>
		public AspnetWebEventEventsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetWebEventEventsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetWebEventEventsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetWebEventEventsFilterBuilder
	
	#region AspnetWebEventEventsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetWebEventEventsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsParameterBuilder : ParameterizedSqlFilterBuilder<AspnetWebEventEventsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsParameterBuilder class.
		/// </summary>
		public AspnetWebEventEventsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetWebEventEventsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetWebEventEventsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetWebEventEventsParameterBuilder
	
	#region AspnetWebEventEventsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetWebEventEventsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetWebEventEventsSortBuilder : SqlSortBuilder<AspnetWebEventEventsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsSqlSortBuilder class.
		/// </summary>
		public AspnetWebEventEventsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetWebEventEventsSortBuilder
	
} // end namespace
