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
            litHeader.Text = GetCurrentCompanyName();
            //LoadChart();
        }

        //private void LoadChart()
        //{
        //    TList<QuestionGroups> questionGroupCollection = GetAllGroup();
        //    TList<Results> resultCollection = GetAllResultByUserId();

        //    if (
        //        ((questionGroupCollection != null) && (questionGroupCollection.Count != 0)) ||
        //        ((resultCollection != null) && (resultCollection.Count != 0))
        //        )
        //    {
        //        List<String> groupName = new List<String>();
        //        List<int> groupMark = new List<int>();

        //        questionGroupCollection.Sort("GroupId");
        //        resultCollection.Sort("GroupId");

        //        foreach (QuestionGroups questionGroup in questionGroupCollection)
        //        {
        //            groupName.Add(questionGroup.GroupName);
        //        }

        //        foreach (Results result in resultCollection)
        //        {
        //            groupMark.Add((int)result.GroupMark);
        //        }

        //        int[] yValues = groupMark.ToArray();
        //        String[] xValues = groupName.ToArray();

        //        ChartResult.Series["Series1"].Points.DataBindXY(xValues, yValues);
        //        //ChartResult.Series["Series1"].ChartType = SeriesChartType.Radar;
        //        ChartResult.Series["Series1"]["RadarDrawingStyle"] = "Area";
        //        ChartResult.Series["Series1"]["AreaDrawingStyle"] = "Polygon";
        //        ChartResult.Series["Series1"]["CircularLabelsStyle"] = "Horizontal";
        //    }
        //}

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
        public TList<QuestionGroups> GetAllGroup()
        {
            return Presenter.GetAllGroup();
        }

        public TList<Results> GetAllResultByUserId()
        {
            return Presenter.GetAllResultByUserId(new Guid(hidUserId.Value));
        }

        public string GetCurrentCompanyName()
        {
            string currentCompanyName = string.Empty;
            NDMSInvestigation.Entities.CompanyDetails currentCompanyDetails = _presenter.GetCompanyDetailsByUserId(new Guid(hidUserId.Value));

            if (currentCompanyDetails != null)
            {
                currentCompanyName = String.Format(Resources.StringResource.ViewResult_Text_ViewResultHeader, currentCompanyDetails.CompanyName);
            }
            return currentCompanyName;
        }

        protected void ddlChartType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

