using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Services;
using Microsoft.Practices.CompositeWeb.Configuration;
using Microsoft.Practices.CompositeWeb.EnterpriseLibrary.Services;

using NDMSInvestigation.Services;

namespace NDMSInvestigation.ServiceRepository
{
    public class ServiceRepositoryModuleInitializer : ModuleInitializer
    {
        public override void Load(CompositionContainer container)
        {
            base.Load(container);

            AddGlobalServices(container.Services);
        }

        protected virtual void AddGlobalServices(IServiceCollection globalServices)
        {
            
            globalServices.AddNew<QuestionGroupsService>();
            globalServices.AddNew<AnswerDetailsService>();
            globalServices.AddNew<ResultsService>();
            globalServices.AddNew<CompanyDetailsService>();
            globalServices.AddNew<QuestionAnswerService>();
        }

        public override void Configure(IServiceCollection services, System.Configuration.Configuration moduleConfiguration)
        {
        }
    }
}
