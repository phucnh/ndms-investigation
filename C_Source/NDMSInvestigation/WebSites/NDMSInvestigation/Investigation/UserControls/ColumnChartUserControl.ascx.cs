using System;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using Microsoft.Practices.ObjectBuilder;
using System.Drawing;
using NDMSInvestigation.Entities;
using System.Collections.Generic;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class ColumnChartUserControl : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, IColumnChartUserControlView
    {
        private ColumnChartUserControlPresenter _presenter;

        public Chart ChartControl
        {
            set
            {
                ChartColumn = value;
            }
            get
            {
                return ChartColumn;
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
        public ColumnChartUserControlPresenter Presenter
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

                ChartColumn.Series["Series1"].Points.DataBindXY(xValues, yValues);
                if (string.Compare(ChartType.SelectedItem.ToString(),"Column").Equals(0))
                {
                    ChartColumn.Series["Series1"].ChartType = SeriesChartType.Column;
                }
                if (string.Compare(ChartType.SelectedItem.ToString(), "Bar").Equals(0))
                {
                    ChartColumn.Series["Series1"].ChartType = SeriesChartType.Bar;
                }

                ChartColumn.Series["Series1"]["PointWidth"] = BarWidthList.SelectedItem.ToString();
                ChartColumn.Series["Series1"]["DrawingStyle"] = "Cylinder";
                ChartColumn.Series["Series1"].BorderColor = Color.Empty;
                ChartColumn.Series["Series1"].BorderWidth = 1;
                if (chkView3D.Checked)
                {
                    ChartColumn.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                }
                else
                {
                    ChartColumn.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                }
            }
        }
    }
}

