using System;
using System.Web.Security;

using Microsoft.Practices.ObjectBuilder;

using NDMSInvestigation.Entities;

namespace NDMSInvestigation.Shell.MasterPages
{
    public partial class DefaultMaster : Microsoft.Practices.CompositeWeb.Web.UI.MasterPage, IDefaultMasterView
    {
        private DefaultMasterPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            _presenter.OnViewLoaded();
        }

        [CreateNew]
        public DefaultMasterPresenter Presenter
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
    }
}
