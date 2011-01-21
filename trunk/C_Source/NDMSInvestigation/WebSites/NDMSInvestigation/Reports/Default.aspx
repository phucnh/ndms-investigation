<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NDMSInvestigation.Reports.Views.ReportsDefault"
    Title="Default" MasterPageFile="~/Shared/DefaultMaster.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="NumberOfCompanies" Src="~/Reports/UserControls/NumberOfCompanies.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CompanyEstimation" Src="~/Reports/UserControls/CompanyEstimation.ascx" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Reports Default View</h1>
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server">
            <cc1:TabPanel Id="TabNumberOfCompanies" runat="Server" HeaderText="">
                <ContentTemplate>
                    <uc1:NumberOfCompanies runat="Server" ID="NumberOfCompaniesUserControl" NumberOfYears="3" />
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabCompanyEstimation" runat="Server" HeaderText="">
                <ContentTemplate>
                    <uc1:CompanyEstimation runat="Server" ID="CompanyEstimationUserControl" />
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel1" runat="Server" HeaderText="">
                <ContentTemplate>
                    <uc1:CompanyEstimation runat="Server" ID="CompanyEstimation1" />
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
</asp:Content>
