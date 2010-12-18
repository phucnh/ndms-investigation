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
	/// Represents the DataRepository.AspnetSchemaVersionsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetSchemaVersionsDataSourceDesigner))]
	public class AspnetSchemaVersionsDataSource : ProviderDataSource<AspnetSchemaVersions, AspnetSchemaVersionsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsDataSource class.
		/// </summary>
		public AspnetSchemaVersionsDataSource() : base(new AspnetSchemaVersionsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetSchemaVersionsDataSourceView used by the AspnetSchemaVersionsDataSource.
		/// </summary>
		protected AspnetSchemaVersionsDataSourceView AspnetSchemaVersionsView
		{
			get { return ( View as AspnetSchemaVersionsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetSchemaVersionsDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetSchemaVersionsSelectMethod SelectMethod
		{
			get
			{
				AspnetSchemaVersionsSelectMethod selectMethod = AspnetSchemaVersionsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetSchemaVersionsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetSchemaVersionsDataSourceView class that is to be
		/// used by the AspnetSchemaVersionsDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetSchemaVersionsDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetSchemaVersions, AspnetSchemaVersionsKey> GetNewDataSourceView()
		{
			return new AspnetSchemaVersionsDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetSchemaVersionsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetSchemaVersionsDataSourceView : ProviderDataSourceView<AspnetSchemaVersions, AspnetSchemaVersionsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetSchemaVersionsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetSchemaVersionsDataSourceView(AspnetSchemaVersionsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetSchemaVersionsDataSource AspnetSchemaVersionsOwner
		{
			get { return Owner as AspnetSchemaVersionsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetSchemaVersionsSelectMethod SelectMethod
		{
			get { return AspnetSchemaVersionsOwner.SelectMethod; }
			set { AspnetSchemaVersionsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetSchemaVersionsService AspnetSchemaVersionsProvider
		{
			get { return Provider as AspnetSchemaVersionsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetSchemaVersions> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetSchemaVersions> results = null;
			AspnetSchemaVersions item;
			count = 0;
			
			System.String _feature;
			System.String _compatibleSchemaVersion;

			switch ( SelectMethod )
			{
				case AspnetSchemaVersionsSelectMethod.Get:
					AspnetSchemaVersionsKey entityKey  = new AspnetSchemaVersionsKey();
					entityKey.Load(values);
					item = AspnetSchemaVersionsProvider.Get(entityKey);
					results = new TList<AspnetSchemaVersions>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetSchemaVersionsSelectMethod.GetAll:
                    results = AspnetSchemaVersionsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetSchemaVersionsSelectMethod.GetPaged:
					results = AspnetSchemaVersionsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetSchemaVersionsSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetSchemaVersionsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetSchemaVersionsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetSchemaVersionsSelectMethod.GetByFeatureCompatibleSchemaVersion:
					_feature = ( values["Feature"] != null ) ? (System.String) EntityUtil.ChangeType(values["Feature"], typeof(System.String)) : string.Empty;
					_compatibleSchemaVersion = ( values["CompatibleSchemaVersion"] != null ) ? (System.String) EntityUtil.ChangeType(values["CompatibleSchemaVersion"], typeof(System.String)) : string.Empty;
					item = AspnetSchemaVersionsProvider.GetByFeatureCompatibleSchemaVersion(_feature, _compatibleSchemaVersion);
					results = new TList<AspnetSchemaVersions>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == AspnetSchemaVersionsSelectMethod.Get || SelectMethod == AspnetSchemaVersionsSelectMethod.GetByFeatureCompatibleSchemaVersion )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetSchemaVersions entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetSchemaVersionsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetSchemaVersions> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetSchemaVersionsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetSchemaVersionsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetSchemaVersionsDataSource class.
	/// </summary>
	public class AspnetSchemaVersionsDataSourceDesigner : ProviderDataSourceDesigner<AspnetSchemaVersions, AspnetSchemaVersionsKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsDataSourceDesigner class.
		/// </summary>
		public AspnetSchemaVersionsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetSchemaVersionsSelectMethod SelectMethod
		{
			get { return ((AspnetSchemaVersionsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetSchemaVersionsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetSchemaVersionsDataSourceActionList

	/// <summary>
	/// Supports the AspnetSchemaVersionsDataSourceDesigner class.
	/// </summary>
	internal class AspnetSchemaVersionsDataSourceActionList : DesignerActionList
	{
		private AspnetSchemaVersionsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetSchemaVersionsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetSchemaVersionsDataSourceActionList(AspnetSchemaVersionsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetSchemaVersionsSelectMethod SelectMethod
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

	#endregion AspnetSchemaVersionsDataSourceActionList
	
	#endregion AspnetSchemaVersionsDataSourceDesigner
	
	#region AspnetSchemaVersionsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetSchemaVersionsDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetSchemaVersionsSelectMethod
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
		/// Represents the GetByFeatureCompatibleSchemaVersion method.
		/// </summary>
		GetByFeatureCompatibleSchemaVersion
	}
	
	#endregion AspnetSchemaVersionsSelectMethod

	#region AspnetSchemaVersionsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsFilter : SqlFilter<AspnetSchemaVersionsColumn>
	{
	}
	
	#endregion AspnetSchemaVersionsFilter

	#region AspnetSchemaVersionsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsExpressionBuilder : SqlExpressionBuilder<AspnetSchemaVersionsColumn>
	{
	}
	
	#endregion AspnetSchemaVersionsExpressionBuilder	

	#region AspnetSchemaVersionsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetSchemaVersionsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetSchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetSchemaVersionsProperty : ChildEntityProperty<AspnetSchemaVersionsChildEntityTypes>
	{
	}
	
	#endregion AspnetSchemaVersionsProperty
}

