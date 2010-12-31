using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDMSInvestigation.Web.UI;

public partial class CompanyDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterUpdate(GridView1, "CompanyDetails.aspx?page={0}");
        FormUtil.SetPageIndex(GridView1, "page");
        FormUtil.SetDefaultButton((Button)GridViewSearchPanel1.FindControl("cmdSearch"));
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("CompanyId={0}", GridView1.SelectedDataKey.Values[0]);
        Response.Redirect("CompanyDetailsEdit.aspx?" + urlParams, true);
    }

}
