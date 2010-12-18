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
	/// Represents the DataRepository.AspnetProfileProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetProfileDataSourceDesigner))]
	public class AspnetProfileDataSource : ProviderDataSource<AspnetProfile, AspnetProfileKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetProfileDataSource class.
		/// </summary>
		public AspnetProfileDataSource() : base(new AspnetProfileService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetProfileDataSourceView used by the AspnetProfileDataSource.
		/// </summary>
		protected AspnetProfileDataSourceView AspnetProfileView
		{
			get { return ( View as AspnetProfileDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetProfileDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetProfileSelectMethod SelectMethod
		{
			get
			{
				AspnetProfileSelectMethod selectMethod = AspnetProfileSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetProfileSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetProfileDataSourceView class that is to be
		/// used by the AspnetProfileDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetProfileDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetProfile, AspnetProfileKey> GetNewDataSourceView()
		{
			return new AspnetProfileDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetProfileDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetProfileDataSourceView : ProviderDataSourceView<AspnetProfile, AspnetProfileKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetProfileDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetProfileDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetProfileDataSourceView(AspnetProfileDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetProfileDataSource AspnetProfileOwner
		{
			get { return Owner as AspnetProfileDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetProfileSelectMethod SelectMethod
		{
			get { return AspnetProfileOwner.SelectMethod; }
			set { AspnetProfileOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetProfileService AspnetProfileProvider
		{
			get { return Provider as AspnetProfileService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetProfile> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetProfile> results = null;
			AspnetProfile item;
			count = 0;
			
			System.Guid _userId;

			switch ( SelectMethod )
			{
				case AspnetProfileSelectMethod.Get:
					AspnetProfileKey entityKey  = new AspnetProfileKey();
					entityKey.Load(values);
					item = AspnetProfileProvider.Get(entityKey);
					results = new TList<AspnetProfile>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetProfileSelectMethod.GetAll:
                    results = AspnetProfileProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetProfileSelectMethod.GetPaged:
					results = AspnetProfileProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetProfileSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetProfileProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetProfileProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetProfileSelectMethod.GetByUserId:
					_userId = ( values["UserId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetProfileProvider.GetByUserId(_userId);
					results = new TList<AspnetProfile>();
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
			if ( SelectMethod == AspnetProfileSelectMethod.Get || SelectMethod == AspnetProfileSelectMethod.GetByUserId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetProfile entity)
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
				AspnetProfile entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetProfileProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetProfile> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetProfileProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetProfileDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetProfileDataSource class.
	/// </summary>
	public class AspnetProfileDataSourceDesigner : ProviderDataSourceDesigner<AspnetProfile, AspnetProfileKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetProfileDataSourceDesigner class.
		/// </summary>
		public AspnetProfileDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetProfileSelectMethod SelectMethod
		{
			get { return ((AspnetProfileDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetProfileDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetProfileDataSourceActionList

	/// <summary>
	/// Supports the AspnetProfileDataSourceDesigner class.
	/// </summary>
	internal class AspnetProfileDataSourceActionList : DesignerActionList
	{
		private AspnetProfileDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetProfileDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetProfileDataSourceActionList(AspnetProfileDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetProfileSelectMethod SelectMethod
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

	#endregion AspnetProfileDataSourceActionList
	
	#endregion AspnetProfileDataSourceDesigner
	
	#region AspnetProfileSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetProfileDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetProfileSelectMethod
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
		GetByUserId
	}
	
	#endregion AspnetProfileSelectMethod

	#region AspnetProfileFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetProfile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetProfileFilter : SqlFilter<AspnetProfileColumn>
	{
	}
	
	#endregion AspnetProfileFilter

	#region AspnetProfileExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetProfile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetProfileExpressionBuilder : SqlExpressionBuilder<AspnetProfileColumn>
	{
	}
	
	#endregion AspnetProfileExpressionBuilder	

	#region AspnetProfileProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetProfileChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetProfile"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetProfileProperty : ChildEntityProperty<AspnetProfileChildEntityTypes>
	{
	}
	
	#endregion AspnetProfileProperty
}

