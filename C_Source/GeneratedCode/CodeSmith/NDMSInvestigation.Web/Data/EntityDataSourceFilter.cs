﻿#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDMSInvestigation.Entities;
#endregion

namespace NDMSInvestigation.Web.Data
{
	/// <summary>
	/// Provides the ability to filter the list of data retrieved by an
	/// EntityDataSource object.
	/// </summary>
	public class EntityDataSourceFilter : DataBoundControl, IDataSource
	{
		#region Declarations

		private static readonly String FilteredViewName = "FilteredView";
		private EntityDataSourceFilterView _filteredView;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EntityDataSourceFilter class.
		/// </summary>
		public EntityDataSourceFilter()
		{
		}

		#endregion

		#region IDataSource Members

		/// <summary>
		/// Occurs when a data source control has changed in some way that affects data-bound controls.
		/// </summary>
		public event EventHandler DataSourceChanged;

		/// <summary>
		/// Gets the named data source view associated with the data source control.
		/// </summary>
		/// <param name="viewName">The name of the view to retrieve.</param>
		/// <returns>
		/// Returns the named System.Web.UI.DataSourceView associated with the System.Web.UI.IDataSource.
		/// </returns>
		public DataSourceView GetView(String viewName)
		{
			return FilteredView;
		}

		/// <summary>
		/// Gets a collection of names representing the list of view objects associated
		/// with the System.Web.UI.IDataSource interface.
		/// </summary>
		/// <returns>
		/// An System.Collections.ICollection that contains the names of the views associated
		/// with the System.Web.UI.IDataSource.
		/// </returns>
		public ICollection GetViewNames()
		{
			return new String[] { FilteredViewName };
		}

		#endregion

		#region Methods

		/// <summary>
		/// Gets a reference to the associated <see cref="IListDataSource"/> object.
		/// </summary>
		/// <returns>An reference to an <see cref="IListDataSource"/> object.</returns>
		public IListDataSource GetListDataSource()
		{
			return GetDataSource() as IListDataSource;
		}

