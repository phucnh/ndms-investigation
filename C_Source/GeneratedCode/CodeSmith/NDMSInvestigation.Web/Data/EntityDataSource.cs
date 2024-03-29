﻿#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;
#endregion

namespace NDMSInvestigation.Web.Data
{
	/// <summary>
	/// Represents a business object that provides data to data-bound
	/// controls in multi-tier Web application architectures.
	/// </summary>
	[ ParseChildren(true), PersistChildren(false) ]
	public class EntityDataSource : DataSourceControl, ILinkedDataSource
	{
		#region Declarations
		/// <summary>
		/// The default view name.
		/// </summary>
		public static readonly String EntityViewName = "EntityView";
		/// <summary>
		/// The EntityId parameter name.
		/// </summary>
		public static readonly String EntityIdParameterName = "EntityId";
		/// <summary>
		/// The WhereClause parameter name.
		/// </summary>
		public static readonly String WhereClauseParameterName = "WhereClause";
		/// <summary>
		/// The OrderByClause parameter name.
		/// </summary>
		public static readonly String OrderByClauseParameterName = "OrderByClause";
		/// <summary>
		/// The PageIndex parameter name.
		/// </summary>
		public static readonly String PageIndexParameterName = "PageIndex";
		/// <summary>
		/// The PageSize parameter name.
		/// </summary>
		public static readonly String PageSizeParameterName = "PageSize";
		/// <summary>
		/// The RecordCount parameter name.
		/// </summary>
		public static readonly String RecordCountParameterName = "RecordCount";
		/// <summary>
		/// The NullableRecordCount parameter name.
		/// </summary>
		public static readonly String NullableRecordCountParameterName = "NullableRecordCount";
		/// <summary>
		/// The SortExpression parameter name.
		/// </summary>
		public static readonly String SortExpressionParameterName = "SortExpression";

		private EntityDataSourceView _entityView;
		private ParameterCollection _parameters;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the EntityDataSource class.
		/// </summary>
		public EntityDataSource()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EntityDataSource class for
		/// the specified provider, entity type, and data retrieval method name.
		/// </summary>
		/// <param name="provider">The business object that provides data access.</param>
		/// <param name="entityType">The type of entity that is returned by the provider.</param>
		/// <param name="selectMethod">The name of the method or function that the EntityDataSource invokes to retrieve data.</param>
		public EntityDataSource(Object provider, Type entityType, String selectMethod)
		{
			Provider = provider;
			EntityType = entityType;
			SelectMethod = selectMethod;
		}
		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the primary key value used when retreiving a single entity.
		/// </summary>
		public String EntityId
		{
			get
			{
				String s = (String) ViewState[EntityIdParameterName];
				return s ?? String.Empty;
			}
			set
			{
				if ( String.Compare(value, EntityId, StringComparison.Ordinal) != 0 )
				{
					UpdateEntityId(value);
					EntityView.RaiseChangedEvent();
				}
			}
		}

		/// <summary>
		/// Gets the parameters collection that contains the parameters that
		/// are used by the EntityDataSource.SelectMethod method.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ParameterCollection Parameters
		{
			get
			{
				if ( _parameters == null )
				{
					_parameters = new ParameterCollection();
					_parameters.ParametersChanged += new EventHandler(this.OnParametersChanged);

					if ( IsTrackingViewState )
					{
						((IStateManager) _parameters).TrackViewState();
					}
				}

				return _parameters;
			}
		}

		/// <summary>
		/// Gets a reference to the EntityDataSourceView used by the EntityDataSource.
		/// </summary>
		private EntityDataSourceView EntityView
		{
			get
			{
				if ( _entityView == null )
				{
					_entityView = new EntityDataSourceView(this, EntityViewName);
				}

				return _entityView;
			}
		}

