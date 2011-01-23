using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using NDMSInvestigation.Services;
using NDMSInvestigation.Entities;

namespace NDMSInvestigation.Investigation.Views
{
    public class PieChartUserControlPresenter : Presenter<IPieChartUserControlView>
    {
        private IInvestigationController _controller;
        private ResultsService _resultService;
        private QuestionGroupsService _questionGroupService;

        public PieChartUserControlPresenter(
            [CreateNew] IInvestigationController controller,
            [ServiceDependency] QuestionGroupsService questionGroupService,
            [ServiceDependency] ResultsService resultService)
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

        public TList<QuestionGroups> GetAllGroup(Guid userId)
        {
            TList<QuestionGroups> questionGroupCollection;
            questionGroupCollection = _questionGroupService.GetByUserIdFromResults(userId);

            //Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(questionGroupCollection, "questionGroupCollection");

            return questionGroupCollection;
        }

        public TList<Results> GetAllResultByUserId(Guid userId)
        {
            TList<Results> resultCollection;
            resultCollection = _resultService.GetByUserId(userId);

            return resultCollection;
        }

    }
}




