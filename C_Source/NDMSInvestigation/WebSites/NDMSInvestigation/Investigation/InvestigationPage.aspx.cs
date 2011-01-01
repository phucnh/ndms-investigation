using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb.Utility;

using NDMSInvestigation.Web.UI;
using NDMSInvestigation.Entities;
using System.Data;

namespace NDMSInvestigation.Investigation.Views
{
    public partial class InvestigationPage : Microsoft.Practices.CompositeWeb.Web.UI.Page, IInvestigationPageView
    {
        private InvestigationPagePresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();

            hidUserId.Value = NDMSInvestigation.WCSF.Utility.GetUserId();
        }

        [CreateNew]
        public InvestigationPagePresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Int32 sum = new Int32();
            TList<NDMSInvestigation.Entities.Results> resultCollection = Presenter.GetResultByCustomerId(new Guid(hidUserId.Value));

            foreach (Control rptQuestionGroupControl in rptQuestionGroup.Controls)
            {
                Repeater rptQuestionDetails = (Repeater)rptQuestionGroupControl.FindControl("rptQuestionDetails");
                HiddenField hiddenField = (HiddenField)rptQuestionGroupControl.FindControl("hidGroupId");

                Int32 sumGroup = new Int32();

                foreach (Control rptQuestionDetailsControl in rptQuestionDetails.Controls)
                {
                    //EntityDropDownList ddlQuestionAnswer = (EntityDropDownList)rptQuestionDetailsControl.FindControl("ddlQuestionAnswer");
                    RadioButtonList radioButtonList = (RadioButtonList)rptQuestionDetailsControl.FindControl("rblQuestionAnswer");
                    sumGroup += Int32.Parse(radioButtonList.SelectedValue);
                    sum += Int32.Parse(radioButtonList.SelectedValue);
                }

                if (resultCollection != null)
                {
                    Results result = resultCollection.Find(ResultsColumn.GroupId, Int32.Parse(hiddenField.Value));
                    if (result != null)
                    {
                        result.GroupMark = sumGroup;
                        result.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        result = new Results();

                        result.GroupId = Int32.Parse(hiddenField.Value);
                        result.UserId = new Guid(hidUserId.Value); 
                        result.GroupMark = sumGroup;
                        result.CreatedDate = DateTime.Now;

                        resultCollection.Add(result);
                    }
                }
                else
                {
                    Results result = new Results();

                    result.GroupId = Int32.Parse(hiddenField.Value);
                    result.UserId = new Guid(hidUserId.Value);
                    result.GroupMark = sumGroup;
                    result.CreatedDate = DateTime.Now;

                    resultCollection.Add(result);
                }

                Presenter.Save(resultCollection);
            }
        }

        public String GetAnswerContent(int answerId)
        {
            NDMSInvestigation.Entities.AnswerDetails answerDetails;
            answerDetails = Presenter.GetAnswerContent(answerId);

            Guard.ArgumentNotNull(answerDetails, "answerDetails");

            if (!String.IsNullOrEmpty(answerDetails.AnswerContent))
                return answerDetails.AnswerContent;
            else
                return "";
        }

        protected void rptQuestionDetails_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            RadioButtonList radioButtonList = (RadioButtonList)e.Item.FindControl("rblQuestionAnswer");
            Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(radioButtonList, "radioButtonList");

            NDMSInvestigation.Web.Data.QuestionAnswerDataSource questionAnswerDataSource = (NDMSInvestigation.Web.Data.QuestionAnswerDataSource)e.Item.FindControl("QuestionAnswerDataSource");
            Guard.ArgumentNotNull(questionAnswerDataSource, "questionAnswerDataSource");

            TList<NDMSInvestigation.Entities.QuestionAnswer> tList = (TList<NDMSInvestigation.Entities.QuestionAnswer>)questionAnswerDataSource.GetEntityList();
            Guard.ArgumentNotNull(tList, "tList");

            foreach (NDMSInvestigation.Entities.QuestionAnswer questionAnswer in tList)
            {
                ListItem listItem = new ListItem();
                listItem.Text = GetAnswerContent(questionAnswer.AnswerId);
                listItem.Value = questionAnswer.Mark.ToString();
                radioButtonList.Items.Add(listItem);
            }
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

