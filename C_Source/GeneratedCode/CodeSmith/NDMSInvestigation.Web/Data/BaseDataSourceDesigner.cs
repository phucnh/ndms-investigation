﻿#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI.Design;
using System.Web.UI;
#endregion

namespace NDMSInvestigation.Web.Data
{
	/// <summary>
	/// Provides design-time support in a design host for the BaseDataSource class.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the key
	/// property of the specified business object class.</typeparam>
	[Serializable]
	[CLSCompliant(true)]
	public abstract class BaseDataSourceDesigner<Entity, EntityKey> : DataSourceDesigner
		where Entity : new()
		where EntityKey : new()
	{
		#region Declarations

		private BaseDataSource<Entity, EntityKey> _dataSource;
		private BaseDesignerDataSourceView<Entity, EntityKey> _view;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BaseDataSourceDesigner class.
		/// </summary>
		public BaseDataSourceDesigner()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets a reference to the BaseDesignerDataSourceView used by the BaseDataSourceDesigner.
		/// </summary>
		protected BaseDesignerDataSourceView<Entity, EntityKey> View
		{
			get
			{
				if ( _view == null )
				{
					_view = new BaseDesignerDataSourceView<Entity, EntityKey>(this, BaseDataSource<Entity, EntityKey>.DefaultViewName);
				}

				return _view;
			}
		}

		/// <summary>
		/// Gets or sets the data source control being designed.
		/// </summary>
		internal BaseDataSource<Entity, EntityKey> DataSource
		{
			get { return _dataSource; }
			set { _dataSource = value; }
		}

		/// <summary>
		/// Gets a value indicating whether the System.Web.UI.Design.DataSourceDesigner.Configure()
		/// method can be called.
		/// </summary>
		public override bool CanConfigure
		{
			get { return true; }
		}

		/// <summary>
		/// Gets a value indicating whether the System.Web.UI.Design.DataSourceDesigner.RefreshSchema(System.Boolean)
		/// method can be called.
		/// </summary>
		public override bool CanRefreshSchema
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a value indicating whether the control can be resized in the design-time environment.
		/// </summary>
		public override bool AllowResize
		{
			get { return false; }
		}

		/// <summary>
		/// Gets a schema that describes the data source view that is represented by this view object.
		/// </summary>
		public virtual IDataSourceViewSchema Schema
		{
			get
			{
				TypeSchema ts = new TypeSchema(typeof(Entity));
				return ts.GetViews()[0];
			}
		}

		/// <summary>
		/// Gets or sets the EnablePaging property.
		/// </summary>
		public bool EnablePaging
		{
			get { return DataSource.EnablePaging; }
			set { SetPropertyValue("EnablePaging", value); }
		}

		/// <summary>
		/// Gets or sets the EnableSorting property.
		/// </summary>
		public bool EnableSorting
		{
			get { return DataSource.EnableSorting; }
			set { SetPropertyValue("EnableSorting", value); }
		}

		/// <summary>
		/// Gets or sets the EnableTransaction property.
		/// </summary>
		public bool EnableTransaction
		{
			get { return DataSource.EnableTransaction; }
			set { SetPropertyValue("EnableTransaction", value); }
		}

		/// <summary>
		/// Gets or sets the EnableCaching property.
		/// </summary>
		public bool EnableCaching
		{
			get { return DataSource.EnableCaching; }
			set { SetPropertyValue("EnableCaching", value); }
		}

		/// <summary>
		/// Gets or sets the CacheDuration property.
		/// </summary>
		public int CacheDuration
		{
			get { return DataSource.CacheDuration; }
			set { SetPropertyValue("CacheDuration", value); }
		}

		/// <summary>
		/// Gets or sets the Filter property.
		/// </summary>
		public string Filter
		{
			get { return DataSource.Filter; }
			set { SetPropertyValue("Filter", value); }
		}

		/// <summary>
		/// Gets or sets the Sort property.
		/// </summary>
		public string Sort
		{
			get { return DataSource.Sort; }
			set { SetPropertyValue("Sort", value); }
		}

		/// <summary>
		/// Sets the value of the specified property.
		/// </summary>
		/// <param name="propertyName">The name of the property to set.</param>
		/// <param name="value">The new property value.</param>
		protected void SetPropertyValue(String propertyName, Object value)
		{
			PropertyDescriptor propDesc = TypeDescriptor.GetProperties(DataSource.GetType())[propertyName];
			propDesc.SetValue(DataSource, value);
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				// uncomment to add the default item "Configure data source..."
				//actions.AddRange(base.ActionLists);
				actions.Add(new BaseDataSourceActionList<Entity, EntityKey>(this));
				return actions;
			}
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Initializes the control designer and loads the specified component.
		/// </summary>
		/// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			// keep a reference to the data source control
			DataSource = (BaseDataSource<Entity, EntityKey>) component;
			// disable default transaction behavior
			//DataSource.EnableTransaction = false;
			// allow server-side paging
			//DataSource.EnablePaging = true;
		}

		/// <summary>
		/// Launches the data source configuration utility in the design host.
		/// </summary>
		public override void Configure()
		{
		}

