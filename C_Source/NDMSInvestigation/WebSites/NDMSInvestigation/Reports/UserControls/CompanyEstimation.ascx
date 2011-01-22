<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyEstimation.ascx.cs"
    Inherits="NDMSInvestigation.Reports.Views.CompanyEstimation" %>
<h1>
    CompanyEstimation</h1>
<data:EntityDropDownList runat="Server" ID="ddlCompanySelector" DataSourceID="CompanyDetailsDataSource1"
    DataTextField="CompanyName" DataValueField="CompanyId" AutoPostBack="true" />
<div>
    <div>
        <asp:Label runat="Server" ID="lblCompanyRank" />
    </div>
    <div>
    </div>
</div>
<data:CompanyDetailsDataSource runat="Server" ID="CompanyDetailsDataSource1" SelectMethod="GetAll">
</data:CompanyDetailsDataSource>
