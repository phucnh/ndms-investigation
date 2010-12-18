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
	/// Represents the DataRepository.AspnetApplicationsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetApplicationsDataSourceDesigner))]
	public class AspnetApplicationsDataSource : ProviderDataSource<AspnetApplications, AspnetApplicationsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsDataSource class.
		/// </summary>
		public AspnetApplicationsDataSource() : base(new AspnetApplicationsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetApplicationsDataSourceView used by the AspnetApplicationsDataSource.
		/// </summary>
		protected AspnetApplicationsDataSourceView AspnetApplicationsView
		{
			get { return ( View as AspnetApplicationsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetApplicationsDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetApplicationsSelectMethod SelectMethod
		{
			get
			{
				AspnetApplicationsSelectMethod selectMethod = AspnetApplicationsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetApplicationsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetApplicationsDataSourceView class that is to be
		/// used by the AspnetApplicationsDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetApplicationsDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetApplications, AspnetApplicationsKey> GetNewDataSourceView()
		{
			return new AspnetApplicationsDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetApplicationsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetApplicationsDataSourceView : ProviderDataSourceView<AspnetApplications, AspnetApplicationsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetApplicationsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetApplicationsDataSourceView(AspnetApplicationsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetApplicationsDataSource AspnetApplicationsOwner
		{
			get { return Owner as AspnetApplicationsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetApplicationsSelectMethod SelectMethod
		{
			get { return AspnetApplicationsOwner.SelectMethod; }
			set { AspnetApplicationsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetApplicationsService AspnetApplicationsProvider
		{
			get { return Provider as AspnetApplicationsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetApplications> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetApplications> results = null;
			AspnetApplications item;
			count = 0;
			
			System.String _loweredApplicationName;
			System.Guid _applicationId;
			System.String _applicationName;

			switch ( SelectMethod )
			{
				case AspnetApplicationsSelectMethod.Get:
					AspnetApplicationsKey entityKey  = new AspnetApplicationsKey();
					entityKey.Load(values);
					item = AspnetApplicationsProvider.Get(entityKey);
					results = new TList<AspnetApplications>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetApplicationsSelectMethod.GetAll:
                    results = AspnetApplicationsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetApplicationsSelectMethod.GetPaged:
					results = AspnetApplicationsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetApplicationsSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetApplicationsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetApplicationsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetApplicationsSelectMethod.GetByApplicationId:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetApplicationsProvider.GetByApplicationId(_applicationId);
					results = new TList<AspnetApplications>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetApplicationsSelectMethod.GetByLoweredApplicationName:
					_loweredApplicationName = ( values["LoweredApplicationName"] != null ) ? (System.String) EntityUtil.ChangeType(values["LoweredApplicationName"], typeof(System.String)) : string.Empty;
					results = AspnetApplicationsProvider.GetByLoweredApplicationName(_loweredApplicationName, this.StartIndex, this.PageSize, out count);
					break;
				case AspnetApplicationsSelectMethod.GetByApplicationName:
					_applicationName = ( values["ApplicationName"] != null ) ? (System.String) EntityUtil.ChangeType(values["ApplicationName"], typeof(System.String)) : string.Empty;
					item = AspnetApplicationsProvider.GetByApplicationName(_applicationName);
					results = new TList<AspnetApplications>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
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
			if ( SelectMethod == AspnetApplicationsSelectMethod.Get || SelectMethod == AspnetApplicationsSelectMethod.GetByApplicationId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetApplications entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.ApplicationId == Guid.Empty )
				entity.ApplicationId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetApplications entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetApplicationsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetApplications> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetApplicationsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetApplicationsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetApplicationsDataSource class.
	/// </summary>
	public class AspnetApplicationsDataSourceDesigner : ProviderDataSourceDesigner<AspnetApplications, AspnetApplicationsKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsDataSourceDesigner class.
		/// </summary>
		public AspnetApplicationsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetApplicationsSelectMethod SelectMethod
		{
			get { return ((AspnetApplicationsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetApplicationsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetApplicationsDataSourceActionList

	/// <summary>
	/// Supports the AspnetApplicationsDataSourceDesigner class.
	/// </summary>
	internal class AspnetApplicationsDataSourceActionList : DesignerActionList
	{
		private AspnetApplicationsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetApplicationsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetApplicationsDataSourceActionList(AspnetApplicationsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetApplicationsSelectMethod SelectMethod
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

	#endregion AspnetApplicationsDataSourceActionList
	
	#endregion AspnetApplicationsDataSourceDesigner
	
	#region AspnetApplicationsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetApplicationsDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetApplicationsSelectMethod
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
		/// Represents the GetByLoweredApplicationName method.
		/// </summary>
		GetByLoweredApplicationName,
		/// <summary>
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId,
		/// <summary>
		/// Represents the GetByApplicationName method.
		/// </summary>
		GetByApplicationName
	}
	
	#endregion AspnetApplicationsSelectMethod

	#region AspnetApplicationsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsFilter : SqlFilter<AspnetApplicationsColumn>
	{
	}
	
	#endregion AspnetApplicationsFilter

	#region AspnetApplicationsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsExpressionBuilder : SqlExpressionBuilder<AspnetApplicationsColumn>
	{
	}
	
	#endregion AspnetApplicationsExpressionBuilder	

	#region AspnetApplicationsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetApplicationsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetApplications"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetApplicationsProperty : ChildEntityProperty<AspnetApplicationsChildEntityTypes>
	{
	}
	
	#endregion AspnetApplicationsProperty
}

