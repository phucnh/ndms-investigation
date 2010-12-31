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
	/// Represents the DataRepository.TraceChangeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TraceChangeDataSourceDesigner))]
	public class TraceChangeDataSource : ProviderDataSource<TraceChange, TraceChangeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TraceChangeDataSource class.
		/// </summary>
		public TraceChangeDataSource() : base(new TraceChangeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TraceChangeDataSourceView used by the TraceChangeDataSource.
		/// </summary>
		protected TraceChangeDataSourceView TraceChangeView
		{
			get { return ( View as TraceChangeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TraceChangeDataSource control invokes to retrieve data.
		/// </summary>
		public TraceChangeSelectMethod SelectMethod
		{
			get
			{
				TraceChangeSelectMethod selectMethod = TraceChangeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TraceChangeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TraceChangeDataSourceView class that is to be
		/// used by the TraceChangeDataSource.
		/// </summary>
		/// <returns>An instance of the TraceChangeDataSourceView class.</returns>
		protected override BaseDataSourceView<TraceChange, TraceChangeKey> GetNewDataSourceView()
		{
			return new TraceChangeDataSourceView(this, DefaultViewName);
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
	/// Supports the TraceChangeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TraceChangeDataSourceView : ProviderDataSourceView<TraceChange, TraceChangeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TraceChangeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TraceChangeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TraceChangeDataSourceView(TraceChangeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TraceChangeDataSource TraceChangeOwner
		{
			get { return Owner as TraceChangeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TraceChangeSelectMethod SelectMethod
		{
			get { return TraceChangeOwner.SelectMethod; }
			set { TraceChangeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TraceChangeService TraceChangeProvider
		{
			get { return Provider as TraceChangeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TraceChange> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TraceChange> results = null;
			TraceChange item;
			count = 0;
			
			System.Int32 _traceId;

			switch ( SelectMethod )
			{
				case TraceChangeSelectMethod.Get:
					TraceChangeKey entityKey  = new TraceChangeKey();
					entityKey.Load(values);
					item = TraceChangeProvider.Get(entityKey);
					results = new TList<TraceChange>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TraceChangeSelectMethod.GetAll:
                    results = TraceChangeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TraceChangeSelectMethod.GetPaged:
					results = TraceChangeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TraceChangeSelectMethod.Find:
					if ( FilterParameters != null )
						results = TraceChangeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TraceChangeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TraceChangeSelectMethod.GetByTraceId:
					_traceId = ( values["TraceId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TraceId"], typeof(System.Int32)) : (int)0;
					item = TraceChangeProvider.GetByTraceId(_traceId);
					results = new TList<TraceChange>();
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
			if ( SelectMethod == TraceChangeSelectMethod.Get || SelectMethod == TraceChangeSelectMethod.GetByTraceId )
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
				TraceChange entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TraceChangeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TraceChange> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TraceChangeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TraceChangeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TraceChangeDataSource class.
	/// </summary>
	public class TraceChangeDataSourceDesigner : ProviderDataSourceDesigner<TraceChange, TraceChangeKey>
	{
		/// <summary>
		/// Initializes a new instance of the TraceChangeDataSourceDesigner class.
		/// </summary>
		public TraceChangeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TraceChangeSelectMethod SelectMethod
		{
			get { return ((TraceChangeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TraceChangeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TraceChangeDataSourceActionList

	/// <summary>
	/// Supports the TraceChangeDataSourceDesigner class.
	/// </summary>
	internal class TraceChangeDataSourceActionList : DesignerActionList
	{
		private TraceChangeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TraceChangeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TraceChangeDataSourceActionList(TraceChangeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TraceChangeSelectMethod SelectMethod
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

	#endregion TraceChangeDataSourceActionList
	
	#endregion TraceChangeDataSourceDesigner
	
	#region TraceChangeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TraceChangeDataSource.SelectMethod property.
	/// </summary>
	public enum TraceChangeSelectMethod
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
		/// Represents the GetByTraceId method.
		/// </summary>
		GetByTraceId
	}
	
	#endregion TraceChangeSelectMethod

	#region TraceChangeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TraceChange"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TraceChangeFilter : SqlFilter<TraceChangeColumn>
	{
	}
	
	#endregion TraceChangeFilter

	#region TraceChangeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TraceChange"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TraceChangeExpressionBuilder : SqlExpressionBuilder<TraceChangeColumn>
	{
	}
	
	#endregion TraceChangeExpressionBuilder	

	#region TraceChangeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TraceChangeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TraceChange"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TraceChangeProperty : ChildEntityProperty<TraceChangeChildEntityTypes>
	{
	}
	
	#endregion TraceChangeProperty
}

