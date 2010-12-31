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
	/// Represents the DataRepository.ResultsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ResultsDataSourceDesigner))]
	public class ResultsDataSource : ProviderDataSource<Results, ResultsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultsDataSource class.
		/// </summary>
		public ResultsDataSource() : base(new ResultsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ResultsDataSourceView used by the ResultsDataSource.
		/// </summary>
		protected ResultsDataSourceView ResultsView
		{
			get { return ( View as ResultsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ResultsDataSource control invokes to retrieve data.
		/// </summary>
		public ResultsSelectMethod SelectMethod
		{
			get
			{
				ResultsSelectMethod selectMethod = ResultsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ResultsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ResultsDataSourceView class that is to be
		/// used by the ResultsDataSource.
		/// </summary>
		/// <returns>An instance of the ResultsDataSourceView class.</returns>
		protected override BaseDataSourceView<Results, ResultsKey> GetNewDataSourceView()
		{
			return new ResultsDataSourceView(this, DefaultViewName);
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
	/// Supports the ResultsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ResultsDataSourceView : ProviderDataSourceView<Results, ResultsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ResultsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ResultsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ResultsDataSourceView(ResultsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ResultsDataSource ResultsOwner
		{
			get { return Owner as ResultsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ResultsSelectMethod SelectMethod
		{
			get { return ResultsOwner.SelectMethod; }
			set { ResultsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ResultsService ResultsProvider
		{
			get { return Provider as ResultsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Results> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Results> results = null;
			Results item;
			count = 0;
			
			System.Guid _userId;
			System.Int32 _groupId;
			System.Int32? _testTimes_nullable;

			switch ( SelectMethod )
			{
				case ResultsSelectMethod.Get:
					ResultsKey entityKey  = new ResultsKey();
					entityKey.Load(values);
					item = ResultsProvider.Get(entityKey);
					results = new TList<Results>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ResultsSelectMethod.GetAll:
                    results = ResultsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ResultsSelectMethod.GetPaged:
					results = ResultsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ResultsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ResultsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ResultsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ResultsSelectMethod.GetByUserIdGroupId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					item = ResultsProvider.GetByUserIdGroupId(_userId, _groupId);
					results = new TList<Results>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case ResultsSelectMethod.GetByUserIdGroupIdTestTimes:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					_testTimes_nullable = (System.Int32?) EntityUtil.ChangeType(values["TestTimes"], typeof(System.Int32?));
					item = ResultsProvider.GetByUserIdGroupIdTestTimes(_userId, _groupId, _testTimes_nullable);
					results = new TList<Results>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case ResultsSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					results = ResultsProvider.GetByUserId(_userId, this.StartIndex, this.PageSize, out count);
					break;
				case ResultsSelectMethod.GetByGroupId:
					_groupId = ( values["GroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["GroupId"], typeof(System.Int32)) : (int)0;
					results = ResultsProvider.GetByGroupId(_groupId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ResultsSelectMethod.Get || SelectMethod == ResultsSelectMethod.GetByUserIdGroupId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(Results entity)
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
				Results entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ResultsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Results> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ResultsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ResultsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ResultsDataSource class.
	/// </summary>
	public class ResultsDataSourceDesigner : ProviderDataSourceDesigner<Results, ResultsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ResultsDataSourceDesigner class.
		/// </summary>
		public ResultsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResultsSelectMethod SelectMethod
		{
			get { return ((ResultsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ResultsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ResultsDataSourceActionList

	/// <summary>
	/// Supports the ResultsDataSourceDesigner class.
	/// </summary>
	internal class ResultsDataSourceActionList : DesignerActionList
	{
		private ResultsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ResultsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ResultsDataSourceActionList(ResultsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ResultsSelectMethod SelectMethod
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

	#endregion ResultsDataSourceActionList
	
	#endregion ResultsDataSourceDesigner
	
	#region ResultsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ResultsDataSource.SelectMethod property.
	/// </summary>
	public enum ResultsSelectMethod
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
		/// Represents the GetByUserIdGroupIdTestTimes method.
		/// </summary>
		GetByUserIdGroupIdTestTimes,
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
	
	#endregion ResultsSelectMethod

	#region ResultsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Results"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultsFilter : SqlFilter<ResultsColumn>
	{
	}
	
	#endregion ResultsFilter

	#region ResultsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Results"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultsExpressionBuilder : SqlExpressionBuilder<ResultsColumn>
	{
	}
	
	#endregion ResultsExpressionBuilder	

	#region ResultsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ResultsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Results"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ResultsProperty : ChildEntityProperty<ResultsChildEntityTypes>
	{
	}
	
	#endregion ResultsProperty
}

