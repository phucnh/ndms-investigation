<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NDMSInvestigation.Reports.Views.ReportsDefault"
    Title="Default" MasterPageFile="~/Shared/DefaultMaster.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="NumberOfCompanies" Src="~/Reports/UserControls/NumberOfCompanies.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CompanyEstimation" Src="~/Reports/UserControls/CompanyEstimation.ascx" %>
<%@ Register TagPrefix="uc1" TagName="TopMarkCompanies" Src="~/Reports/UserControls/TopMarkCompanies.ascx" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Reports Default View</h1>
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server">
            <cc1:TabPanel ID="TabNumberOfCompanies" runat="Server" HeaderText='<%$ Resources:StringResource, Reports_Text_OverviewTab %>'>
                <ContentTemplate>
                    <uc1:NumberOfCompanies runat="Server" ID="NumberOfCompaniesUserControl" NumberOfYears="3" />
                    <br />
                    
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabCompanyEstimation" runat="Server" HeaderText='<%$ Resources:StringResource, Reports_Text_DetailTab %>'>
                <ContentTemplate>
                    <uc1:CompanyEstimation runat="Server" ID="CompanyEstimationUserControl" />
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
        <uc1:TopMarkCompanies runat="Server" ID="TopMarkCompaniesUserControl" />
        <%--<telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPageReports"
            SelectedIndex="0" Align="Justify" ReorderTabsOnSelect="true">
            <Tabs>
                <telerik:RadTab Text='<%$ Resources:StringResource, Reports_Text_OverviewTab %>' />
                <telerik:RadTab Text='<%$ Resources:StringResource, Reports_Text_DetailTab %>' />
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPageReports" runat="Server" CssClass="reports_pageView" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView1" runat="server">
                <uc1:NumberOfCompanies runat="Server" ID="NumberOfCompanies2" NumberOfYears="3" />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server">
                <uc1:CompanyEstimation runat="Server" ID="CompanyEstimation2" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>--%>
    </div>
</asp:Content>
