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
	/// This class is the base class for any <see cref="AspnetPersonalizationPerUserProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class AspnetPersonalizationPerUserProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.AspnetPersonalizationPerUser, NDMSInvestigation.Entities.AspnetPersonalizationPerUserKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationPerUserKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__PathI__4F7CD00D key.
		///		FK__aspnet_Pe__PathI__4F7CD00D Description: 
		/// </summary>
		/// <param name="_pathId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByPathId(System.Guid? _pathId)
		{
			int count = -1;
			return GetByPathId(_pathId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__PathI__4F7CD00D key.
		///		FK__aspnet_Pe__PathI__4F7CD00D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		/// <remarks></remarks>
		public TList<AspnetPersonalizationPerUser> GetByPathId(TransactionManager transactionManager, System.Guid? _pathId)
		{
			int count = -1;
			return GetByPathId(transactionManager, _pathId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__PathI__4F7CD00D key.
		///		FK__aspnet_Pe__PathI__4F7CD00D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByPathId(TransactionManager transactionManager, System.Guid? _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathId(transactionManager, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__PathI__4F7CD00D key.
		///		fkAspnetPePathi4f7Cd00d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_pathId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByPathId(System.Guid? _pathId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPathId(null, _pathId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__PathI__4F7CD00D key.
		///		fkAspnetPePathi4f7Cd00d Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_pathId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByPathId(System.Guid? _pathId, int start, int pageLength,out int count)
		{
			return GetByPathId(null, _pathId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__PathI__4F7CD00D key.
		///		FK__aspnet_Pe__PathI__4F7CD00D Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public abstract TList<AspnetPersonalizationPerUser> GetByPathId(TransactionManager transactionManager, System.Guid? _pathId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__UserI__5070F446 key.
		///		FK__aspnet_Pe__UserI__5070F446 Description: 
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByUserId(System.Guid? _userId)
		{
			int count = -1;
			return GetByUserId(_userId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__UserI__5070F446 key.
		///		FK__aspnet_Pe__UserI__5070F446 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		/// <remarks></remarks>
		public TList<AspnetPersonalizationPerUser> GetByUserId(TransactionManager transactionManager, System.Guid? _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__UserI__5070F446 key.
		///		FK__aspnet_Pe__UserI__5070F446 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByUserId(TransactionManager transactionManager, System.Guid? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__UserI__5070F446 key.
		///		fkAspnetPeUseri5070f446 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByUserId(System.Guid? _userId, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserId(null, _userId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__UserI__5070F446 key.
		///		fkAspnetPeUseri5070f446 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public TList<AspnetPersonalizationPerUser> GetByUserId(System.Guid? _userId, int start, int pageLength,out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__aspnet_Pe__UserI__5070F446 key.
		///		FK__aspnet_Pe__UserI__5070F446 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.AspnetPersonalizationPerUser objects.</returns>
		public abstract TList<AspnetPersonalizationPerUser> GetByUserId(TransactionManager transactionManager, System.Guid? _userId, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.AspnetPersonalizationPerUser Get(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationPerUserKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_PersonalizationPerUser_index1 index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByPathIdUserId(System.Guid? _pathId, System.Guid? _userId)
		{
			int count = -1;
			return GetByPathIdUserId(null,_pathId, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_index1 index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByPathIdUserId(System.Guid? _pathId, System.Guid? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathIdUserId(null, _pathId, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_index1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByPathIdUserId(TransactionManager transactionManager, System.Guid? _pathId, System.Guid? _userId)
		{
			int count = -1;
			return GetByPathIdUserId(transactionManager, _pathId, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_index1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByPathIdUserId(TransactionManager transactionManager, System.Guid? _pathId, System.Guid? _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByPathIdUserId(transactionManager, _pathId, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_index1 index.
		/// </summary>
		/// <param name="_pathId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByPathIdUserId(System.Guid? _pathId, System.Guid? _userId, int start, int pageLength, out int count)
		{
			return GetByPathIdUserId(null, _pathId, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_index1 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_pathId"></param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByPathIdUserId(TransactionManager transactionManager, System.Guid? _pathId, System.Guid? _userId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key aspnet_PersonalizationPerUser_ncindex2 index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_pathId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByUserIdPathId(System.Guid? _userId, System.Guid? _pathId)
		{
			int count = -1;
			return GetByUserIdPathId(null,_userId, _pathId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_ncindex2 index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByUserIdPathId(System.Guid? _userId, System.Guid? _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdPathId(null, _userId, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_ncindex2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_pathId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByUserIdPathId(TransactionManager transactionManager, System.Guid? _userId, System.Guid? _pathId)
		{
			int count = -1;
			return GetByUserIdPathId(transactionManager, _userId, _pathId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_ncindex2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByUserIdPathId(TransactionManager transactionManager, System.Guid? _userId, System.Guid? _pathId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserIdPathId(transactionManager, _userId, _pathId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_ncindex2 index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByUserIdPathId(System.Guid? _userId, System.Guid? _pathId, int start, int pageLength, out int count)
		{
			return GetByUserIdPathId(null, _userId, _pathId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the aspnet_PersonalizationPerUser_ncindex2 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="_pathId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetByUserIdPathId(TransactionManager transactionManager, System.Guid? _userId, System.Guid? _pathId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__aspnet_Personali__4D94879B index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetById(System.Guid _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4D94879B index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetById(System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4D94879B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetById(TransactionManager transactionManager, System.Guid _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4D94879B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4D94879B index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetById(System.Guid _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__aspnet_Personali__4D94879B index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> class.</returns>
		public abstract NDMSInvestigation.Entities.AspnetPersonalizationPerUser GetById(TransactionManager transactionManager, System.Guid _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;AspnetPersonalizationPerUser&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;AspnetPersonalizationPerUser&gt;"/></returns>
		public static TList<AspnetPersonalizationPerUser> Fill(IDataReader reader, TList<AspnetPersonalizationPerUser> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.AspnetPersonalizationPerUser c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("AspnetPersonalizationPerUser")
					.Append("|").Append((System.Guid)reader[((int)AspnetPersonalizationPerUserColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<AspnetPersonalizationPerUser>(
					key.ToString(), // EntityTrackingKey
					"AspnetPersonalizationPerUser",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.AspnetPersonalizationPerUser();
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
					c.Id = (System.Guid)reader[((int)AspnetPersonalizationPerUserColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.PathId = (reader.IsDBNull(((int)AspnetPersonalizationPerUserColumn.PathId - 1)))?null:(System.Guid?)reader[((int)AspnetPersonalizationPerUserColumn.PathId - 1)];
					c.UserId = (reader.IsDBNull(((int)AspnetPersonalizationPerUserColumn.UserId - 1)))?null:(System.Guid?)reader[((int)AspnetPersonalizationPerUserColumn.UserId - 1)];
					c.PageSettings = (System.Byte[])reader[((int)AspnetPersonalizationPerUserColumn.PageSettings - 1)];
					c.LastUpdatedDate = (System.DateTime)reader[((int)AspnetPersonalizationPerUserColumn.LastUpdatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.AspnetPersonalizationPerUser entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Guid)reader[((int)AspnetPersonalizationPerUserColumn.Id - 1)];
			entity.OriginalId = (System.Guid)reader["Id"];
			entity.PathId = (reader.IsDBNull(((int)AspnetPersonalizationPerUserColumn.PathId - 1)))?null:(System.Guid?)reader[((int)AspnetPersonalizationPerUserColumn.PathId - 1)];
			entity.UserId = (reader.IsDBNull(((int)AspnetPersonalizationPerUserColumn.UserId - 1)))?null:(System.Guid?)reader[((int)AspnetPersonalizationPerUserColumn.UserId - 1)];
			entity.PageSettings = (System.Byte[])reader[((int)AspnetPersonalizationPerUserColumn.PageSettings - 1)];
			entity.LastUpdatedDate = (System.DateTime)reader[((int)AspnetPersonalizationPerUserColumn.LastUpdatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.AspnetPersonalizationPerUser entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Guid)dataRow["Id"];
			entity.OriginalId = (System.Guid)dataRow["Id"];
			entity.PathId = Convert.IsDBNull(dataRow["PathId"]) ? null : (System.Guid?)dataRow["PathId"];
			entity.UserId = Convert.IsDBNull(dataRow["UserId"]) ? null : (System.Guid?)dataRow["UserId"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.AspnetPersonalizationPerUser"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetPersonalizationPerUser Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationPerUser entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region PathIdSource	
			if (CanDeepLoad(entity, "AspnetPaths|PathIdSource", deepLoadType, innerList) 
				&& entity.PathIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PathId ?? Guid.Empty);
				AspnetPaths tmpEntity = EntityManager.LocateEntity<AspnetPaths>(EntityLocator.ConstructKeyFromPkItems(typeof(AspnetPaths), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PathIdSource = tmpEntity;
				else
					entity.PathIdSource = DataRepository.AspnetPathsProvider.GetByPathId(transactionManager, (entity.PathId ?? Guid.Empty));		
				
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

			#region UserIdSource	
			if (CanDeepLoad(entity, "AspnetUsers|UserIdSource", deepLoadType, innerList) 
				&& entity.UserIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UserId ?? Guid.Empty);
				AspnetUsers tmpEntity = EntityManager.LocateEntity<AspnetUsers>(EntityLocator.ConstructKeyFromPkItems(typeof(AspnetUsers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserIdSource = tmpEntity;
				else
					entity.UserIdSource = DataRepository.AspnetUsersProvider.GetByUserId(transactionManager, (entity.UserId ?? Guid.Empty));		
				
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.AspnetPersonalizationPerUser object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.AspnetPersonalizationPerUser instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.AspnetPersonalizationPerUser Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.AspnetPersonalizationPerUser entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region AspnetPersonalizationPerUserChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.AspnetPersonalizationPerUser</c>
	///</summary>
	public enum AspnetPersonalizationPerUserChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetPaths</c> at PathIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetPaths))]
		AspnetPaths,
			
		///<summary>
		/// Composite Property for <c>AspnetUsers</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetUsers))]
		AspnetUsers,
		}
	
	#endregion AspnetPersonalizationPerUserChildEntityTypes
	
	#region AspnetPersonalizationPerUserFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;AspnetPersonalizationPerUserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserFilterBuilder : SqlFilterBuilder<AspnetPersonalizationPerUserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserFilterBuilder class.
		/// </summary>
		public AspnetPersonalizationPerUserFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationPerUserFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationPerUserFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationPerUserFilterBuilder
	
	#region AspnetPersonalizationPerUserParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;AspnetPersonalizationPerUserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserParameterBuilder : ParameterizedSqlFilterBuilder<AspnetPersonalizationPerUserColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserParameterBuilder class.
		/// </summary>
		public AspnetPersonalizationPerUserParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AspnetPersonalizationPerUserParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AspnetPersonalizationPerUserParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AspnetPersonalizationPerUserParameterBuilder
	
	#region AspnetPersonalizationPerUserSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;AspnetPersonalizationPerUserColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class AspnetPersonalizationPerUserSortBuilder : SqlSortBuilder<AspnetPersonalizationPerUserColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserSqlSortBuilder class.
		/// </summary>
		public AspnetPersonalizationPerUserSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion AspnetPersonalizationPerUserSortBuilder
	
} // end namespace