		/// <summary>
		/// Raises the DataSourceChanged event.
		/// </summary>
		/// <param name="e">An instance of EventArgs containing the event data.</param>
		protected void OnDataSourceChanged(EventArgs e)
		{
			if ( DataSourceChanged != null )
			{
				DataSourceChanged(this, e);
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets a reference to the EntityDataSourceFilterView used by the EntityDataSourceFilter.
		/// </summary>
		private EntityDataSourceFilterView FilteredView
		{
			get
			{
				if ( _filteredView == null )
				{
					_filteredView = new EntityDataSourceFilterView(this, FilteredViewName);
				}

				return _filteredView;
			}
		}

		/// <summary>
		/// Gets or sets the filter condition to apply to the list of data.
		/// </summary>
		[Bindable(true)]
		public String Filter
		{
			get { return FilteredView.Filter; }
			set
			{
				if ( FilteredView.Filter != value )
				{
					FilteredView.Filter = value;
					OnDataSourceChanged(new EventArgs());
				}
			}
		}

		/// <summary>
		/// Gets or sets the sort expression to apply to the list of data.
		/// </summary>
		[Bindable(true)]
		public String Sort
		{
			get { return FilteredView.Sort; }
			set
			{
				if ( FilteredView.Sort != value )
				{
					FilteredView.Sort = value;
					OnDataSourceChanged(new EventArgs());
				}
			}
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurs before the filter condition is applied.
		/// </summary>
		public event EntityListEventHandler ApplyFilter
		{
			add { FilteredView.ApplyFilter += value; }
			remove { FilteredView.ApplyFilter -= value; }
		}

		/// <summary>
		/// Occurs before the sort expression is applied.
		/// </summary>
		public event EntityListEventHandler ApplySort
		{
			add { FilteredView.ApplySort += value; }
			remove { FilteredView.ApplySort -= value; }
		}

		#endregion

		/// <summary>
		/// Supports the EntityDataSourceFilter control.
		/// </summary>
		private sealed class EntityDataSourceFilterView : DataSourceView
		{
			#region Declarations

			private EntityDataSourceFilter _owner;
			private String _filter;
			private String _sort;

			#endregion

			#region Constructors

			/// <summary>
			/// Initializes a new instance of the EntityDataSourceFilterView class.
			/// </summary>
			/// <param name="owner">A reference to the EntityDataSourceFilter which created this instance.</param>
			/// <param name="viewName">The name of the view.</param>
			public EntityDataSourceFilterView(EntityDataSourceFilter owner, String viewName)
				: base(owner, viewName)
			{
				_owner = owner;
			}

			#endregion

			#region DataSourceView Members

			/// <summary>
			/// Gets the list of data from the associated <see cref="IListDataSource"/> control and
			/// applies the specified filter and sort expression.
			/// </summary>
			/// <param name="arguments">A System.Web.UI.DataSourceSelectArguments that
			/// is used to request operations on the data beyond basic data retrieval.</param>
			/// <returns>An System.Collections.IEnumerable list of data from the associated EntityDataSource.</returns>
			protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
			{
				IListDataSource dataSource = _owner.GetListDataSource();
				IEnumerable entityList = null;

				if ( dataSource != null )
				{
					entityList = dataSource.GetEntityList();
				}
				else
				{
					_owner.DataBind();

					if ( _owner.DataSource is IEnumerable )
					{
						entityList = _owner.DataSource as IEnumerable;
					}
				}

				if( entityList != null )
				{
					// apply filter
					OnApplyFilter(entityList);

					if ( !String.IsNullOrEmpty(Filter) )
					{
						EntityUtil.SetPropertyValue(entityList, "Filter", Filter);
					}

					// apply sort
					OnApplySort(entityList);

					if ( !String.IsNullOrEmpty(Sort) )
					{
						EntityUtil.InvokeMethod(entityList, "Sort", new Object[] { Sort });
					}
				}

				return entityList;
			}

			#endregion

			#region Properties

			/// <summary>
			/// Gets or sets the filter condition to apply to the list of data.
			/// </summary>
			internal String Filter
			{
				get { return _filter; }
				set { _filter = value; }
			}

			/// <summary>
			/// Gets or sets the sort expression to apply to the list of data.
			/// </summary>
			internal String Sort
			{
				get { return _sort; }
				set { _sort = value; }
			}

			#endregion

			#region Events

			/// <summary>
			/// Occurs before the filter condition is applied.
			/// </summary>
			internal event EntityListEventHandler ApplyFilter;

			/// <summary>
			/// Occurs before the sort expression is applied.
			/// </summary>
			internal event EntityListEventHandler ApplySort;

			/// <summary>
			/// Raises the ApplyFilter event.
			/// </summary>
			/// <param name="entityList">The list of data retrieved from the associated
			/// <see cref="IListDataSource"/> control.</param>
			private void OnApplyFilter(IEnumerable entityList)
			{
				if ( ApplyFilter != null )
				{
					EntityListEventArgs args = new EntityListEventArgs(entityList);
					ApplyFilter(this, args);
				}
			}

			/// <summary>
			/// Raises the ApplySort event.
			/// </summary>
			/// <param name="entityList">The list of data retrieved from the associated
			/// <see cref="IListDataSource"/> control.</param>
			private void OnApplySort(IEnumerable entityList)
			{
				if ( ApplySort != null )
				{
					EntityListEventArgs args = new EntityListEventArgs(entityList);
					ApplySort(this, args);
				}
			}

			#endregion
		}
	}

	#region Event Helpers

	/// <summary>
	/// Represents the method that will handle either the ApplyFilter or
	/// ApplySort events of the EntityDataSourceFilterView control.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public delegate void EntityListEventHandler(Object sender, EntityListEventArgs args);

	/// <summary>
	/// Provides data for the ApplyFilter or ApplySort events
	/// of the EntityDataSourceFilterView control.
	/// </summary>
	public class EntityListEventArgs : EventArgs
	{
		private IEnumerable _entityList;

		/// <summary>
		/// Initializes a new instance of the EntityListEventArgs class.
		/// </summary>
		/// <param name="entityList">The IEnumerable list of data from the associated EntityDataSource.</param>
		public EntityListEventArgs(IEnumerable entityList)
		{
			_entityList = entityList;
		}

		/// <summary>
		/// The IEnumerable list of data from the associated EntityDataSource.
		/// </summary>
		public IEnumerable EntityList
		{
			get { return _entityList; }
			set { _entityList = value; }
		}
	}

	#endregion
}
