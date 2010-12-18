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
	/// Represents the DataRepository.AspnetMembershipProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetMembershipDataSourceDesigner))]
	public class AspnetMembershipDataSource : ProviderDataSource<AspnetMembership, AspnetMembershipKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipDataSource class.
		/// </summary>
		public AspnetMembershipDataSource() : base(new AspnetMembershipService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetMembershipDataSourceView used by the AspnetMembershipDataSource.
		/// </summary>
		protected AspnetMembershipDataSourceView AspnetMembershipView
		{
			get { return ( View as AspnetMembershipDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetMembershipDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetMembershipSelectMethod SelectMethod
		{
			get
			{
				AspnetMembershipSelectMethod selectMethod = AspnetMembershipSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetMembershipSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetMembershipDataSourceView class that is to be
		/// used by the AspnetMembershipDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetMembershipDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetMembership, AspnetMembershipKey> GetNewDataSourceView()
		{
			return new AspnetMembershipDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetMembershipDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetMembershipDataSourceView : ProviderDataSourceView<AspnetMembership, AspnetMembershipKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetMembershipDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetMembershipDataSourceView(AspnetMembershipDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetMembershipDataSource AspnetMembershipOwner
		{
			get { return Owner as AspnetMembershipDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetMembershipSelectMethod SelectMethod
		{
			get { return AspnetMembershipOwner.SelectMethod; }
			set { AspnetMembershipOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetMembershipService AspnetMembershipProvider
		{
			get { return Provider as AspnetMembershipService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetMembership> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetMembership> results = null;
			AspnetMembership item;
			count = 0;
			
			System.Guid _applicationId;
			System.String _loweredEmail_nullable;
			System.Guid _userId;

			switch ( SelectMethod )
			{
				case AspnetMembershipSelectMethod.Get:
					AspnetMembershipKey entityKey  = new AspnetMembershipKey();
					entityKey.Load(values);
					item = AspnetMembershipProvider.Get(entityKey);
					results = new TList<AspnetMembership>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetMembershipSelectMethod.GetAll:
                    results = AspnetMembershipProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetMembershipSelectMethod.GetPaged:
					results = AspnetMembershipProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetMembershipSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetMembershipProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetMembershipProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetMembershipSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetMembershipProvider.GetByUserId(_userId);
					results = new TList<AspnetMembership>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetMembershipSelectMethod.GetByApplicationIdLoweredEmail:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					_loweredEmail_nullable = (System.String) EntityUtil.ChangeType(values["LoweredEmail"], typeof(System.String));
					results = AspnetMembershipProvider.GetByApplicationIdLoweredEmail(_applicationId, _loweredEmail_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case AspnetMembershipSelectMethod.GetByApplicationId:
					_applicationId = ( values["ApplicationId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ApplicationId"], typeof(System.Guid)) : Guid.Empty;
					results = AspnetMembershipProvider.GetByApplicationId(_applicationId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AspnetMembershipSelectMethod.Get || SelectMethod == AspnetMembershipSelectMethod.GetByUserId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetMembership entity)
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
				AspnetMembership entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetMembershipProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetMembership> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetMembershipProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetMembershipDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetMembershipDataSource class.
	/// </summary>
	public class AspnetMembershipDataSourceDesigner : ProviderDataSourceDesigner<AspnetMembership, AspnetMembershipKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetMembershipDataSourceDesigner class.
		/// </summary>
		public AspnetMembershipDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetMembershipSelectMethod SelectMethod
		{
			get { return ((AspnetMembershipDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetMembershipDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetMembershipDataSourceActionList

	/// <summary>
	/// Supports the AspnetMembershipDataSourceDesigner class.
	/// </summary>
	internal class AspnetMembershipDataSourceActionList : DesignerActionList
	{
		private AspnetMembershipDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetMembershipDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetMembershipDataSourceActionList(AspnetMembershipDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetMembershipSelectMethod SelectMethod
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

	#endregion AspnetMembershipDataSourceActionList
	
	#endregion AspnetMembershipDataSourceDesigner
	
	#region AspnetMembershipSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetMembershipDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetMembershipSelectMethod
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
		/// Represents the GetByApplicationIdLoweredEmail method.
		/// </summary>
		GetByApplicationIdLoweredEmail,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId,
		/// <summary>
		/// Represents the GetByApplicationId method.
		/// </summary>
		GetByApplicationId
	}
	
	#endregion AspnetMembershipSelectMethod

	#region AspnetMembershipFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipFilter : SqlFilter<AspnetMembershipColumn>
	{
	}
	
	#endregion AspnetMembershipFilter

	#region AspnetMembershipExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipExpressionBuilder : SqlExpressionBuilder<AspnetMembershipColumn>
	{
	}
	
	#endregion AspnetMembershipExpressionBuilder	

	#region AspnetMembershipProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetMembershipChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetMembership"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetMembershipProperty : ChildEntityProperty<AspnetMembershipChildEntityTypes>
	{
	}
	
	#endregion AspnetMembershipProperty
}

