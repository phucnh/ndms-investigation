using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Services;

namespace NDMSInvestigation.UserControl.Views
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private NDMSInvestigation.Services.CompanyDetailsService _companyDetailsService;
        private IUserControlController _controller;

        public RegisterPresenter(
            [CreateNew] IUserControlController controller,
            [ServiceDependency] NDMSInvestigation.Services.CompanyDetailsService companyDetailsService
            )
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

        public void Insert(CompanyDetails companyDetails)
        {
            _companyDetailsService.Insert(companyDetails);
        }

        // TODO: Handle other view events and set state in the view
    }
}




