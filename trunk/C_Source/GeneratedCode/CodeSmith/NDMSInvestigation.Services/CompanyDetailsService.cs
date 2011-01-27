

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;
using System.Linq;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Entities.Validation;

using NDMSInvestigation.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace NDMSInvestigation.Services
{
    /// <summary>
    /// An component type implementation of the 'CompanyDetails' table.
    /// </summary>
    /// <remarks>
    /// All custom implementations should be done here.
    /// </remarks>
    [CLSCompliant(true)]
    public partial class CompanyDetailsService : NDMSInvestigation.Services.CompanyDetailsServiceBase
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the CompanyDetailsService class.
        /// </summary>
        public CompanyDetailsService()
            : base()
        {
        }
        #endregion Constructors

        /// <summary>
        /// Gets the company rank.
        /// </summary>
        /// <param name="companyId">The company id.</param>
        /// <returns></returns>
        public int GetCompanyRank(int companyId)
        {
            CompanyDetails currentCompanyDetails = GetByCompanyId(companyId);

            if (currentCompanyDetails == null) return -1;

            TList<CompanyDetails> companyDetailsCollection = GetAll();
            int rank = 0;

            // TODO: Sort Company CurrentMarkInHere

            int lastCurrentTotalMark = 0;

            companyDetailsCollection.Sort("CurrentTotalMark");

            foreach (CompanyDetails companyDetails in companyDetailsCollection)
            {
                if ((companyDetails.CurrentTotalMark.HasValue)&&
                    (companyDetails.CurrentTotalMark.Value == 0))
                    continue;
                if ((companyDetails.CurrentTotalMark.HasValue)&&
                    (companyDetails.CurrentTotalMark.Value != lastCurrentTotalMark))
                {
                    rank++;
                    lastCurrentTotalMark = companyDetails.CurrentTotalMark.Value;
                }
                if (companyDetails == currentCompanyDetails) break;
            }

            return rank;
        }

        /// <summary>
        /// Gets the top mark companies.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns></returns>
        public TList<CompanyDetails> GetTopMarkCompanies(int top)
        {
            TList<CompanyDetails> companyDetailsList = this.GetAll();

            if (companyDetailsList == null) return null;

            companyDetailsList = (from t in companyDetailsList
                                  orderby t.CurrentTotalMark.HasValue ? t.CurrentTotalMark.Value : 0 descending
                                  select t) as TList<CompanyDetails>;

            TList<CompanyDetails> result = new TList<CompanyDetails>();
            int count = 0;

            foreach (CompanyDetails companyDetails in companyDetailsList)
            {
                if (count < top) result.Add(companyDetails);
                count++;
            }

            // TODO: add code to GetTopMarkCompanies function
            return result;
        }


    }//End Class

} // end namespace
