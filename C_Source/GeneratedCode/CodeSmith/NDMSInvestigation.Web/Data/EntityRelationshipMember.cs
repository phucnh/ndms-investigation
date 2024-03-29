﻿#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Web.UI;
#endregion

namespace NDMSInvestigation.Web.Data
{
	/// <summary>
	/// Supports the <see cref="EntityRelationship"/> control by
	/// providing relationchip configuration properties.
	/// </summary>
	[ParseChildren(true), PersistChildren(false)]
	public class EntityRelationshipMember : DataBoundControl
	{
		#region Declarations
		private String _entityTypeName;
		private String _entityKeyName;
		private String _foreignKeyName;
		private String _referenceProperty;
		private String _linkProperty;
		private String _listControlID;
		private String _gridControlID;
		private String _viewControlID;

		private IList _inserts;
		private IList _propertyMappings;
		private ListControl _listControl;
		private GridView _gridControl;
		private Control _viewControl;
		private Type _entityType;
		private Object _currentEntity;
		private bool _enableDeepLoad;
		private bool _enableDeepSave;
		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EntityRelationship class.
		/// </summary>
		public EntityRelationshipMember()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the CurrentEntity property.
		/// </summary>
		public Object CurrentEntity
		{
			get { return _currentEntity; }
			set { _currentEntity = value; }
		}

		/// <summary>
		/// Gets or set the name of the class of the entity that is returned by the Provider.
		/// </summary>
		public String EntityTypeName
		{
			get { return _entityTypeName; }
			set { _entityTypeName = value; }
		}

		/// <summary>
		/// Gets or sets the System.Type of entity that is returned by the Provider.
		/// </summary>
		[Browsable(false)]
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
			set { _entityType = value; }
		}

		/// <summary>
		/// Gets or sets the name of the primary key property of the entity.
		/// </summary>
		public String EntityKeyName
		{
			get { return _entityKeyName; }
			set { _entityKeyName = value; }
		}

		/// <summary>
		/// Gets or sets the index of the current entity when dealing with
		/// a collection of entities.
		/// </summary>
		public int EntityIndex
		{
			get { return Math.Max((int) (ViewState["EntityIndex"] ?? 0), 0); }
			set { ViewState["EntityIndex"] = value; }
		}

		/// <summary>
		/// Gets or sets the foreign key property name.
		/// </summary>
		public String ForeignKeyName
		{
			get { return _foreignKeyName; }
			set { _foreignKeyName = value; }
		}

		/// <summary>
		/// Gets or sets the reference collection property name.
		/// </summary>
		public String ReferenceProperty
		{
			get { return _referenceProperty; }
			set { _referenceProperty = value; }
		}

		/// <summary>
		/// Gets or sets the link collection property name.
		/// </summary>
		public String LinkProperty
		{
			get { return _linkProperty; }
			set { _linkProperty = value; }
		}

		/// <summary>
		/// Gets or sets the ListControl's ID property value.
		/// </summary>
		public String ListControlID
		{
			get { return _listControlID; }
			set { _listControlID = value; }
		}

		/// <summary>
		/// Gets or sets a reference to the ListControl.
		/// </summary>
		[Browsable(false)]
		public ListControl ListControl
		{
			get
			{
				if ( _listControl == null && !String.IsNullOrEmpty(ListControlID) )
				{
					_listControl = GetControl(ListControlID) as ListControl;
				}

				return _listControl;
			}
			set
			{
				_listControl = value;
			}
		}

		/// <summary>
		/// Gets or sets the GridView control's ID property value.
		/// </summary>
		public String GridControlID
		{
			get { return _gridControlID; }
			set { _gridControlID = value; }
		}

		/// <summary>
		/// Gets or sets a reference to the GridView control.
		/// </summary>
		[Browsable(false)]
		public GridView GridControl
		{
			get
			{
				if ( _gridControl == null && !String.IsNullOrEmpty(GridControlID) )
				{
					_gridControl = GetControl(GridControlID) as GridView;
				}

				return _gridControl;
			}
			set
			{
				_gridControl = value;
			}
		}

		/// <summary>
		/// Gets or sets the FormView control's ID property value.
		/// </summary>
		public String ViewControlID
		{
			get { return _viewControlID; }
			set { _viewControlID = value; }
		}

