using System;
using System.Collections.Generic;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI;

namespace NDMSInvestigation.Investigation.Views
{
    public interface IChartUserControl
    {
        Chart ChartControl
        {
            set;
            get;
        }

        //Microsoft.Practices.CompositeWeb.Web.UI.UserControl UserControlInstance
        //{
        //    get;
        //}
    }
}
