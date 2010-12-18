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
	/// Represents the DataRepository.AspnetRolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetRolesDataSourceDesigner))]
	public class AspnetRolesDataSource : ProviderDataSource<AspnetRoles, AspnetRolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesDataSource class.
		/// </summary>
		public AspnetRolesDataSource() : base(new AspnetRolesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetRolesDataSourceView used by the AspnetRolesDataSource.
		/// </summary>
		protected AspnetRolesDataSourceView AspnetRolesView
		{
			get { return ( View as AspnetRolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetRolesDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetRolesSelectMethod SelectMethod
		{
			get
			{
				AspnetRolesSelectMethod selectMethod = AspnetRolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetRolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetRolesDataSourceView class that is to be
		/// used by the AspnetRolesDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetRolesDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetRoles, AspnetRolesKey> GetNewDataSourceView()
		{
			return new AspnetRolesDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetRolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetRolesDataSourceView : ProviderDataSourceView<AspnetRoles, AspnetRolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetRolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetRolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetRolesDataSourceView(AspnetRolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetRolesDataSource AspnetRolesOwner
		{
			get { return Owner as AspnetRolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetRolesSelectMethod SelectMethod
		{
			get { return AspnetRolesOwner.SelectMethod; }
			set { AspnetRolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetRolesService AspnetRolesProvider
		{
			get { return Provider as AspnetRolesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetRoles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetRoles> results = null;
			AspnetRoles item;
			count = 0;
			
			System.Guid _applicationId;
			System.String _loweredRoleName;
			System.Guid _roleId;
			System.Guid _userId;

			switch ( SelectMethod )
			{
				case AspnetRolesSelectMethod.Get:
					AspnetRolesKey entityKey  = new AspnetRolesKey();
					entityKey.Load(values);
					item = AspnetRolesProvider.Get(entityKey);
					results = new TList<AspnetRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetRolesSelectMethod.GetAll:
                    results = AspnetRolesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetRolesSelectMethod.GetPaged:
					results = AspnetRolesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetRolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetRolesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetRolesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetRolesSelectMethod.GetByRoleId:
					_roleId = ( values["RoleId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["RoleId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetRolesProvider.GetByRoleId(_roleId);
					results = new TList<AspnetRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetRolesSelectMethod.GetByApplicationIdLoweredRoleName:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					_loweredRoleName = ( values["LoweredRoleName"] != null ) ? (System.String) EntityUtil.ChangeType(values["LoweredRoleName"], typeof(System.String)) : string.Empty;
					item = AspnetRolesProvider.GetByApplicationIdLoweredRoleName(_applicationId, _loweredRoleName);
					results = new TList<AspnetRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case AspnetRolesSelectMethod.GetByApplicationId:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetRolesProvider.GetByApplicationId(_applicationId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case AspnetRolesSelectMethod.GetByUserIdFromAspnetUsersInRoles:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetRolesProvider.GetByUserIdFromAspnetUsersInRoles(_userId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AspnetRolesSelectMethod.Get || SelectMethod == AspnetRolesSelectMethod.GetByRoleId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetRoles entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.RoleId == Guid.Empty )
				entity.RoleId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetRoles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetRolesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetRoles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetRolesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetRolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetRolesDataSource class.
	/// </summary>
	public class AspnetRolesDataSourceDesigner : ProviderDataSourceDesigner<AspnetRoles, AspnetRolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetRolesDataSourceDesigner class.
		/// </summary>
		public AspnetRolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetRolesSelectMethod SelectMethod
		{
			get { return ((AspnetRolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetRolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetRolesDataSourceActionList

	/// <summary>
	/// Supports the AspnetRolesDataSourceDesigner class.
	/// </summary>
	internal class AspnetRolesDataSourceActionList : DesignerActionList
	{
		private AspnetRolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetRolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetRolesDataSourceActionList(AspnetRolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetRolesSelectMethod SelectMethod
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

	#endregion AspnetRolesDataSourceActionList
	
	#endregion AspnetRolesDataSourceDesigner
	
	#region AspnetRolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetRolesDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetRolesSelectMethod
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
		/// Represents the GetByApplicationIdLoweredRoleName method.
		/// </summary>
		GetByApplicationIdLoweredRoleName,
		/// <summary>
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId,
		/// <summary>
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId,
		/// <summary>
		/// Represents the GetByUserIdFromAspnetUsersInRoles method.
		/// </summary>
		GetByUserIdFromAspnetUsersInRoles
	}
	
	#endregion AspnetRolesSelectMethod

	#region AspnetRolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesFilter : SqlFilter<AspnetRolesColumn>
	{
	}
	
	#endregion AspnetRolesFilter

	#region AspnetRolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesExpressionBuilder : SqlExpressionBuilder<AspnetRolesColumn>
	{
	}
	
	#endregion AspnetRolesExpressionBuilder	

	#region AspnetRolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetRolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetRolesProperty : ChildEntityProperty<AspnetRolesChildEntityTypes>
	{
	}
	
	#endregion AspnetRolesProperty
}

