using System;
using Microsoft.Practices.ObjectBuilder;

namespace NDMSInvestigation.UserControl.Views
{
    public partial class UserEdit : Microsoft.Practices.CompositeWeb.Web.UI.Page, IUserEditView
    {
        private UserEditPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
            hidUserId.Value = NDMSInvestigation.WCSF.Utility.GetUserId();
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
            if (String.Compare(e.CommandName,"Cancel") == 0)
            {
                Response.Redirect("~/UserControl/UserEdit.aspx");
            }
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

