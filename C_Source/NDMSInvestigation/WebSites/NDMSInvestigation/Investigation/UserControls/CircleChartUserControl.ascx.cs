﻿using System;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using Microsoft.Practices.ObjectBuilder;
using System.Drawing;
using NDMSInvestigation.Entities;
using System.Collections.Generic;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class CircleChartUserControl : Microsoft.Practices.CompositeWeb.Web.UI.UserControl, ICircleChartUserControlView, IChartUserControl
    {
        private CircleChartUserControlPresenter _presenter;

        public Chart ChartControl
        {
            get { return ChartCircle; }
            set { ChartCircle = value; }
        }

        public Microsoft.Practices.CompositeWeb.Web.UI.UserControl UserControlInstance
        {
            get { return this; }
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

                ChartCircle.Series["Series1"].Points.DataBindXY(xValues, yValues);
                ChartCircle.Series["Series1"].ChartType = SeriesChartType.Radar;
                ChartCircle.Series["Series1"]["AreaDrawingStyle"] = "Circle";
                ChartCircle.Series["Series1"]["CircularLabelsStyle"] = "Horizontal";
                ChartCircle.Series["Series1"].BorderColor = Color.Empty;
                ChartCircle.Series["Series1"].BorderWidth = 2;
                ChartCircle.Series["Series1"]["RadarDrawingStyle"] = ddlRadarType.SelectedItem.Text;
            }
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

