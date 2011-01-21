using System;
using System.Collections.Generic;
using System.Text;

namespace NDMSInvestigation.Reports.Views
{
    public interface ICompanyEstimationView
    {
        string DisplayCompanyRank
        {
            set;
            get;
        }
        int CurrentCompanyId
        {
            get;
        }
        string DisplayCompanyRankFormat
        {
            get;
        }
    }
}