		/// <summary>
		/// Gets or sets the cached SortExpression that is supplied by
		/// DataBoundControls tied to this IDataSource.
		/// </summary>
		private String SortExpression
		{
			get
			{
				String s = (String) ViewState[SortExpressionParameterName];
				return s ?? String.Empty;
			}
			set
			{
				ViewState[SortExpressionParameterName] = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EntityDataSource control invokes to retrieve data.
		/// </summary>
		public String SelectMethod
		{
			get { return ((String) ViewState["SelectMethod"]) ?? "GetAll"; }
			set { ViewState["SelectMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EntityDataSource control invokes to insert data.
		/// </summary>
		public String InsertMethod
		{
			get { return ((String) ViewState["InsertMethod"]) ?? "Insert"; }
			set { ViewState["InsertMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EntityDataSource control invokes to update data.
		/// </summary>
		public String UpdateMethod
		{
			get { return ((String) ViewState["UpdateMethod"]) ?? "Update"; }
			set { ViewState["UpdateMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EntityDataSource control invokes to delete data.
		/// </summary>
		public String DeleteMethod
		{
			get { return ((String) ViewState["DeleteMethod"]) ?? "Delete"; }
			set { ViewState["DeleteMethod"] = value; }
		}

		/// <summary>
		/// Gets or sets a filtering expression that is applied when the method that
		/// is specified by the EntityDataSource.SelectMethod property is called.
		/// This only applies if EnablePaging and EnableSorting are both false.
		/// </summary>
		public String Filter
		{
			get { return ((String) ViewState["Filter"]) ?? String.Empty; }
			set { ViewState["Filter"] = value; }
		}

		/// <summary>
		/// Gets or sets a sorting expression that is applied when the method that
		/// is specified by the EntityDataSource.SelectMethod property is called.
		/// This only applies if EnablePaging and EnableSorting are both false.
		/// </summary>
		public String Sort
		{
			get { return ((String) ViewState["Sort"]) ?? String.Empty; }
			set { ViewState["Sort"] = value; }
		}

		#endregion

		#region EntityDataSourceView Properties

		/// <summary>
		/// Gets or sets the object that the EntityDataSource object represents.
		/// </summary>
		[Browsable(false)]
		public Object Provider
		{
			get { return EntityView.Provider; }
			set { EntityView.Provider = value; }
		}

		/// <summary>
		/// Gets or sets the name of the property of the Provider which holds
		/// a reference to an object instance that the EntityDataSource object represents.
		/// </summary>
		public String ProviderName
		{
			get { return TypeProperty; }
			set { TypeProperty = value; }
		}

		/// <summary>
		/// Gets or sets the name of the class that the EntityDataSource object represents.
		/// </summary>
		public String TypeName
		{
			get { return EntityView.TypeName; }
			set { EntityView.TypeName = value; }
		}

		/// <summary>
		/// Gets or sets the name of the property of the Provider which holds
		/// a reference to an object instance that the EntityDataSource object represents.
		/// </summary>
		public String TypeProperty
		{
			get { return EntityView.TypeProperty; }
			set { EntityView.TypeProperty = value; }
		}

		/// <summary>
		/// Gets the index of the current entity when dealing with
		/// a collection of entities.
		/// </summary>
		public int EntityIndex
		{
			get { return EntityView.EntityIndex; }
		}

		/// <summary>
		/// Gets or sets the System.Type of entity that is returned by the Provider.
		/// </summary>
		[Browsable(false)]
		public Type EntityType
		{
			get { return EntityView.EntityType; }
			set { EntityView.EntityType = value; }
		}

		/// <summary>
		/// Gets or set the name of the class of the entity that is returned by the Provider.
		/// </summary>
		public String EntityTypeName
		{
			get { return EntityView.EntityTypeName; }
			set { EntityView.EntityTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the name of the primary key property of the entity.
		/// </summary>
		public String EntityKeyName
		{
			get { return EntityView.EntityKeyName; }
			set { EntityView.EntityKeyName = value; }
		}

		/// <summary>
		/// Gets or sets the name of the class of the primary key property of the entity.
		/// </summary>
		public String EntityKeyTypeName
		{
			get { return EntityView.EntityKeyTypeName; }
			set { EntityView.EntityKeyTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the System.Type of the primary key property of the entity.
		/// </summary>
		[Browsable(false)]
		public Type EntityKeyType
		{
			get { return EntityView.EntityKeyType; }
			set { EntityView.EntityKeyType = value; }
		}

		/// <summary>
		/// Gets or sets a comma-separated list of the entity's property names that
		/// will be initialized to the current system time during an insert operation.
		/// </summary>
		public String InsertDateTimeNames
		{
			get { return EntityView.InsertDateTimeNames; }
			set { EntityView.InsertDateTimeNames = value; }
		}

		/// <summary>
		/// Gets or sets a comma-separated list of the entity's property names that
		/// will be initialized to the current system time during an update operation.
		/// </summary>
		public String UpdateDateTimeNames
		{
			get { return EntityView.UpdateDateTimeNames; }
			set { EntityView.UpdateDateTimeNames = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// supports paging through the set of data that it retrieves.
		/// </summary>
		public bool EnablePaging
		{
			get { return EntityView.EnablePaging; }
			set { EntityView.EnablePaging = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// supports sorting the set of data that it retrieves.
		/// </summary>
		public bool EnableSorting
		{
			get { return EntityView.EnableSorting; }
			set { EntityView.EnableSorting = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control
		/// passes a TransactionManager instance as the first parameter of
		/// any data retreival operation.
		/// </summary>
		public bool EnableTransaction
		{
			get { return EntityView.EnableTransaction; }
			set { EntityView.EnableTransaction = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the data source control should
		/// perform a recursive deep load when the DeepLoad method is called.
		/// </summary>
		public bool EnableRecursiveDeepLoad
		{
			get { return EntityView.EnableRecursiveDeepLoad; }
			set { EntityView.EnableRecursiveDeepLoad = value; }
		}

		#endregion

		#region EntityDataSourceView Events

		/// <summary>
		/// Occurs before a select operation.
		/// </summary>
		public event EntityDataSourceSelectingEventHandler Selecting;

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		public event EntityDataSourceMethodEventHandler Selected;

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		public event EntityDataSourceMethodEventHandler Inserting;

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		public event EntityDataSourceMethodEventHandler Inserted;

		/// <summary>
		/// Occurs before an update operation
		/// </summary>
		public event EntityDataSourceMethodEventHandler Updating;

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		public event EntityDataSourceMethodEventHandler Updated;

		/// <summary>
		/// Occurs before a delete operation.
		/// </summary>
		public event EntityDataSourceMethodEventHandler Deleting;

		/// <summary>
		/// Occurs when a delete operation has completed.
		/// </summary>
		public event EntityDataSourceMethodEventHandler Deleted;

		#endregion

		#region ILinkedDataSource Events

		/// <summary>
		/// Occurs when a select operation has completed.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterSelected;

		/// <summary>
		/// Occurs before an insert operation.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterInserting;

		/// <summary>
		/// Occurs when an insert operation has completed.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterInserted;

		/// <summary>
		/// Occurs before an update operation.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterUpdating;

		/// <summary>
		/// Occurs when an update operation has completed.
		/// </summary>
		public event LinkedDataSourceEventHandler AfterUpdated;

		#endregion

		#region Methods

		/// <summary>
		/// Retrieves the named data source view that is associated with the data source control.
		/// </summary>
		/// <param name="viewName">The name of the view to retrieve.</param>
		/// <returns>The EntityDataSourceView named EntityView that is associated with the EntityDataSource.</returns>
		protected override DataSourceView GetView(string viewName)
		{
			return EntityView;
		}

		/// <summary>
		/// Retrieves a collection of names representing the list of view
		/// objects that are associated with the EntityDataSource object.
		/// </summary>
		/// <returns>An System.Collections.ICollection that contains the
		/// names of the views associated with the EntityDataSource.</returns>
		protected override ICollection GetViewNames()
		{
			return new String[] { EntityViewName };
		}

		/// <summary>
		/// Gets the current value of the EntityId parameter.
		/// </summary>
		/// <returns>The current value of the EntityId property if not null or empty,
		/// otherwise the value of the EntityId parameter, if present.</returns>
		public String GetSelectedEntityId()
		{
			String entityId = EntityId;

			if ( String.IsNullOrEmpty(entityId) )
			{
				entityId = GetParameterStringValue(EntityIdParameterName);
			}

			return entityId;
		}

		/// <summary>
		/// Sets the value of the EntityId property.
		/// </summary>
		/// <param name="entityId">The entityId to update.</param>
		private void UpdateEntityId(String entityId)
		{
			ViewState[EntityIdParameterName] = entityId;
		}

		/// <summary>
		/// Gets the value of the WhereClause parameter as a string.
		/// </summary>
		/// <returns>A string representing the current value of the WhereClause parameter.</returns>
		public String GetWhereClause()
		{
			return GetParameterStringValue(WhereClauseParameterName);
		}

		/// <summary>
		/// Gets the value of the OrderByClause parameter as a string.
		/// </summary>
		/// <returns>A string representing the current value of the OrderByClause parameter.</returns>
		public String GetOrderByClause()
		{
			return GetParameterStringValue(OrderByClauseParameterName);
		}

		/// <summary>
		/// Gets the value of the PageIndex parameter as an int.
		/// </summary>
		/// <returns>A System.Int32 representing the current value of the PageIndex parameter.</returns>
		public int GetPageIndex()
		{
			return GetParameterIntValue(PageIndexParameterName);
		}

		/// <summary>
		/// Gets the value of the PageSize parameter as an int.
		/// </summary>
		/// <returns>A System.Int32 representing the current value of the PageSize parameter.</returns>
		public int GetPageSize()
		{
			return GetParameterIntValue(PageSizeParameterName);
		}

		/// <summary>
		/// Gets a reference to the current list of entities.
		/// </summary>
		/// <returns>The current list of entities if present, otherwise
		/// the data will be retreived by the Provider and cached for future use.</returns>
		public IEnumerable GetEntityList()
		{
			return EntityView.GetEntityList();
		}

		/// <summary>
		/// Gets a specific entry from the cached list of entities
		/// based on the value of the EntityIndex property.
		/// </summary>
		/// <returns>The current business object.</returns>
		public Object GetCurrentEntity()
		{
			return EntityView.GetCurrentEntity();
		}

		/// <summary>
		/// Creates a new instance of the class specified by the
		/// EntityType property.
		/// </summary>
		/// <returns>A new instance of the business object.</returns>
		public Object GetNewEntity()
		{
			return EntityView.GetNewEntity();
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		public void DeepLoad()
		{
			EntityView.DeepLoad();
		}

		/// <summary>
		/// Performs an insert operation on the list of data
		/// that the EntityDataSourceView object represents.
		/// </summary>
		/// <param name="values">A System.Collections.IDictionary of
		/// name/value pairs used during an insert operation.</param>
		/// <returns>The number of items that were inserted into the underlying data storage.</returns>
		public int Insert(IDictionary values)
		{
			return EntityView.Insert(values);
		}

		/// <summary>
		/// Performs an update operation on the list of data
		/// that the EntityDataSourceView object represents.
		/// </summary>
		/// <param name="entity">The business object to delete.</param>
		/// <param name="values">A System.Collections.IDictionary of
		/// name/value pairs used during an update operation.</param>
		/// <returns>The number of items that were updated into the underlying data storage.</returns>
		public int Update(Object entity, IDictionary values)
		{
			return EntityView.Update(entity, values);
		}

		/// <summary>
		/// Performs a delete operation on the list of data
		/// that the EntityDataSourceView object represents.
		/// </summary>
		/// <param name="entity">The business object to delete.</param>
		/// <returns>The number of items that were deleted into the underlying data storage.</returns>
		public int Delete(Object entity)
		{
			return EntityView.Delete(entity);
		}

		#endregion

		#region Parameter Helper Methods
		/// <summary>
		/// Raises the System.Web.UI.Control.Init event.
		/// </summary>
		/// <param name="e">A System.EventArgs object that contains the event data.</param>
		protected override void OnInit(EventArgs e)
		{
			Page.LoadComplete += new EventHandler(this.OnPageLoadComplete);
		}

		/// <summary>
		/// Handles the Page.LoadComplete event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">A System.EventArgs object that contains the event data.</param>
		private void OnPageLoadComplete(object sender, EventArgs e)
		{
			if ( _parameters != null )
			{
				_parameters.UpdateValues(Context, this);
			}
		}

		/// <summary>
		/// Handles the ParameterCollection.ParametersChanged event.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">A System.EventArgs object that contains the event data.</param>
		private void OnParametersChanged(object sender, EventArgs e)
		{
			EntityView.RaiseChangedEvent();
		}

		/// <summary>
		/// Loads the previously saved view state of the
		/// EntityDataSource control.
		/// </summary>
		/// <param name="state">An object that contains
		/// the saved view state values for the control.</param>
		protected override void LoadViewState(object state)
		{
			object baseState = null;

			if ( state != null )
			{
				Pair p = (Pair) state;
				baseState = p.First;

				if ( p.Second != null )
				{
					((IStateManager) Parameters).LoadViewState(p.Second);
				}
			}

			base.LoadViewState(baseState);
		}

		/// <summary>
		/// Saves the state of the EntityDataSource control.
		/// </summary>
		/// <returns>Returns the server control's current view state; otherwise,
		/// null, if there is no view state associated with the control.</returns>
		protected override object SaveViewState()
		{
			object baseState = base.SaveViewState();
			object parameterState = null;

			if ( _parameters != null )
			{
				parameterState = ((IStateManager) _parameters).SaveViewState();
			}

			if ( (baseState != null) || (parameterState != null) )
			{
				return new Pair(baseState, parameterState);
			}

			return null;
		}

		/// <summary>
		/// Tracks view-state changes to the EntityDataSource control so
		/// that they can be stored in the System.Web.UI.StateBag object.
		/// </summary>
		protected override void TrackViewState()
		{
			base.TrackViewState();
			if ( _parameters != null )
			{
				((IStateManager) _parameters).TrackViewState();
			}
		}

		/// <summary>
		/// Gets the current value of the parameter with the name specified
		/// by the parameterName argument.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.</param>
		/// <returns>A System.String representing the current value of the parameter.</returns>
		public String GetParameterStringValue(String parameterName)
		{
			return String.Format("{0}", GetParameterValue(parameterName));
		}

		/// <summary>
		/// Gets the current value of the parameter with the name specified
		/// by the parameterName argument.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.</param>
		/// <returns>A System.Int32 representing the current value of the parameter.</returns>
		public int GetParameterIntValue(String parameterName)
		{
			object objValue = GetParameterValue(parameterName);
			int value = 0;

			if ( objValue != null )
			{
				value = (int) objValue;
			}

			return value;
		}

		/// <summary>
		/// Gets the current value of the parameter with the name specified
		/// by the parameterName argument.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.</param>
		/// <returns>A System.Object representing the current value of the parameter.</returns>
		public Object GetParameterValue(String parameterName)
		{
			IOrderedDictionary values = GetParameterValueMap(parameterName);
			Object value = null;

			if ( values != null )
			{
				value = values[parameterName];
			}

			return value;
		}

		/// <summary>
		/// Gets an ordered collection of parameter names and values, but only if
		/// a parameter exists with the name specified by the parameterName argument.
		/// </summary>
		/// <param name="parameterName">The name of the parameter.</param>
		/// <returns>An IOrderedDictionary containing the names and values
		/// currently held in the Parameters collection if there is currently
		/// a parameter named <paramref name="parameterName"/>, otherwise null.</returns>
		private IOrderedDictionary GetParameterValueMap(String parameterName)
		{
			IOrderedDictionary values = GetParameterValueMap();

			if ( values != null && _parameters[parameterName] == null )
			{
				values = null;
			}

			return values;
		}

		/// <summary>
		/// Gets an ordered collection of parameter names and values.
		/// </summary>
		/// <returns>An IOrderedDictionary containing the names and values
		/// currently held in the Parameters collection.</returns>
		private IOrderedDictionary GetParameterValueMap()
		{
			IOrderedDictionary values = null;

			if ( _parameters != null )
			{
				values = _parameters.GetValues(Context, this);
			}

			return values;
		}
		#endregion

		/// <summary>
		/// Supports the EntityDataSource control and provides an interface for
		/// data-bound controls to perform data operations with business and data objects.
		/// </summary>
		private sealed class EntityDataSourceView : DataSourceView
		{
			#region Declarations
			
			private EntityDataSource _owner;
			private IEnumerable _entityList;
			private IEnumerable _prevEntityList;
			private Type _providerType = typeof(DataRepository);
			private Type _entityType;
			private Type _entityKeyType;
			private Object _provider;
			private bool _enableRecursiveDeepLoad;
			private bool _enableTransaction = true;
			private bool _enablePaging;
			private bool _enableSorting;
			private bool _isDeepLoaded;
			private int _entityIndex = 0;
			private int _prevEntityIndex = 0;
			private int _entityCount = -1;
			private int _prevEntityCount = -1;

			private String _typeName;
			private String _typeInstanceProperty;
			private String _typeProperty;
			private String _entityTypeName;
			private String _entityKeyName;
			private String _entityKeyTypeName;
			private String _prevEntityId;
			private String _insertDateTimeNames;
			private String _updateDateTimeNames;
			
			#endregion

			#region Constructors
			/// <summary>
			/// Initializes a new instance of the EntityDataSourceView class.
			/// </summary>
			/// <param name="owner">A reference to the EntityDataSource which created this instance.</param>
			/// <param name="viewName">The name of the view, which defaults to EntityView.</param>
			public EntityDataSourceView(EntityDataSource owner, String viewName)
				: base(owner, viewName)
			{
				_owner = owner;
			}
			#endregion

			#region Public Properties

			public Type ProviderType
			{
				get
				{
					if ( _providerType == null )
					{
						_providerType = EntityUtil.GetType(TypeName);
					}

					return _providerType;
				}
				set { _providerType = value; }
			}

			public Object Provider
			{
				get
				{
					if ( _provider == null )
					{
						Type t = ProviderType;

						if ( String.IsNullOrEmpty(TypeProperty) )
						{
							_provider = EntityUtil.GetNewEntity(t);
						}
                        else if (String.IsNullOrEmpty(TypeInstanceProperty))
                        {
                            _provider = EntityUtil.GetStaticPropertyValue(t, TypeProperty);
                        }
						else
						{
                            Object providerManager = EntityUtil.GetStaticPropertyValue(t, TypeInstanceProperty);
                            _provider = EntityUtil.GetPropertyValue(providerManager, TypeProperty);
						}
					}

					return _provider;
				}
				set
				{
					_provider = value;
				}
			}

			/// <summary>
			/// Gets the index of the current entity when dealing with
			/// a collection of entities.
			/// </summary>
			public int EntityIndex
			{
				get { return _entityIndex; }
			}

			public String EntityTypeName
			{
				get { return _entityTypeName; }
				set { _entityTypeName = value; }
			}

			public Type EntityType
			{
				get
				{
					if ( _entityType == null )
					{
						_entityType = EntityUtil.GetType(EntityTypeName);
					}

					return _entityType;
				}
				set
				{
					_entityType = value;
				}
			}

			public String EntityKeyName
			{
				get { return _entityKeyName; }
				set { _entityKeyName = value; }
			}

			public String EntityKeyTypeName
			{
				get { return _entityKeyTypeName; }
				set { _entityKeyTypeName = value; }
			}

			public Type EntityKeyType
			{
				get
				{
					if ( _entityKeyType == null )
					{
						_entityKeyType = EntityUtil.GetType(EntityKeyTypeName);
					}

					return _entityKeyType;
				}
				set { _entityKeyType = value; }
			}

			public String TypeName
			{
				get { return _typeName; }
				set
				{
					_providerType = null;
					_typeName = value;
				}
			}

			public String TypeProperty
			{
				get { return _typeProperty; }
				set { _typeProperty = value; }
			}

			public String TypeInstanceProperty
			{
				get { return _typeInstanceProperty; }
				set { _typeInstanceProperty = value; }
			}

			public String SelectMethod
			{
				get { return _owner.SelectMethod; }
				set { _owner.SelectMethod = value; }
			}

			public String InsertMethod
			{
				get { return _owner.InsertMethod; }
				set { _owner.InsertMethod = value; }
			}

			public String UpdateMethod
			{
				get { return _owner.UpdateMethod; }
				set { _owner.UpdateMethod = value; }
			}

			public String DeleteMethod
			{
				get { return _owner.DeleteMethod; }
				set { _owner.DeleteMethod = value; }
			}

			public String InsertDateTimeNames
			{
				get { return _insertDateTimeNames; }
				set { _insertDateTimeNames = value; }
			}

			public String UpdateDateTimeNames
			{
				get { return _updateDateTimeNames; }
				set { _updateDateTimeNames = value; }
			}

			public String Filter
			{
				get { return _owner.Filter; }
				set { _owner.Filter = value; }
			}

			public String Sort
			{
				get { return _owner.Sort; }
				set { _owner.Sort = value; }
			}

			public override bool CanInsert
			{
				get { return !String.IsNullOrEmpty(InsertMethod); }
			}

			public override bool CanUpdate
			{
				get { return !String.IsNullOrEmpty(UpdateMethod); }
			}

			public override bool CanDelete
			{
				get { return !String.IsNullOrEmpty(DeleteMethod); }
			}

			public override bool CanPage
			{
				get { return EnablePaging; }
			}

			public override bool CanSort
			{
				get { return EnableSorting; }
			}

			public override bool CanRetrieveTotalRowCount
			{
				get { return CanPage; }
			}

			public bool IsDeepLoaded
			{
				get { return _isDeepLoaded; }
			}

			public bool EnablePaging
			{
				get { return _enablePaging; }
				set { _enablePaging = value; }
			}

			public bool EnableSorting
			{
				get { return _enableSorting; }
				set { _enableSorting = value; }
			}

			/// <summary>
			/// Gets or sets a value indicating whether the data source control
			/// passes a TransactionManager instance as the first parameter of
			/// any data retreival operation.
			/// </summary>
			public bool EnableTransaction
			{
				get { return _enableTransaction; }
				set { _enableTransaction = value; }
			}

			/// <summary>
			/// Gets or sets a value indicating whether the data source control should
			/// perform a recursive deep load when the DeepLoad method is called.
			/// </summary>
			internal bool EnableRecursiveDeepLoad
			{
				get { return _enableRecursiveDeepLoad; }
				set { _enableRecursiveDeepLoad = value; }
			}

			#endregion

			#region Select Methods

			/// <summary>
			/// Gets a list of data from the underlying data storage.
			/// </summary>
			/// <param name="arguments">A System.Web.UI.DataSourceSelectArguments that
			/// is used to request operations on the data beyond basic data retrieval.</param>
			/// <returns>An System.Collections.IEnumerable list of data from the underlying data storage.</returns>
			protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
			{
				arguments.RaiseUnsupportedCapabilitiesError(this);
				IEnumerable entityList = null;

				Hashtable param = new Hashtable();
				Object entityId = GetEntityId();

				if ( entityId != null )
				{
					String key = EntityKeyName ?? EntityDataSource.EntityIdParameterName;
					param.Add(key, entityId);
				}

				EntityDataSourceSelectingEventArgs eventArgs = new EntityDataSourceSelectingEventArgs(param, arguments);
				OnSelecting(eventArgs);

				if ( eventArgs.Cancel )
				{
					return null;
				}

				try
				{
					entityList = GetEntityList(arguments);

					if ( entityList != null )
					{
						IList list = EntityUtil.GetEntityList(entityList);

						// make sure we have a valid TotalRowCount
						if ( arguments.TotalRowCount < 1 )
						{
							arguments.TotalRowCount = list.Count;
						}

						UpdateEntityId(entityList);
						OnSelected(new EntityDataSourceMethodEventArgs(entityList, EntityIndex, param, arguments.TotalRowCount));

						if ( arguments.TotalRowCount > 0 && list.Count > 0 )
						{
							// raise linked event
							OnAfterSelected(new LinkedDataSourceEventArgs(list[EntityIndex], _owner.GetParameterValueMap(), EntityIndex));
						}
					}
				}
				catch ( Exception ex )
				{
					EntityDataSourceMethodEventArgs e = new EntityDataSourceMethodEventArgs(entityList, EntityIndex, param, 0, ex);
					OnSelected(e);

					if ( !e.ExceptionHandled )
					{
						throw;
					}
				}

				return entityList;
			}

			#endregion

			#region Insert Methods

			/// <summary>
			/// Performs an insert operation on the list of data
			/// that the EntityDataSourceView object represents.
			/// </summary>
			/// <param name="values">A System.Collections.IDictionary of
			/// name/value pairs used during an insert operation.</param>
			/// <returns>The number of items that were inserted into the underlying data storage.</returns>
			internal int Insert(IDictionary values)
			{
				int count = 0;

				if ( values != null )
				{
					SetPreviousValues();

					count = ExecuteInsert(values);

					ResetPreviousValues();
				}

				return count;
			}

			/// <summary>
			/// Performs an insert operation on the list of data
			/// that the EntityDataSourceView object represents.
			/// </summary>
			/// <param name="values">A System.Collections.IDictionary of
			/// name/value pairs used during an insert operation.</param>
			/// <returns>The number of items that were inserted into the underlying data storage.</returns>
			protected override int ExecuteInsert(IDictionary values)
			{
				Object entity = GetNewEntity();
				IEnumerable entityList = new Object[] { entity };
				Guid entityId = Guid.Empty;

				ValidateEntity(entityList);

				EntityDataSourceMethodEventArgs eventArgs = new EntityDataSourceMethodEventArgs(entityList, 0, values);
				OnInserting(eventArgs);

				if ( eventArgs.Cancel )
				{
					return 0;
				}

				// raise linked event
				OnAfterInserting(new LinkedDataSourceEventArgs(entity, values, 0));

				// set date/time values
				String[] names = GetInsertDateTimeNames();
				EntityUtil.InitEntityDateTimeValues(entity, names);
				EntityUtil.SetEntityValues(entity, values);

				// set primary key value
				if ( !String.IsNullOrEmpty(EntityKeyName) )
				{
					entityId = EntityUtil.SetEntityKeyValue(entity, EntityKeyName);
				}

				// perform insert
				Object[] args = GetArgs(entity);
				int count = 0;

				try
				{
					Object result = EntityUtil.InvokeMethod(Provider, InsertMethod, args);

					if ( result == null || Convert.ToBoolean(result) )
					{
						count = 1;
						UpdateEntityId(entityList);
						OnInserted(new EntityDataSourceMethodEventArgs(entityList, 0, values, count));
						OnAfterInserted(new LinkedDataSourceEventArgs(entity, values, 0));
						RaiseChangedEvent();
					}
				}
				catch ( Exception ex )
				{
					EntityDataSourceMethodEventArgs e = new EntityDataSourceMethodEventArgs(entityList, 0, values, count, ex);
					OnInserted(e);

					if ( !e.ExceptionHandled )
					{
						throw;
					}
				}

				return count;
			}

			#endregion

			#region Update Methods

			/// <summary>
			/// Performs an update operation on the list of data
			/// that the EntityDataSourceView object represents.
			/// </summary>
			/// <param name="entity">The business object to update.</param>
			/// <param name="values">An System.Collections.IDictionary of name/value
			/// pairs that represent data elements and their original values.</param>
			/// <returns>The number of items that were updated in the underlying data storage.</returns>
			internal int Update(Object entity, IDictionary values)
			{
				int count = 0;

				if ( entity != null && values != null )
				{
					SetPreviousValues();

					// set initial index
					_entityIndex = 0;
					// set temporary reference
					_entityList = new Object[] { entity };
					// perform delete operation
					count = ExecuteUpdate(new Hashtable(), values, new Hashtable());

					ResetPreviousValues();
				}

				return count;
			}

			/// <summary>
			/// Performs an update operation on the list of data
			/// that the EntityDataSourceView object represents.
			/// </summary>
			/// <param name="keys">An System.Collections.IDictionary of object or
			/// row keys to be updated by the update operation.</param>
			/// <param name="values">An System.Collections.IDictionary of name/value
			/// pairs that represent data elements and their original values.</param>
			/// <param name="oldValues">An System.Collections.IDictionary of name/value
			/// pairs that represent data elements and their new values.</param>
			/// <returns>The number of items that were updated in the underlying data storage.</returns>
			protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
			{
				IEnumerable entityList = GetEntityList();
				ValidateEntity(entityList);

				// set the EntityIndex based on keys
				SetEntityIndex(entityList, keys);

				EntityDataSourceMethodEventArgs eventArgs = new EntityDataSourceMethodEventArgs(entityList, EntityIndex, values);
				OnUpdating(eventArgs);

				if ( eventArgs.Cancel )
				{
					return 0;
				}

				// get the current item in the collection
				Object entity = GetCurrentEntity();

				// raise linked event
				OnAfterUpdating(new LinkedDataSourceEventArgs(entity, values, EntityIndex));

				// set date/time values
				String[] names = GetUpdateDateTimeNames();
				EntityUtil.InitEntityDateTimeValues(entity, names);
				EntityUtil.SetEntityValues(entity, values);

				// perform update
				Object[] args = GetArgs(entity);
				int count = 0;

				try
				{
					Object result = EntityUtil.InvokeMethod(Provider, UpdateMethod, args);

					if ( result == null || Convert.ToBoolean(result) )
					{
						count = 1;
						UpdateEntityId(entityList);
						OnUpdated(new EntityDataSourceMethodEventArgs(entityList, EntityIndex, values, count));
						OnAfterUpdated(new LinkedDataSourceEventArgs(entity, values, EntityIndex));
						RaiseChangedEvent();
					}
				}
				catch ( Exception ex )
				{
					EntityDataSourceMethodEventArgs e = new EntityDataSourceMethodEventArgs(entityList, EntityIndex, values, count, ex);
					OnUpdated(e);

					if ( !e.ExceptionHandled )
					{
						throw;
					}
				}

				return count;
			}

			#endregion

			#region Delete Methods

			/// <summary>
			/// Performs a delete operation on the list of data
			/// that the EntityDataSourceView object represents.
			/// </summary>
			/// <param name="entity">The business object to delete.</param>
			/// <returns>The number of items that were deleted from the underlying data storage.</returns>
			internal int Delete(Object entity)
			{
				int count = 0;

				if ( entity != null )
				{
					SetPreviousValues();

					// set initial index
					_entityIndex = 0;
					// set temporary reference
					_entityList = new Object[] { entity };
					// perform delete operation
					count = ExecuteDelete(new Hashtable(), new Hashtable());

					ResetPreviousValues();
				}

				return count;
			}

			/// <summary>
			/// Performs a delete operation on the list of data
			/// that the EntityDataSourceView object represents.
			/// </summary>
			/// <param name="keys">A System.Collections.IDictionary of object or
			/// row keys to be deleted by the ExecuteDelete operation.</param>
			/// <param name="oldValues">An System.Collections.IDictionary of name/value
			/// pairs that represent data elements and their original values.</param>
			/// <returns>The number of items that were deleted from the underlying data storage.</returns>
			protected override int ExecuteDelete(IDictionary keys, IDictionary oldValues)
			{
				IEnumerable entityList = GetEntityList();
				ValidateEntity(entityList);

				// set the EntityIndex based on keys
				SetEntityIndex(entityList, keys);

				EntityDataSourceMethodEventArgs eventArgs = new EntityDataSourceMethodEventArgs(entityList, EntityIndex, oldValues);
				OnDeleting(eventArgs);

				if ( eventArgs.Cancel )
				{
					return 0;
				}

				// get the current item in the collection
				Object entity = GetCurrentEntity();

				// perform delete
				Object[] args = GetArgs(entity);
				int count = 0;

				try
				{
					Object result = EntityUtil.InvokeMethod(Provider, DeleteMethod, args);

					if ( result == null || Convert.ToBoolean(result) )
					{
						count = 1;
						OnDeleted(new EntityDataSourceMethodEventArgs(entityList, EntityIndex, oldValues, count));
						RaiseChangedEvent();
					}
				}
				catch ( Exception ex )
				{
					EntityDataSourceMethodEventArgs e = new EntityDataSourceMethodEventArgs(entityList, EntityIndex, oldValues, count, ex);
					OnDeleted(e);

					if ( !e.ExceptionHandled )
					{
						throw;
					}
				}

				return count;
			}

			#endregion

			#region Entity Methods

			/// <summary>
			/// Gets a reference to the requested list of entities.
			/// </summary>
			/// <returns>The current list of entities if present, otherwise
			/// the data will be retreived by the Provider and cached for future use.</returns>
			internal IEnumerable GetEntityList()
			{
				return GetEntityList(null);
			}

			/// <summary>
			/// Gets a reference to the requested list of entities.
			/// </summary>
			/// <param name="arguments">An instance of System.Web.UI.DataSourceSelectArguments.</param>
			/// <returns>The current list of entities if present, otherwise
			/// the data will be retreived by the Provider and cached for future use.</returns>
			private IEnumerable GetEntityList(DataSourceSelectArguments arguments)
			{
				if ( _entityList == null && !String.IsNullOrEmpty(SelectMethod) )
				{
					Object entityId = GetEntityId();
					Object entity = null;

					// reset _entityIndex property
					_entityIndex = 0;
					// reset _entityCount property
					_entityCount = -1;

					if ( entityId != null )
					{
						Object[] args = GetArgs(entityId);
						entity = EntityUtil.InvokeMethod(Provider, SelectMethod, args);
					}
					else
					{
						if ( EnablePaging )
						{
							entity = GetPagedAndSortedData(arguments);
						}
						else
						{
							entity = EntityUtil.InvokeMethod(Provider, SelectMethod, GetArgumentValues(true));
						}
					}
					if ( entity != null )
					{
						if ( entity is IEnumerable )
						{
							// make sure paging and sorting were not enabled
							if ( !EnablePaging && !EnableSorting )
							{
								// apply filter
								if ( !String.IsNullOrEmpty(Filter) )
								{
									EntityUtil.SetPropertyValue(entity, "Filter", Filter);
								}
								// apply sort
								if ( !String.IsNullOrEmpty(Sort) )
								{
									EntityUtil.InvokeMethod(entity, "Sort", new Object[] { Sort });
								}
							}

							_entityList = entity as IEnumerable;
						}
						else
						{
							_entityList = new Object[] { entity };
						}
					}
				}
				else if ( arguments != null && _entityCount > -1 )
				{
					// be sure to set the total row count if using the cached list
					arguments.TotalRowCount = _entityCount;
				}

				return _entityList;
			}

			/// <summary>
			/// Gets a specific entry from the cached list of entities
			/// based on the value of the EntityIndex property.
			/// </summary>
			/// <returns>The current business object.</returns>
			internal Object GetCurrentEntity()
			{
				if ( _entityList != null )
				{
					Object[] array = _entityList as Object[];
					if ( array != null && array.Length > EntityIndex )
					{
						return array[EntityIndex];
					}

					IList list = _entityList as IList;
					if ( list != null && list.Count > EntityIndex )
					{
						return list[EntityIndex];
					}
				}

				return _entityList;
			}

			/// <summary>
			/// Creates a new instance of the class specifed by the
			/// EntityType property.
			/// </summary>
			/// <returns>A new instance of the business object.</returns>
			internal Object GetNewEntity()
			{
				return EntityUtil.GetNewEntity(EntityType);
			}

			#endregion

			#region Helper Methods

			private void ValidateEntity(IEnumerable entityList)
			{
				if ( entityList == null )
				{
					throw new NullReferenceException("entityList cannot be null");
				}
			}

			private Object[] GetArgumentValues()
			{
				return GetArgumentValues(false);
			}

			private Object[] GetArgumentValues(bool convertStringToGuid)
			{
				IOrderedDictionary values = _owner.GetParameterValueMap();
				ParameterCollection parameters = _owner.Parameters;
				Object[] result = new Object[parameters.Count];
				Parameter parameter;
				Object value;

				for ( int i = 0; i < parameters.Count; i++ )
				{
					parameter = parameters[i];
					value = values[parameter.Name];

					if ( convertStringToGuid && value is string )
					{
						// System.TypeCode and DataSource parameters do not support Guid, this is a workaround.
						Guid valueAsGuid;
						if ( EntityUtil.GuidTryParse(value as string, out valueAsGuid) )
						{
							value = valueAsGuid;
						}
					}

					result[i] = value;
				}

				return GetArgs(result);
			}

			private Object[] GetArgs(params Object[] args)
			{
				if ( EnableTransaction )
				{
					Object[] newArgs = new Object[args.Length + 1];
					newArgs[0] = EntityTransactionModule.TransactionManager;

					if ( args.Length > 0 )
					{
						args.CopyTo(newArgs, 1);
					}

					args = newArgs;
				}

				return args;
			}

			/// <summary>
            /// Gets the types.
            /// </summary>
            /// <param name="types">The types.</param>
            /// <returns></returns>
			private Type[] GetTypes(params Type[] types)
			{
				if ( EnableTransaction )
				{
					Type[] newTypes = new Type[types.Length + 1];
					newTypes[0] = typeof(ITransactionManager);

					if ( types.Length > 0 )
					{
						types.CopyTo(newTypes, 1);
					}

					types = newTypes;
				}

				return types;
			}

			private Object GetEntityId()
			{
				String entityId = _owner.GetSelectedEntityId();
				Object objectId = null;

				if ( !String.IsNullOrEmpty(entityId) )
				{
					if ( typeof(String).Equals(EntityKeyType) )
					{
						objectId = entityId;
					}
					else if ( typeof(Int32).Equals(EntityKeyType) )
					{
						int intId;

						if ( Int32.TryParse(entityId, out intId) )
						{
							objectId = intId;
						}
					}
					else
					{
						objectId = new Guid(entityId);
					}
				}

				return objectId;
			}

			private void UpdateEntityId(IEnumerable entityList)
			{
				if ( entityList != null )
				{
					// list needed by GetCurrentEntity()
					_entityList = entityList;
					// get indexed entity
					Object entity = GetCurrentEntity();
					// get primary key value
					Object entityId = EntityUtil.GetPropertyValue(entity, EntityKeyName);
					// update property
					_owner.UpdateEntityId(String.Format("{0}", entityId));
				}

				// update reference
				_entityList = entityList;
			}

			private void SetEntityIndex(IEnumerable entityList, IDictionary keys)
			{
				if ( entityList != null && keys != null && keys.Count > 0 )
				{
					IList list = EntityUtil.GetEntityList(entityList);
					String propertyName = null;
					Object value = null;

					foreach ( Object key in keys.Keys )
					{
						propertyName = key.ToString();
						value = keys[key];
						break;
					}

					Object entity = EntityUtil.GetEntity(list, propertyName, value);
					_entityIndex = list.IndexOf(entity);
				}
			}

			private Object GetPagedAndSortedData(DataSourceSelectArguments arguments)
			{
				IOrderedDictionary values = _owner.GetParameterValueMap();
				int paramCount = _owner.Parameters.Count;
				int countIndex = -1;

				Object[] args = new Object[paramCount];
				Type[] types = new Type[paramCount];
				Object entity = null;

				Parameter param;
				Object value;
				Type type;

				for ( int i = 0; i < paramCount; i++ )
				{
					param = _owner.Parameters[i];
					value = values[param.Name];
					type = value.GetType();

					if ( OrderByClauseParameterName.Equals(param.Name) )
					{
						if ( EnableSorting )
						{
							if ( arguments != null )
							{
								value = arguments.SortExpression ?? String.Empty;
								// cache the SortExpression for later use
								_owner.SortExpression = arguments.SortExpression;
							}
							else if ( _owner.SortExpression != null )
							{
								// use the cached SortExpression when arguments object is not available
								value = _owner.SortExpression;
							}
						}
					}
					else if ( RecordCountParameterName.Equals(param.Name) )
					{
						type = EntityUtil.GetType("System.Int32&");
						countIndex = i;

						// increment to account for TransactionManager argument
						if ( EnableTransaction )
						{
							countIndex++;
						}
					}
					else if ( NullableRecordCountParameterName.Equals(param.Name) )
					{
						type = EntityUtil.GetType("System.Nullable`1[System.Int32]&");
						countIndex = i;

						// increment to account for TransactionManager argument
						if ( EnableTransaction )
						{
							countIndex++;
						}
					}

					args[i] = value;
					types[i] = type;
				}

				args = GetArgs(args);
				types = GetTypes(types);

				entity = EntityUtil.InvokeMethod(Provider, SelectMethod, args, types);

				if ( arguments != null && countIndex > -1 )
				{
					int count = (int) args[countIndex];
					arguments.TotalRowCount = count;
					_entityCount = count;
				}

				return entity;
			}

			private void SetPreviousValues()
			{
				_prevEntityId = _owner.EntityId;
				_prevEntityIndex = _entityIndex;
				_prevEntityList = _entityList;
				_prevEntityCount = _entityCount;
			}

			private void ResetPreviousValues()
			{
				_owner.UpdateEntityId(_prevEntityId);
				_entityList = _prevEntityList;
				_entityIndex = _prevEntityIndex;
				_entityCount = _prevEntityCount;

				_prevEntityId = null;
				_prevEntityList = null;
				_prevEntityIndex = 0;
				_prevEntityCount = -1;
			}

			internal String[] GetInsertDateTimeNames()
			{
				return GetNames(InsertDateTimeNames);
			}

			internal String[] GetUpdateDateTimeNames()
			{
				return GetNames(UpdateDateTimeNames);
			}

			internal String[] GetNames(String value)
			{
				String[] names = new String[0];

				if ( !String.IsNullOrEmpty(value) )
				{
					names = value.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
					for ( int i = 0; i < names.Length; i++ )
					{
						names[i] = names[i].Trim();
					}
				}

				return names;
			}

			/// <summary>
			/// Performs a DeepLoad operation for the current entity if it has
			/// not already been performed.
			/// </summary>
			internal void DeepLoad()
			{
				if ( !IsDeepLoaded )
				{
					Object entity = GetCurrentEntity();
					
					if ( entity != null )
					{
						Object[] args = { entity, EnableRecursiveDeepLoad };
						EntityUtil.InvokeMethod(Provider, "DeepLoad", args);
						_isDeepLoaded = true;
					}
				}
			}
			#endregion

			#region Event Methods

			/// <summary>
			/// Raises the DataSourceView.OnDataSourceViewChanged event.
			/// </summary>
			internal void RaiseChangedEvent()
			{
				_entityList = null;
				OnDataSourceViewChanged(EventArgs.Empty);
			}

			/// <summary>
			/// Raises the EntityDataSource.Selecting event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceSelectingEventArgs containing the event data.</param>
			internal void OnSelecting(EntityDataSourceSelectingEventArgs args)
			{
				if ( _owner.Selecting != null )
				{
					_owner.Selecting(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Selected event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnSelected(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Selected != null )
				{
					_owner.Selected(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Inserting event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnInserting(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Inserting != null )
				{
					_owner.Inserting(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Inserted event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnInserted(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Inserted != null )
				{
					_owner.Inserted(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Updating event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnUpdating(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Updating != null )
				{
					_owner.Updating(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Updated event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnUpdated(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Updated != null )
				{
					_owner.Updated(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Deleting event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnDeleting(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Deleting != null )
				{
					_owner.Deleting(_owner, args);
				}
			}

			/// <summary>
			/// Raises the EntityDataSource.Deleted event.
			/// </summary>
			/// <param name="args">An instance of EntityDataSourceMethodEventArgs containing the event data.</param>
			internal void OnDeleted(EntityDataSourceMethodEventArgs args)
			{
				if ( _owner.Deleted != null )
				{
					_owner.Deleted(_owner, args);
				}
			}

			/// <summary>
			/// Raises the AfterSelected event.
			/// </summary>
			/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
			internal void OnAfterSelected(LinkedDataSourceEventArgs e)
			{
				if ( _owner.AfterSelected != null )
				{
					_owner.AfterSelected(_owner, e);
				}
			}

			/// <summary>
			/// Raises the AfterInserting event.
			/// </summary>
			/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
			internal void OnAfterInserting(LinkedDataSourceEventArgs e)
			{
				if ( _owner.AfterInserting != null )
				{
					_owner.AfterInserting(_owner, e);
				}
			}

			/// <summary>
			/// Raises the AfterInserted event.
			/// </summary>
			/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
			internal void OnAfterInserted(LinkedDataSourceEventArgs e)
			{
				if ( _owner.AfterInserted != null )
				{
					_owner.AfterInserted(_owner, e);
				}
			}

			/// <summary>
			/// Raises the AfterUpdating event.
			/// </summary>
			/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
			internal void OnAfterUpdating(LinkedDataSourceEventArgs e)
			{
				if ( _owner.AfterUpdating != null )
				{
					_owner.AfterUpdating(_owner, e);
				}
			}

			/// <summary>
			/// Raises the AfterUpdated event.
			/// </summary>
			/// <param name="e">An instance of LinkedDataSourceEventArgs containing the event data.</param>
			internal void OnAfterUpdated(LinkedDataSourceEventArgs e)
			{
				if ( _owner.AfterUpdated != null )
				{
					_owner.AfterUpdated(_owner, e);
				}
			}

			#endregion
		}
	}

	#region Event Helpers
	/// <summary>
	/// Represents the method that will handle the
	/// Selecting event of the EntityDataSource control.
	/// </summary>
	public delegate void EntityDataSourceSelectingEventHandler(Object sender, EntityDataSourceSelectingEventArgs args);

	/// <summary>
	/// Represents the method that will handle the Inserting, Updating, and
	/// Deleting events of the EntityDataSource control.
	/// </summary>
	public delegate void EntityDataSourceMethodEventHandler(Object sender, EntityDataSourceMethodEventArgs args);

	/// <summary>
	/// Provides data for the Selecting event
	/// of the EntityDataSource control.
	/// </summary>
	public class EntityDataSourceSelectingEventArgs : CancelEventArgs
	{
		private IDictionary _inputParameters;
		private DataSourceSelectArguments _arguments;

		/// <summary>
		/// Initializes a new instance of the EntityDataSourceSelectingEventArgs class.
		/// </summary>
		/// <param name="inputParameters">A collection of name/value pairs submitted during the current operation.</param>
		/// <param name="arguments">An instance of System.Web.UI.DataSourceSelectArguments.</param>
		public EntityDataSourceSelectingEventArgs(IDictionary inputParameters, DataSourceSelectArguments arguments)
		{
			_inputParameters = inputParameters;
			_arguments = arguments;
		}

		/// <summary>
		/// Gets a collection that contains business object method parameters and their values.
		/// </summary>
		public IDictionary InputParameters
		{
			get { return _inputParameters; }
		}

		/// <summary>
		/// Provides a mechanism that the EntityDataSource object can use
		/// to request data-related operations when data is retrieved.
		/// </summary>
		public DataSourceSelectArguments Arguments
		{
			get { return _arguments; }
		}
	}

	/// <summary>
	/// Provides data for the Inserting, Updating, and
	/// Deleting events of the EntityDataSource control.
	/// </summary>
	public class EntityDataSourceMethodEventArgs : CancelEventArgs
	{
		private IEnumerable _entityList;
		private IDictionary _inputParameters;
		private Exception _exception;
		private bool _exceptionHandled;
		private int _index;
		private int _affectedRows;

		/// <summary>
		/// Initializes a new instance of the EntityDataSourceEventArgs class.
		/// </summary>
		/// <param name="entityList">The objects on which the current operation is being performed.</param>
		/// <param name="index">The index of the current item being operated on.</param>
		/// <param name="inputParameters">A collection of name/value pairs submitted during the current operation.</param>
		public EntityDataSourceMethodEventArgs(IEnumerable entityList, int index, IDictionary inputParameters)
		{
			this._entityList = entityList;
			this._index = index;
			this._inputParameters = inputParameters;
		}

		/// <summary>
		/// Initializes a new instance of the EntityDataSourceEventArgs class.
		/// </summary>
		/// <param name="entityList">The objects on which the current operation is being performed.</param>
		/// <param name="index">The index of the current item being operated on.</param>
		/// <param name="inputParameters">A collection of name/value pairs submitted during the current operation.</param>
		/// <param name="affectedRows">The number of rows that are affected by the data operation.</param>
		public EntityDataSourceMethodEventArgs(IEnumerable entityList, int index, IDictionary inputParameters, int affectedRows)
			: this(entityList, index, inputParameters)
		{
			this._affectedRows = affectedRows;
		}

		/// <summary>
		/// Initializes a new instance of the EntityDataSourceEventArgs class.
		/// </summary>
		/// <param name="entityList">The objects on which the current operation is being performed.</param>
		/// <param name="index">The index of the current item being operated on.</param>
		/// <param name="inputParameters">A collection of name/value pairs submitted during the current operation.</param>
		/// <param name="affectedRows">The number of rows that are affected by the data operation.</param>
		/// <param name="exception">An System.Exception that wraps any internal exceptions thrown during the method call.</param>
		public EntityDataSourceMethodEventArgs(IEnumerable entityList, int index, IDictionary inputParameters, int affectedRows, Exception exception)
			: this(entityList, index, inputParameters, affectedRows)
		{
			this._exception = exception;
		}

		/// <summary>
		/// The current list of business objects.
		/// </summary>
		public IEnumerable EntityList
		{
			get { return _entityList; }
		}

		/// <summary>
		/// Gets a collection that contains business object method parameters and their values.
		/// </summary>
		public IDictionary InputParameters
		{
			get { return _inputParameters; }
		}

		/// <summary>
		/// Gets the position within EntityList that contains the current item.
		/// </summary>
		public int Index
		{
			get { return _index; }
		}

		/// <summary>
		/// Gets the number of rows that are affected by the data operation.
		/// </summary>
		public int AffectedRows
		{
			get { return _affectedRows; }
		}

		/// <summary>
		/// Gets a wrapper for any exceptions that are thrown by the method that is called by the EntityDataSource control during a data operation.
		/// </summary>
		public Exception Exception
		{
			get { return _exception; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether an exception that was thrown by the business object has been handled.
		/// </summary>
		public bool ExceptionHandled
		{
			get { return _exceptionHandled; }
			set { _exceptionHandled = value; }
		}
	}
	#endregion
}
