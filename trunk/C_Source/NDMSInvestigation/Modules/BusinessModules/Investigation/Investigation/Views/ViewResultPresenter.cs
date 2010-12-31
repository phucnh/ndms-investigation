using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using NDMSInvestigation.Services;
using NDMSInvestigation.Entities;

namespace NDMSInvestigation.Investigation.Views
{
    public class ViewResultPresenter : Presenter<IViewResultView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //

        private ResultsService _resultService;
        private QuestionGroupsService _questionGroupService;
        private IInvestigationController _controller;
        
        public ViewResultPresenter(
            [CreateNew] IInvestigationController controller,
            [ServiceDependency] QuestionGroupsService questionGroupService,
            [ServiceDependency] ResultsService resultService
            )
        {
            _controller = controller;
            _questionGroupService = questionGroupService;
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
        /// Gets all group.
        /// </summary>
        /// <returns></returns>
        public TList<QuestionGroups> GetAllGroup()
        {
            TList<QuestionGroups> questionGroupCollection;
            questionGroupCollection = _questionGroupService.GetAll();

            //Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(questionGroupCollection, "questionGroupCollection");

            return questionGroupCollection;
        }

        public TList<Results> GetAllResultByUserId(Guid userId)
        {
            TList<Results> resultCollection;
            resultCollection = _resultService.GetByUserId(userId);

            return resultCollection;
        }

        // TODO: Handle other view events and set state in the view
    }
}




