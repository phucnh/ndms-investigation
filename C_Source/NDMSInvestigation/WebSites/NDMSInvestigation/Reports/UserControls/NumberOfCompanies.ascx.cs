using System;
using Microsoft.Practices.ObjectBuilder;

using NDMSInvestigation.WCSF;

namespace NDMSInvestigation.Reports.Views
{
    public partial class NumberOfCompanies : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, INumberOfCompaniesView
    {
        private NumberOfCompaniesPresenter _presenter;
        private int _numberOfYears;

        /// <summary>
        /// Gets or sets the number of years.
        /// </summary>
        /// <value>
        /// The number of years.
        /// </value>
        public int NumberOfYears
        {
            get { return _numberOfYears; }
            set { _numberOfYears = value; }
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            LiteralNumberOfYearsLast.Text = string.Format(
                Resources.StringResource.Reports_Text_TotalCompaniesNow,
                Presenter.GetNumberOfCompanies(),
                Utility.GetAllUsersCount()
                );
        }

        [CreateNew]
        public NumberOfCompaniesPresenter Presenter
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
        /// Binds the chart data.
        /// </summary>
        public void BindChartData()
        {
            if (Presenter.CalculateYears(_numberOfYears) == null) return;

            ChartReports.Series[0].Points.DataBindXY(
                Presenter.CalculateYears(_numberOfYears),
                Resources.StringResource.Reports_Text_Year,
                Presenter.CalculateCompanies(_numberOfYears),
                Resources.StringResource.Reports_Text_TotalCompanies
                );
        }

        protected void DropDownListYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(DropDownListYears.SelectedValue, out _numberOfYears))
                return;

            Presenter.BindChartData();
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

