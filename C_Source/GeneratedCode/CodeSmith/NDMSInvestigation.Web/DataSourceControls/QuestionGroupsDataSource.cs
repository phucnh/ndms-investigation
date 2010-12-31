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
	/// Represents the DataRepository.QuestionGroupsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(QuestionGroupsDataSourceDesigner))]
	public class QuestionGroupsDataSource : ProviderDataSource<QuestionGroups, QuestionGroupsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsDataSource class.
		/// </summary>
		public QuestionGroupsDataSource() : base(new QuestionGroupsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the QuestionGroupsDataSourceView used by the QuestionGroupsDataSource.
		/// </summary>
		protected QuestionGroupsDataSourceView QuestionGroupsView
		{
			get { return ( View as QuestionGroupsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the QuestionGroupsDataSource control invokes to retrieve data.
		/// </summary>
		public QuestionGroupsSelectMethod SelectMethod
		{
			get
			{
				QuestionGroupsSelectMethod selectMethod = QuestionGroupsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (QuestionGroupsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the QuestionGroupsDataSourceView class that is to be
		/// used by the QuestionGroupsDataSource.
		/// </summary>
		/// <returns>An instance of the QuestionGroupsDataSourceView class.</returns>
		protected override BaseDataSourceView<QuestionGroups, QuestionGroupsKey> GetNewDataSourceView()
		{
			return new QuestionGroupsDataSourceView(this, DefaultViewName);
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
	/// Supports the QuestionGroupsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class QuestionGroupsDataSourceView : ProviderDataSourceView<QuestionGroups, QuestionGroupsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the QuestionGroupsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public QuestionGroupsDataSourceView(QuestionGroupsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal QuestionGroupsDataSource QuestionGroupsOwner
		{
			get { return Owner as QuestionGroupsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal QuestionGroupsSelectMethod SelectMethod
		{
			get { return QuestionGroupsOwner.SelectMethod; }
			set { QuestionGroupsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal QuestionGroupsService QuestionGroupsProvider
		{
			get { return Provider as QuestionGroupsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<QuestionGroups> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<QuestionGroups> results = null;
			QuestionGroups item;
			count = 0;
			
			System.Int32? _orderNumber_nullable;
			System.Int32 _groupId;
			System.Guid _userId;

			switch ( SelectMethod )
			{
				case QuestionGroupsSelectMethod.Get:
					QuestionGroupsKey entityKey  = new QuestionGroupsKey();
					entityKey.Load(values);
					item = QuestionGroupsProvider.Get(entityKey);
					results = new TList<QuestionGroups>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case QuestionGroupsSelectMethod.GetAll:
                    results = QuestionGroupsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case QuestionGroupsSelectMethod.GetPaged:
					results = QuestionGroupsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case QuestionGroupsSelectMethod.Find:
					if ( FilterParameters != null )
						results = QuestionGroupsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = QuestionGroupsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case QuestionGroupsSelectMethod.GetByGroupId:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					item = QuestionGroupsProvider.GetByGroupId(_groupId);
					results = new TList<QuestionGroups>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case QuestionGroupsSelectMethod.GetByOrderNumber:
					_orderNumber_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderNumber"], typeof(System.Int32?));
					item = QuestionGroupsProvider.GetByOrderNumber(_orderNumber_nullable);
					results = new TList<QuestionGroups>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case QuestionGroupsSelectMethod.GetByUserIdFromResults:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					results = QuestionGroupsProvider.GetByUserIdFromResults(_userId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == QuestionGroupsSelectMethod.Get || SelectMethod == QuestionGroupsSelectMethod.GetByGroupId )
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
				QuestionGroups entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					QuestionGroupsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<QuestionGroups> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			QuestionGroupsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region QuestionGroupsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the QuestionGroupsDataSource class.
	/// </summary>
	public class QuestionGroupsDataSourceDesigner : ProviderDataSourceDesigner<QuestionGroups, QuestionGroupsKey>
	{
		/// <summary>
		/// Initializes a new instance of the QuestionGroupsDataSourceDesigner class.
		/// </summary>
		public QuestionGroupsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionGroupsSelectMethod SelectMethod
		{
			get { return ((QuestionGroupsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new QuestionGroupsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region QuestionGroupsDataSourceActionList

	/// <summary>
	/// Supports the QuestionGroupsDataSourceDesigner class.
	/// </summary>
	internal class QuestionGroupsDataSourceActionList : DesignerActionList
	{
		private QuestionGroupsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the QuestionGroupsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public QuestionGroupsDataSourceActionList(QuestionGroupsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionGroupsSelectMethod SelectMethod
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

	#endregion QuestionGroupsDataSourceActionList
	
	#endregion QuestionGroupsDataSourceDesigner
	
	#region QuestionGroupsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the QuestionGroupsDataSource.SelectMethod property.
	/// </summary>
	public enum QuestionGroupsSelectMethod
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
		/// Represents the GetByOrderNumber method.
		/// </summary>
		GetByOrderNumber,
		/// <summary>
		/// Represents the GetByGroupId method.
		/// </summary>
		GetByGroupId,
		/// <summary>
		/// Represents the GetByUserIdFromResults method.
		/// </summary>
		GetByUserIdFromResults
	}
	
	#endregion QuestionGroupsSelectMethod

	#region QuestionGroupsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupsFilter : SqlFilter<QuestionGroupsColumn>
	{
	}
	
	#endregion QuestionGroupsFilter

	#region QuestionGroupsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupsExpressionBuilder : SqlExpressionBuilder<QuestionGroupsColumn>
	{
	}
	
	#endregion QuestionGroupsExpressionBuilder	

	#region QuestionGroupsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;QuestionGroupsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroups"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupsProperty : ChildEntityProperty<QuestionGroupsChildEntityTypes>
	{
	}
	
	#endregion QuestionGroupsProperty
}

