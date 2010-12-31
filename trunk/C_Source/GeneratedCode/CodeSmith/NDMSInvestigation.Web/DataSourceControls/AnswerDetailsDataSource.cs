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
	/// Represents the DataRepository.AnswerDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AnswerDetailsDataSourceDesigner))]
	public class AnswerDetailsDataSource : ProviderDataSource<AnswerDetails, AnswerDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsDataSource class.
		/// </summary>
		public AnswerDetailsDataSource() : base(new AnswerDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AnswerDetailsDataSourceView used by the AnswerDetailsDataSource.
		/// </summary>
		protected AnswerDetailsDataSourceView AnswerDetailsView
		{
			get { return ( View as AnswerDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AnswerDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public AnswerDetailsSelectMethod SelectMethod
		{
			get
			{
				AnswerDetailsSelectMethod selectMethod = AnswerDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AnswerDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AnswerDetailsDataSourceView class that is to be
		/// used by the AnswerDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the AnswerDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<AnswerDetails, AnswerDetailsKey> GetNewDataSourceView()
		{
			return new AnswerDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the AnswerDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AnswerDetailsDataSourceView : ProviderDataSourceView<AnswerDetails, AnswerDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AnswerDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AnswerDetailsDataSourceView(AnswerDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AnswerDetailsDataSource AnswerDetailsOwner
		{
			get { return Owner as AnswerDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AnswerDetailsSelectMethod SelectMethod
		{
			get { return AnswerDetailsOwner.SelectMethod; }
			set { AnswerDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AnswerDetailsService AnswerDetailsProvider
		{
			get { return Provider as AnswerDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AnswerDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AnswerDetails> results = null;
			AnswerDetails item;
			count = 0;
			
			System.Int32 _answerId;
			System.Int32 _questionId;

			switch ( SelectMethod )
			{
				case AnswerDetailsSelectMethod.Get:
					AnswerDetailsKey entityKey  = new AnswerDetailsKey();
					entityKey.Load(values);
					item = AnswerDetailsProvider.Get(entityKey);
					results = new TList<AnswerDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AnswerDetailsSelectMethod.GetAll:
                    results = AnswerDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AnswerDetailsSelectMethod.GetPaged:
					results = AnswerDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AnswerDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = AnswerDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AnswerDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AnswerDetailsSelectMethod.GetByAnswerId:
					_answerId = ( values["AnswerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AnswerId"], typeof(System.Int32)) : (int)0;
					item = AnswerDetailsProvider.GetByAnswerId(_answerId);
					results = new TList<AnswerDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				// M:M
				case AnswerDetailsSelectMethod.GetByQuestionIdFromQuestionAnswer:
					_questionId = ( values["QuestionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["QuestionId"], typeof(System.Int32)) : (int)0;
					results = AnswerDetailsProvider.GetByQuestionIdFromQuestionAnswer(_questionId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AnswerDetailsSelectMethod.Get || SelectMethod == AnswerDetailsSelectMethod.GetByAnswerId )
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
				AnswerDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AnswerDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AnswerDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AnswerDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AnswerDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AnswerDetailsDataSource class.
	/// </summary>
	public class AnswerDetailsDataSourceDesigner : ProviderDataSourceDesigner<AnswerDetails, AnswerDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the AnswerDetailsDataSourceDesigner class.
		/// </summary>
		public AnswerDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AnswerDetailsSelectMethod SelectMethod
		{
			get { return ((AnswerDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AnswerDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AnswerDetailsDataSourceActionList

	/// <summary>
	/// Supports the AnswerDetailsDataSourceDesigner class.
	/// </summary>
	internal class AnswerDetailsDataSourceActionList : DesignerActionList
	{
		private AnswerDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AnswerDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AnswerDetailsDataSourceActionList(AnswerDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AnswerDetailsSelectMethod SelectMethod
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

	#endregion AnswerDetailsDataSourceActionList
	
	#endregion AnswerDetailsDataSourceDesigner
	
	#region AnswerDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AnswerDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum AnswerDetailsSelectMethod
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
		/// Represents the GetByAnswerId method.
		/// </summary>
		GetByAnswerId,
		/// <summary>
		/// Represents the GetByQuestionIdFromQuestionAnswer method.
		/// </summary>
		GetByQuestionIdFromQuestionAnswer
	}
	
	#endregion AnswerDetailsSelectMethod

	#region AnswerDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsFilter : SqlFilter<AnswerDetailsColumn>
	{
	}
	
	#endregion AnswerDetailsFilter

	#region AnswerDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsExpressionBuilder : SqlExpressionBuilder<AnswerDetailsColumn>
	{
	}
	
	#endregion AnswerDetailsExpressionBuilder	

	#region AnswerDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AnswerDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AnswerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AnswerDetailsProperty : ChildEntityProperty<AnswerDetailsChildEntityTypes>
	{
	}
	
	#endregion AnswerDetailsProperty
}

