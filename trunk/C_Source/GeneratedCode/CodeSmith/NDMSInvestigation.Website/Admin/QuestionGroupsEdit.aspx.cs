
#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDMSInvestigation.Web.UI;
#endregion

public partial class QuestionGroupsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "QuestionGroupsEdit.aspx?{0}", QuestionGroupsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "QuestionGroupsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "QuestionGroups.aspx");
		FormUtil.SetDefaultMode(FormView1, "GroupId");
	}
	protected void GridViewQuestionDetails1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("QuestionId={0}", GridViewQuestionDetails1.SelectedDataKey.Values[0]);
		Response.Redirect("QuestionDetailsEdit.aspx?" + urlParams, true);		
	}	
}


