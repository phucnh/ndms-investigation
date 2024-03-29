﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDMSInvestigation.Investigation.Views;
using Microsoft.Practices.ObjectBuilder;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class InvestigationDefault : Microsoft.Practices.CompositeWeb.Web.UI.Page, IDefaultView
    {
        private DefaultViewPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public DefaultViewPresenter Presenter
        {
            set
            {
                this._presenter = value;
                this._presenter.View = this;
            }
        }
    }
}
