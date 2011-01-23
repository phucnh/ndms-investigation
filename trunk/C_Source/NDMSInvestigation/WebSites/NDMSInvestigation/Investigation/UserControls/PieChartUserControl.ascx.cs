using System;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using Microsoft.Practices.ObjectBuilder;
using System.Drawing;
using NDMSInvestigation.Entities;
using System.Collections.Generic;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class PieChartUserControl : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, IPieChartUserControlView
    {
        private PieChartUserControlPresenter _presenter;

        public Chart ChartControl
        {
            set
            {
                ChartPie = value;
            }
            get
            {
                return ChartPie;
            }
        }

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

        [CreateNew]
        public PieChartUserControlPresenter Presenter
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

        public TList<QuestionGroups> GetAllGroup()
        {
            return Presenter.GetAllGroup(new Guid(hidUserId.Value));
        }

        public TList<Results> GetAllResultByUserId()
        {
            return Presenter.GetAllResultByUserId(new Guid(hidUserId.Value));
        }

        private void LoadChart()
        {
            int i = 0;
            TList<QuestionGroups> questionGroupCollection = GetAllGroup();
            TList<Results> resultCollection = GetAllResultByUserId();

            if (
                ((questionGroupCollection != null) && (questionGroupCollection.Count != 0)) ||
                ((resultCollection != null) && (resultCollection.Count != 0))
                )
            {
                List<String> groupName = new List<String>();
                List<int> groupMark = new List<int>();

                questionGroupCollection.Sort("GroupId");
                resultCollection.Sort("GroupId");

                foreach (QuestionGroups questionGroup in questionGroupCollection)
                {
                    groupName.Add(questionGroup.GroupName);
                }

                foreach (Results result in resultCollection)
                {
                    groupMark.Add((int)result.GroupMark);
                }

                string[] xValues = new string[groupName.Count];
                for (i = 0; i < groupName.Count; i++)
                {
                    xValues.SetValue(groupName[i], i);
                }

                double[] yValues = new double[groupMark.Count];
                for (i = 0; i < groupMark.Count; i++)
                {
                    yValues.SetValue(groupMark[i], i);
                }

                ChartPie.Series["Series1"].Points.DataBindXY(xValues, yValues);
                if (string.Compare(ddlPieChartType.SelectedItem.Text,"Doughnut").Equals(0))
                {
                    ChartPie.Series["Series1"].ChartType = SeriesChartType.Doughnut;
                }
                if (ddlPieChartType.SelectedItem.Text == "Pie")
                {
                    ChartPie.Series["Series1"].ChartType = SeriesChartType.Pie;
                }
                ChartPie.Series["Series1"]["PieDrawingStyle"] = "Concave";
                ChartPie.Series["Series1"]["DoughnutRadius"] = "70";
                ChartPie.Series["Series1"]["PieLabelStyle"] = ddlShowLegend.SelectedItem.Value.ToString();
                ChartPie.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = chk3DView.Checked;
            }
        }

    }
}

