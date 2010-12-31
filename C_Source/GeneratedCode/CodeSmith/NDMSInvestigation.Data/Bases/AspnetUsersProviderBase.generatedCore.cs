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
	/// This class is the base class for any <see cref="AspnetUsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetUsersProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetUsers, NDMSInvestigation.Entities.AspnetUsersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetByRoleIdFromAspnetUsersInRoles
		
		/// <summary>
		///		Gets aspnet_Users objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <returns>Returns a typed collection of AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(System.Guid _roleId)
		{
			int count = -1;
			return GetByRoleIdFromAspnetUsersInRoles(null,_roleId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.AspnetUsers objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(System.Guid _roleId, int start, int pageLength)
		{
			int count = -1;
			return GetByRoleIdFromAspnetUsersInRoles(null, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AspnetUsers objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(TransactionManager transactionManager, System.Guid _roleId)
		{
			int count = -1;
			return GetByRoleIdFromAspnetUsersInRoles(transactionManager, _roleId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AspnetUsers objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(TransactionManager transactionManager, System.Guid _roleId,int start, int pageLength)
		{
			int count = -1;
			return GetByRoleIdFromAspnetUsersInRoles(transactionManager, _roleId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AspnetUsers objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="_roleId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(System.Guid _roleId,int start, int pageLength, out int count)
		{
			
			return GetByRoleIdFromAspnetUsersInRoles(null, _roleId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets aspnet_Users objects from the datasource by RoleId in the
		///		aspnet_UsersInRoles table. Table aspnet_Users is related to table aspnet_Roles
		///		through the (M:N) relationship defined in the aspnet_UsersInRoles table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_roleId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AspnetUsers objects.</returns>
		public abstract TList<AspnetUsers> GetByRoleIdFromAspnetUsersInRoles(TransactionManager transactionManager,System.Guid _roleId, int start, int pageLength, out int count);
		
		#endregion GetByRoleIdFromAspnetUsersInRoles
		
		#region GetByGroupIdFromResults
		
		/// <summary>
		///		Gets aspnet_Users objects from the datasource by GroupId in the
		///		Results table. Table aspnet_Users is related to table QuestionGroups
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <returns>Returns a typed collection of AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByGroupIdFromResults(System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupIdFromResults(null,_groupId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets NDMSInvestigation.Entities.AspnetUsers objects from the datasource by GroupId in the
		///		Results table. Table aspnet_Users is related to table QuestionGroups
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByGroupIdFromResults(System.Int32 _groupId, int start, int pageLength)
		{
			int count = -1;
			return GetByGroupIdFromResults(null, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AspnetUsers objects from the datasource by GroupId in the
		///		Results table. Table aspnet_Users is related to table QuestionGroups
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public TList<AspnetUsers> GetByGroupIdFromResults(TransactionManager transactionManager, System.Int32 _groupId)
		{
			int count = -1;
			return GetByGroupIdFromResults(transactionManager, _groupId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets AspnetUsers objects from the datasource by GroupId in the
		///		Results table. Table aspnet_Users is related to table QuestionGroups
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public TList<AspnetUsers> GetByGroupIdFromResults(TransactionManager transactionManager, System.Int32 _groupId,int start, int pageLength)
		{
			int count = -1;
			return GetByGroupIdFromResults(transactionManager, _groupId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets AspnetUsers objects from the datasource by GroupId in the
		///		Results table. Table aspnet_Users is related to table QuestionGroups
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="_groupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of aspnet_Users objects.</returns>
		public TList<AspnetUsers> GetByGroupIdFromResults(System.Int32 _groupId,int start, int pageLength, out int count)
		{
			
			return GetByGroupIdFromResults(null, _groupId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets aspnet_Users objects from the datasource by GroupId in the
		///		Results table. Table aspnet_Users is related to table QuestionGroups
		///		through the (M:N) relationship defined in the Results table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_groupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of AspnetUsers objects.</returns>
		public abstract TList<AspnetUsers> GetByGroupIdFromResults(TransactionManager transactionManager,System.Int32 _groupId, int start, int pageLength, out int count);
		
		#endregion GetByGroupIdFromResults
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetUsersKey key)
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
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		FK__aspnet_Us__Appli__0425A276 Description: 
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByApplicationId(System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(_applicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		FK__aspnet_Us__Appli__0425A276 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		/// <remarks></remarks>
		public TList<AspnetUsers> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		FK__aspnet_Us__Appli__0425A276 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		fkAspnetUsAppli0425a276 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByApplicationId(System.Guid _applicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByApplicationId(null, _applicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		fkAspnetUsAppli0425a276 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public TList<AspnetUsers> GetByApplicationId(System.Guid _applicationId, int start, int pageLength,out int count)
		{
			return GetByApplicationId(null, _applicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Us__Appli__0425A276 key.
		///		FK__aspnet_Us__Appli__0425A276 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetUsers objects.</returns>
		public abstract TList<AspnetUsers> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.AspnetUsers Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetUsersKey key, int start, int pageLength)
		{
			return GetByUserId(transactionManager, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_Users_Index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(System.Guid _applicationId, System.String _loweredUserName)
		{
			int count = -1;
			return GetByApplicationIdLoweredUserName(null,_applicationId, _loweredUserName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(System.Guid _applicationId, System.String _loweredUserName, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredUserName(null, _applicationId, _loweredUserName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredUserName)
		{
			int count = -1;
			return GetByApplicationIdLoweredUserName(transactionManager, _applicationId, _loweredUserName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredUserName, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredUserName(transactionManager, _applicationId, _loweredUserName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(System.Guid _applicationId, System.String _loweredUserName, int start, int pageLength, out int count)
		{
			return GetByApplicationIdLoweredUserName(null, _applicationId, _loweredUserName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredUserName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetUsers GetByApplicationIdLoweredUserName(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredUserName, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetUsers&gt;"/> class.</returns>
		public TList<AspnetUsers> GetByApplicationIdLastActivityDate(System.Guid _applicationId, System.DateTime _lastActivityDate)
		{
			int count = -1;
			return GetByApplicationIdLastActivityDate(null,_applicationId, _lastActivityDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetUsers&gt;"/> class.</returns>
		public TList<AspnetUsers> GetByApplicationIdLastActivityDate(System.Guid _applicationId, System.DateTime _lastActivityDate, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLastActivityDate(null, _applicationId, _lastActivityDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetUsers&gt;"/> class.</returns>
		public TList<AspnetUsers> GetByApplicationIdLastActivityDate(TransactionManager transactionManager, System.Guid _applicationId, System.DateTime _lastActivityDate)
		{
			int count = -1;
			return GetByApplicationIdLastActivityDate(transactionManager, _applicationId, _lastActivityDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetUsers&gt;"/> class.</returns>
		public TList<AspnetUsers> GetByApplicationIdLastActivityDate(TransactionManager transactionManager, System.Guid _applicationId, System.DateTime _lastActivityDate, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLastActivityDate(transactionManager, _applicationId, _lastActivityDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetUsers&gt;"/> class.</returns>
		public TList<AspnetUsers> GetByApplicationIdLastActivityDate(System.Guid _applicationId, System.DateTime _lastActivityDate, int start, int pageLength, out int count)
		{
			return GetByApplicationIdLastActivityDate(null, _applicationId, _lastActivityDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Users_Index2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_lastActivityDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetUsers&gt;"/> class.</returns>
		public abstract TList<AspnetUsers> GetByApplicationIdLastActivityDate(TransactionManager transactionManager, System.Guid _applicationId, System.DateTime _lastActivityDate, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByUserId(System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByUserId(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByUserId(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetUsers GetByUserId(System.Guid _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Users__03317E3D index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetUsers GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetUsers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetUsers&gt;"/></returns>
		public static TList<AspnetUsers> Fill(IDataReader reader, TList<AspnetUsers> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetUsers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetUsers")
					.Append("|").Append((System.Guid)reader[((int)AspnetUsersColumn.UserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetUsers>(
					key.ToString(), // EntityTrackingKey
					"AspnetUsers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetUsers();
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
					c.ApplicationId = (System.Guid)reader[((int)AspnetUsersColumn.ApplicationId - 1)];
					c.UserId = (System.Guid)reader[((int)AspnetUsersColumn.UserId - 1)];
					c.OriginalUserId = c.UserId;
					c.UserName = (System.String)reader[((int)AspnetUsersColumn.UserName - 1)];
					c.LoweredUserName = (System.String)reader[((int)AspnetUsersColumn.LoweredUserName - 1)];
					c.MobileAlias = (reader.IsDBNull(((int)AspnetUsersColumn.MobileAlias - 1)))?null:(System.String)reader[((int)AspnetUsersColumn.MobileAlias - 1)];
					c.IsAnonymous = (System.Boolean)reader[((int)AspnetUsersColumn.IsAnonymous - 1)];
					c.LastActivityDate = (System.DateTime)reader[((int)AspnetUsersColumn.LastActivityDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetUsers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetUsers entity)
		{
			if (!reader.Read()) return;
			
			entity.ApplicationId = (System.Guid)reader[((int)AspnetUsersColumn.ApplicationId - 1)];
			entity.UserId = (System.Guid)reader[((int)AspnetUsersColumn.UserId - 1)];
			entity.OriginalUserId = (System.Guid)reader["UserId"];
			entity.UserName = (System.String)reader[((int)AspnetUsersColumn.UserName - 1)];
			entity.LoweredUserName = (System.String)reader[((int)AspnetUsersColumn.LoweredUserName - 1)];
			entity.MobileAlias = (reader.IsDBNull(((int)AspnetUsersColumn.MobileAlias - 1)))?null:(System.String)reader[((int)AspnetUsersColumn.MobileAlias - 1)];
			entity.IsAnonymous = (System.Boolean)reader[((int)AspnetUsersColumn.IsAnonymous - 1)];
			entity.LastActivityDate = (System.DateTime)reader[((int)AspnetUsersColumn.LastActivityDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetUsers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetUsers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetUsers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ApplicationId = (System.Guid)dataRow["ApplicationId"];
			entity.UserId = (System.Guid)dataRow["UserId"];
			entity.OriginalUserId = (System.Guid)dataRow["UserId"];
			entity.UserName = (System.String)dataRow["UserName"];
			entity.LoweredUserName = (System.String)dataRow["LoweredUserName"];
			entity.MobileAlias = Convert.IsDBNull(dataRow["MobileAlias"]) ? null : (System.String)dataRow["MobileAlias"];
			entity.IsAnonymous = (System.Boolean)dataRow["IsAnonymous"];
			entity.LastActivityDate = (System.DateTime)dataRow["LastActivityDate"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetUsers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetUsers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetUsers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
			// Deep load child collections  - Call GetByUserId methods when available
			
			#region AspnetMembership
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "AspnetMembership|AspnetMembership", deepLoadType, innerList))
			{
				entity.AspnetMembership = DataRepository.AspnetMembershipProvider.GetByUserId(transactionManager, entity.UserId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetMembership' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.AspnetMembership != null)
				{
					deepHandles.Add("AspnetMembership",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< AspnetMembership >) DataRepository.AspnetMembershipProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetMembership, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region AspnetProfile
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "AspnetProfile|AspnetProfile", deepLoadType, innerList))
			{
				entity.AspnetProfile = DataRepository.AspnetProfileProvider.GetByUserId(transactionManager, entity.UserId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetProfile' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.AspnetProfile != null)
				{
					deepHandles.Add("AspnetProfile",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< AspnetProfile >) DataRepository.AspnetProfileProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetProfile, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region GroupIdQuestionGroupsCollection_From_Results
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<QuestionGroups>|GroupIdQuestionGroupsCollection_From_Results", deepLoadType, innerList))
			{
				entity.GroupIdQuestionGroupsCollection_From_Results = DataRepository.QuestionGroupsProvider.GetByUserIdFromResults(transactionManager, entity.UserId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GroupIdQuestionGroupsCollection_From_Results' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GroupIdQuestionGroupsCollection_From_Results != null)
				{
					deepHandles.Add("GroupIdQuestionGroupsCollection_From_Results",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< QuestionGroups >) DataRepository.QuestionGroupsProvider.DeepLoad,
						new object[] { transactionManager, entity.GroupIdQuestionGroupsCollection_From_Results, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			#region AspnetPersonalizationPerUserCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetPersonalizationPerUser>|AspnetPersonalizationPerUserCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetPersonalizationPerUserCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetPersonalizationPerUserCollection = DataRepository.AspnetPersonalizationPerUserProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.AspnetPersonalizationPerUserCollection.Count > 0)
				{
					deepHandles.Add("AspnetPersonalizationPerUserCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetPersonalizationPerUser>) DataRepository.AspnetPersonalizationPerUserProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetPersonalizationPerUserCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region AspnetUsersInRolesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<AspnetUsersInRoles>|AspnetUsersInRolesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'AspnetUsersInRolesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.AspnetUsersInRolesCollection = DataRepository.AspnetUsersInRolesProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.AspnetUsersInRolesCollection.Count > 0)
				{
					deepHandles.Add("AspnetUsersInRolesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<AspnetUsersInRoles>) DataRepository.AspnetUsersInRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.AspnetUsersInRolesCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.ResultsCollection = DataRepository.ResultsProvider.GetByUserId(transactionManager, entity.UserId);

				if (deep && entity.ResultsCollection.Count > 0)
				{
					deepHandles.Add("ResultsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Results>) DataRepository.ResultsProvider.DeepLoad,
						new object[] { transactionManager, entity.ResultsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CompanyDetails
			// RelationshipType.OneToOne
			if (CanDeepLoad(entity, "CompanyDetails|CompanyDetails", deepLoadType, innerList))
			{
				entity.CompanyDetails = DataRepository.CompanyDetailsProvider.GetByUserId(transactionManager, entity.UserId);
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyDetails' loaded. key " + entity.EntityTrackingKey);
				#endif 

				if (deep && entity.CompanyDetails != null)
				{
					deepHandles.Add("CompanyDetails",
						new KeyValuePair<Delegate, object>((DeepLoadSingleHandle< CompanyDetails >) DataRepository.CompanyDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.CompanyDetails, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion 
			
			
			
			#region RoleIdAspnetRolesCollection_From_AspnetUsersInRoles
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<AspnetRoles>|RoleIdAspnetRolesCollection_From_AspnetUsersInRoles", deepLoadType, innerList))
			{
				entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles = DataRepository.AspnetRolesProvider.GetByUserIdFromAspnetUsersInRoles(transactionManager, entity.UserId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'RoleIdAspnetRolesCollection_From_AspnetUsersInRoles' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles != null)
				{
					deepHandles.Add("RoleIdAspnetRolesCollection_From_AspnetUsersInRoles",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< AspnetRoles >) DataRepository.AspnetRolesProvider.DeepLoad,
						new object[] { transactionManager, entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetUsers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetUsers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetUsers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetUsers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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

			#region AspnetMembership
			if (CanDeepSave(entity.AspnetMembership, "AspnetMembership|AspnetMembership", deepSaveType, innerList))
			{

				if (entity.AspnetMembership != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.AspnetMembership.UserId = entity.UserId;
					//DataRepository.AspnetMembershipProvider.Save(transactionManager, entity.AspnetMembership);
					deepHandles.Add("AspnetMembership",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< AspnetMembership >) DataRepository.AspnetMembershipProvider.DeepSave,
						new object[] { transactionManager, entity.AspnetMembership, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region AspnetProfile
			if (CanDeepSave(entity.AspnetProfile, "AspnetProfile|AspnetProfile", deepSaveType, innerList))
			{

				if (entity.AspnetProfile != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.AspnetProfile.UserId = entity.UserId;
					//DataRepository.AspnetProfileProvider.Save(transactionManager, entity.AspnetProfile);
					deepHandles.Add("AspnetProfile",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< AspnetProfile >) DataRepository.AspnetProfileProvider.DeepSave,
						new object[] { transactionManager, entity.AspnetProfile, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region CompanyDetails
			if (CanDeepSave(entity.CompanyDetails, "CompanyDetails|CompanyDetails", deepSaveType, innerList))
			{

				if (entity.CompanyDetails != null)
				{
					// update each child parent id with the real parent id (mostly used on insert)

					entity.CompanyDetails.UserId = entity.UserId;
					//DataRepository.CompanyDetailsProvider.Save(transactionManager, entity.CompanyDetails);
					deepHandles.Add("CompanyDetails",
						new KeyValuePair<Delegate, object>((DeepSaveSingleHandle< CompanyDetails >) DataRepository.CompanyDetailsProvider.DeepSave,
						new object[] { transactionManager, entity.CompanyDetails, deepSaveType, childTypes, innerList }
					));
				}
			} 
			#endregion 

			#region GroupIdQuestionGroupsCollection_From_Results>
			if (CanDeepSave(entity.GroupIdQuestionGroupsCollection_From_Results, "List<QuestionGroups>|GroupIdQuestionGroupsCollection_From_Results", deepSaveType, innerList))
			{
				if (entity.GroupIdQuestionGroupsCollection_From_Results.Count > 0 || entity.GroupIdQuestionGroupsCollection_From_Results.DeletedItems.Count > 0)
				{
					DataRepository.QuestionGroupsProvider.Save(transactionManager, entity.GroupIdQuestionGroupsCollection_From_Results); 
					deepHandles.Add("GroupIdQuestionGroupsCollection_From_Results",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<QuestionGroups>) DataRepository.QuestionGroupsProvider.DeepSave,
						new object[] { transactionManager, entity.GroupIdQuestionGroupsCollection_From_Results, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 

			#region RoleIdAspnetRolesCollection_From_AspnetUsersInRoles>
			if (CanDeepSave(entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles, "List<AspnetRoles>|RoleIdAspnetRolesCollection_From_AspnetUsersInRoles", deepSaveType, innerList))
			{
				if (entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles.Count > 0 || entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles.DeletedItems.Count > 0)
				{
					DataRepository.AspnetRolesProvider.Save(transactionManager, entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles); 
					deepHandles.Add("RoleIdAspnetRolesCollection_From_AspnetUsersInRoles",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<AspnetRoles>) DataRepository.AspnetRolesProvider.DeepSave,
						new object[] { transactionManager, entity.RoleIdAspnetRolesCollection_From_AspnetUsersInRoles, deepSaveType, childTypes, innerList }
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
						if(child.UserIdSource != null)
						{
							child.UserId = child.UserIdSource.UserId;
						}
						else
						{
							child.UserId = entity.UserId;
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
				
	
			#region List<AspnetUsersInRoles>
				if (CanDeepSave(entity.AspnetUsersInRolesCollection, "List<AspnetUsersInRoles>|AspnetUsersInRolesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(AspnetUsersInRoles child in entity.AspnetUsersInRolesCollection)
					{
						if(child.UserIdSource != null)
						{
								child.UserId = child.UserIdSource.UserId;
						}

						if(child.RoleIdSource != null)
						{
								child.RoleId = child.RoleIdSource.RoleId;
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
				
	
			#region List<Results>
				if (CanDeepSave(entity.ResultsCollection, "List<Results>|ResultsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Results child in entity.ResultsCollection)
					{
						if(child.UserIdSource != null)
						{
								child.UserId = child.UserIdSource.UserId;
						}

						if(child.GroupIdSource != null)
						{
								child.GroupId = child.GroupIdSource.GroupId;
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
	
	#region AspnetUsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetUsers</c>
	///</summary>
	public enum AspnetUsersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetApplications</c> at ApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetApplications))]
		AspnetApplications,
			///<summary>
		/// Entity <c>AspnetMembership</c> as OneToOne for AspnetMembership
		///</summary>
		[ChildEntityType(typeof(AspnetMembership))]
		AspnetMembership,
		///<summary>
		/// Entity <c>AspnetProfile</c> as OneToOne for AspnetProfile
		///</summary>
		[ChildEntityType(typeof(AspnetProfile))]
		AspnetProfile,

		///<summary>
		/// Collection of <c>AspnetUsers</c> as ManyToMany for QuestionGroupsCollection_From_Results
		///</summary>
		[ChildEntityType(typeof(TList<QuestionGroups>))]
		GroupIdQuestionGroupsCollection_From_Results,

		///<summary>
		/// Collection of <c>AspnetUsers</c> as OneToMany for AspnetPersonalizationPerUserCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetPersonalizationPerUser>))]
		AspnetPersonalizationPerUserCollection,

		///<summary>
		/// Collection of <c>AspnetUsers</c> as OneToMany for AspnetUsersInRolesCollection
		///</summary>
		[ChildEntityType(typeof(TList<AspnetUsersInRoles>))]
		AspnetUsersInRolesCollection,

		///<summary>
		/// Collection of <c>AspnetUsers</c> as OneToMany for ResultsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Results>))]
		ResultsCollection,
		///<summary>
		/// Entity <c>CompanyDetails</c> as OneToOne for CompanyDetails
		///</summary>
		[ChildEntityType(typeof(CompanyDetails))]
		CompanyDetails,

		///<summary>
		/// Collection of <c>AspnetUsers</c> as ManyToMany for AspnetRolesCollection_From_AspnetUsersInRoles
		///</summary>
		[ChildEntityType(typeof(TList<AspnetRoles>))]
		RoleIdAspnetRolesCollection_From_AspnetUsersInRoles,
	}
	
	#endregion AspnetUsersChildEntityTypes
	
	#region AspnetUsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersFilterBuilder : SqlFilterBuilder<AspnetUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersFilterBuilder class.
		/// </summary>
		public AspnetUsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetUsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetUsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetUsersFilterBuilder
	
	#region AspnetUsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersParameterBuilder : ParameterizedSqlFilterBuilder<AspnetUsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersParameterBuilder class.
		/// </summary>
		public AspnetUsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetUsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetUsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetUsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetUsersParameterBuilder
	
	#region AspnetUsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetUsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetUsersSortBuilder : SqlSortBuilder<AspnetUsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersSqlSortBuilder class.
		/// </summary>
		public AspnetUsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetUsersSortBuilder
	
} // end namespace
