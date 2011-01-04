	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

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
		public CompanyDetailsService() : base()
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
			TList<CompanyDetails> companyDetailsCollection = GetAll();
			int rank = 0;

            // TODO: Sort Company CurrentMarkInHere

            int lastCurrentTotalMark = 0;

            companyDetailsCollection.Sort("order by CurrentTotalMark DESC");
			
			foreach (CompanyDetails companyDetails in companyDetailsCollection)
			{
				if (companyDetails.CurrentTotalMark.Value == 0)
					continue;
                if (companyDetails.CurrentTotalMark.Value != lastCurrentTotalMark)
				{
					rank++;
					lastCurrentTotalMark = companyDetails.CurrentTotalMark.Value;
				}
			}
			
			return rank;
		}
		
		
	}//End Class

} // end namespace
