﻿using System;
using Microsoft.Practices.ObjectBuilder;

namespace NDMSInvestigation.Reports.Views
{
    public partial class TopMarkCompanies : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, ITopMarkCompaniesView
    {
        private TopMarkCompaniesPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            gridViewTest.DataSource = Presenter.GetTopMarkCompanies(2);
        }

        public TopMarkCompanies()
        {
            Microsoft.Practices.CompositeWeb.WebClientApplication.BuildItemWithCurrentContext(this);
        }

        [CreateNew]
        public TopMarkCompaniesPresenter Presenter
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

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

