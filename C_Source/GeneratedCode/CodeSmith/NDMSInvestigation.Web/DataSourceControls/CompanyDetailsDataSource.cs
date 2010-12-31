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
	/// Represents the DataRepository.CompanyDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CompanyDetailsDataSourceDesigner))]
	public class CompanyDetailsDataSource : ProviderDataSource<CompanyDetails, CompanyDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsDataSource class.
		/// </summary>
		public CompanyDetailsDataSource() : base(new CompanyDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CompanyDetailsDataSourceView used by the CompanyDetailsDataSource.
		/// </summary>
		protected CompanyDetailsDataSourceView CompanyDetailsView
		{
			get { return ( View as CompanyDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CompanyDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public CompanyDetailsSelectMethod SelectMethod
		{
			get
			{
				CompanyDetailsSelectMethod selectMethod = CompanyDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CompanyDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CompanyDetailsDataSourceView class that is to be
		/// used by the CompanyDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the CompanyDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<CompanyDetails, CompanyDetailsKey> GetNewDataSourceView()
		{
			return new CompanyDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the CompanyDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CompanyDetailsDataSourceView : ProviderDataSourceView<CompanyDetails, CompanyDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CompanyDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CompanyDetailsDataSourceView(CompanyDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CompanyDetailsDataSource CompanyDetailsOwner
		{
			get { return Owner as CompanyDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CompanyDetailsSelectMethod SelectMethod
		{
			get { return CompanyDetailsOwner.SelectMethod; }
			set { CompanyDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CompanyDetailsService CompanyDetailsProvider
		{
			get { return Provider as CompanyDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CompanyDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CompanyDetails> results = null;
			CompanyDetails item;
			count = 0;
			
			System.Guid _userId;
			System.Int32 _companyId;
			System.Int32? _traceChange_nullable;

			switch ( SelectMethod )
			{
				case CompanyDetailsSelectMethod.Get:
					CompanyDetailsKey entityKey  = new CompanyDetailsKey();
					entityKey.Load(values);
					item = CompanyDetailsProvider.Get(entityKey);
					results = new TList<CompanyDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CompanyDetailsSelectMethod.GetAll:
                    results = CompanyDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CompanyDetailsSelectMethod.GetPaged:
					results = CompanyDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CompanyDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = CompanyDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CompanyDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CompanyDetailsSelectMethod.GetByCompanyId:
					_companyId = ( values["CompanyId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CompanyId"], typeof(System.Int32)) : (int)0;
					item = CompanyDetailsProvider.GetByCompanyId(_companyId);
					results = new TList<CompanyDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case CompanyDetailsSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					item = CompanyDetailsProvider.GetByUserId(_userId);
					results = new TList<CompanyDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case CompanyDetailsSelectMethod.GetByTraceChange:
					_traceChange_nullable = (System.Int32?) EntityUtil.ChangeType(values["TraceChange"], typeof(System.Int32?));
					results = CompanyDetailsProvider.GetByTraceChange(_traceChange_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CompanyDetailsSelectMethod.Get || SelectMethod == CompanyDetailsSelectMethod.GetByCompanyId )
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
				CompanyDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CompanyDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CompanyDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CompanyDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CompanyDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CompanyDetailsDataSource class.
	/// </summary>
	public class CompanyDetailsDataSourceDesigner : ProviderDataSourceDesigner<CompanyDetails, CompanyDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the CompanyDetailsDataSourceDesigner class.
		/// </summary>
		public CompanyDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyDetailsSelectMethod SelectMethod
		{
			get { return ((CompanyDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CompanyDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CompanyDetailsDataSourceActionList

	/// <summary>
	/// Supports the CompanyDetailsDataSourceDesigner class.
	/// </summary>
	internal class CompanyDetailsDataSourceActionList : DesignerActionList
	{
		private CompanyDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CompanyDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CompanyDetailsDataSourceActionList(CompanyDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CompanyDetailsSelectMethod SelectMethod
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

	#endregion CompanyDetailsDataSourceActionList
	
	#endregion CompanyDetailsDataSourceDesigner
	
	#region CompanyDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CompanyDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum CompanyDetailsSelectMethod
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
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByCompanyId method.
		/// </summary>
		GetByCompanyId,
		/// <summary>
		/// Represents the GetByTraceChange method.
		/// </summary>
		GetByTraceChange
	}
	
	#endregion CompanyDetailsSelectMethod

	#region CompanyDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyDetailsFilter : SqlFilter<CompanyDetailsColumn>
	{
	}
	
	#endregion CompanyDetailsFilter

	#region CompanyDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyDetailsExpressionBuilder : SqlExpressionBuilder<CompanyDetailsColumn>
	{
	}
	
	#endregion CompanyDetailsExpressionBuilder	

	#region CompanyDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CompanyDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CompanyDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CompanyDetailsProperty : ChildEntityProperty<CompanyDetailsChildEntityTypes>
	{
	}
	
	#endregion CompanyDetailsProperty
}