		/// <summary>
		/// Gets or sets a reference to the FormView control.
		/// </summary>
		[Browsable(false)]
		public Control ViewControl
		{
			get
			{
				if ( _viewControl == null && !String.IsNullOrEmpty(ViewControlID) )
				{
					_viewControl = GetControl(ViewControlID);
				}

				return _viewControl;
			}
			set
			{
				_viewControl = value;
			}
		}

		/// <summary>
		/// Gets a reference to the collection of EntityProperty objects.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList PropertyMappings
		{
			get
			{
				if ( _propertyMappings == null )
				{
					_propertyMappings = new ArrayList();
				}

				return _propertyMappings; 
			}
		}

		/// <summary>
		/// Gets a collection of business objects to be inserted
		/// after the primary business object is inserted.
		/// </summary>
		public IList Inserts
		{
			get
			{
				if ( _inserts == null )
				{
					_inserts = new ArrayList();
				}

				return _inserts;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the primary
		/// business object should be DeepLoaded.
		/// </summary>
		public bool EnableDeepLoad
		{
			get { return _enableDeepLoad; }
			set { _enableDeepLoad = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the primary
		/// business object will be DeepSaved.
		/// </summary>
		public bool EnableDeepSave
		{
			get { return _enableDeepSave; }
			set { _enableDeepSave = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the current relationship
		/// member has a reference to an <see cref="ILinkedDataSource"/> control.
		/// </summary>
		public bool HasDataSource
		{
			get { return GetLinkedDataSource() != null; }
		}

		#endregion

		#region Methods

		#region Entity Methods

		/// <summary>
		/// Gets a reference to the associated <see cref="ILinkedDataSource"/> control.
		/// </summary>
		/// <returns>An <see cref="ILinkedDataSource"/> object.</returns>
		public ILinkedDataSource GetLinkedDataSource()
		{
			return GetDataSource() as ILinkedDataSource;
		}

		/// <summary>
		/// Gets the unique identifier value for the current business object.
		/// </summary>
		/// <returns></returns>
		public Object GetEntityId()
		{
			return GetEntityId(CurrentEntity);
		}

		/// <summary>
		/// Gets the unique identifier value for the specified business object.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public Object GetEntityId(Object entity)
		{
			return EntityUtil.GetPropertyValue(entity, EntityKeyName);
		}

		/// <summary>
		/// Gets the list of data retrieved by the associated <see cref="ILinkedDataSource"/> object.
		/// </summary>
		/// <returns>A collection of business objects.</returns>
		public IList GetEntityList()
		{
			IList entityList = null;

			if ( HasDataSource )
			{
				IEnumerable list = GetLinkedDataSource().GetEntityList();
				entityList = EntityUtil.GetEntityList(list);
			}

			return entityList;
		}

		/// <summary>
		/// Performs a DeepLoad operation on the associated <see cref="ILinkedDataSource"/> object.
		/// </summary>
		public void DeepLoad()
		{
			if ( HasDataSource && EnableDeepLoad )
			{
				GetLinkedDataSource().DeepLoad();
			}
		}

		#endregion

		#region Control Methods

		/// <summary>
		/// Gets a reference to the control with the specified control id.
		/// </summary>
		/// <param name="controlId">The control's ID value.</param>
		/// <returns>A <see cref="Control"/> object.</returns>
		private Control GetControl(String controlId)
		{
			Control control = null;

			if ( EntityIndex > 0 )
			{
				IList<Control> controls = FormUtil.GetControls(Page, controlId);
				control = controls[EntityIndex];
			}
			else
			{
				control = FindControl(controlId);
			}

			return control;
		}

		#endregion

		#region ListControl Methods

		/// <summary>
		/// Gets a value indicating whether the specified value is selected in
		/// the <paramref name="ListControl"/> object.
		/// </summary>
		/// <param name="value">The current value.</param>
		/// <returns>True if the specified value is selected; otherwise false.</returns>
		public bool IsSelected(String value)
		{
			if ( ListControl != null )
			{
				foreach ( ListItem item in ListControl.Items )
				{
					if ( Object.Equals(item.Value, value) )
					{
						return item.Selected;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Selects the specified value in the <paramref name="ListControl"/> object.
		/// </summary>
		/// <param name="value">The value to select.</param>
		public void Select(String value)
		{
			foreach ( ListItem item in ListControl.Items )
			{
				if ( Object.Equals(item.Value, value) )
				{
					item.Selected = true;
				}
			}
		}

		/// <summary>
		/// Clears the currently selected values in the <paramref name="ListControl"/> object.
		/// </summary>
		public void ClearSelections()
		{
			if ( ListControl != null )
			{
				foreach ( ListItem item in ListControl.Items )
				{
					item.Selected = false;
				}
			}
		}
		#endregion

		#region GridControl Methods

		/// <summary>
		/// Gets the current business object that is bound to
		/// the specified <see cref="GridViewRow"/> object.
		/// </summary>
		/// <param name="links">A collection of business objects.</param>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <returns></returns>
		public Object GetLink(IList links, GridViewRow row)
		{
			String id = GetEntityKeyValue(row);
			return EntityUtil.GetEntity(links, EntityKeyName, id);
		}

		/// <summary>
		/// Gets the current <see cref="GridViewRow"/> object that represents
		/// the specified business object.
		/// </summary>
		/// <param name="rows">A <see cref="GridViewRowCollection"/>.</param>
		/// <param name="link">The current business object.</param>
		/// <returns>A <see cref="GridViewRow"/> object.</returns>
		public GridViewRow GetRow(GridViewRowCollection rows, Object link)
		{
			Object value = EntityUtil.GetPropertyValue(link, ForeignKeyName);
			GridViewRow gridRow = null;

			if ( value != null )
			{
				String strValue = String.Format("{0}", value);
				String id;

				foreach ( GridViewRow row in rows )
				{
					id = GetForeignKeyValue(row) as String;

					if ( strValue.Equals(id) )
					{
						gridRow = row;
						break;
					}
				}
			}

			return gridRow;
		}

		/// <summary>
		/// Gets the <see cref="TableCell"/> object that is bound to
		/// the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <param name="dataField">The property name.</param>
		/// <returns>A <see cref="TableCell"/> object.</returns>
		public TableCell GetCell(GridViewRow row, String dataField)
		{
			EntityProperty property = null;
			return GetCell(row, dataField, out property);
		}

		/// <summary>
		/// Gets the <see cref="TableCell"/> object that is bound to
		/// the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <param name="dataField">The property name.</param>
		/// <param name="property">a <see cref="EntityProperty"/> object.</param>
		/// <returns>A <see cref="TableCell"/> object.</returns>
		public TableCell GetCell(GridViewRow row, String dataField, out EntityProperty property)
		{
			TableCell cell = null;
			property = null;

			if ( row != null )
			{
				int index = GetColumnIndex(dataField, out property);

				if ( index > -1 && index < row.Cells.Count )
				{
					cell = row.Cells[index];
				}
			}

			return cell;
		}

		/// <summary>
		/// Sets the current value of the specified <see cref="TableCell"/> object.
		/// </summary>
		/// <param name="cell">The current <see cref="TableCell"/> object.</param>
		/// <param name="controlId">The nested control's ID property value.</param>
		/// <param name="controlProperty">The nested control's value property name.</param>
		/// <param name="value">The current value.</param>
		public void SetValue(TableCell cell, String controlId, String controlProperty, Object value)
		{
			if ( cell != null )
			{
				if ( String.IsNullOrEmpty(controlId) )
				{
					cell.Text = String.Format("{0}", value);
				}
				else
				{
					Control control = cell.FindControl(controlId);
					FormUtil.SetValue(control, controlProperty, value);
				}
			}
		}

		/// <summary>
		/// Sets the current value of the cell bound to the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <param name="dataField">The property name.</param>
		/// <param name="value">The current value.</param>
		public void SetValue(GridViewRow row, String dataField, Object value)
		{
			EntityProperty property = null;
			TableCell cell = GetCell(row, dataField, out property);

			if ( cell != null && property != null )
			{
				SetValue(cell, property.ControlID, property.ControlProperty, value);

				if ( !String.IsNullOrEmpty(property.OriginalValueControlID) )
				{
					SetValue(cell, property.OriginalValueControlID, property.OriginalValueControlProperty, value);
				}
			}
		}

		/// <summary>
		/// Gets the current value of the specified <see cref="TableCell"/> object.
		/// </summary>
		/// <param name="cell">The current <see cref="TableCell"/> object.</param>
		/// <param name="controlId">The nested control's ID property value.</param>
		/// <param name="controlProperty">The nested control's value property name.</param>
		/// <returns>The current value.</returns>
		public Object GetValue(TableCell cell, String controlId, String controlProperty)
		{
			Object value = null;

			if ( String.IsNullOrEmpty(controlId) )
			{
				value = cell.Text;
			}
			else
			{
				Control control = cell.FindControl(controlId);
				value = FormUtil.GetValue(control, controlProperty);
			}

			return value;
		}

		/// <summary>
		/// Gets the current value of the cell bound to the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <param name="dataField">The property name.</param>
		/// <returns>The current value.</returns>
		public Object GetValue(GridViewRow row, String dataField)
		{
			return GetValue(row, dataField, false);
		}

		/// <summary>
		/// Gets the original value of the cell bound to the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <param name="dataField">The property name.</param>
		/// <returns>The current value.</returns>
		public Object GetOriginalValue(GridViewRow row, String dataField)
		{
			return GetValue(row, dataField, true);
		}

		/// <summary>
		/// Gets the value of the cell bound to the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <param name="dataField">The property name.</param>
		/// <param name="useOriginal">A value indicating whether to
		/// return the current value or the original value.</param>
		/// <returns>The current value.</returns>
		public Object GetValue(GridViewRow row, String dataField, bool useOriginal)
		{
			EntityProperty property = null;
			TableCell cell = GetCell(row, dataField, out property);
			Object value = null;

			if ( cell != null && property != null )
			{
				String controlId = property.ControlID;
				String propertyName = property.ControlProperty;

				if ( useOriginal && !String.IsNullOrEmpty(property.OriginalValueControlID) )
				{
					controlId = property.OriginalValueControlID;
					propertyName = property.OriginalValueControlProperty;
				}

				value = GetValue(cell, controlId, propertyName);
			}

			return value;
		}

		/// <summary>
		/// Gets a collection of bound values for the specified <see cref="GridViewRow"/> object.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <returns>A collection of name/value pairs.</returns>
		public IDictionary GetValues(GridViewRow row)
		{
			IDictionary values = new Hashtable();
			Object value;

			// get property values
			foreach ( EntityProperty property in PropertyMappings )
			{
				value = GetValue(row, property.DataField);
				values.Add(property.DataField, value);
			}

			return values;
		}

		/// <summary>
		/// Gets the original value of the cell bound to the configured
		/// <paramref name="EntityKeyName"/> property.
		/// </summary>
		/// <param name="row">The current <see cref="GridViewRow"/> object.</param>
		/// <returns>The oringal value.</returns>
		public String GetEntityKeyValue(GridViewRow row)
		{
			return GetOriginalValue(row, EntityKeyName) as String;
		}

		/// <summary>
		/// Gets the original value of the cell bound to the configured
		/// <paramref name="ForeignKeyName"/> property.
		/// </summary>
		/// <param name="row">The current <see cref="GridViewRow"/> object.</param>
		/// <returns>The oringal value.</returns>
		public String GetForeignKeyValue(GridViewRow row)
		{
			return GetOriginalValue(row, ForeignKeyName) as String;
		}

		/// <summary>
		/// Gets the zero-based index of the column that is bound
		/// to the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="dataField">The property name.</param>
		/// <returns>The column index.</returns>
		public int GetColumnIndex(String dataField)
		{
			EntityProperty property = null;
			return GetColumnIndex(dataField, out property);
		}

		/// <summary>
		/// Gets the zero-based index of the column that is bound
		/// to the specified <paramref name="dataField"/> property.
		/// </summary>
		/// <param name="dataField">The property name.</param>
		/// <param name="property">A reference to the <see cref="EntityProperty"/> object.</param>
		/// <returns>The column index.</returns>
		public int GetColumnIndex(String dataField, out EntityProperty property)
		{
			int index = -1;
			property = null;

			if ( !String.IsNullOrEmpty(dataField) )
			{
				foreach ( EntityProperty prop in PropertyMappings )
				{
					if ( dataField.Equals(prop.DataField) )
					{
						index = prop.ColumnIndex;
						property = prop;
						break;
					}
				}
			}

			return index;
		}

		/// <summary>
		/// Gets a value indicating whether the object represented by the
		/// specified <see cref="GridViewRow"/> object is a new object.
		/// </summary>
		/// <param name="row">A <see cref="GridViewRow"/> object.</param>
		/// <returns>True if the object represented by the <see cref="GridViewRow"/>
		/// object is a new object; otherwise false.</returns>
		public bool IsNewItem(GridViewRow row)
		{
			String value = GetEntityKeyValue(row);
			bool isNew = String.IsNullOrEmpty(value);

			if ( isNew )
			{
				foreach ( EntityProperty property in PropertyMappings )
				{
					if ( property.IsKey )
					{
						value = String.Format("{0}", GetValue(row, property.DataField));

						if ( String.IsNullOrEmpty(value) )
						{
							isNew = false;
							break;
						}
					}
				}
			}

			return isNew;
		}

		/// <summary>
		/// Gets a value indicating whether the specified business object is
		/// currently represented by the <see cref="GridViewRowCollection"/> object.
		/// </summary>
		/// <param name="rows">A <see cref="GridViewRowCollection"/> object.</param>
		/// <param name="link">The current business object.</param>
		/// <returns>True if the specified business object is represented by
		/// the <see cref="GridViewRowCollection"/> object.</returns>
		public bool IsCurrentItem(GridViewRowCollection rows, Object link)
		{
			GridViewRow row = GetRow(rows, link);
			String origValue, currValue;
			bool isCurrent = false;

			if ( row != null )
			{
				isCurrent = true;

				foreach ( EntityProperty property in PropertyMappings )
				{
					if ( property.IsKey )
					{
						/*
						value = GetOriginalValue(row, property.DataField);

						// compare original value
						if ( !EntityUtil.IsPropertyValueEqual(link, property.DataField, value) )
						{
							isCurrent = false;
							break;
						}
						// check for current value, if OriginalValueControlID is used
						if ( !String.IsNullOrEmpty(property.OriginalValueControlID) )
						{
							strValue = String.Format("{0}", GetValue(row, property.DataField));

							if ( String.IsNullOrEmpty(strValue) )
							{
								isCurrent = false;
								break;
							}
						}
						*/

						origValue = String.Format("{0}", GetOriginalValue(row, property.DataField));
						currValue = String.Format("{0}", GetValue(row, property.DataField));

						if ( !String.IsNullOrEmpty(origValue) && String.IsNullOrEmpty(currValue) )
						{
							isCurrent = false;
							break;
						}
					}
				}
			}

			return isCurrent;
		}
		#endregion
		
		#endregion
	}

	/// <summary>
	/// Represents an <see cref="EntityRelationshipMember"/> column mapping.
	/// </summary>
	public sealed class EntityProperty
	{
		#region Declarations
		private String _controlID;
		private String _controlProperty;
		private String _originalValueControlID;
		private String _originalValueControlProperty;
		private String _dataField;
		private int _columnIndex = Int32.MinValue;
		private bool _isKey = false;
		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EntityProperty class.
		/// </summary>
		public EntityProperty()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EntityProperty class.
		/// </summary>
		/// <param name="controlId">The control's ID property value.</param>
		/// <param name="dataField">The property name to bind to.</param>
		/// <param name="columnIndex">The zero-based column index.</param>
		/// <param name="isKey">A value indicating whether the property
		/// should be treated as a key field.</param>
		public EntityProperty(String controlId, String dataField, int columnIndex, bool isKey)
		{
			ControlID = controlId;
			DataField = dataField;
			ColumnIndex = columnIndex;
			IsKey = isKey;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the mapped control's ID property value.
		/// </summary>
		public String ControlID
		{
			get { return _controlID; }
			set { _controlID = value; }
		}

		/// <summary>
		/// Gets or sets the mapped control's value property name.
		/// </summary>
		public String ControlProperty
		{
			get { return _controlProperty; }
			set { _controlProperty = value; }
		}

		/// <summary>
		/// Gets or sets the mapped control's ID property value.
		/// This control contains the original property value.
		/// </summary>
		public String OriginalValueControlID
		{
			get { return _originalValueControlID; }
			set { _originalValueControlID = value; }
		}

		/// <summary>
		/// Gets or sets the mapped control's value property name.
		/// This control contains the original property value.
		/// </summary>
		public String OriginalValueControlProperty
		{
			get { return _originalValueControlProperty; }
			set { _originalValueControlProperty = value; }
		}

		/// <summary>
		/// Gets or sets the name of the property that the mapped
		/// control is bound to.
		/// </summary>
		public String DataField
		{
			get { return _dataField; }
			set { _dataField = value; }
		}

		/// <summary>
		/// Gets or sets the zero-based column index.
		/// </summary>
		public int ColumnIndex
		{
			get { return _columnIndex; }
			set { _columnIndex = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the property
		/// should be treated as a key field.
		/// </summary>
		public bool IsKey
		{
			get { return _isKey; }
			set { _isKey = value; }
		}

		#endregion
	}
}
