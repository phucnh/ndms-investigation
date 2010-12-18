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
	/// Represents the DataRepository.ResultProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ResultDataSourceDesigner))]
	public class ResultDataSource : ProviderDataSource<Result, ResultKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultDataSource class.
		/// </summary>
		public ResultDataSource() : base(new ResultService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ResultDataSourceView used by the ResultDataSource.
		/// </summary>
		protected ResultDataSourceView ResultView
		{
			get { return ( View as ResultDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ResultDataSource control invokes to retrieve data.
		/// </summary>
		public ResultSelectMethod SelectMethod
		{
			get
			{
				ResultSelectMethod selectMethod = ResultSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ResultSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ResultDataSourceView class that is to be
		/// used by the ResultDataSource.
		/// </summary>
		/// <returns>An instance of the ResultDataSourceView class.</returns>
		protected override BaseDataSourceView<Result, ResultKey> GetNewDataSourceView()
		{
			return new ResultDataSourceView(this, DefaultViewName);
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
	/// Supports the ResultDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ResultDataSourceView : ProviderDataSourceView<Result, ResultKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ResultDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ResultDataSourceView(ResultDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ResultDataSource ResultOwner
		{
			get { return Owner as ResultDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ResultSelectMethod SelectMethod
		{
			get { return ResultOwner.SelectMethod; }
			set { ResultOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ResultService ResultProvider
		{
			get { return Provider as ResultService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Result> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Result> results = null;
			Result item;
			count = 0;
			
			System.Guid _userId;
			System.Int32 _groupId;

			switch ( SelectMethod )
			{
				case ResultSelectMethod.Get:
					ResultKey entityKey  = new ResultKey();
					entityKey.Load(values);
					item = ResultProvider.Get(entityKey);
					results = new TList<Result>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ResultSelectMethod.GetAll:
                    results = ResultProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ResultSelectMethod.GetPaged:
					results = ResultProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ResultSelectMethod.Find:
					if ( FilterParameters != null )
						results = ResultProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ResultProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ResultSelectMethod.GetByUserIdGroupId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					item = ResultProvider.GetByUserIdGroupId(_userId, _groupId);
					results = new TList<Result>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ResultSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					results = ResultProvider.GetByUserId(_userId, this.StartIndex, this.PageSize, out count);
					break;
				case ResultSelectMethod.GetByGroupId:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					results = ResultProvider.GetByGroupId(_groupId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ResultSelectMethod.Get || SelectMethod == ResultSelectMethod.GetByUserIdGroupId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Result entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.UserId == Guid.Empty )
				entity.UserId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				Result entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ResultProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Result> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ResultProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ResultDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ResultDataSource class.
	/// </summary>
	public class ResultDataSourceDesigner : ProviderDataSourceDesigner<Result, ResultKey>
	{
		/// <summary>
		/// Initializes a new instance of the ResultDataSourceDesigner class.
		/// </summary>
		public ResultDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResultSelectMethod SelectMethod
		{
			get { return ((ResultDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ResultDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ResultDataSourceActionList

	/// <summary>
	/// Supports the ResultDataSourceDesigner class.
	/// </summary>
	internal class ResultDataSourceActionList : DesignerActionList
	{
		private ResultDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ResultDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ResultDataSourceActionList(ResultDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResultSelectMethod SelectMethod
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

	#endregion ResultDataSourceActionList
	
	#endregion ResultDataSourceDesigner
	
	#region ResultSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ResultDataSource.SelectMethod property.
	/// </summary>
	public enum ResultSelectMethod
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
		/// Represents the GetByUserIdGroupId method.
		/// </summary>
		GetByUserIdGroupId,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByGroupId method.
		/// </summary>
		GetByGroupId
	}
	
	#endregion ResultSelectMethod

	#region ResultFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultFilter : SqlFilter<ResultColumn>
	{
	}
	
	#endregion ResultFilter

	#region ResultExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultExpressionBuilder : SqlExpressionBuilder<ResultColumn>
	{
	}
	
	#endregion ResultExpressionBuilder	

	#region ResultProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ResultChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Result"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultProperty : ChildEntityProperty<ResultChildEntityTypes>
	{
	}
	
	#endregion ResultProperty
}

