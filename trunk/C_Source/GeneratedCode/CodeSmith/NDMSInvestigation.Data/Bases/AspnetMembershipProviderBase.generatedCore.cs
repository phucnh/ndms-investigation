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
	/// This class is the base class for any <see cref="AspnetMembershipProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetMembershipProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetMembership, NDMSInvestigation.Entities.AspnetMembershipKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetMembershipKey key)
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
		/// 	Gets rows from the datasource based on the FK__aspnet_Me__Appli__145C0A3F key.
		///		FK__aspnet_Me__Appli__145C0A3F Description: 
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetMembership objects.</returns>
		public TList<AspnetMembership> GetByApplicationId(System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(_applicationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Me__Appli__145C0A3F key.
		///		FK__aspnet_Me__Appli__145C0A3F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetMembership objects.</returns>
		/// <remarks></remarks>
		public TList<AspnetMembership> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Me__Appli__145C0A3F key.
		///		FK__aspnet_Me__Appli__145C0A3F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetMembership objects.</returns>
		public TList<AspnetMembership> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationId(transactionManager, _applicationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Me__Appli__145C0A3F key.
		///		fkAspnetMeAppli145c0a3f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetMembership objects.</returns>
		public TList<AspnetMembership> GetByApplicationId(System.Guid _applicationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByApplicationId(null, _applicationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Me__Appli__145C0A3F key.
		///		fkAspnetMeAppli145c0a3f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_applicationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetMembership objects.</returns>
		public TList<AspnetMembership> GetByApplicationId(System.Guid _applicationId, int start, int pageLength,out int count)
		{
			return GetByApplicationId(null, _applicationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Me__Appli__145C0A3F key.
		///		FK__aspnet_Me__Appli__145C0A3F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetMembership objects.</returns>
		public abstract TList<AspnetMembership> GetByApplicationId(TransactionManager transactionManager, System.Guid _applicationId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.AspnetMembership Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetMembershipKey key, int start, int pageLength)
		{
			return GetByUserId(transactionManager, key.UserId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_Membership_index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredEmail"></param>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetMembership&gt;"/> class.</returns>
		public TList<AspnetMembership> GetByApplicationIdLoweredEmail(System.Guid _applicationId, System.String _loweredEmail)
		{
			int count = -1;
			return GetByApplicationIdLoweredEmail(null,_applicationId, _loweredEmail, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Membership_index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetMembership&gt;"/> class.</returns>
		public TList<AspnetMembership> GetByApplicationIdLoweredEmail(System.Guid _applicationId, System.String _loweredEmail, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredEmail(null, _applicationId, _loweredEmail, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Membership_index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredEmail"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetMembership&gt;"/> class.</returns>
		public TList<AspnetMembership> GetByApplicationIdLoweredEmail(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredEmail)
		{
			int count = -1;
			return GetByApplicationIdLoweredEmail(transactionManager, _applicationId, _loweredEmail, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Membership_index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetMembership&gt;"/> class.</returns>
		public TList<AspnetMembership> GetByApplicationIdLoweredEmail(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredEmail, int start, int pageLength)
		{
			int count = -1;
			return GetByApplicationIdLoweredEmail(transactionManager, _applicationId, _loweredEmail, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Membership_index index.
		/// </summary>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetMembership&gt;"/> class.</returns>
		public TList<AspnetMembership> GetByApplicationIdLoweredEmail(System.Guid _applicationId, System.String _loweredEmail, int start, int pageLength, out int count)
		{
			return GetByApplicationIdLoweredEmail(null, _applicationId, _loweredEmail, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_Membership_index index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_applicationId"></param>
		/// <param name="_loweredEmail"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;AspnetMembership&gt;"/> class.</returns>
		public abstract TList<AspnetMembership> GetByApplicationIdLoweredEmail(TransactionManager transactionManager, System.Guid _applicationId, System.String _loweredEmail, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Membershi__1367E606 index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetMembership GetByUserId(System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Membershi__1367E606 index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetMembership GetByUserId(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Membershi__1367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetMembership GetByUserId(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Membershi__1367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetMembership GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Membershi__1367E606 index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetMembership GetByUserId(System.Guid _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Membershi__1367E606 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetMembership GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetMembership&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetMembership&gt;"/></returns>
		public static TList<AspnetMembership> Fill(IDataReader reader, TList<AspnetMembership> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetMembership c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetMembership")
					.Append("|").Append((System.Guid)reader[((int)AspnetMembershipColumn.UserId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetMembership>(
					key.ToString(), // EntityTrackingKey
					"AspnetMembership",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetMembership();
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
					c.ApplicationId = (System.Guid)reader[((int)AspnetMembershipColumn.ApplicationId - 1)];
					c.UserId = (System.Guid)reader[((int)AspnetMembershipColumn.UserId - 1)];
					c.OriginalUserId = c.UserId;
					c.Password = (System.String)reader[((int)AspnetMembershipColumn.Password - 1)];
					c.PasswordFormat = (System.Int32)reader[((int)AspnetMembershipColumn.PasswordFormat - 1)];
					c.PasswordSalt = (System.String)reader[((int)AspnetMembershipColumn.PasswordSalt - 1)];
					c.MobilePin = (reader.IsDBNull(((int)AspnetMembershipColumn.MobilePin - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.MobilePin - 1)];
					c.Email = (reader.IsDBNull(((int)AspnetMembershipColumn.Email - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.Email - 1)];
					c.LoweredEmail = (reader.IsDBNull(((int)AspnetMembershipColumn.LoweredEmail - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.LoweredEmail - 1)];
					c.PasswordQuestion = (reader.IsDBNull(((int)AspnetMembershipColumn.PasswordQuestion - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.PasswordQuestion - 1)];
					c.PasswordAnswer = (reader.IsDBNull(((int)AspnetMembershipColumn.PasswordAnswer - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.PasswordAnswer - 1)];
					c.IsApproved = (System.Boolean)reader[((int)AspnetMembershipColumn.IsApproved - 1)];
					c.IsLockedOut = (System.Boolean)reader[((int)AspnetMembershipColumn.IsLockedOut - 1)];
					c.CreateDate = (System.DateTime)reader[((int)AspnetMembershipColumn.CreateDate - 1)];
					c.LastLoginDate = (System.DateTime)reader[((int)AspnetMembershipColumn.LastLoginDate - 1)];
					c.LastPasswordChangedDate = (System.DateTime)reader[((int)AspnetMembershipColumn.LastPasswordChangedDate - 1)];
					c.LastLockoutDate = (System.DateTime)reader[((int)AspnetMembershipColumn.LastLockoutDate - 1)];
					c.FailedPasswordAttemptCount = (System.Int32)reader[((int)AspnetMembershipColumn.FailedPasswordAttemptCount - 1)];
					c.FailedPasswordAttemptWindowStart = (System.DateTime)reader[((int)AspnetMembershipColumn.FailedPasswordAttemptWindowStart - 1)];
					c.FailedPasswordAnswerAttemptCount = (System.Int32)reader[((int)AspnetMembershipColumn.FailedPasswordAnswerAttemptCount - 1)];
					c.FailedPasswordAnswerAttemptWindowStart = (System.DateTime)reader[((int)AspnetMembershipColumn.FailedPasswordAnswerAttemptWindowStart - 1)];
					c.Comment = (reader.IsDBNull(((int)AspnetMembershipColumn.Comment - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.Comment - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetMembership"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetMembership entity)
		{
			if (!reader.Read()) return;
			
			entity.ApplicationId = (System.Guid)reader[((int)AspnetMembershipColumn.ApplicationId - 1)];
			entity.UserId = (System.Guid)reader[((int)AspnetMembershipColumn.UserId - 1)];
			entity.OriginalUserId = (System.Guid)reader["UserId"];
			entity.Password = (System.String)reader[((int)AspnetMembershipColumn.Password - 1)];
			entity.PasswordFormat = (System.Int32)reader[((int)AspnetMembershipColumn.PasswordFormat - 1)];
			entity.PasswordSalt = (System.String)reader[((int)AspnetMembershipColumn.PasswordSalt - 1)];
			entity.MobilePin = (reader.IsDBNull(((int)AspnetMembershipColumn.MobilePin - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.MobilePin - 1)];
			entity.Email = (reader.IsDBNull(((int)AspnetMembershipColumn.Email - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.Email - 1)];
			entity.LoweredEmail = (reader.IsDBNull(((int)AspnetMembershipColumn.LoweredEmail - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.LoweredEmail - 1)];
			entity.PasswordQuestion = (reader.IsDBNull(((int)AspnetMembershipColumn.PasswordQuestion - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.PasswordQuestion - 1)];
			entity.PasswordAnswer = (reader.IsDBNull(((int)AspnetMembershipColumn.PasswordAnswer - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.PasswordAnswer - 1)];
			entity.IsApproved = (System.Boolean)reader[((int)AspnetMembershipColumn.IsApproved - 1)];
			entity.IsLockedOut = (System.Boolean)reader[((int)AspnetMembershipColumn.IsLockedOut - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)AspnetMembershipColumn.CreateDate - 1)];
			entity.LastLoginDate = (System.DateTime)reader[((int)AspnetMembershipColumn.LastLoginDate - 1)];
			entity.LastPasswordChangedDate = (System.DateTime)reader[((int)AspnetMembershipColumn.LastPasswordChangedDate - 1)];
			entity.LastLockoutDate = (System.DateTime)reader[((int)AspnetMembershipColumn.LastLockoutDate - 1)];
			entity.FailedPasswordAttemptCount = (System.Int32)reader[((int)AspnetMembershipColumn.FailedPasswordAttemptCount - 1)];
			entity.FailedPasswordAttemptWindowStart = (System.DateTime)reader[((int)AspnetMembershipColumn.FailedPasswordAttemptWindowStart - 1)];
			entity.FailedPasswordAnswerAttemptCount = (System.Int32)reader[((int)AspnetMembershipColumn.FailedPasswordAnswerAttemptCount - 1)];
			entity.FailedPasswordAnswerAttemptWindowStart = (System.DateTime)reader[((int)AspnetMembershipColumn.FailedPasswordAnswerAttemptWindowStart - 1)];
			entity.Comment = (reader.IsDBNull(((int)AspnetMembershipColumn.Comment - 1)))?null:(System.String)reader[((int)AspnetMembershipColumn.Comment - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetMembership"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetMembership"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetMembership entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ApplicationId = (System.Guid)dataRow["ApplicationId"];
			entity.UserId = (System.Guid)dataRow["UserId"];
			entity.OriginalUserId = (System.Guid)dataRow["UserId"];
			entity.Password = (System.String)dataRow["Password"];
			entity.PasswordFormat = (System.Int32)dataRow["PasswordFormat"];
			entity.PasswordSalt = (System.String)dataRow["PasswordSalt"];
			entity.MobilePin = Convert.IsDBNull(dataRow["MobilePIN"]) ? null : (System.String)dataRow["MobilePIN"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.LoweredEmail = Convert.IsDBNull(dataRow["LoweredEmail"]) ? null : (System.String)dataRow["LoweredEmail"];
			entity.PasswordQuestion = Convert.IsDBNull(dataRow["PasswordQuestion"]) ? null : (System.String)dataRow["PasswordQuestion"];
			entity.PasswordAnswer = Convert.IsDBNull(dataRow["PasswordAnswer"]) ? null : (System.String)dataRow["PasswordAnswer"];
			entity.IsApproved = (System.Boolean)dataRow["IsApproved"];
			entity.IsLockedOut = (System.Boolean)dataRow["IsLockedOut"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.LastLoginDate = (System.DateTime)dataRow["LastLoginDate"];
			entity.LastPasswordChangedDate = (System.DateTime)dataRow["LastPasswordChangedDate"];
			entity.LastLockoutDate = (System.DateTime)dataRow["LastLockoutDate"];
			entity.FailedPasswordAttemptCount = (System.Int32)dataRow["FailedPasswordAttemptCount"];
			entity.FailedPasswordAttemptWindowStart = (System.DateTime)dataRow["FailedPasswordAttemptWindowStart"];
			entity.FailedPasswordAnswerAttemptCount = (System.Int32)dataRow["FailedPasswordAnswerAttemptCount"];
			entity.FailedPasswordAnswerAttemptWindowStart = (System.DateTime)dataRow["FailedPasswordAnswerAttemptWindowStart"];
			entity.Comment = Convert.IsDBNull(dataRow["Comment"]) ? null : (System.String)dataRow["Comment"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetMembership"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetMembership Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetMembership entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetMembership object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetMembership instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetMembership Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetMembership entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AspnetMembershipChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetMembership</c>
	///</summary>
	public enum AspnetMembershipChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetApplications</c> at ApplicationIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetApplications))]
		AspnetApplications,
			
		///<summary>
		/// Composite Property for <c>AspnetUsers</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetUsers))]
		AspnetUsers,
		}
	
	#endregion AspnetMembershipChildEntityTypes
	
	#region AspnetMembershipFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetMembershipColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipFilterBuilder : SqlFilterBuilder<AspnetMembershipColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipFilterBuilder class.
		/// </summary>
		public AspnetMembershipFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetMembershipFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetMembershipFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetMembershipFilterBuilder
	
	#region AspnetMembershipParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetMembershipColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipParameterBuilder : ParameterizedSqlFilterBuilder<AspnetMembershipColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipParameterBuilder class.
		/// </summary>
		public AspnetMembershipParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetMembershipParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetMembershipParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetMembershipParameterBuilder
	
	#region AspnetMembershipSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetMembershipColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetMembershipSortBuilder : SqlSortBuilder<AspnetMembershipColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipSqlSortBuilder class.
		/// </summary>
		public AspnetMembershipSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetMembershipSortBuilder
	
} // end namespace
