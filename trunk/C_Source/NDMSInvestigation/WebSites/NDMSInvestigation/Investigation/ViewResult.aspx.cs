using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

using Microsoft.Practices.ObjectBuilder;

using NDMSInvestigation.Entities;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class ViewResult : Microsoft.Practices.CompositeWeb.Web.UI.Page, IViewResultView
    {
        private ViewResultPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            hidUserId.Value = NDMSInvestigation.WCSF.Utility.GetUserId();
            LoadChart();
        }

        private void LoadChart()
        {
            TList<NDMSInvestigation.Entities.QuestionGroup> questionGroupCollection = GetAllGroup();
            TList<NDMSInvestigation.Entities.Result> resultCollection = GetAllResultByUserId();

            if (
                ((questionGroupCollection != null) && (questionGroupCollection.Count != 0)) ||
                ((resultCollection != null) && (resultCollection.Count != 0))
                )
            {
                List<String> groupName = new List<String>();
                List<int> groupMark = new List<int>();

                questionGroupCollection.Sort("GroupId");
                resultCollection.Sort("GroupId");

                foreach (NDMSInvestigation.Entities.QuestionGroup questionGroup in questionGroupCollection)
                {
                    groupName.Add(questionGroup.GroupName);
                }

                foreach (NDMSInvestigation.Entities.Result result in resultCollection)
                {
                    groupMark.Add((int)result.GroupMark);
                }

                int[] yValues = groupMark.ToArray();
                String[] xValues = groupName.ToArray();

                ChartResult.Series["Series1"].Points.DataBindXY(xValues, yValues);
                //ChartResult.Series["Series1"].ChartType = SeriesChartType.Radar;
                ChartResult.Series["Series1"]["RadarDrawingStyle"] = "Area";
                ChartResult.Series["Series1"]["AreaDrawingStyle"] = "Polygon";
                ChartResult.Series["Series1"]["CircularLabelsStyle"] = "Horizontal";
            }
        }

        protected ViewResult()
        {
            Microsoft.Practices.CompositeWeb.WebClientApplication.BuildItemWithCurrentContext(this);
        }

        [CreateNew]
        public ViewResultPresenter Presenter
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
        /// Gets all group.
        /// </summary>
        /// <returns></returns>
        public TList<NDMSInvestigation.Entities.QuestionGroup> GetAllGroup()
        {
            return Presenter.GetAllGroup();
        }

        public TList<NDMSInvestigation.Entities.Result> GetAllResultByUserId()
        {
            return Presenter.GetAllResultByUserId(new Guid(hidUserId.Value));
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

