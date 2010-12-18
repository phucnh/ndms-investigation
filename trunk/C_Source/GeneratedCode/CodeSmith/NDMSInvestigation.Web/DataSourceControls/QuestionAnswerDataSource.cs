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
	/// Represents the DataRepository.QuestionAnswerProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(QuestionAnswerDataSourceDesigner))]
	public class QuestionAnswerDataSource : ProviderDataSource<QuestionAnswer, QuestionAnswerKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerDataSource class.
		/// </summary>
		public QuestionAnswerDataSource() : base(new QuestionAnswerService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the QuestionAnswerDataSourceView used by the QuestionAnswerDataSource.
		/// </summary>
		protected QuestionAnswerDataSourceView QuestionAnswerView
		{
			get { return ( View as QuestionAnswerDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the QuestionAnswerDataSource control invokes to retrieve data.
		/// </summary>
		public QuestionAnswerSelectMethod SelectMethod
		{
			get
			{
				QuestionAnswerSelectMethod selectMethod = QuestionAnswerSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (QuestionAnswerSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the QuestionAnswerDataSourceView class that is to be
		/// used by the QuestionAnswerDataSource.
		/// </summary>
		/// <returns>An instance of the QuestionAnswerDataSourceView class.</returns>
		protected override BaseDataSourceView<QuestionAnswer, QuestionAnswerKey> GetNewDataSourceView()
		{
			return new QuestionAnswerDataSourceView(this, DefaultViewName);
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
	/// Supports the QuestionAnswerDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class QuestionAnswerDataSourceView : ProviderDataSourceView<QuestionAnswer, QuestionAnswerKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the QuestionAnswerDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public QuestionAnswerDataSourceView(QuestionAnswerDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal QuestionAnswerDataSource QuestionAnswerOwner
		{
			get { return Owner as QuestionAnswerDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal QuestionAnswerSelectMethod SelectMethod
		{
			get { return QuestionAnswerOwner.SelectMethod; }
			set { QuestionAnswerOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal QuestionAnswerService QuestionAnswerProvider
		{
			get { return Provider as QuestionAnswerService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<QuestionAnswer> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<QuestionAnswer> results = null;
			QuestionAnswer item;
			count = 0;
			
			System.Int32 _questionAnswerId;
			System.Int32 _answerId;
			System.Int32 _questionId;

			switch ( SelectMethod )
			{
				case QuestionAnswerSelectMethod.Get:
					QuestionAnswerKey entityKey  = new QuestionAnswerKey();
					entityKey.Load(values);
					item = QuestionAnswerProvider.Get(entityKey);
					results = new TList<QuestionAnswer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case QuestionAnswerSelectMethod.GetAll:
                    results = QuestionAnswerProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case QuestionAnswerSelectMethod.GetPaged:
					results = QuestionAnswerProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case QuestionAnswerSelectMethod.Find:
					if ( FilterParameters != null )
						results = QuestionAnswerProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = QuestionAnswerProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case QuestionAnswerSelectMethod.GetByQuestionAnswerId:
					_questionAnswerId = ( values["QuestionAnswerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["QuestionAnswerId"], typeof(System.Int32)) : (int)0;
					item = QuestionAnswerProvider.GetByQuestionAnswerId(_questionAnswerId);
					results = new TList<QuestionAnswer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case QuestionAnswerSelectMethod.GetByAnswerId:
					_answerId = ( values["AnswerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AnswerId"], typeof(System.Int32)) : (int)0;
					results = QuestionAnswerProvider.GetByAnswerId(_answerId, this.StartIndex, this.PageSize, out count);
					break;
				case QuestionAnswerSelectMethod.GetByQuestionId:
					_questionId = ( values["QuestionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["QuestionId"], typeof(System.Int32)) : (int)0;
					results = QuestionAnswerProvider.GetByQuestionId(_questionId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == QuestionAnswerSelectMethod.Get || SelectMethod == QuestionAnswerSelectMethod.GetByQuestionAnswerId )
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
				QuestionAnswer entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					QuestionAnswerProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<QuestionAnswer> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			QuestionAnswerProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region QuestionAnswerDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the QuestionAnswerDataSource class.
	/// </summary>
	public class QuestionAnswerDataSourceDesigner : ProviderDataSourceDesigner<QuestionAnswer, QuestionAnswerKey>
	{
		/// <summary>
		/// Initializes a new instance of the QuestionAnswerDataSourceDesigner class.
		/// </summary>
		public QuestionAnswerDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionAnswerSelectMethod SelectMethod
		{
			get { return ((QuestionAnswerDataSource) DataSource).SelectMethod; }
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
				actions.Add(new QuestionAnswerDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region QuestionAnswerDataSourceActionList

	/// <summary>
	/// Supports the QuestionAnswerDataSourceDesigner class.
	/// </summary>
	internal class QuestionAnswerDataSourceActionList : DesignerActionList
	{
		private QuestionAnswerDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the QuestionAnswerDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public QuestionAnswerDataSourceActionList(QuestionAnswerDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public QuestionAnswerSelectMethod SelectMethod
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

	#endregion QuestionAnswerDataSourceActionList
	
	#endregion QuestionAnswerDataSourceDesigner
	
	#region QuestionAnswerSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the QuestionAnswerDataSource.SelectMethod property.
	/// </summary>
	public enum QuestionAnswerSelectMethod
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
		/// Represents the GetByQuestionAnswerId method.
		/// </summary>
		GetByQuestionAnswerId,
		/// <summary>
		/// Represents the GetByAnswerId method.
		/// </summary>
		GetByAnswerId,
		/// <summary>
		/// Represents the GetByQuestionId method.
		/// </summary>
		GetByQuestionId
	}
	
	#endregion QuestionAnswerSelectMethod

	#region QuestionAnswerFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerFilter : SqlFilter<QuestionAnswerColumn>
	{
	}
	
	#endregion QuestionAnswerFilter

	#region QuestionAnswerExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerExpressionBuilder : SqlExpressionBuilder<QuestionAnswerColumn>
	{
	}
	
	#endregion QuestionAnswerExpressionBuilder	

	#region QuestionAnswerProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;QuestionAnswerChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="QuestionAnswer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class QuestionAnswerProperty : ChildEntityProperty<QuestionAnswerChildEntityTypes>
	{
	}
	
	#endregion QuestionAnswerProperty
}

