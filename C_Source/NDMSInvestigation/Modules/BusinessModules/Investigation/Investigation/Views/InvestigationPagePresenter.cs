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
        private ResultsService _resultService;
        private IInvestigationController _controller;

        public InvestigationPagePresenter(
            [CreateNew] IInvestigationController controller,
            [ServiceDependency] AnswerDetailsService answerDetailsService,
            [ServiceDependency] ResultsService resultService
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

        /// <summary>
        /// Gets the content of the answer.
        /// </summary>
        /// <param name="answerId">The answer id.</param>
        /// <returns></returns>
        public AnswerDetails GetAnswerContent(int answerId)
        {
            return _answerDetailsService.GetByAnswerId(answerId);
        }

        /// <summary>
        /// Gets the result by customer id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public TList<Results> GetResultByCustomerId(Guid userId)
        {
            return _resultService.GetByUserId(userId);
        }

        public void Save(TList<Results> resultCollection)
        {
            _resultService.Save(resultCollection);
        }

        /// <summary>
        /// Calculates the sum mark.
        /// </summary>
        /// <param name="groupMarks">The group marks.</param>
        /// <returns></returns>
        public Int32 CalculateSumMark(Int32[] groupMarks)
        {
            Int32 sumMark = 0;

            foreach (Int32 groupMark in groupMarks)
            {
                sumMark += groupMark;
            }

            return sumMark;
        }
        // TODO: Handle other view events and set state in the view
    }
}




