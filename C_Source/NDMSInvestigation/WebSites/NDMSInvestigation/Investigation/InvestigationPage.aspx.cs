#define DEBUG

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
        //private Dictionary<RadioButtonList, int> _radioButtonDict;
        //private bool _isSubmit = false;
        //private WCSF.InvestigationEnum _state;
        private Dictionary<int, int> groupMarkDict;

        //public Dictionary<RadioButtonList, int> RadioButtonDict
        //{
        //    get
        //    {
        //        return _radioButtonDict;

        //    }
        //    set { _radioButtonDict = value; }
        //}

        //private void GetSession()
        //{
        //    if (Session["UserAnswers"] != null)
        //        RadioButtonDict = Session["UserAnswers"] as Dictionary<RadioButtonList, int>;

        //    else
        //        RadioButtonDict = new Dictionary<RadioButtonList, int>();
        //}

        //private void SetSession()
        //{
        //    Session["UserAnswers"] = RadioButtonDict;
        //}

        //private void ClearSession()
        //{
        //    Session["UserAnswers"] = null;
        //}

        //public void AddToDictionary(int groupId, RadioButtonList radioButtonList)
        //{
        //    if (radioButtonList == null) return;

        //    if (_radioButtonDict == null) _radioButtonDict = new Dictionary<RadioButtonList, int>();

        //    RadioButtonList radioButtonListTemp = new RadioButtonList();

        //    if (!RadioButtonDict.ContainsKey(radioButtonList))
        //    {
        //        RadioButtonDict.Add(radioButtonList, groupId);
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this._presenter.OnViewInitialized();
            }
            this._presenter.OnViewLoaded();
            //_state = WCSF.InvestigationEnum.Pre_Load;

            //LoadSessionToDict();

            //hidUserId.Value = NDMSInvestigation.WCSF.Utility.GetUserId();
        }

        //private void LoadSessionToDict()
        //{
        //    GetSession();

        //    //foreach (RadioButtonList radioButtonList in RadioButtonDict.Keys)
        //    //{
        //    //    RadioButtonList radioButtonListTemp = this.FindControl(radioButtonList.ClientID) as RadioButtonList;

        //    //    if (radioButtonListTemp != null)
        //    //        radioButtonList.SelectedValue = radioButtonListTemp.SelectedValue;
        //    //}

        //    foreach (RepeaterItem repeaterItem in rptQuestionGroup.Items)
        //    {
        //        Repeater rptQuestionDetails = (Repeater)repeaterItem.FindControl("rptQuestionDetails");
        //        if (rptQuestionDetails == null) continue;

        //        HiddenField hidGroupId = (HiddenField)repeaterItem.FindControl("hidGroupId");
        //        if (hidGroupId == null) continue;

        //        foreach (RepeaterItem rptQuestionDetailsItem in rptQuestionDetails.Items)
        //        {
        //            foreach (RadioButtonList radioButtonList in RadioButtonDict.Keys)
        //            {
        //                RadioButtonList rblQuestionAnswer =
        //                    rptQuestionDetailsItem.FindControl(radioButtonList.ClientID) as RadioButtonList;

        //                if (rblQuestionAnswer == null) continue;

        //                radioButtonList.SelectedValue = rblQuestionAnswer.SelectedValue;
        //            }
        //        }

        //    }

        //}

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
            

            //GetSession();
            //int totalMark = 0;
            //int currentTestTime = Presenter.GetCurrentTestTime(new Guid(WCSF.Utility.GetUserId()));
            //Dictionary<int, int> groupMark = new Dictionary<int, int>();

            //if (RadioButtonDict == null) return;
            //if (RadioButtonDict.Count == 0) return;

            //foreach (RadioButtonList radioButtonList in RadioButtonDict.Keys)
            //{
            //    int groupId;

            //    if (!RadioButtonDict.TryGetValue(radioButtonList, out groupId)) continue;

            //    if (radioButtonList == null) continue;

            //    if (groupMark.ContainsKey(groupId))
            //    {
            //        int mark = 0;

            //        groupMark.TryGetValue(groupId, out mark);

            //        if (mark < 0) mark = 0;
            //        if (string.IsNullOrEmpty(radioButtonList.SelectedValue)) mark += 0;
            //        else
            //        {
            //            mark += Convert.ToInt32(radioButtonList.SelectedValue);

            //            groupMark.Remove(groupId);
            //            groupMark.Add(groupId, mark);
            //        }
            //    }
            //    else
            //    {
            //        int mark = 0;

            //        if (!string.IsNullOrEmpty(radioButtonList.SelectedValue))
            //            mark += Convert.ToInt32(radioButtonList.SelectedValue);

            //        groupMark.Add(groupId, mark);
            //    }
            //}

            //foreach (int groupId in groupMark.Keys)
            //{
            //    int mark = 0;
            //    groupMark.TryGetValue(groupId, out mark);
            //    totalMark += mark;

            //    Presenter.InsertNewGroupMark(new Guid(WCSF.Utility.GetUserId()),
            //        groupId,
            //        mark,
            //        currentTestTime);
            //}

            //Presenter.UpdateCurrentTotalMark(new Guid(WCSF.Utility.GetUserId()), totalMark);


            //foreach (RepeaterItem repeaterItem in rptQuestionGroup.Items)
            //{
            //    foreach (Control rptQuestionGroupControl in repeaterItem.Controls)
            //    {

            //        Repeater rptQuestionDetails = (Repeater)rptQuestionGroupControl.FindControl("rptQuestionDetails");
            //        if (rptQuestionDetails == null) continue;

            //        HiddenField hidGroupId = (HiddenField)rptQuestionGroupControl.FindControl("hidGroupId");
            //        if (hidGroupId == null) continue;

            //        int sumGroup = 0;

            //        foreach (RepeaterItem rptQuestionDetailsItem in rptQuestionDetails.Items)
            //            foreach (Control rptQuestionDetailsControl in rptQuestionDetailsItem.Controls)
            //            {
            //                RadioButtonList radioButtonList = (RadioButtonList)rptQuestionDetailsControl.FindControl("rblQuestionAnswer");
            //                if (radioButtonList == null) continue;

            //                if (string.IsNullOrEmpty(radioButtonList.SelectedValue))
            //                    totalMark += 0;
            //                else
            //                {
            //                    sumGroup += Int32.Parse(radioButtonList.SelectedValue);
            //                    totalMark += sumGroup;
            //                }
            //            }

            //        Presenter.InsertNewGroupMark(
            //            new Guid(WCSF.Utility.GetUserId()),
            //            Int32.Parse(hidGroupId.Value),
            //            sumGroup, currentTestTime);
            //    }

            //    Presenter.UpdateCurrentTotalMark(
            //            new Guid(WCSF.Utility.GetUserId()),
            //            totalMark
            //            );
            //}

        }




        protected void rptQuestionDetails_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            //if (_state != WCSF.InvestigationEnum.Loading)
            //{
            //    ClearSession();
            //    RadioButtonDict = null;
            //    _state = WCSF.InvestigationEnum.Loading;
            //}

            if (!((e.Item.ItemType == ListItemType.Item) || 
                (e.Item.ItemType == ListItemType.AlternatingItem))) return;

            NDMSInvestigation.Entities.QuestionDetails questionDetails = e.Item.DataItem
                as NDMSInvestigation.Entities.QuestionDetails;

            if (questionDetails == null) return;
            if (!questionDetails.GroupId.HasValue) return;

            RadioButtonList radioButtonList = (RadioButtonList)e.Item.FindControl("rblQuestionAnswer");
            Guard.ArgumentNotNull(radioButtonList, "radioButtonList");

            //NDMSInvestigation.Web.Data.QuestionAnswerDataSource questionAnswerDataSource
            //    = (NDMSInvestigation.Web.Data.QuestionAnswerDataSource)e.Item.FindControl("QuestionAnswerDataSource");
            //Guard.ArgumentNotNull(questionAnswerDataSource, "questionAnswerDataSource");

            //HiddenField hidQuestionId = (HiddenField)e.Item.FindControl("hidQuestionId");
            //Guard.ArgumentNotNull(hidQuestionId, "hidQuestionId");

            //TList<NDMSInvestigation.Entities.QuestionAnswer> questionAnswers 
            //= (TList<NDMSInvestigation.Entities.QuestionAnswer>)questionAnswerDataSource.GetEntityList();
            TList<NDMSInvestigation.Entities.QuestionAnswer> questionAnswers
                = Presenter.GetRandomQuestionAnswersList(Convert.ToInt32(questionDetails.QuestionId));

            if (questionAnswers == null) return;

            //radioButtonList.DataSource = questionAnswers;
            //radioButtonList.DataBind();

            foreach (NDMSInvestigation.Entities.QuestionAnswer questionAnswer in questionAnswers)
            {
                ListItem listItem = new ListItem();
#if DEBUG
                listItem.Text = Presenter.GetAnswerContent(questionAnswer.AnswerId) + "    " + questionAnswer.Mark.ToString();
#else
                listItem.Text = Presenter.GetAnswerContent(questionAnswer.AnswerId);
#endif

                listItem.Value = questionAnswer.Mark.ToString();
                radioButtonList.Items.Add(listItem);
            }

            //AddToDictionary(questionDetails.GroupId.Value, radioButtonList);
            //SetSession();

            //this.AddToDictionary(radioButtonList);
        }

        protected void rptQuestionGroup_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (string.CompareOrdinal(e.CommandName, "Submit") != 0) return;

            int totalMark = 0;
            int currentTestTime = Presenter.GetCurrentTestTime(new Guid(WCSF.Utility.GetUserId()));
            groupMarkDict = new Dictionary<int, int>();

            foreach (RepeaterItem repeaterItem in rptQuestionGroup.Items)
            {
                Repeater rptQuestionDetails = (Repeater)repeaterItem.FindControl("rptQuestionDetails");
                if (rptQuestionDetails == null) continue;

                HiddenField hidGroupId = (HiddenField)repeaterItem.FindControl("hidGroupId");
                if (hidGroupId == null) continue;

                int sumGroup = 0;

                foreach (RepeaterItem rptQuestionDetailsItem in rptQuestionDetails.Items)
                {
                    foreach (Control rptQuestionDetailsControl in rptQuestionDetailsItem.Controls)
                    {
                        RadioButtonList radioButtonAnswer = null;
                        if (rptQuestionDetailsControl is RadioButtonList)
                            radioButtonAnswer = rptQuestionDetailsControl as RadioButtonList;

                        if (radioButtonAnswer == null) continue;

                        if (!string.IsNullOrEmpty(radioButtonAnswer.SelectedValue))
                            sumGroup += Convert.ToInt32(radioButtonAnswer.SelectedValue);

                        sumGroup += 0;
                    }
                }

                totalMark += sumGroup;
                Presenter.InsertNewGroupMark(new Guid(WCSF.Utility.GetUserId()),
                    Convert.ToInt32(hidGroupId.Value),
                    sumGroup, 
                    currentTestTime);
            }

            Presenter.UpdateCurrentTotalMark(new Guid(WCSF.Utility.GetUserId()),
                totalMark);

            //ClearSession();

            //if (string.CompareOrdinal(e.CommandName, "Submit") != 0) return;

            //int totalMark = 0;
            //int currentTestTime = Presenter.GetCurrentTestTime(new Guid(WCSF.Utility.GetUserId()));
            //Dictionary<int, int> groupMark = new Dictionary<int, int>();

            //if (RadioButtonDict == null) return;
            //if (RadioButtonDict.Count == 0) return;

            //foreach (RadioButtonList radioButtonList in RadioButtonDict.Keys)
            //{
            //    int groupId;

            //    if (!RadioButtonDict.TryGetValue(radioButtonList, out groupId)) continue;

            //    if (radioButtonList == null) continue;

            //    if (groupMark.ContainsKey(groupId))
            //    {
            //        int mark = 0;

            //        groupMark.TryGetValue(groupId, out mark);

            //        if (mark < 0) mark = 0;
            //        if (string.IsNullOrEmpty(radioButtonList.SelectedValue)) mark += 0;
            //        else
            //        {
            //            mark += Convert.ToInt32(radioButtonList.SelectedValue);

            //            groupMark.Remove(groupId);
            //            groupMark.Add(groupId, mark);
            //        }
            //    }
            //    else
            //    {
            //        int mark = 0;

            //        if (!string.IsNullOrEmpty(radioButtonList.SelectedValue))
            //            mark += Convert.ToInt32(radioButtonList.SelectedValue);

            //        groupMark.Add(groupId, mark);
            //    }

            //    _isSubmit = true;
            //}

            //foreach (int groupId in groupMark.Keys)
            //{
            //    int mark = 0;
            //    groupMark.TryGetValue(groupId, out mark);
            //    totalMark += mark;

            //    Presenter.InsertNewGroupMark(new Guid(WCSF.Utility.GetUserId()),
            //        groupId,
            //        mark,
            //        currentTestTime);
            //}

            //Presenter.UpdateCurrentTotalMark(new Guid(WCSF.Utility.GetUserId()), totalMark);
        }

        // TODO: Forward events to the presenter and show state to the user.
        // For examples of this, see the View-Presenter (with Application Controller) QuickStart:
        //		ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.practices.wcsf.2007oct/wcsf/html/08da6294-8a4e-46b2-8bbe-ec94c06f1c30.html

    }
}

