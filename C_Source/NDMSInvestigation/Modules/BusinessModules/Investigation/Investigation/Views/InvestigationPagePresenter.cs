using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using NDMSInvestigation.Services;
using NDMSInvestigation.Entities;

namespace NDMSInvestigation.Investigation.Views
{
    public class InvestigationPagePresenter : Presenter<IInvestigationPageView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //

        private AnswerDetailsService _answerDetailsService;
        private ResultService _resultService;
        private IInvestigationController _controller;

        public InvestigationPagePresenter(
            [CreateNew] IInvestigationController controller,
            [ServiceDependency] AnswerDetailsService answerDetailsService,
            [ServiceDependency] ResultService resultService
            )
        {
            _controller = controller;
            _answerDetailsService = answerDetailsService;
            _resultService = resultService;
        }

        public override void OnViewLoaded()
        {
            // TODO: Implement code that will be executed every time the view loads
        }

        public override void OnViewInitialized()
        {
            // TODO: Implement code that will be executed the first time the view loads
        }

        public AnswerDetails GetAnswerContent(int answerId)
        {
            return _answerDetailsService.GetByAnswerId(answerId);
        }

        public TList<Result> GetResultByCustomerId(Guid userId)
        {
            return _resultService.GetByUserId(userId);
        }

        public void Save(TList<Result> resultCollection)
        {
            _resultService.Save(resultCollection);
        }
        // TODO: Handle other view events and set state in the view
    }
}




