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

        /// <summary>
        /// Handles the CreatedUser event of the CreateUserWizard1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            MembershipUser membership = Membership.GetUser(CreateUserWizard1.UserName);

            #region Find control from interface
            TextBox CompanyName = (TextBox)CreateUserWizard1.FindControl("CompanyName");
            TextBox Phone = (TextBox)CreateUserWizard1.FindControl("Phone");
            TextBox Fax = (TextBox)CreateUserWizard1.FindControl("Fax");
            TextBox Address = (TextBox)CreateUserWizard1.FindControl("Address");
            TextBox District = (TextBox)CreateUserWizard1.FindControl("District");
            TextBox City = (TextBox)CreateUserWizard1.FindControl("City");
            TextBox Country = (TextBox)CreateUserWizard1.FindControl("Country");
            TextBox Director = (TextBox)CreateUserWizard1.FindControl("Director");
            TextBox EmployeeNumber = (TextBox)CreateUserWizard1.FindControl("EmployeeNumber");
            #endregion
            
            NDMSInvestigation.Entities.CompanyDetails companyDetails = new NDMSInvestigation.Entities.CompanyDetails();

            companyDetails.UserId = new Guid(membership.ProviderUserKey.ToString());
            if (CompanyName != null) companyDetails.CompanyName = CompanyName.Text;
            if (Phone != null) companyDetails.Phone = Phone.Text;
            if (Fax != null) companyDetails.Fax = Fax.Text;
            if (Address != null) companyDetails.Address = Address.Text;
            if (District != null) companyDetails.District = District.Text;
            if (City != null) companyDetails.City = City.Text;
            if (Country != null) companyDetails.Country = Country.Text;
            if (Director != null) companyDetails.Director = Director.Text;
            if (EmployeeNumber != null) { companyDetails.EmployeeNumber = Convert.ToInt32(EmployeeNumber.Text); }

            Presenter.Insert(companyDetails);
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

