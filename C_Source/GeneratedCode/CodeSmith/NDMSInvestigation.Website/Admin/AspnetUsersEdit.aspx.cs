﻿
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

public partial class AspnetUsersEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AspnetUsersEdit.aspx?{0}", AspnetUsersDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AspnetUsersEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AspnetUsers.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserId");
	}
	protected void GridViewAspnetPersonalizationPerUser1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAspnetPersonalizationPerUser1.SelectedDataKey.Values[0]);
		Response.Redirect("AspnetPersonalizationPerUserEdit.aspx?" + urlParams, true);		
	}	
}


