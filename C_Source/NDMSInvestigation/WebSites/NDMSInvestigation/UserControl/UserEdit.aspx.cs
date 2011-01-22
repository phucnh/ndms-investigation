using System;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Practices.ObjectBuilder;

namespace NDMSInvestigation.UserControl.Views
{
    public partial class UserEdit : Microsoft.Practices.CompositeWeb.Web.UI.Page, IUserEditView
    {
        private UserEditPresenter _presenter;
        private string _pageMode = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            hidUserId.Value = NDMSInvestigation.WCSF.Utility.GetUserId();

            if ((hidUserId == null) ||
                (string.IsNullOrEmpty(hidUserId.Value)))
                Response.Redirect("~/Shared/authenticated/login.aspx");

            LoadMultiFormViewMode();
        }

        private void LoadMultiFormViewMode()
        {
            _pageMode = Request.QueryString["Mode"];
            if (string.Compare(_pageMode, "Create") == 0)
                FormView1.ChangeMode(FormViewMode.Insert);
        }

        [CreateNew]
        public UserEditPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;

            }
        }

        protected void FormView1_ItemCommand(object sender, System.Web.UI.WebControls.FormViewCommandEventArgs e)
        {
            if (String.Compare(e.CommandName, "Cancel") == 0)
            {
                Response.Redirect("~/UserControl/UserEdit.aspx");
            }
        }

        /// <summary>
        /// Handles the Click event of the InsertButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserControl/UserEdit.aspx?Mode=" + "Create");
        }

        protected void CompanyDetailsDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["UserId"] = new Guid(hidUserId.Value);
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

