using System;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using Microsoft.Practices.ObjectBuilder;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class CircleChartUserControl : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, ICircleChartUserControlView,IChartUserControl
    {
        private CircleChartUserControlPresenter _presenter;

        public Chart ChartControl
        {
            get { return ChartCircle; }
            set {ChartCircle = value;}
        }

        public Microsoft.Practices.CompositeWeb.Web.UI.UserControl UserControlInstance
        {
            get {return this;}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
        }

        [CreateNew]
        public CircleChartUserControlPresenter Presenter
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

