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
	/// This class is the base class for any <see cref="CompanyDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CompanyDetailsProviderBaseCore : EntityProviderBase<NDMSInvestigation.Entities.CompanyDetails, NDMSInvestigation.Entities.CompanyDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, NDMSInvestigation.Entities.CompanyDetailsKey key)
		{
			return Delete(transactionManager, key.CompanyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_companyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _companyId)
		{
			return Delete(null, _companyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _companyId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyDetails_TraceChange key.
		///		FK_CompanyDetails_TraceChange Description: 
		/// </summary>
		/// <param name="_traceChange"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.CompanyDetails objects.</returns>
		public TList<CompanyDetails> GetByTraceChange(System.Int32? _traceChange)
		{
			int count = -1;
			return GetByTraceChange(_traceChange, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyDetails_TraceChange key.
		///		FK_CompanyDetails_TraceChange Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceChange"></param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.CompanyDetails objects.</returns>
		/// <remarks></remarks>
		public TList<CompanyDetails> GetByTraceChange(TransactionManager transactionManager, System.Int32? _traceChange)
		{
			int count = -1;
			return GetByTraceChange(transactionManager, _traceChange, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyDetails_TraceChange key.
		///		FK_CompanyDetails_TraceChange Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceChange"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.CompanyDetails objects.</returns>
		public TList<CompanyDetails> GetByTraceChange(TransactionManager transactionManager, System.Int32? _traceChange, int start, int pageLength)
		{
			int count = -1;
			return GetByTraceChange(transactionManager, _traceChange, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyDetails_TraceChange key.
		///		fkCompanyDetailsTraceChange Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_traceChange"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.CompanyDetails objects.</returns>
		public TList<CompanyDetails> GetByTraceChange(System.Int32? _traceChange, int start, int pageLength)
		{
			int count =  -1;
			return GetByTraceChange(null, _traceChange, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyDetails_TraceChange key.
		///		fkCompanyDetailsTraceChange Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_traceChange"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.CompanyDetails objects.</returns>
		public TList<CompanyDetails> GetByTraceChange(System.Int32? _traceChange, int start, int pageLength,out int count)
		{
			return GetByTraceChange(null, _traceChange, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CompanyDetails_TraceChange key.
		///		FK_CompanyDetails_TraceChange Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_traceChange"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of NDMSInvestigation.Entities.CompanyDetails objects.</returns>
		public abstract TList<CompanyDetails> GetByTraceChange(TransactionManager transactionManager, System.Int32? _traceChange, int start, int pageLength, out int count);
		
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
		public override NDMSInvestigation.Entities.CompanyDetails Get(TransactionManager transactionManager, NDMSInvestigation.Entities.CompanyDetailsKey key, int start, int pageLength)
		{
			return GetByCompanyId(transactionManager, key.CompanyId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_CompanyDetails index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByUserId(System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(null,_userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CompanyDetails index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByUserId(System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CompanyDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByUserId(TransactionManager transactionManager, System.Guid _userId)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CompanyDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength)
		{
			int count = -1;
			return GetByUserId(transactionManager, _userId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CompanyDetails index.
		/// </summary>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByUserId(System.Guid _userId, int start, int pageLength, out int count)
		{
			return GetByUserId(null, _userId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_CompanyDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public abstract NDMSInvestigation.Entities.CompanyDetails GetByUserId(TransactionManager transactionManager, System.Guid _userId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CompanyDetails index.
		/// </summary>
		/// <param name="_companyId"></param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByCompanyId(System.Int32 _companyId)
		{
			int count = -1;
			return GetByCompanyId(null,_companyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CompanyDetails index.
		/// </summary>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByCompanyId(System.Int32 _companyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyId(null, _companyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CompanyDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByCompanyId(TransactionManager transactionManager, System.Int32 _companyId)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CompanyDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByCompanyId(TransactionManager transactionManager, System.Int32 _companyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CompanyDetails index.
		/// </summary>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public NDMSInvestigation.Entities.CompanyDetails GetByCompanyId(System.Int32 _companyId, int start, int pageLength, out int count)
		{
			return GetByCompanyId(null, _companyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CompanyDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> class.</returns>
		public abstract NDMSInvestigation.Entities.CompanyDetails GetByCompanyId(TransactionManager transactionManager, System.Int32 _companyId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CompanyDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CompanyDetails&gt;"/></returns>
		public static TList<CompanyDetails> Fill(IDataReader reader, TList<CompanyDetails> rows, int start, int pageLength)
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
				
				NDMSInvestigation.Entities.CompanyDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CompanyDetails")
					.Append("|").Append((System.Int32)reader[((int)CompanyDetailsColumn.CompanyId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CompanyDetails>(
					key.ToString(), // EntityTrackingKey
					"CompanyDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new NDMSInvestigation.Entities.CompanyDetails();
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
					c.CompanyId = (System.Int32)reader[((int)CompanyDetailsColumn.CompanyId - 1)];
					c.UserId = (System.Guid)reader[((int)CompanyDetailsColumn.UserId - 1)];
					c.CompanyName = (reader.IsDBNull(((int)CompanyDetailsColumn.CompanyName - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.CompanyName - 1)];
					c.Phone = (reader.IsDBNull(((int)CompanyDetailsColumn.Phone - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Phone - 1)];
					c.Fax = (reader.IsDBNull(((int)CompanyDetailsColumn.Fax - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Fax - 1)];
					c.Email = (reader.IsDBNull(((int)CompanyDetailsColumn.Email - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Email - 1)];
					c.Address = (reader.IsDBNull(((int)CompanyDetailsColumn.Address - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Address - 1)];
					c.EmployeeNumber = (reader.IsDBNull(((int)CompanyDetailsColumn.EmployeeNumber - 1)))?null:(System.Int32?)reader[((int)CompanyDetailsColumn.EmployeeNumber - 1)];
					c.Director = (reader.IsDBNull(((int)CompanyDetailsColumn.Director - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Director - 1)];
					c.Country = (reader.IsDBNull(((int)CompanyDetailsColumn.Country - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Country - 1)];
					c.City = (reader.IsDBNull(((int)CompanyDetailsColumn.City - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.City - 1)];
					c.District = (reader.IsDBNull(((int)CompanyDetailsColumn.District - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.District - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)CompanyDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CompanyDetailsColumn.CreatedDate - 1)];
					c.UpdatedDate = (reader.IsDBNull(((int)CompanyDetailsColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)CompanyDetailsColumn.UpdatedDate - 1)];
					c.Description = (reader.IsDBNull(((int)CompanyDetailsColumn.Description - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Description - 1)];
					c.CurrentTotalMark = (reader.IsDBNull(((int)CompanyDetailsColumn.CurrentTotalMark - 1)))?null:(System.Int32?)reader[((int)CompanyDetailsColumn.CurrentTotalMark - 1)];
					c.TraceChange = (reader.IsDBNull(((int)CompanyDetailsColumn.TraceChange - 1)))?null:(System.Int32?)reader[((int)CompanyDetailsColumn.TraceChange - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.CompanyDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, NDMSInvestigation.Entities.CompanyDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.CompanyId = (System.Int32)reader[((int)CompanyDetailsColumn.CompanyId - 1)];
			entity.UserId = (System.Guid)reader[((int)CompanyDetailsColumn.UserId - 1)];
			entity.CompanyName = (reader.IsDBNull(((int)CompanyDetailsColumn.CompanyName - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.CompanyName - 1)];
			entity.Phone = (reader.IsDBNull(((int)CompanyDetailsColumn.Phone - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Phone - 1)];
			entity.Fax = (reader.IsDBNull(((int)CompanyDetailsColumn.Fax - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Fax - 1)];
			entity.Email = (reader.IsDBNull(((int)CompanyDetailsColumn.Email - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Email - 1)];
			entity.Address = (reader.IsDBNull(((int)CompanyDetailsColumn.Address - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Address - 1)];
			entity.EmployeeNumber = (reader.IsDBNull(((int)CompanyDetailsColumn.EmployeeNumber - 1)))?null:(System.Int32?)reader[((int)CompanyDetailsColumn.EmployeeNumber - 1)];
			entity.Director = (reader.IsDBNull(((int)CompanyDetailsColumn.Director - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Director - 1)];
			entity.Country = (reader.IsDBNull(((int)CompanyDetailsColumn.Country - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Country - 1)];
			entity.City = (reader.IsDBNull(((int)CompanyDetailsColumn.City - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.City - 1)];
			entity.District = (reader.IsDBNull(((int)CompanyDetailsColumn.District - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.District - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)CompanyDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CompanyDetailsColumn.CreatedDate - 1)];
			entity.UpdatedDate = (reader.IsDBNull(((int)CompanyDetailsColumn.UpdatedDate - 1)))?null:(System.DateTime?)reader[((int)CompanyDetailsColumn.UpdatedDate - 1)];
			entity.Description = (reader.IsDBNull(((int)CompanyDetailsColumn.Description - 1)))?null:(System.String)reader[((int)CompanyDetailsColumn.Description - 1)];
			entity.CurrentTotalMark = (reader.IsDBNull(((int)CompanyDetailsColumn.CurrentTotalMark - 1)))?null:(System.Int32?)reader[((int)CompanyDetailsColumn.CurrentTotalMark - 1)];
			entity.TraceChange = (reader.IsDBNull(((int)CompanyDetailsColumn.TraceChange - 1)))?null:(System.Int32?)reader[((int)CompanyDetailsColumn.TraceChange - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="NDMSInvestigation.Entities.CompanyDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.CompanyDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, NDMSInvestigation.Entities.CompanyDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CompanyId = (System.Int32)dataRow["CompanyId"];
			entity.UserId = (System.Guid)dataRow["UserId"];
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
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.UpdatedDate = Convert.IsDBNull(dataRow["UpdatedDate"]) ? null : (System.DateTime?)dataRow["UpdatedDate"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.CurrentTotalMark = Convert.IsDBNull(dataRow["CurrentTotalMark"]) ? null : (System.Int32?)dataRow["CurrentTotalMark"];
			entity.TraceChange = Convert.IsDBNull(dataRow["TraceChange"]) ? null : (System.Int32?)dataRow["TraceChange"];
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
		/// <param name="entity">The <see cref="NDMSInvestigation.Entities.CompanyDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.CompanyDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, NDMSInvestigation.Entities.CompanyDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region TraceChangeSource	
			if (CanDeepLoad(entity, "TraceChange|TraceChangeSource", deepLoadType, innerList) 
				&& entity.TraceChangeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TraceChange ?? (int)0);
				TraceChange tmpEntity = EntityManager.LocateEntity<TraceChange>(EntityLocator.ConstructKeyFromPkItems(typeof(TraceChange), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TraceChangeSource = tmpEntity;
				else
					entity.TraceChangeSource = DataRepository.TraceChangeProvider.GetByTraceId(transactionManager, (entity.TraceChange ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TraceChangeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TraceChangeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TraceChangeProvider.DeepLoad(transactionManager, entity.TraceChangeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TraceChangeSource
			
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
		/// Deep Save the entire object graph of the NDMSInvestigation.Entities.CompanyDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">NDMSInvestigation.Entities.CompanyDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">NDMSInvestigation.Entities.CompanyDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, NDMSInvestigation.Entities.CompanyDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region TraceChangeSource
			if (CanDeepSave(entity, "TraceChange|TraceChangeSource", deepSaveType, innerList) 
				&& entity.TraceChangeSource != null)
			{
				DataRepository.TraceChangeProvider.Save(transactionManager, entity.TraceChangeSource);
				entity.TraceChange = entity.TraceChangeSource.TraceId;
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
	
	#region CompanyDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>NDMSInvestigation.Entities.CompanyDetails</c>
	///</summary>
	public enum CompanyDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>AspnetUsers</c> at UserIdSource
		///</summary>
		[ChildEntityType(typeof(AspnetUsers))]
		AspnetUsers,
			
		///<summary>
		/// Composite Property for <c>TraceChange</c> at TraceChangeSource
		///</summary>
		[ChildEntityType(typeof(TraceChange))]
		TraceChange,
		}
	
	#endregion CompanyDetailsChildEntityTypes
	
	#region CompanyDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CompanyDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyDetailsFilterBuilder : SqlFilterBuilder<CompanyDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsFilterBuilder class.
		/// </summary>
		public CompanyDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyDetailsFilterBuilder
	
	#region CompanyDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CompanyDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyDetailsParameterBuilder : ParameterizedSqlFilterBuilder<CompanyDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsParameterBuilder class.
		/// </summary>
		public CompanyDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CompanyDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CompanyDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CompanyDetailsParameterBuilder
	
	#region CompanyDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CompanyDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CompanyDetailsSortBuilder : SqlSortBuilder<CompanyDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsSqlSortBuilder class.
		/// </summary>
		public CompanyDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CompanyDetailsSortBuilder
	
} // end namespace
