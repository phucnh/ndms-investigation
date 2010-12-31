
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

public partial class TraceChangeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "TraceChangeEdit.aspx?{0}", TraceChangeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "TraceChangeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "TraceChange.aspx");
		FormUtil.SetDefaultMode(FormView1, "TraceId");
	}
	protected void GridViewCompanyDetails1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CompanyId={0}", GridViewCompanyDetails1.SelectedDataKey.Values[0]);
		Response.Redirect("CompanyDetailsEdit.aspx?" + urlParams, true);		
	}	
}


