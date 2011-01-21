using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using NDMSInvestigation.Services;

namespace NDMSInvestigation.Reports.Views
{
    public class CompanyEstimationPresenter : Presenter<ICompanyEstimationView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private IReportsController _controller;
        private CompanyDetailsService _companyDetailsService;

        public CompanyEstimationPresenter(
            [CreateNew] IReportsController controller,
            [ServiceDependency] CompanyDetailsService companyDetailsService)
        {
            _controller = controller;
            _companyDetailsService = companyDetailsService;
        }

        public override void OnViewLoaded()
        {
            View.DisplayCompanyRank = GetCurrentCompanyRankString();
        }

        public override void OnViewInitialized()
        {
            
        }

        public string GetCurrentCompanyRankString()
        {
            int rank = _companyDetailsService.GetCompanyRank(View.CurrentCompanyId);

            if (rank <= 0) return "";

            View.DisplayCompanyRank = string.Format(
                View.DisplayCompanyRankFormat,
                _companyDetailsService.GetByCompanyId(View.CurrentCompanyId).CompanyName,
                rank,_companyDetailsService.GetAll().Count
                );

            return View.DisplayCompanyRank;
        }

        // TODO: Handle other view events and set state in the view
    }
}




