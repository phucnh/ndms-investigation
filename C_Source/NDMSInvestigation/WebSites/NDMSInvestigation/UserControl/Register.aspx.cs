using System;
using System.Security;
using Microsoft.Practices.ObjectBuilder;

using NDMSInvestigation.Entities;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace NDMSInvestigation.UserControl.Views
{
    public partial class Register : Microsoft.Practices.CompositeWeb.Web.UI.Page, IRegisterView
    {
        private RegisterPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public RegisterPresenter Presenter
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

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            MembershipUser membership = Membership.GetUser(CreateUserWizard1.UserName);
            NDMSInvestigation.Entities.User user = new NDMSInvestigation.Entities.User();
 
            #region Find control from interface
            TextBox CompanyName = CreateUserWizard1.FindControl("CompanyName");
            TextBox Phone = CreateUserWizard1.FindControl("Phone");
            #endregion

            user.UserId = new Guid(membership.ProviderUserKey.ToString());
            
            Presenter.Insert(user);
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

