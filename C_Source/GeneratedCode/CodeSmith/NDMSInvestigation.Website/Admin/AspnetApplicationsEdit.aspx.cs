
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

public partial class AspnetApplicationsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AspnetApplicationsEdit.aspx?{0}", AspnetApplicationsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AspnetApplicationsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AspnetApplications.aspx");
		FormUtil.SetDefaultMode(FormView1, "ApplicationId");
	}
	protected void GridViewAspnetPaths1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("PathId={0}", GridViewAspnetPaths1.SelectedDataKey.Values[0]);
		Response.Redirect("AspnetPathsEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewAspnetMembership2_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("UserId={0}", GridViewAspnetMembership2.SelectedDataKey.Values[0]);
		Response.Redirect("AspnetMembershipEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewAspnetUsers3_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("UserId={0}", GridViewAspnetUsers3.SelectedDataKey.Values[0]);
		Response.Redirect("AspnetUsersEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewAspnetRoles4_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("RoleId={0}", GridViewAspnetRoles4.SelectedDataKey.Values[0]);
		Response.Redirect("AspnetRolesEdit.aspx?" + urlParams, true);		
	}	
}


