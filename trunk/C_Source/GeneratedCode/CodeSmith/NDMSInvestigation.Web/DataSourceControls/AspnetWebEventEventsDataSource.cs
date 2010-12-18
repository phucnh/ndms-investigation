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
	/// Represents the DataRepository.AspnetWebEventEventsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetWebEventEventsDataSourceDesigner))]
	public class AspnetWebEventEventsDataSource : ProviderDataSource<AspnetWebEventEvents, AspnetWebEventEventsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsDataSource class.
		/// </summary>
		public AspnetWebEventEventsDataSource() : base(new AspnetWebEventEventsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetWebEventEventsDataSourceView used by the AspnetWebEventEventsDataSource.
		/// </summary>
		protected AspnetWebEventEventsDataSourceView AspnetWebEventEventsView
		{
			get { return ( View as AspnetWebEventEventsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetWebEventEventsDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetWebEventEventsSelectMethod SelectMethod
		{
			get
			{
				AspnetWebEventEventsSelectMethod selectMethod = AspnetWebEventEventsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetWebEventEventsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetWebEventEventsDataSourceView class that is to be
		/// used by the AspnetWebEventEventsDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetWebEventEventsDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetWebEventEvents, AspnetWebEventEventsKey> GetNewDataSourceView()
		{
			return new AspnetWebEventEventsDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetWebEventEventsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetWebEventEventsDataSourceView : ProviderDataSourceView<AspnetWebEventEvents, AspnetWebEventEventsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetWebEventEventsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetWebEventEventsDataSourceView(AspnetWebEventEventsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetWebEventEventsDataSource AspnetWebEventEventsOwner
		{
			get { return Owner as AspnetWebEventEventsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetWebEventEventsSelectMethod SelectMethod
		{
			get { return AspnetWebEventEventsOwner.SelectMethod; }
			set { AspnetWebEventEventsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetWebEventEventsService AspnetWebEventEventsProvider
		{
			get { return Provider as AspnetWebEventEventsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetWebEventEvents> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetWebEventEvents> results = null;
			AspnetWebEventEvents item;
			count = 0;
			
			System.String _eventId;

			switch ( SelectMethod )
			{
				case AspnetWebEventEventsSelectMethod.Get:
					AspnetWebEventEventsKey entityKey  = new AspnetWebEventEventsKey();
					entityKey.Load(values);
					item = AspnetWebEventEventsProvider.Get(entityKey);
					results = new TList<AspnetWebEventEvents>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetWebEventEventsSelectMethod.GetAll:
                    results = AspnetWebEventEventsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetWebEventEventsSelectMethod.GetPaged:
					results = AspnetWebEventEventsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetWebEventEventsSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetWebEventEventsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetWebEventEventsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetWebEventEventsSelectMethod.GetByEventId:
					_eventId = ( values["EventId"] != null ) ? (System.String) EntityUtil.ChangeType(values["EventId"], typeof(System.String)) : string.Empty;
					item = AspnetWebEventEventsProvider.GetByEventId(_eventId);
					results = new TList<AspnetWebEventEvents>();
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
			if ( SelectMethod == AspnetWebEventEventsSelectMethod.Get || SelectMethod == AspnetWebEventEventsSelectMethod.GetByEventId )
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
				AspnetWebEventEvents entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetWebEventEventsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetWebEventEvents> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetWebEventEventsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetWebEventEventsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetWebEventEventsDataSource class.
	/// </summary>
	public class AspnetWebEventEventsDataSourceDesigner : ProviderDataSourceDesigner<AspnetWebEventEvents, AspnetWebEventEventsKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsDataSourceDesigner class.
		/// </summary>
		public AspnetWebEventEventsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetWebEventEventsSelectMethod SelectMethod
		{
			get { return ((AspnetWebEventEventsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetWebEventEventsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetWebEventEventsDataSourceActionList

	/// <summary>
	/// Supports the AspnetWebEventEventsDataSourceDesigner class.
	/// </summary>
	internal class AspnetWebEventEventsDataSourceActionList : DesignerActionList
	{
		private AspnetWebEventEventsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetWebEventEventsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetWebEventEventsDataSourceActionList(AspnetWebEventEventsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetWebEventEventsSelectMethod SelectMethod
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

	#endregion AspnetWebEventEventsDataSourceActionList
	
	#endregion AspnetWebEventEventsDataSourceDesigner
	
	#region AspnetWebEventEventsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetWebEventEventsDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetWebEventEventsSelectMethod
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
		/// Represents the GetByEventId method.
		/// </summary>
		GetByEventId
	}
	
	#endregion AspnetWebEventEventsSelectMethod

	#region AspnetWebEventEventsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsFilter : SqlFilter<AspnetWebEventEventsColumn>
	{
	}
	
	#endregion AspnetWebEventEventsFilter

	#region AspnetWebEventEventsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsExpressionBuilder : SqlExpressionBuilder<AspnetWebEventEventsColumn>
	{
	}
	
	#endregion AspnetWebEventEventsExpressionBuilder	

	#region AspnetWebEventEventsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetWebEventEventsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetWebEventEvents"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetWebEventEventsProperty : ChildEntityProperty<AspnetWebEventEventsChildEntityTypes>
	{
	}
	
	#endregion AspnetWebEventEventsProperty
}

