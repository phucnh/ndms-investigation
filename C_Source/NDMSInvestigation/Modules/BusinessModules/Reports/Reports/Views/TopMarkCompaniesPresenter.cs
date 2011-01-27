using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Services;

namespace NDMSInvestigation.Reports.Views
{
    public class TopMarkCompaniesPresenter : Presenter<ITopMarkCompaniesView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
         private IReportsController _controller;
        private CompanyDetailsService _companyDetailsService;

         public TopMarkCompaniesPresenter(
             [CreateNew] IReportsController controller,
             [ServiceDependency] CompanyDetailsService companyDetailsService)
         {
         		_controller = controller;
             _companyDetailsService = companyDetailsService;
         }

        public override void OnViewLoaded()
        {
            // TODO: Implement code that will be executed every time the view loads
        }

        public override void OnViewInitialized()
        {
            // TODO: Implement code that will be executed the first time the view loads
        }

        public TList<CompanyDetails> GetTopMarkCompanies(int top)
        {
            return _companyDetailsService.GetTopMarkCompanies(top);
        }

        // TODO: Handle other view events and set state in the view
    }
}




