
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

public partial class AnswerDetailsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AnswerDetailsEdit.aspx?{0}", AnswerDetailsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AnswerDetailsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AnswerDetails.aspx");
		FormUtil.SetDefaultMode(FormView1, "AnswerId");
	}
	protected void GridViewQuestionAnswer1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("QuestionAnswerId={0}", GridViewQuestionAnswer1.SelectedDataKey.Values[0]);
		Response.Redirect("QuestionAnswerEdit.aspx?" + urlParams, true);		
	}	
}


