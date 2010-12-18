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

public partial class AspnetPersonalizationAllUsersEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AspnetPersonalizationAllUsersEdit.aspx?{0}", AspnetPersonalizationAllUsersDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AspnetPersonalizationAllUsersEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AspnetPersonalizationAllUsers.aspx");
		FormUtil.SetDefaultMode(FormView1, "PathId");
	}
}


