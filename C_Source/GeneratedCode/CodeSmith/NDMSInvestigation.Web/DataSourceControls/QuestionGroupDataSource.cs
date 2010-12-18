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
	/// Represents the DataRepository.QuestionGroupProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(QuestionGroupDataSourceDesigner))]
	public class QuestionGroupDataSource : ProviderDataSource<QuestionGroup, QuestionGroupKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupDataSource class.
		/// </summary>
		public QuestionGroupDataSource() : base(new QuestionGroupService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the QuestionGroupDataSourceView used by the QuestionGroupDataSource.
		/// </summary>
		protected QuestionGroupDataSourceView QuestionGroupView
		{
			get { return ( View as QuestionGroupDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the QuestionGroupDataSource control invokes to retrieve data.
		/// </summary>
		public QuestionGroupSelectMethod SelectMethod
		{
			get
			{
				QuestionGroupSelectMethod selectMethod = QuestionGroupSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (QuestionGroupSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the QuestionGroupDataSourceView class that is to be
		/// used by the QuestionGroupDataSource.
		/// </summary>
		/// <returns>An instance of the QuestionGroupDataSourceView class.</returns>
		protected override BaseDataSourceView<QuestionGroup, QuestionGroupKey> GetNewDataSourceView()
		{
			return new QuestionGroupDataSourceView(this, DefaultViewName);
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
	/// Supports the QuestionGroupDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class QuestionGroupDataSourceView : ProviderDataSourceView<QuestionGroup, QuestionGroupKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionGroupDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the QuestionGroupDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public QuestionGroupDataSourceView(QuestionGroupDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal QuestionGroupDataSource QuestionGroupOwner
		{
			get { return Owner as QuestionGroupDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal QuestionGroupSelectMethod SelectMethod
		{
			get { return QuestionGroupOwner.SelectMethod; }
			set { QuestionGroupOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal QuestionGroupService QuestionGroupProvider
		{
			get { return Provider as QuestionGroupService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<QuestionGroup> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<QuestionGroup> results = null;
			QuestionGroup item;
			count = 0;
			
			System.Int32? _orderNumber_nullable;
			System.Int32 _groupId;
			System.Guid _userId;

			switch ( SelectMethod )
			{
				case QuestionGroupSelectMethod.Get:
					QuestionGroupKey entityKey  = new QuestionGroupKey();
					entityKey.Load(values);
					item = QuestionGroupProvider.Get(entityKey);
					results = new TList<QuestionGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case QuestionGroupSelectMethod.GetAll:
                    results = QuestionGroupProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case QuestionGroupSelectMethod.GetPaged:
					results = QuestionGroupProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case QuestionGroupSelectMethod.Find:
					if ( FilterParameters != null )
						results = QuestionGroupProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = QuestionGroupProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case QuestionGroupSelectMethod.GetByGroupId:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					item = QuestionGroupProvider.GetByGroupId(_groupId);
					results = new TList<QuestionGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case QuestionGroupSelectMethod.GetByOrderNumber:
					_orderNumber_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderNumber"], typeof(System.Int32?));
					item = QuestionGroupProvider.GetByOrderNumber(_orderNumber_nullable);
					results = new TList<QuestionGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				// M:M
				case QuestionGroupSelectMethod.GetByUserIdFromResult:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					results = QuestionGroupProvider.GetByUserIdFromResult(_userId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == QuestionGroupSelectMethod.Get || SelectMethod == QuestionGroupSelectMethod.GetByGroupId )
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
				QuestionGroup entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					QuestionGroupProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<QuestionGroup> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			QuestionGroupProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region QuestionGroupDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the QuestionGroupDataSource class.
	/// </summary>
	public class QuestionGroupDataSourceDesigner : ProviderDataSourceDesigner<QuestionGroup, QuestionGroupKey>
	{
		/// <summary>
		/// Initializes a new instance of the QuestionGroupDataSourceDesigner class.
		/// </summary>
		public QuestionGroupDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionGroupSelectMethod SelectMethod
		{
			get { return ((QuestionGroupDataSource) DataSource).SelectMethod; }
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
				actions.Add(new QuestionGroupDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region QuestionGroupDataSourceActionList

	/// <summary>
	/// Supports the QuestionGroupDataSourceDesigner class.
	/// </summary>
	internal class QuestionGroupDataSourceActionList : DesignerActionList
	{
		private QuestionGroupDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the QuestionGroupDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public QuestionGroupDataSourceActionList(QuestionGroupDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionGroupSelectMethod SelectMethod
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

	#endregion QuestionGroupDataSourceActionList
	
	#endregion QuestionGroupDataSourceDesigner
	
	#region QuestionGroupSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the QuestionGroupDataSource.SelectMethod property.
	/// </summary>
	public enum QuestionGroupSelectMethod
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
		/// Represents the GetByUserIdFromResult method.
		/// </summary>
		GetByUserIdFromResult
	}
	
	#endregion QuestionGroupSelectMethod

	#region QuestionGroupFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupFilter : SqlFilter<QuestionGroupColumn>
	{
	}
	
	#endregion QuestionGroupFilter

	#region QuestionGroupExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupExpressionBuilder : SqlExpressionBuilder<QuestionGroupColumn>
	{
	}
	
	#endregion QuestionGroupExpressionBuilder	

	#region QuestionGroupProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;QuestionGroupChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionGroupProperty : ChildEntityProperty<QuestionGroupChildEntityTypes>
	{
	}
	
	#endregion QuestionGroupProperty
}

