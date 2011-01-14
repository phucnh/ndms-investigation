<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="NDMSInvestigation.Reports.Views.ReportsDefault"
    Title="Default" MasterPageFile="~/Shared/DefaultMaster.master" %>
    <%@ Register TagPrefix="uc1" TagName="NumberOfCompanies" Src="~/Reports/UserControls/NumberOfCompanies.ascx"%>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
		<h1>Reports Default View</h1>
		<div>
		<uc1:NumberOfCompanies runat="Server" id="NumberOfCompaniesUserControl" NumberOfYears="1" />
		</div>
</asp:Content>

