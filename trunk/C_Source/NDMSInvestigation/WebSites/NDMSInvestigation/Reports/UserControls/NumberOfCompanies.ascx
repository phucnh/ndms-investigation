<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NumberOfCompanies.ascx.cs"
    Inherits="NDMSInvestigation.Reports.Views.NumberOfCompanies" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<h1>
    NumberOfCompanies</h1>
<div>
    <div>
        <asp:Literal runat="Server" ID="TotalCompaniesLiteral" />
    </div>
    <div>
        <asp:Label runat="Server" ID="lblNumberOfYearsLast" Text='<%$ Resources:StringResource, Reports_Text_NumberOfYearsLast %>' /></div>
    <div>
        <asp:DropDownList ID="DropDownListYears" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListYears_SelectedIndexChanged">
            <asp:ListItem Enabled="true" Selected="True" Value="2" />
            <asp:ListItem Enabled="true" Selected="False" Value="3" />
            <asp:ListItem Enabled="true" Selected="False" Value="4" />
            <asp:ListItem Enabled="true" Selected="False" Value="5" />
            <asp:ListItem Enabled="true" Selected="False" Value="6" />
            <asp:ListItem Enabled="true" Selected="False" Value="7" />
            <asp:ListItem Enabled="true" Selected="False" Value="8" />
        </asp:DropDownList>
    </div>
</div>
<asp:Chart ID="ChartReports" runat="server">
    <Series>
        <asp:Series Name="Series1" ChartType="Line" IsValueShownAsLabel="true">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
