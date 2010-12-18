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
	/// This class is the base class for any <see cref="UserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UserProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.User, NDMSInvestigation.Entities.UserKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.UserKey key)
		{
			return Delete(transactionManager, key.UserId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _userId)
		{
			return Delete(null, _userId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _userId);		
		
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
		public override NDMSInvestigation.Entities.User Get(TransactionManager transactionManager, NDMSInvestigation.Entities.UserKey key, int start, int pageLength)
		{
			return GetByUserId(transactionManager, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_User index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.User"/> class.</returns>
		public NDMSInvestigation.Entities.User GetByUserId(System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.User"/> class.</returns>
		public NDMSInvestigation.Entities.User GetByUserId(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.User"/> class.</returns>
		public NDMSInvestigation.Entities.User GetByUserId(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.User"/> class.</returns>
		public NDMSInvestigation.Entities.User GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.User"/> class.</returns>
		public NDMSInvestigation.Entities.User GetByUserId(System.Guid _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_User index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.User"/> class.</returns>
		public abstract NDMSInvestigation.Entities.User GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;User&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;User&gt;"/></returns>
		public static TList<User> Fill(IDataReader reader, TList<User> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.User c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("User")
					.Append("|").Append((System.Guid)reader[((int)UserColumn.UserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<User>(
					key.ToString(), // EntityTrackingKey
					"User",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.User();
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
					c.UserId = (System.Guid)reader[((int)UserColumn.UserId - 1)];
					c.OriginalUserId = c.UserId;
					c.CompanyName = (reader.IsDBNull(((int)UserColumn.CompanyName - 1)))?null:(System.String)reader[((int)UserColumn.CompanyName - 1)];
					c.Phone = (reader.IsDBNull(((int)UserColumn.Phone - 1)))?null:(System.String)reader[((int)UserColumn.Phone - 1)];
					c.Fax = (reader.IsDBNull(((int)UserColumn.Fax - 1)))?null:(System.String)reader[((int)UserColumn.Fax - 1)];
					c.Email = (reader.IsDBNull(((int)UserColumn.Email - 1)))?null:(System.String)reader[((int)UserColumn.Email - 1)];
					c.Address = (reader.IsDBNull(((int)UserColumn.Address - 1)))?null:(System.String)reader[((int)UserColumn.Address - 1)];
					c.EmployeeNumber = (reader.IsDBNull(((int)UserColumn.EmployeeNumber - 1)))?null:(System.Int32?)reader[((int)UserColumn.EmployeeNumber - 1)];
					c.Director = (reader.IsDBNull(((int)UserColumn.Director - 1)))?null:(System.String)reader[((int)UserColumn.Director - 1)];
					c.Country = (reader.IsDBNull(((int)UserColumn.Country - 1)))?null:(System.String)reader[((int)UserColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)UserColumn.City - 1)))?null:(System.String)reader[((int)UserColumn.City - 1)];
					c.District = (reader.IsDBNull(((int)UserColumn.District - 1)))?null:(System.String)reader[((int)UserColumn.District - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.User"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.User"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.User entity)
		{
			if (!reader.Read()) return;
			
			entity.UserId = (System.Guid)reader[((int)UserColumn.UserId - 1)];
			entity.OriginalUserId = (System.Guid)reader["UserId"];
			entity.CompanyName = (reader.IsDBNull(((int)UserColumn.CompanyName - 1)))?null:(System.String)reader[((int)UserColumn.CompanyName - 1)];
			entity.Phone = (reader.IsDBNull(((int)UserColumn.Phone - 1)))?null:(System.String)reader[((int)UserColumn.Phone - 1)];
			entity.Fax = (reader.IsDBNull(((int)UserColumn.Fax - 1)))?null:(System.String)reader[((int)UserColumn.Fax - 1)];
			entity.Email = (reader.IsDBNull(((int)UserColumn.Email - 1)))?null:(System.String)reader[((int)UserColumn.Email - 1)];
			entity.Address = (reader.IsDBNull(((int)UserColumn.Address - 1)))?null:(System.String)reader[((int)UserColumn.Address - 1)];
			entity.EmployeeNumber = (reader.IsDBNull(((int)UserColumn.EmployeeNumber - 1)))?null:(System.Int32?)reader[((int)UserColumn.EmployeeNumber - 1)];
			entity.Director = (reader.IsDBNull(((int)UserColumn.Director - 1)))?null:(System.String)reader[((int)UserColumn.Director - 1)];
			entity.Country = (reader.IsDBNull(((int)UserColumn.Country - 1)))?null:(System.String)reader[((int)UserColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)UserColumn.City - 1)))?null:(System.String)reader[((int)UserColumn.City - 1)];
			entity.District = (reader.IsDBNull(((int)UserColumn.District - 1)))?null:(System.String)reader[((int)UserColumn.District - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.User"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.User"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.User entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserId = (System.Guid)dataRow["UserId"];
			entity.OriginalUserId = (System.Guid)dataRow["UserId"];
			entity.CompanyName = Convert.IsDBNull(dataRow["CompanyName"]) ? null : (System.String)dataRow["CompanyName"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.String)dataRow["Phone"];
			entity.Fax = Convert.IsDBNull(dataRow["Fax"]) ? null : (System.String)dataRow["Fax"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.EmployeeNumber = Convert.IsDBNull(dataRow["EmployeeNumber"]) ? null : (System.Int32?)dataRow["EmployeeNumber"];
			entity.Director = Convert.IsDBNull(dataRow["Director"]) ? null : (System.String)dataRow["Director"];
			entity.Country = Convert.IsDBNull(dataRow["Country"]) ? null : (System.String)dataRow["Country"];
			entity.City = Convert.IsDBNull(dataRow["City"]) ? null : (System.String)dataRow["City"];
			entity.District = Convert.IsDBNull(dataRow["District"]) ? null : (System.String)dataRow["District"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.User"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.User Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.User entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.User object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.User instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.User Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.User entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region UserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.User</c>
	///</summary>
	public enum UserChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetUsers</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetUsers))]
		AspnetUsers,
		}
	
	#endregion UserChildEntityTypes
	
	#region UserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserFilterBuilder : SqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		public UserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserFilterBuilder
	
	#region UserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserParameterBuilder : ParameterizedSqlFilterBuilder<UserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		public UserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserParameterBuilder
	
	#region UserSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;UserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="User"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class UserSortBuilder : SqlSortBuilder<UserColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserSqlSortBuilder class.
		/// </summary>
		public UserSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion UserSortBuilder
	
} // end namespace
