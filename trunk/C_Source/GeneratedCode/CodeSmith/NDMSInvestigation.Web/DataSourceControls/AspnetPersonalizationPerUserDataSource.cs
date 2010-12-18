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
	/// Represents the DataRepository.AspnetPersonalizationPerUserProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AspnetPersonalizationPerUserDataSourceDesigner))]
	public class AspnetPersonalizationPerUserDataSource : ProviderDataSource<AspnetPersonalizationPerUser, AspnetPersonalizationPerUserKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserDataSource class.
		/// </summary>
		public AspnetPersonalizationPerUserDataSource() : base(new AspnetPersonalizationPerUserService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AspnetPersonalizationPerUserDataSourceView used by the AspnetPersonalizationPerUserDataSource.
		/// </summary>
		protected AspnetPersonalizationPerUserDataSourceView AspnetPersonalizationPerUserView
		{
			get { return ( View as AspnetPersonalizationPerUserDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AspnetPersonalizationPerUserDataSource control invokes to retrieve data.
		/// </summary>
		public AspnetPersonalizationPerUserSelectMethod SelectMethod
		{
			get
			{
				AspnetPersonalizationPerUserSelectMethod selectMethod = AspnetPersonalizationPerUserSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AspnetPersonalizationPerUserSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AspnetPersonalizationPerUserDataSourceView class that is to be
		/// used by the AspnetPersonalizationPerUserDataSource.
		/// </summary>
		/// <returns>An instance of the AspnetPersonalizationPerUserDataSourceView class.</returns>
		protected override BaseDataSourceView<AspnetPersonalizationPerUser, AspnetPersonalizationPerUserKey> GetNewDataSourceView()
		{
			return new AspnetPersonalizationPerUserDataSourceView(this, DefaultViewName);
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
	/// Supports the AspnetPersonalizationPerUserDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AspnetPersonalizationPerUserDataSourceView : ProviderDataSourceView<AspnetPersonalizationPerUser, AspnetPersonalizationPerUserKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AspnetPersonalizationPerUserDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AspnetPersonalizationPerUserDataSourceView(AspnetPersonalizationPerUserDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AspnetPersonalizationPerUserDataSource AspnetPersonalizationPerUserOwner
		{
			get { return Owner as AspnetPersonalizationPerUserDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AspnetPersonalizationPerUserSelectMethod SelectMethod
		{
			get { return AspnetPersonalizationPerUserOwner.SelectMethod; }
			set { AspnetPersonalizationPerUserOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AspnetPersonalizationPerUserService AspnetPersonalizationPerUserProvider
		{
			get { return Provider as AspnetPersonalizationPerUserService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AspnetPersonalizationPerUser> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AspnetPersonalizationPerUser> results = null;
			AspnetPersonalizationPerUser item;
			count = 0;
			
			System.Guid? _pathId_nullable;
			System.Guid? _userId_nullable;
			System.Guid _id;

			switch ( SelectMethod )
			{
				case AspnetPersonalizationPerUserSelectMethod.Get:
					AspnetPersonalizationPerUserKey entityKey  = new AspnetPersonalizationPerUserKey();
					entityKey.Load(values);
					item = AspnetPersonalizationPerUserProvider.Get(entityKey);
					results = new TList<AspnetPersonalizationPerUser>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetPersonalizationPerUserSelectMethod.GetAll:
                    results = AspnetPersonalizationPerUserProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AspnetPersonalizationPerUserSelectMethod.GetPaged:
					results = AspnetPersonalizationPerUserProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AspnetPersonalizationPerUserSelectMethod.Find:
					if ( FilterParameters != null )
						results = AspnetPersonalizationPerUserProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AspnetPersonalizationPerUserProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AspnetPersonalizationPerUserSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["Id"], typeof(System.Guid)) : Guid.Empty;
					item = AspnetPersonalizationPerUserProvider.GetById(_id);
					results = new TList<AspnetPersonalizationPerUser>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AspnetPersonalizationPerUserSelectMethod.GetByPathIdUserId:
					_pathId_nullable = (System.Guid?) EntityUtil.ChangeType(values["PathId"], typeof(System.Guid?));
					_userId_nullable = (System.Guid?) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid?));
					item = AspnetPersonalizationPerUserProvider.GetByPathIdUserId(_pathId_nullable, _userId_nullable);
					results = new TList<AspnetPersonalizationPerUser>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AspnetPersonalizationPerUserSelectMethod.GetByUserIdPathId:
					_userId_nullable = (System.Guid?) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid?));
					_pathId_nullable = (System.Guid?) EntityUtil.ChangeType(values["PathId"], typeof(System.Guid?));
					item = AspnetPersonalizationPerUserProvider.GetByUserIdPathId(_userId_nullable, _pathId_nullable);
					results = new TList<AspnetPersonalizationPerUser>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case AspnetPersonalizationPerUserSelectMethod.GetByPathId:
					_pathId_nullable = (System.Guid?) EntityUtil.ChangeType(values["PathId"], typeof(System.Guid?));
					results = AspnetPersonalizationPerUserProvider.GetByPathId(_pathId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case AspnetPersonalizationPerUserSelectMethod.GetByUserId:
					_userId_nullable = (System.Guid?) EntityUtil.ChangeType(values["UserId"], typeof(System.Guid?));
					results = AspnetPersonalizationPerUserProvider.GetByUserId(_userId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AspnetPersonalizationPerUserSelectMethod.Get || SelectMethod == AspnetPersonalizationPerUserSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Sets the primary key values of the specified Entity object.
		/// </summary>
		/// <param name="entity">The Entity object to update.</param>
		protected override void SetEntityKeyValues(AspnetPersonalizationPerUser entity)
		{
			base.SetEntityKeyValues(entity);
			
			// make sure primary key column(s) have been set
			if ( entity.Id == Guid.Empty )
				entity.Id = Guid.NewGuid();
		}
		
		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				AspnetPersonalizationPerUser entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AspnetPersonalizationPerUserProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AspnetPersonalizationPerUser> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AspnetPersonalizationPerUserProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AspnetPersonalizationPerUserDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AspnetPersonalizationPerUserDataSource class.
	/// </summary>
	public class AspnetPersonalizationPerUserDataSourceDesigner : ProviderDataSourceDesigner<AspnetPersonalizationPerUser, AspnetPersonalizationPerUserKey>
	{
		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserDataSourceDesigner class.
		/// </summary>
		public AspnetPersonalizationPerUserDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetPersonalizationPerUserSelectMethod SelectMethod
		{
			get { return ((AspnetPersonalizationPerUserDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AspnetPersonalizationPerUserDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AspnetPersonalizationPerUserDataSourceActionList

	/// <summary>
	/// Supports the AspnetPersonalizationPerUserDataSourceDesigner class.
	/// </summary>
	internal class AspnetPersonalizationPerUserDataSourceActionList : DesignerActionList
	{
		private AspnetPersonalizationPerUserDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AspnetPersonalizationPerUserDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AspnetPersonalizationPerUserDataSourceActionList(AspnetPersonalizationPerUserDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AspnetPersonalizationPerUserSelectMethod SelectMethod
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

	#endregion AspnetPersonalizationPerUserDataSourceActionList
	
	#endregion AspnetPersonalizationPerUserDataSourceDesigner
	
	#region AspnetPersonalizationPerUserSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AspnetPersonalizationPerUserDataSource.SelectMethod property.
	/// </summary>
	public enum AspnetPersonalizationPerUserSelectMethod
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
		/// Represents the GetByPathIdUserId method.
		/// </summary>
		GetByPathIdUserId,
		/// <summary>
		/// Represents the GetByUserIdPathId method.
		/// </summary>
		GetByUserIdPathId,
		/// <summary>
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByPathId method.
		/// </summary>
		GetByPathId,
		/// <summary>
		/// Represents the GetByUserId method.
		/// </summary>
		GetByUserId
	}
	
	#endregion AspnetPersonalizationPerUserSelectMethod

	#region AspnetPersonalizationPerUserFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserFilter : SqlFilter<AspnetPersonalizationPerUserColumn>
	{
	}
	
	#endregion AspnetPersonalizationPerUserFilter

	#region AspnetPersonalizationPerUserExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserExpressionBuilder : SqlExpressionBuilder<AspnetPersonalizationPerUserColumn>
	{
	}
	
	#endregion AspnetPersonalizationPerUserExpressionBuilder	

	#region AspnetPersonalizationPerUserProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AspnetPersonalizationPerUserChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AspnetPersonalizationPerUser"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AspnetPersonalizationPerUserProperty : ChildEntityProperty<AspnetPersonalizationPerUserChildEntityTypes>
	{
	}
	
	#endregion AspnetPersonalizationPerUserProperty
}

