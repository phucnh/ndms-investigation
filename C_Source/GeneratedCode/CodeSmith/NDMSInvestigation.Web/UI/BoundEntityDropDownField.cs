﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections;
using NDMSInvestigation;
#endregion

namespace NDMSInvestigation.Web.UI
{
    /// <summary>
    /// A specialised BoundField that adds DropDownList functionality to the base class.
    /// It uses the EntityDropDownList to bind to a datasource. Data is cached so that
    /// it is only retrieved once for all bound rows
    /// </summary>
    public class BoundEntityDropDownField : BoundField 
    {

        #region Properties

        /// <summary>
        /// Gets or sets the data text field.
        /// </summary>
        /// <value>The data text field.</value>
        public string DataTextField
        {
            get
            {
                object val = this.ViewState["DataTextField"];
                if (null == val)
                {
                    return String.Empty;
                }

                return (string)val;
            }
            set
            {
                if (0 != String.CompareOrdinal(value, this.DataTextField))
                {
                    this.ViewState["DataTextField"] = value;
                    base.OnFieldChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the data value field.
        /// </summary>
        /// <value>The data value field.</value>
        public string DataValueField
        {
            get
            {
                object val = this.ViewState["DataValueField"];
                if (null == val)
                {
                    return String.Empty;
                }

                return (string)val;
            }
            set
            {
                if (0 != String.CompareOrdinal(value, this.DataValueField))
                {
                    this.ViewState["DataValueField"] = value;
                    base.OnFieldChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the list data source ID.
        /// </summary>
        /// <value>The data source ID.</value>
        [IDReferenceProperty(typeof(DataSourceControl)), Themeable(false)]
        public string DataSourceID
        {
            get
            {
                object val = this.ViewState["DataSourceID"];
                if (null == val)
                {
                    return String.Empty;
                }

                return (string)val;
            }
            set
            {
                if (0 != String.CompareOrdinal(value, this.DataSourceID))
                {
                    this.ViewState["DataSourceID"] = value;
                    base.OnFieldChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to append a null item.
        /// </summary>
        /// <value><c>true</c> if append null item; otherwise, <c>false</c>.</value>
        public bool AppendNullItem
        {
            get
            {
                object val = this.ViewState[ "AppendNullItem" ];
                if ( null == val )
                {
                    return false;
                }

                return (bool)val;
            }
            set
            {
                if ( this.AppendNullItem != value )
                {
                    this.ViewState[ "AppendNullItem" ] = value;
                    base.OnFieldChanged();
                }
            }
        }
        #endregion

	#region Design Time
        /// <summary>
        /// Retrieves the value used for a field's value when rendering the <see cref="T:System.Web.UI.WebControls.BoundField"></see> object in a designer.
        /// </summary>
        /// <returns>
        /// The value to display in the designer as the field's value.
        /// </returns>
        protected override object GetDesignTimeValue()
        {
            return 0;
        }
        #endregion Design time

	#region Cell overrides
        /// <summary>
        /// Initializes the specified <see cref="T:System.Web.UI.WebControls.TableCell"></see> object to the specified row state.
        /// </summary>
        /// <param name="cell">The <see cref="T:System.Web.UI.WebControls.TableCell"></see> to initialize.</param>
        /// <param name="rowState">One of the <see cref="T:System.Web.UI.WebControls.DataControlRowState"></see> values.</param>
        protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
        {
            if((!this.ReadOnly && (0!= (rowState & DataControlRowState.Edit)))
                || 0 != (rowState & DataControlRowState.Insert))
            {
                EntityDropDownList eddl = new EntityDropDownList();
                eddl.ToolTip = this.HeaderText;
                eddl.AppendNullItem = this.AppendNullItem;

                if (!String.IsNullOrEmpty(this.DataField) && 0 != (rowState & DataControlRowState.Edit))
                {
                    eddl.DataBinding += new EventHandler(HandleDataBinding);
                    eddl.DataBound += new EventHandler(HandleDataBound);
                }

                cell.Controls.Add(eddl);
            }
            else if (!String.IsNullOrEmpty(this.DataField))
            {
                Label label = new Label();
                label.DataBinding += new EventHandler(HandleDataBinding);
                cell.Controls.Add(label);
            }
        }

        /// <summary>
        /// Fills the specified <see cref="T:System.Collections.IDictionary"></see> object with the values from the specified <see cref="T:System.Web.UI.WebControls.TableCell"></see> object.
        /// </summary>
        /// <param name="dictionary">A <see cref="T:System.Collections.IDictionary"></see> used to store the values of the specified cell.</param>
        /// <param name="cell">The <see cref="T:System.Web.UI.WebControls.TableCell"></see> that contains the values to retrieve.</param>
        /// <param name="rowState">One of the <see cref="T:System.Web.UI.WebControls.DataControlRowState"></see> values.</param>
        /// <param name="includeReadOnly">true to include the values of read-only fields; otherwise, false.</param>
        public override void ExtractValuesFromCell(System.Collections.Specialized.IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
        {
            if ( cell.HasControls() &&
            	  cell.Controls[0] is EntityDropDownList )
            {
                EntityDropDownList eddl = (EntityDropDownList)cell.Controls[0];
                dictionary[this.DataField] = String.IsNullOrEmpty(eddl.SelectedValue) ? null : eddl.SelectedValue;               
            }
        }
        #endregion Cell overrides

        #region Private Event Handlers
        /// <summary>
        /// Callback from the datasourceview.
        /// </summary>
        /// <param name="data"></param>
        private void DataSourceCallback( IEnumerable data )
        {
            this.data = data;
        }

        IEnumerable data = null;

        /// <summary>
        /// Handles the data binding.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void HandleDataBinding( object sender, EventArgs e )
        {
            Control ctrl = (Control)sender;
            object val = GetValue( ctrl.NamingContainer ) ?? string.Empty;

            if ( data == null )
            {
                //Cache the data from the DataSourceControl, so that we only get the data once.  If 
                //we just set the DataSourceID on the dropdown, the select command would get called 
                //once for each row.
                DataSourceControl dsc = this.Control.NamingContainer.FindControl( this.DataSourceID ) as DataSourceControl;
                DataSourceView dsv = ( (IDataSource)dsc ).GetView( "DefaultView" );
                dsv.Select( DataSourceSelectArguments.Empty, new DataSourceViewSelectCallback( this.DataSourceCallback ) );
            }

            if ( ctrl is EntityDropDownList )
            {
                EntityDropDownList eddl = (EntityDropDownList)ctrl;
                eddl.DataTextField = this.DataTextField;
                eddl.DataValueField = this.DataValueField;
                eddl.DataSource = this.data;
                eddl.AppendNullItem = this.AppendNullItem;
            }
            else if ( ctrl is Label )
            {
                Label label = (Label)ctrl;
                EntityDropDownList temp = new EntityDropDownList();
                temp.DataTextField = this.DataTextField;
                temp.DataValueField = this.DataValueField;
                temp.DataSource = this.data;
                temp.Visible = false;
                temp.AppendNullItem = this.AppendNullItem;
                label.Controls.Add( temp );
                temp.DataBind();

                label.Text = String.Empty;
                foreach ( ListItem listItem in temp.Items )
                {
                    if ( 0 == String.Compare( listItem.Value, val.ToString() ) )
                    {
                        label.Text = listItem.Text;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the data bound.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        private void HandleDataBound( object sender, EventArgs e )
        {
            Control ctrl = (Control)sender;
            object val = GetValue( ctrl.NamingContainer ) ?? string.Empty;
            EntityDropDownList eddl = ctrl as EntityDropDownList;
            
            if ( null != eddl )
            {
                //make sure the appropriate value is selected
                ListItem listItem = eddl.Items.FindByValue( val.ToString() );
                if ( null != listItem )
                {
                    listItem.Selected = true;
                }
            }
        } 
        #endregion

    }
}
