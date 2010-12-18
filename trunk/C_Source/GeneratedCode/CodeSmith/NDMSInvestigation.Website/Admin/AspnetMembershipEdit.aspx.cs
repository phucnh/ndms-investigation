
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

public partial class AspnetMembershipEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AspnetMembershipEdit.aspx?{0}", AspnetMembershipDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AspnetMembershipEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AspnetMembership.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserId");
	}
}


