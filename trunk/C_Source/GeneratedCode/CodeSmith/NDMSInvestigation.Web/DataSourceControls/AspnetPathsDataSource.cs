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
	/// Represents the DataRepository.AspnetPathsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetPathsDataSourceDesigner))]
	public class AspnetPathsDataSource : ProviderDataSource<AspnetPaths, AspnetPathsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsDataSource class.
		/// </summary>
		public AspnetPathsDataSource() : base(new AspnetPathsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetPathsDataSourceView used by the AspnetPathsDataSource.
		/// </summary>
		protected AspnetPathsDataSourceView AspnetPathsView
		{
			get { return ( View as AspnetPathsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetPathsDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetPathsSelectMethod SelectMethod
		{
			get
			{
				AspnetPathsSelectMethod selectMethod = AspnetPathsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetPathsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetPathsDataSourceView class that is to be
		/// used by the AspnetPathsDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetPathsDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetPaths, AspnetPathsKey> GetNewDataSourceView()
		{
			return new AspnetPathsDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetPathsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetPathsDataSourceView : ProviderDataSourceView<AspnetPaths, AspnetPathsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPathsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetPathsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetPathsDataSourceView(AspnetPathsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetPathsDataSource AspnetPathsOwner
		{
			get { return Owner as AspnetPathsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetPathsSelectMethod SelectMethod
		{
			get { return AspnetPathsOwner.SelectMethod; }
			set { AspnetPathsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetPathsService AspnetPathsProvider
		{
			get { return Provider as AspnetPathsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetPaths> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetPaths> results = null;
			AspnetPaths item;
			count = 0;
			
			System.Guid _applicationId;
			System.String _loweredPath;
			System.Guid _pathId;

			switch ( SelectMethod )
			{
				case AspnetPathsSelectMethod.Get:
					AspnetPathsKey entityKey  = new AspnetPathsKey();
					entityKey.Load(values);
					item = AspnetPathsProvider.Get(entityKey);
					results = new TList<AspnetPaths>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetPathsSelectMethod.GetAll:
                    results = AspnetPathsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetPathsSelectMethod.GetPaged:
					results = AspnetPathsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetPathsSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetPathsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetPathsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetPathsSelectMethod.GetByPathId:
					_pathId = ( values["PathId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["PathId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetPathsProvider.GetByPathId(_pathId);
					results = new TList<AspnetPaths>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetPathsSelectMethod.GetByApplicationIdLoweredPath:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					_loweredPath = ( values["LoweredPath"] != null ) ? (System.String) EntityUtil.ChangeType(values["LoweredPath"], typeof(System.String)) : string.Empty;
					item = AspnetPathsProvider.GetByApplicationIdLoweredPath(_applicationId, _loweredPath);
					results = new TList<AspnetPaths>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case AspnetPathsSelectMethod.GetByApplicationId:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetPathsProvider.GetByApplicationId(_applicationId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AspnetPathsSelectMethod.Get || SelectMethod == AspnetPathsSelectMethod.GetByPathId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetPaths entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.PathId == Guid.Empty )
				entity.PathId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetPaths entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetPathsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetPaths> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetPathsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetPathsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetPathsDataSource class.
	/// </summary>
	public class AspnetPathsDataSourceDesigner : ProviderDataSourceDesigner<AspnetPaths, AspnetPathsKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetPathsDataSourceDesigner class.
		/// </summary>
		public AspnetPathsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetPathsSelectMethod SelectMethod
		{
			get { return ((AspnetPathsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetPathsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetPathsDataSourceActionList

	/// <summary>
	/// Supports the AspnetPathsDataSourceDesigner class.
	/// </summary>
	internal class AspnetPathsDataSourceActionList : DesignerActionList
	{
		private AspnetPathsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetPathsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetPathsDataSourceActionList(AspnetPathsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetPathsSelectMethod SelectMethod
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

	#endregion AspnetPathsDataSourceActionList
	
	#endregion AspnetPathsDataSourceDesigner
	
	#region AspnetPathsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetPathsDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetPathsSelectMethod
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
		/// Represents the GetByApplicationIdLoweredPath method.
		/// </summary>
		GetByApplicationIdLoweredPath,
		/// <summary>
		/// Represents the GetByPathId method.
		/// </summary>
		GetByPathId,
		/// <summary>
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId
	}
	
	#endregion AspnetPathsSelectMethod

	#region AspnetPathsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsFilter : SqlFilter<AspnetPathsColumn>
	{
	}
	
	#endregion AspnetPathsFilter

	#region AspnetPathsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsExpressionBuilder : SqlExpressionBuilder<AspnetPathsColumn>
	{
	}
	
	#endregion AspnetPathsExpressionBuilder	

	#region AspnetPathsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetPathsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPaths"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPathsProperty : ChildEntityProperty<AspnetPathsChildEntityTypes>
	{
	}
	
	#endregion AspnetPathsProperty
}

