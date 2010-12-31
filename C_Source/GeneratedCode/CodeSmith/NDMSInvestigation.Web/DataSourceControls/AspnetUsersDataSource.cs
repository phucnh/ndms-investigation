#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;
using NDMSInvestigation.Data.Bases;
using NDMSInvestigation.Services;
#endregion

namespace NDMSInvestigation.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.AspnetUsersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetUsersDataSourceDesigner))]
	public class AspnetUsersDataSource : ProviderDataSource<AspnetUsers, AspnetUsersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersDataSource class.
		/// </summary>
		public AspnetUsersDataSource() : base(new AspnetUsersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetUsersDataSourceView used by the AspnetUsersDataSource.
		/// </summary>
		protected AspnetUsersDataSourceView AspnetUsersView
		{
			get { return ( View as AspnetUsersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetUsersDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetUsersSelectMethod SelectMethod
		{
			get
			{
				AspnetUsersSelectMethod selectMethod = AspnetUsersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetUsersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetUsersDataSourceView class that is to be
		/// used by the AspnetUsersDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetUsersDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetUsers, AspnetUsersKey> GetNewDataSourceView()
		{
			return new AspnetUsersDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the AspnetUsersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetUsersDataSourceView : ProviderDataSourceView<AspnetUsers, AspnetUsersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetUsersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetUsersDataSourceView(AspnetUsersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetUsersDataSource AspnetUsersOwner
		{
			get { return Owner as AspnetUsersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetUsersSelectMethod SelectMethod
		{
			get { return AspnetUsersOwner.SelectMethod; }
			set { AspnetUsersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetUsersService AspnetUsersProvider
		{
			get { return Provider as AspnetUsersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetUsers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetUsers> results = null;
			AspnetUsers item;
			count = 0;
			
			System.Guid _applicationId;
			System.String _loweredUserName;
			System.DateTime _lastActivityDate;
			System.Guid _userId;
			System.Guid _roleId;
			System.Int32 _groupId;

			switch ( SelectMethod )
			{
				case AspnetUsersSelectMethod.Get:
					AspnetUsersKey entityKey  = new AspnetUsersKey();
					entityKey.Load(values);
					item = AspnetUsersProvider.Get(entityKey);
					results = new TList<AspnetUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetUsersSelectMethod.GetAll:
                    results = AspnetUsersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetUsersSelectMethod.GetPaged:
					results = AspnetUsersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetUsersSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetUsersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetUsersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetUsersSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetUsersProvider.GetByUserId(_userId);
					results = new TList<AspnetUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetUsersSelectMethod.GetByApplicationIdLoweredUserName:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					_loweredUserName = ( values["LoweredUserName"] != null ) ? (System.String) EntityUtil.ChangeType(values["LoweredUserName"], typeof(System.String)) : string.Empty;
					item = AspnetUsersProvider.GetByApplicationIdLoweredUserName(_applicationId, _loweredUserName);
					results = new TList<AspnetUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetUsersSelectMethod.GetByApplicationIdLastActivityDate:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					_lastActivityDate = ( values["LastActivityDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["LastActivityDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = AspnetUsersProvider.GetByApplicationIdLastActivityDate(_applicationId, _lastActivityDate, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case AspnetUsersSelectMethod.GetByApplicationId:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetUsersProvider.GetByApplicationId(_applicationId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case AspnetUsersSelectMethod.GetByRoleIdFromAspnetUsersInRoles:
					_roleId = ( values["RoleId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["RoleId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetUsersProvider.GetByRoleIdFromAspnetUsersInRoles(_roleId, this.StartIndex, this.PageSize, out count);
					break;
				case AspnetUsersSelectMethod.GetByGroupIdFromResults:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					results = AspnetUsersProvider.GetByGroupIdFromResults(_groupId, this.StartIndex, this.PageSize, out count);
					break;
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == AspnetUsersSelectMethod.Get || SelectMethod == AspnetUsersSelectMethod.GetByUserId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetUsers entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.UserId == Guid.Empty )
				entity.UserId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetUsers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetUsersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<AspnetUsers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetUsersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetUsersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetUsersDataSource class.
	/// </summary>
	public class AspnetUsersDataSourceDesigner : ProviderDataSourceDesigner<AspnetUsers, AspnetUsersKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetUsersDataSourceDesigner class.
		/// </summary>
		public AspnetUsersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetUsersSelectMethod SelectMethod
		{
			get { return ((AspnetUsersDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new AspnetUsersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetUsersDataSourceActionList

	/// <summary>
	/// Supports the AspnetUsersDataSourceDesigner class.
	/// </summary>
	internal class AspnetUsersDataSourceActionList : DesignerActionList
	{
		private AspnetUsersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetUsersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetUsersDataSourceActionList(AspnetUsersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetUsersSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion AspnetUsersDataSourceActionList
	
	#endregion AspnetUsersDataSourceDesigner
	
	#region AspnetUsersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetUsersDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetUsersSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByApplicationIdLoweredUserName method.
		/// </summary>
		GetByApplicationIdLoweredUserName,
		/// <summary>
		/// Represents the GetByApplicationIdLastActivityDate method.
		/// </summary>
		GetByApplicationIdLastActivityDate,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId,
		/// <summary>
		/// Represents the GetByRoleIdFromAspnetUsersInRoles method.
		/// </summary>
		GetByRoleIdFromAspnetUsersInRoles,
		/// <summary>
		/// Represents the GetByGroupIdFromResults method.
		/// </summary>
		GetByGroupIdFromResults
	}
	
	#endregion AspnetUsersSelectMethod

	#region AspnetUsersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersFilter : SqlFilter<AspnetUsersColumn>
	{
	}
	
	#endregion AspnetUsersFilter

	#region AspnetUsersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersExpressionBuilder : SqlExpressionBuilder<AspnetUsersColumn>
	{
	}
	
	#endregion AspnetUsersExpressionBuilder	

	#region AspnetUsersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetUsersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersProperty : ChildEntityProperty<AspnetUsersChildEntityTypes>
	{
	}
	
	#endregion AspnetUsersProperty
}

