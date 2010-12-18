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
	/// Represents the DataRepository.QuestionDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(QuestionDetailsDataSourceDesigner))]
	public class QuestionDetailsDataSource : ProviderDataSource<QuestionDetails, QuestionDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsDataSource class.
		/// </summary>
		public QuestionDetailsDataSource() : base(new QuestionDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the QuestionDetailsDataSourceView used by the QuestionDetailsDataSource.
		/// </summary>
		protected QuestionDetailsDataSourceView QuestionDetailsView
		{
			get { return ( View as QuestionDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the QuestionDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public QuestionDetailsSelectMethod SelectMethod
		{
			get
			{
				QuestionDetailsSelectMethod selectMethod = QuestionDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (QuestionDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the QuestionDetailsDataSourceView class that is to be
		/// used by the QuestionDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the QuestionDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<QuestionDetails, QuestionDetailsKey> GetNewDataSourceView()
		{
			return new QuestionDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the QuestionDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class QuestionDetailsDataSourceView : ProviderDataSourceView<QuestionDetails, QuestionDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the QuestionDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public QuestionDetailsDataSourceView(QuestionDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal QuestionDetailsDataSource QuestionDetailsOwner
		{
			get { return Owner as QuestionDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal QuestionDetailsSelectMethod SelectMethod
		{
			get { return QuestionDetailsOwner.SelectMethod; }
			set { QuestionDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal QuestionDetailsService QuestionDetailsProvider
		{
			get { return Provider as QuestionDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<QuestionDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<QuestionDetails> results = null;
			QuestionDetails item;
			count = 0;
			
			System.Int32 _groupId;
			System.Int32? _orderNumber_nullable;
			System.Int32 _questionId;

			switch ( SelectMethod )
			{
				case QuestionDetailsSelectMethod.Get:
					QuestionDetailsKey entityKey  = new QuestionDetailsKey();
					entityKey.Load(values);
					item = QuestionDetailsProvider.Get(entityKey);
					results = new TList<QuestionDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case QuestionDetailsSelectMethod.GetAll:
                    results = QuestionDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case QuestionDetailsSelectMethod.GetPaged:
					results = QuestionDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case QuestionDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = QuestionDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = QuestionDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case QuestionDetailsSelectMethod.GetByQuestionId:
					_questionId = ( values["QuestionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["QuestionId"], typeof(System.Int32)) : (int)0;
					item = QuestionDetailsProvider.GetByQuestionId(_questionId);
					results = new TList<QuestionDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case QuestionDetailsSelectMethod.GetByGroupIdOrderNumber:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					_orderNumber_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderNumber"], typeof(System.Int32?));
					item = QuestionDetailsProvider.GetByGroupIdOrderNumber(_groupId, _orderNumber_nullable);
					results = new TList<QuestionDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case QuestionDetailsSelectMethod.GetByGroupId:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					results = QuestionDetailsProvider.GetByGroupId(_groupId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == QuestionDetailsSelectMethod.Get || SelectMethod == QuestionDetailsSelectMethod.GetByQuestionId )
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
				QuestionDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					QuestionDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<QuestionDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			QuestionDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region QuestionDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the QuestionDetailsDataSource class.
	/// </summary>
	public class QuestionDetailsDataSourceDesigner : ProviderDataSourceDesigner<QuestionDetails, QuestionDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the QuestionDetailsDataSourceDesigner class.
		/// </summary>
		public QuestionDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionDetailsSelectMethod SelectMethod
		{
			get { return ((QuestionDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new QuestionDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region QuestionDetailsDataSourceActionList

	/// <summary>
	/// Supports the QuestionDetailsDataSourceDesigner class.
	/// </summary>
	internal class QuestionDetailsDataSourceActionList : DesignerActionList
	{
		private QuestionDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the QuestionDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public QuestionDetailsDataSourceActionList(QuestionDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionDetailsSelectMethod SelectMethod
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

	#endregion QuestionDetailsDataSourceActionList
	
	#endregion QuestionDetailsDataSourceDesigner
	
	#region QuestionDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the QuestionDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum QuestionDetailsSelectMethod
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
		/// Represents the GetByGroupIdOrderNumber method.
		/// </summary>
		GetByGroupIdOrderNumber,
		/// <summary>
		/// Represents the GetByQuestionId method.
		/// </summary>
		GetByQuestionId,
		/// <summary>
		/// Represents the GetByGroupId method.
		/// </summary>
		GetByGroupId
	}
	
	#endregion QuestionDetailsSelectMethod

	#region QuestionDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsFilter : SqlFilter<QuestionDetailsColumn>
	{
	}
	
	#endregion QuestionDetailsFilter

	#region QuestionDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsExpressionBuilder : SqlExpressionBuilder<QuestionDetailsColumn>
	{
	}
	
	#endregion QuestionDetailsExpressionBuilder	

	#region QuestionDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;QuestionDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionDetailsProperty : ChildEntityProperty<QuestionDetailsChildEntityTypes>
	{
	}
	
	#endregion QuestionDetailsProperty
}

