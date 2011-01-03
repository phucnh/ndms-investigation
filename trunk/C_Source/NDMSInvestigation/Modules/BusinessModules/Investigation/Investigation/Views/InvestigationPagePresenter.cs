using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

using NDMSInvestigation.Services;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;

namespace NDMSInvestigation.Investigation.Views
{
    public class InvestigationPagePresenter : Presenter<IInvestigationPageView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //

        private AnswerDetailsService _answerDetailsService;
        private ResultsService _resultService;
        private CompanyDetailsService _companyService;
        private QuestionAnswerService _quesstionAnswerService;
        private IInvestigationController _controller;

        public InvestigationPagePresenter(
            [CreateNew] IInvestigationController controller,
            [ServiceDependency] AnswerDetailsService answerDetailsService,
            [ServiceDependency] ResultsService resultService,
            [ServiceDependency] CompanyDetailsService companyService,
            [ServiceDependency] QuestionAnswerService quesstionAnswerService
            )
        {
            _controller = controller;
            _answerDetailsService = answerDetailsService;
            _resultService = resultService;
            _companyService = companyService;
            _quesstionAnswerService = quesstionAnswerService;
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
        /// Inserts the new group mark.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="groupId">The group id.</param>
        /// <param name="sumGroup">The sum group.</param>
        /// <returns></returns>
        public bool InsertNewGroupMark(Guid userId, int groupId, int sumGroup)
        {
            int testTime = GetCurrentTestTime(userId);
            Results _result = new Results();

            _result.UserId = userId;
            _result.GroupId = groupId;
            _result.TestTimes = testTime;
            _result.GroupMark = sumGroup;
            _result.CreatedDate = DateTime.Now;

            return _resultService.Insert(_result);
        }

        /// <summary>
        /// Gets the current test time.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public int GetCurrentTestTime(Guid userId)
        {
            TList<Results> _results = _resultService.GetByUserId(userId);

            if (_resultService == null) return 0;

            int currentTestTime = 0;

            foreach (Results _result in _results)
            {
                int _tempTestTime = 0;
                _tempTestTime = _result.TestTimes.HasValue ? _result.TestTimes.Value : 0;
                if (_tempTestTime > currentTestTime)
                    currentTestTime = _tempTestTime;
            }

            return currentTestTime++;
        }

        /// <summary>
        /// Updates the current total mark.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="newTotalMark">The new total mark.</param>
        /// <returns></returns>
        public bool UpdateCurrentTotalMark(Guid userId, int newTotalMark)
        {
            CompanyDetails _companyDetails = _companyService.GetByUserId(userId);
            if (_companyDetails == null) return false;

            _companyDetails.CurrentTotalMark = newTotalMark;
            return _companyService.Update(_companyDetails);
        }

        public String GetAnswerContent(int answerId)
        {
            AnswerDetails answerDetails = _answerDetailsService.GetByAnswerId(answerId);

            Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(answerDetails, "answerDetails");

            if (!String.IsNullOrEmpty(answerDetails.AnswerContent))
                return answerDetails.AnswerContent;
            else
                return "";
        }

        public TList<QuestionAnswer> GetRandomQuestionAnswersList(int questionId)
        {
            TList<QuestionAnswer> questionAnswers = _quesstionAnswerService.GetByQuestionId(questionId);

            if ((questionAnswers == null) || (questionAnswers.Count == 0)) return null;

            questionAnswers = GetWithDifferentMark(questionAnswers);

            if ((questionAnswers == null) || (questionAnswers.Count == 0)) return null;

            questionAnswers = OrderQuestionAnswersByRandom(questionAnswers);

            return questionAnswers;
        }

        /// <summary>
        /// Gets the with different mark.
        /// </summary>
        /// <param name="questionAnswers">The question answers.</param>
        /// <returns></returns>
        private TList<QuestionAnswer> GetWithDifferentMark(TList<QuestionAnswer> questionAnswers)
        {
            Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(questionAnswers, "questionAnswers");

            List<int> examinedMark = new List<int>();
            TList<QuestionAnswer> _tempCollection = new TList<QuestionAnswer>();

            foreach (QuestionAnswer questionAnswer in questionAnswers)
            {
                int tempMark = 0;

                if (questionAnswer.Mark.HasValue)   tempMark = questionAnswer.Mark.Value;
                else
                {
                    _quesstionAnswerService.DeepLoad(questionAnswer, 
                        false, 
                        DeepLoadType.IncludeChildren,
                        typeof(AnswerDetails));

                    tempMark = questionAnswer.AnswerIdSource.AnswerMark.HasValue ?
                        questionAnswer.AnswerIdSource.AnswerMark.Value :
                        0;
                }

                if (!examinedMark.Contains(tempMark)) _tempCollection.Add(questionAnswer);
            }

            return _tempCollection;
        }

        /// <summary>
        /// Orders the question's answers by random.
        /// </summary>
        /// <param name="questionAnswers">The question answers.</param>
        /// <returns></returns>
        private TList<QuestionAnswer> OrderQuestionAnswersByRandom(TList<QuestionAnswer> questionAnswers)
        {
            Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(questionAnswers, "questionAnswers");

            TList<QuestionAnswer> tempCollection = new TList<QuestionAnswer>();
            List<int> examinedIndex = new List<int>(); //For enhance performance

            int questionAnswerCount = questionAnswers.Count; //For enhance performance

            if (questionAnswerCount == 0) return null;

            Random rand = new Random();

            do
            {
                int index = rand.Next(questionAnswerCount - 1);

                if (!examinedIndex.Contains(index))
                    tempCollection.Add(questionAnswers[index]);
            }
            while ((tempCollection.Count == 5) ||
                (examinedIndex.Count == questionAnswerCount));

            return tempCollection;
        }

        // TODO: Handle other view events and set state in the view
    }
}




