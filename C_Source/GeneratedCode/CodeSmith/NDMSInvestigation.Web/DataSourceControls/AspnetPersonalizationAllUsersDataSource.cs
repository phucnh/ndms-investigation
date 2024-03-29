﻿#region Using Directives
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
	/// Represents the DataRepository.AspnetPersonalizationAllUsersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetPersonalizationAllUsersDataSourceDesigner))]
	public class AspnetPersonalizationAllUsersDataSource : ProviderDataSource<AspnetPersonalizationAllUsers, AspnetPersonalizationAllUsersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersDataSource class.
		/// </summary>
		public AspnetPersonalizationAllUsersDataSource() : base(new AspnetPersonalizationAllUsersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetPersonalizationAllUsersDataSourceView used by the AspnetPersonalizationAllUsersDataSource.
		/// </summary>
		protected AspnetPersonalizationAllUsersDataSourceView AspnetPersonalizationAllUsersView
		{
			get { return ( View as AspnetPersonalizationAllUsersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetPersonalizationAllUsersDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetPersonalizationAllUsersSelectMethod SelectMethod
		{
			get
			{
				AspnetPersonalizationAllUsersSelectMethod selectMethod = AspnetPersonalizationAllUsersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetPersonalizationAllUsersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetPersonalizationAllUsersDataSourceView class that is to be
		/// used by the AspnetPersonalizationAllUsersDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetPersonalizationAllUsersDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetPersonalizationAllUsers, AspnetPersonalizationAllUsersKey> GetNewDataSourceView()
		{
			return new AspnetPersonalizationAllUsersDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetPersonalizationAllUsersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetPersonalizationAllUsersDataSourceView : ProviderDataSourceView<AspnetPersonalizationAllUsers, AspnetPersonalizationAllUsersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetPersonalizationAllUsersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetPersonalizationAllUsersDataSourceView(AspnetPersonalizationAllUsersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetPersonalizationAllUsersDataSource AspnetPersonalizationAllUsersOwner
		{
			get { return Owner as AspnetPersonalizationAllUsersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetPersonalizationAllUsersSelectMethod SelectMethod
		{
			get { return AspnetPersonalizationAllUsersOwner.SelectMethod; }
			set { AspnetPersonalizationAllUsersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetPersonalizationAllUsersService AspnetPersonalizationAllUsersProvider
		{
			get { return Provider as AspnetPersonalizationAllUsersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetPersonalizationAllUsers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetPersonalizationAllUsers> results = null;
			AspnetPersonalizationAllUsers item;
			count = 0;
			
			System.Guid _pathId;

			switch ( SelectMethod )
			{
				case AspnetPersonalizationAllUsersSelectMethod.Get:
					AspnetPersonalizationAllUsersKey entityKey  = new AspnetPersonalizationAllUsersKey();
					entityKey.Load(values);
					item = AspnetPersonalizationAllUsersProvider.Get(entityKey);
					results = new TList<AspnetPersonalizationAllUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetPersonalizationAllUsersSelectMethod.GetAll:
                    results = AspnetPersonalizationAllUsersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetPersonalizationAllUsersSelectMethod.GetPaged:
					results = AspnetPersonalizationAllUsersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetPersonalizationAllUsersSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetPersonalizationAllUsersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetPersonalizationAllUsersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetPersonalizationAllUsersSelectMethod.GetByPathId:
					_pathId = ( values["PathId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["PathId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetPersonalizationAllUsersProvider.GetByPathId(_pathId);
					results = new TList<AspnetPersonalizationAllUsers>();
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
			if ( SelectMethod == AspnetPersonalizationAllUsersSelectMethod.Get || SelectMethod == AspnetPersonalizationAllUsersSelectMethod.GetByPathId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetPersonalizationAllUsers entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.PathId == Guid.Empty )
				entity.PathId = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetPersonalizationAllUsers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetPersonalizationAllUsersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetPersonalizationAllUsers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetPersonalizationAllUsersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetPersonalizationAllUsersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetPersonalizationAllUsersDataSource class.
	/// </summary>
	public class AspnetPersonalizationAllUsersDataSourceDesigner : ProviderDataSourceDesigner<AspnetPersonalizationAllUsers, AspnetPersonalizationAllUsersKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersDataSourceDesigner class.
		/// </summary>
		public AspnetPersonalizationAllUsersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetPersonalizationAllUsersSelectMethod SelectMethod
		{
			get { return ((AspnetPersonalizationAllUsersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetPersonalizationAllUsersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetPersonalizationAllUsersDataSourceActionList

	/// <summary>
	/// Supports the AspnetPersonalizationAllUsersDataSourceDesigner class.
	/// </summary>
	internal class AspnetPersonalizationAllUsersDataSourceActionList : DesignerActionList
	{
		private AspnetPersonalizationAllUsersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationAllUsersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetPersonalizationAllUsersDataSourceActionList(AspnetPersonalizationAllUsersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetPersonalizationAllUsersSelectMethod SelectMethod
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

	#endregion AspnetPersonalizationAllUsersDataSourceActionList
	
	#endregion AspnetPersonalizationAllUsersDataSourceDesigner
	
	#region AspnetPersonalizationAllUsersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetPersonalizationAllUsersDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetPersonalizationAllUsersSelectMethod
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
		/// Represents the GetByPathId method.
		/// </summary>
		GetByPathId
	}
	
	#endregion AspnetPersonalizationAllUsersSelectMethod

	#region AspnetPersonalizationAllUsersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersFilter : SqlFilter<AspnetPersonalizationAllUsersColumn>
	{
	}
	
	#endregion AspnetPersonalizationAllUsersFilter

	#region AspnetPersonalizationAllUsersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersExpressionBuilder : SqlExpressionBuilder<AspnetPersonalizationAllUsersColumn>
	{
	}
	
	#endregion AspnetPersonalizationAllUsersExpressionBuilder	

	#region AspnetPersonalizationAllUsersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetPersonalizationAllUsersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationAllUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationAllUsersProperty : ChildEntityProperty<AspnetPersonalizationAllUsersChildEntityTypes>
	{
	}
	
	#endregion AspnetPersonalizationAllUsersProperty
}

