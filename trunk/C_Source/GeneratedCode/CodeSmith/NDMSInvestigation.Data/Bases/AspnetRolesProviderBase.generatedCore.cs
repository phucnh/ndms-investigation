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
	/// This class is the base class for any <see cref="AspnetRolesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetRolesProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetRoles, NDMSInvestigation.Entities.AspnetRolesKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByUserIdFromAspnetUsersInRoles
		
		/// <summary>
		///		Gets aspnet_Roles objects from the datasource by UserId in the
		///		aspnet_UsersInRoles table. Table aspnet_Roles is related to table aspnet_Users
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of AspnetRoles objects.</returns>
		public TList<AspnetRoles> GetByUserIdFromAspnetUsersInRoles(System.Guid _userId)
		{
			int count = -1;
			return GetByUserIdFromAspnetUsersInRoles(null,_userId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.AspnetRoles objects from the datasource by UserId in the
		///		aspnet_UsersInRoles table. Table aspnet_Roles is related to table aspnet_Users
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AspnetRoles objects.</returns>
		public TList<AspnetRoles> GetByUserIdFromAspnetUsersInRoles(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromAspnetUsersInRoles(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AspnetRoles objects from the datasource by UserId in the
		///		aspnet_UsersInRoles table. Table aspnet_Roles is related to table aspnet_Users
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Roles objects.</returns>
		public TList<AspnetRoles> GetByUserIdFromAspnetUsersInRoles(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserIdFromAspnetUsersInRoles(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AspnetRoles objects from the datasource by UserId in the
		///		aspnet_UsersInRoles table. Table aspnet_Roles is related to table aspnet_Users
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Roles objects.</returns>
		public TList<AspnetRoles> GetByUserIdFromAspnetUsersInRoles(TransactionManager transactionManager, System.Guid _userId,int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdFromAspnetUsersInRoles(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AspnetRoles objects from the datasource by UserId in the
		///		aspnet_UsersInRoles table. Table aspnet_Roles is related to table aspnet_Users
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Roles objects.</returns>
		public TList<AspnetRoles> GetByUserIdFromAspnetUsersInRoles(System.Guid _userId,int start, int pageLength, out int count)
		{
			
			return GetByUserIdFromAspnetUsersInRoles(null, _userId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets aspnet_Roles objects from the datasource by UserId in the
		///		aspnet_UsersInRoles table. Table aspnet_Roles is related to table aspnet_Users
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AspnetRoles objects.</returns>
		public abstract TList<AspnetRoles> GetByUserIdFromAspnetUsersInRoles(TransactionManager transactionManager,System.Guid _userId, int start, int pageLength, out int count);
		
		#endregion GetByUserIdFromAspnetUsersInRoles
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetRolesKey key)
		{
			return Delete(transactionManager, key.RoleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_roleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _roleId)
		{
			return Delete(null, _roleId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _roleId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Ro__Appli__32E0915F key.
		///		FK__aspnet_Ro__Appli__32E0915F Description: 
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetRoles objects.</returns>
		public TList<AspnetRoles> GetByApplicationId(System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(_applicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Ro__Appli__32E0915F key.
		///		FK__aspnet_Ro__Appli__32E0915F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetRoles objects.</returns>
		/// <remarks></remarks>
		public TList<AspnetRoles> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Ro__Appli__32E0915F key.
		///		FK__aspnet_Ro__Appli__32E0915F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetRoles objects.</returns>
		public TList<AspnetRoles> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Ro__Appli__32E0915F key.
		///		fkAspnetRoAppli32e0915f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetRoles objects.</returns>
		public TList<AspnetRoles> GetByApplicationId(System.Guid _applicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByApplicationId(null, _applicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Ro__Appli__32E0915F key.
		///		fkAspnetRoAppli32e0915f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetRoles objects.</returns>
		public TList<AspnetRoles> GetByApplicationId(System.Guid _applicationId, int start, int pageLength,out int count)
		{
			return GetByApplicationId(null, _applicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Ro__Appli__32E0915F key.
		///		FK__aspnet_Ro__Appli__32E0915F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetRoles objects.</returns>
		public abstract TList<AspnetRoles> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.AspnetRoles Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetRolesKey key, int start, int pageLength)
		{
			return GetByRoleId(transactionManager, key.RoleId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_Roles_index1 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredRoleName"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByApplicationIdLoweredRoleName(System.Guid _applicationId, System.String _loweredRoleName)
		{
			int count = -1;
			return GetByApplicationIdLoweredRoleName(null,_applicationId, _loweredRoleName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Roles_index1 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredRoleName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByApplicationIdLoweredRoleName(System.Guid _applicationId, System.String _loweredRoleName, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredRoleName(null, _applicationId, _loweredRoleName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Roles_index1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredRoleName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByApplicationIdLoweredRoleName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredRoleName)
		{
			int count = -1;
			return GetByApplicationIdLoweredRoleName(transactionManager, _applicationId, _loweredRoleName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Roles_index1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredRoleName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByApplicationIdLoweredRoleName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredRoleName, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredRoleName(transactionManager, _applicationId, _loweredRoleName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Roles_index1 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredRoleName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByApplicationIdLoweredRoleName(System.Guid _applicationId, System.String _loweredRoleName, int start, int pageLength, out int count)
		{
			return GetByApplicationIdLoweredRoleName(null, _applicationId, _loweredRoleName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Roles_index1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredRoleName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetRoles GetByApplicationIdLoweredRoleName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredRoleName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Roles__31EC6D26 index.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByRoleId(System.Guid _roleId)
		{
			int count = -1;
			return GetByRoleId(null,_roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Roles__31EC6D26 index.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByRoleId(System.Guid _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(null, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Roles__31EC6D26 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByRoleId(TransactionManager transactionManager, System.Guid _roleId)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Roles__31EC6D26 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByRoleId(TransactionManager transactionManager, System.Guid _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleId(transactionManager, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Roles__31EC6D26 index.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetRoles GetByRoleId(System.Guid _roleId, int start, int pageLength, out int count)
		{
			return GetByRoleId(null, _roleId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Roles__31EC6D26 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetRoles GetByRoleId(TransactionManager transactionManager, System.Guid _roleId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetRoles&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetRoles&gt;"/></returns>
		public static TList<AspnetRoles> Fill(IDataReader reader, TList<AspnetRoles> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetRoles c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetRoles")
					.Append("|").Append((System.Guid)reader[((int)AspnetRolesColumn.RoleId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetRoles>(
					key.ToString(), // EntityTrackingKey
					"AspnetRoles",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetRoles();
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
					c.ApplicationId = (System.Guid)reader[((int)AspnetRolesColumn.ApplicationId - 1)];
					c.RoleId = (System.Guid)reader[((int)AspnetRolesColumn.RoleId - 1)];
					c.RoleName = (System.String)reader[((int)AspnetRolesColumn.RoleName - 1)];
					c.LoweredRoleName = (System.String)reader[((int)AspnetRolesColumn.LoweredRoleName - 1)];
					c.Description = (reader.IsDBNull(((int)AspnetRolesColumn.Description - 1)))?null:(System.String)reader[((int)AspnetRolesColumn.Description - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetRoles"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetRoles entity)
		{
			if (!reader.Read()) return;
			
			entity.ApplicationId = (System.Guid)reader[((int)AspnetRolesColumn.ApplicationId - 1)];
			entity.RoleId = (System.Guid)reader[((int)AspnetRolesColumn.RoleId - 1)];
			entity.RoleName = (System.String)reader[((int)AspnetRolesColumn.RoleName - 1)];
			entity.LoweredRoleName = (System.String)reader[((int)AspnetRolesColumn.LoweredRoleName - 1)];
			entity.Description = (reader.IsDBNull(((int)AspnetRolesColumn.Description - 1)))?null:(System.String)reader[((int)AspnetRolesColumn.Description - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetRoles"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetRoles"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetRoles entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ApplicationId = (System.Guid)dataRow["ApplicationId"];
			entity.RoleId = (System.Guid)dataRow["RoleId"];
			entity.RoleName = (System.String)dataRow["RoleName"];
			entity.LoweredRoleName = (System.String)dataRow["LoweredRoleName"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetRoles"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetRoles Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetRoles entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			// Deep load child collections  - Call GetByRoleId methods when available
			
			#region AspnetUsersInRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetUsersInRoles>|AspnetUsersInRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetUsersInRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetUsersInRolesCollection = DataRepository.AspnetUsersInRolesProvider.GetByRoleId(transactionManager, entity.RoleId);

				if (deep && entity.AspnetUsersInRolesCollection.Count > 0)
				{
					deepHandles.Add("AspnetUsersInRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetUsersInRoles>) DataRepository.AspnetUsersInRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetUsersInRolesCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region UserIdAspnetUsersCollection_From_AspnetUsersInRoles
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AspnetUsers>|UserIdAspnetUsersCollection_From_AspnetUsersInRoles", deepLoadType, innerList))
			{
				entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles = DataRepository.AspnetUsersProvider.GetByRoleIdFromAspnetUsersInRoles(transactionManager, entity.RoleId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserIdAspnetUsersCollection_From_AspnetUsersInRoles' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles != null)
				{
					deepHandles.Add("UserIdAspnetUsersCollection_From_AspnetUsersInRoles",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AspnetUsers >) DataRepository.AspnetUsersProvider.DeepLoad,
						new object[] { transactionManager, entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetRoles object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetRoles instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetRoles Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetRoles entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region UserIdAspnetUsersCollection_From_AspnetUsersInRoles>
			if (CanDeepSave(entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles, "List<AspnetUsers>|UserIdAspnetUsersCollection_From_AspnetUsersInRoles", deepSaveType, innerList))
			{
				if (entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles.Count > 0 || entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles.DeletedItems.Count > 0)
				{
					DataRepository.AspnetUsersProvider.Save(transactionManager, entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles); 
					deepHandles.Add("UserIdAspnetUsersCollection_From_AspnetUsersInRoles",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<AspnetUsers>) DataRepository.AspnetUsersProvider.DeepSave,
						new object[] { transactionManager, entity.UserIdAspnetUsersCollection_From_AspnetUsersInRoles, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<AspnetUsersInRoles>
				if (CanDeepSave(entity.AspnetUsersInRolesCollection, "List<AspnetUsersInRoles>|AspnetUsersInRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetUsersInRoles child in entity.AspnetUsersInRolesCollection)
					{
						if(child.RoleIdSource != null)
						{
								child.RoleId = child.RoleIdSource.RoleId;
						}

						if(child.UserIdSource != null)
						{
								child.UserId = child.UserIdSource.UserId;
						}

					}

					if (entity.AspnetUsersInRolesCollection.Count > 0 || entity.AspnetUsersInRolesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.AspnetUsersInRolesProvider.Save(transactionManager, entity.AspnetUsersInRolesCollection);
						
						deepHandles.Add("AspnetUsersInRolesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< AspnetUsersInRoles >) DataRepository.AspnetUsersInRolesProvider.DeepSave,
							new object[] { transactionManager, entity.AspnetUsersInRolesCollection, deepSaveType, childTypes, innerList }
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
	
	#region AspnetRolesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetRoles</c>
	///</summary>
	public enum AspnetRolesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetApplications</c> at ApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetApplications))]
		AspnetApplications,
	
		///<summary>
		/// Collection of <c>AspnetRoles</c> as OneToMany for AspnetUsersInRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetUsersInRoles>))]
		AspnetUsersInRolesCollection,

		///<summary>
		/// Collection of <c>AspnetRoles</c> as ManyToMany for AspnetUsersCollection_From_AspnetUsersInRoles
		///</summary>
		[ChildEntityType(typeof(TList<AspnetUsers>))]
		UserIdAspnetUsersCollection_From_AspnetUsersInRoles,
	}
	
	#endregion AspnetRolesChildEntityTypes
	
	#region AspnetRolesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesFilterBuilder : SqlFilterBuilder<AspnetRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesFilterBuilder class.
		/// </summary>
		public AspnetRolesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetRolesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetRolesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetRolesFilterBuilder
	
	#region AspnetRolesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesParameterBuilder : ParameterizedSqlFilterBuilder<AspnetRolesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesParameterBuilder class.
		/// </summary>
		public AspnetRolesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetRolesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetRolesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetRolesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetRolesParameterBuilder
	
	#region AspnetRolesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetRolesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetRolesSortBuilder : SqlSortBuilder<AspnetRolesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesSqlSortBuilder class.
		/// </summary>
		public AspnetRolesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetRolesSortBuilder
	
} // end namespace
