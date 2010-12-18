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
	/// Represents the DataRepository.AspnetUsersInRolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetUsersInRolesDataSourceDesigner))]
	public class AspnetUsersInRolesDataSource : ProviderDataSource<AspnetUsersInRoles, AspnetUsersInRolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesDataSource class.
		/// </summary>
		public AspnetUsersInRolesDataSource() : base(new AspnetUsersInRolesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetUsersInRolesDataSourceView used by the AspnetUsersInRolesDataSource.
		/// </summary>
		protected AspnetUsersInRolesDataSourceView AspnetUsersInRolesView
		{
			get { return ( View as AspnetUsersInRolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetUsersInRolesDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetUsersInRolesSelectMethod SelectMethod
		{
			get
			{
				AspnetUsersInRolesSelectMethod selectMethod = AspnetUsersInRolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetUsersInRolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetUsersInRolesDataSourceView class that is to be
		/// used by the AspnetUsersInRolesDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetUsersInRolesDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetUsersInRoles, AspnetUsersInRolesKey> GetNewDataSourceView()
		{
			return new AspnetUsersInRolesDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetUsersInRolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetUsersInRolesDataSourceView : ProviderDataSourceView<AspnetUsersInRoles, AspnetUsersInRolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetUsersInRolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetUsersInRolesDataSourceView(AspnetUsersInRolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetUsersInRolesDataSource AspnetUsersInRolesOwner
		{
			get { return Owner as AspnetUsersInRolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetUsersInRolesSelectMethod SelectMethod
		{
			get { return AspnetUsersInRolesOwner.SelectMethod; }
			set { AspnetUsersInRolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetUsersInRolesService AspnetUsersInRolesProvider
		{
			get { return Provider as AspnetUsersInRolesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetUsersInRoles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetUsersInRoles> results = null;
			AspnetUsersInRoles item;
			count = 0;
			
			System.Guid _roleId;
			System.Guid _userId;

			switch ( SelectMethod )
			{
				case AspnetUsersInRolesSelectMethod.Get:
					AspnetUsersInRolesKey entityKey  = new AspnetUsersInRolesKey();
					entityKey.Load(values);
					item = AspnetUsersInRolesProvider.Get(entityKey);
					results = new TList<AspnetUsersInRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetUsersInRolesSelectMethod.GetAll:
                    results = AspnetUsersInRolesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetUsersInRolesSelectMethod.GetPaged:
					results = AspnetUsersInRolesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetUsersInRolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetUsersInRolesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetUsersInRolesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetUsersInRolesSelectMethod.GetByUserIdRoleId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					_roleId = ( values["RoleId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["RoleId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetUsersInRolesProvider.GetByUserIdRoleId(_userId, _roleId);
					results = new TList<AspnetUsersInRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetUsersInRolesSelectMethod.GetByRoleId:
					_roleId = ( values["RoleId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["RoleId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetUsersInRolesProvider.GetByRoleId(_roleId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case AspnetUsersInRolesSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetUsersInRolesProvider.GetByUserId(_userId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
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
			if ( SelectMethod == AspnetUsersInRolesSelectMethod.Get || SelectMethod == AspnetUsersInRolesSelectMethod.GetByUserIdRoleId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetUsersInRoles entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.UserId == Guid.Empty )
				entity.UserId = Guid.NewGuid();
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
				AspnetUsersInRoles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetUsersInRolesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetUsersInRoles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetUsersInRolesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetUsersInRolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetUsersInRolesDataSource class.
	/// </summary>
	public class AspnetUsersInRolesDataSourceDesigner : ProviderDataSourceDesigner<AspnetUsersInRoles, AspnetUsersInRolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesDataSourceDesigner class.
		/// </summary>
		public AspnetUsersInRolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetUsersInRolesSelectMethod SelectMethod
		{
			get { return ((AspnetUsersInRolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetUsersInRolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetUsersInRolesDataSourceActionList

	/// <summary>
	/// Supports the AspnetUsersInRolesDataSourceDesigner class.
	/// </summary>
	internal class AspnetUsersInRolesDataSourceActionList : DesignerActionList
	{
		private AspnetUsersInRolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetUsersInRolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetUsersInRolesDataSourceActionList(AspnetUsersInRolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetUsersInRolesSelectMethod SelectMethod
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

	#endregion AspnetUsersInRolesDataSourceActionList
	
	#endregion AspnetUsersInRolesDataSourceDesigner
	
	#region AspnetUsersInRolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetUsersInRolesDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetUsersInRolesSelectMethod
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
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId,
		/// <summary>
		/// Represents the GetByUserIdRoleId method.
		/// </summary>
		GetByUserIdRoleId,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId
	}
	
	#endregion AspnetUsersInRolesSelectMethod

	#region AspnetUsersInRolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsersInRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersInRolesFilter : SqlFilter<AspnetUsersInRolesColumn>
	{
	}
	
	#endregion AspnetUsersInRolesFilter

	#region AspnetUsersInRolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsersInRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersInRolesExpressionBuilder : SqlExpressionBuilder<AspnetUsersInRolesColumn>
	{
	}
	
	#endregion AspnetUsersInRolesExpressionBuilder	

	#region AspnetUsersInRolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetUsersInRolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetUsersInRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetUsersInRolesProperty : ChildEntityProperty<AspnetUsersInRolesChildEntityTypes>
	{
	}
	
	#endregion AspnetUsersInRolesProperty
}