		/// <summary>
		/// Retrieves the data source view that is associated with the data source control.
		/// </summary>
		/// <param name="viewName">The name of the view to retrieve.</param>
		/// <returns>The BaseDataSourceView that is associated with the BaseDataSource.</returns>
		public override DesignerDataSourceView GetView(String viewName)
		{
			return View;
		}

		/// <summary>
		/// Returns an array of the view names that are available in this data source.
		/// </summary>
		/// <returns>An array of view names.</returns>
		public override String[] GetViewNames()
		{
			return new String[] { BaseDataSource<Entity, EntityKey>.DefaultViewName };
		}

		#endregion Methods
	}

	/// <summary>
	/// Supports the BaseDataSourceDesigner class.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the key
	/// property of the specified business object class.</typeparam>
	public class BaseDesignerDataSourceView<Entity, EntityKey> : DesignerDataSourceView
		where Entity : new()
		where EntityKey : new()
	{
		#region Declarations

		private BaseDataSourceDesigner<Entity, EntityKey> _owner;

		#endregion Declarations

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the BaseDesignerDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the BaseDataSourceDesigner which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public BaseDesignerDataSourceView(BaseDataSourceDesigner<Entity, EntityKey> owner, String viewName)
			: base(owner, viewName)
		{
			_owner = owner;
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets a schema that describes the data source view that is represented by this view object.
		/// </summary>
		public override IDataSourceViewSchema Schema
		{
			get { return _owner.Schema; }
		}

		/// <summary>
		/// Gets a value indicating whether the DataSourceView object
		/// associated with the current DataSource object supports
		/// retrieving the total number of data rows, instead of the data.
		/// </summary>
		public override bool CanRetrieveTotalRowCount
		{
			get { return true; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Generates design-time data that matches the schema of the associated data
		/// source control using the provided number of rows and returns a value indicating
		/// whether the data is sample or real data.
		/// </summary>
		/// <param name="minimumRows">The minimum number of rows to return.</param>
		/// <param name="isSampleData">true to indicate the returned data is sample data;
		/// false to indicate the returned data is live data.</param>
		/// <returns>The data to display at design time.</returns>
		public override IEnumerable GetDesignTimeData(int minimumRows, out bool isSampleData)
		{
			DataSourceSelectArguments args = new DataSourceSelectArguments(0, minimumRows);
			isSampleData = false;

			return _owner.DataSource.Select(args);
		}

		#endregion Methods
	}

	#region BaseDataSourceActionList

	/// <summary>
	/// Supports the BaseDataSourceDesigner class.
	/// </summary>
	/// <typeparam name="Entity">The class of the business object being accessed.</typeparam>
	/// <typeparam name="EntityKey">The class of the key
	/// property of the specified business object class.</typeparam>
	internal class BaseDataSourceActionList<Entity, EntityKey> : DesignerActionList
		where Entity : new()
		where EntityKey : new()
	{
		private BaseDataSourceDesigner<Entity, EntityKey> _designer;

		/// <summary>
		/// Initializes a new instance of the BaseDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public BaseDataSourceActionList(BaseDataSourceDesigner<Entity, EntityKey> designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the EnablePaging property.
		/// </summary>
		public bool EnablePaging
		{
			get { return _designer.EnablePaging; }
			set { _designer.EnablePaging = value; }
		}

		/// <summary>
		/// Gets or sets the EnableSorting property.
		/// </summary>
		public bool EnableSorting
		{
			get { return _designer.EnableSorting; }
			set { _designer.EnableSorting = value; }
		}

		/// <summary>
		/// Gets or sets the EnableTransaction property.
		/// </summary>
		public bool EnableTransaction
		{
			get { return _designer.EnableTransaction; }
			set { _designer.EnableTransaction = value; }
		}

		/// <summary>
		/// Gets or sets the EnableCaching property.
		/// </summary>
		public bool EnableCaching
		{
			get { return _designer.EnableCaching; }
			set { _designer.EnableCaching = value; }
		}

		/// <summary>
		/// Gets or sets the CacheDuration property.
		/// </summary>
		public int CacheDuration
		{
			get { return _designer.CacheDuration; }
			set { _designer.CacheDuration = value; }
		}

		/// <summary>
		/// Gets or sets the Filter property.
		/// </summary>
		public string Filter
		{
			get { return _designer.Filter; }
			set { _designer.Filter = value; }
		}

		/// <summary>
		/// Gets or sets the Sort property.
		/// </summary>
		public string Sort
		{
			get { return _designer.Sort; }
			set { _designer.Sort = value; }
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

			items.Add(new DesignerActionPropertyItem("EnablePaging", "Enable Paging", "General"));
			items.Add(new DesignerActionPropertyItem("EnableSorting", "Enable Sorting", "General"));
			items.Add(new DesignerActionPropertyItem("EnableTransaction", "Enable Transaction", "General"));

			items.Add(new DesignerActionPropertyItem("EnableCaching", "Enable Caching", "Caching"));
			items.Add(new DesignerActionPropertyItem("CacheDuration", "Cache Duration", "Caching"));

			items.Add(new DesignerActionPropertyItem("Filter", "Filter", "Data"));
			items.Add(new DesignerActionPropertyItem("Sort", "Sort", "Data"));

			return items;
		}
	}

	#endregion BaseDataSourceActionList
}
