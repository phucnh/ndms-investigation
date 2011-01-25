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
            <asp:ListItem Enabled="true" Selected="False" Value="2" />
            <asp:ListItem Enabled="true" Selected="False" Value="3" />
            <asp:ListItem Enabled="true" Selected="False" Value="4" />
            <asp:ListItem Enabled="true" Selected="False" Value="5" />
            <asp:ListItem Enabled="true" Selected="False" Value="6" />
            <asp:ListItem Enabled="true" Selected="False" Value="7" />
            <asp:ListItem Enabled="true" Selected="False" Value="8" />
        </asp:DropDownList>
    </div>
</div>
<asp:Chart ID="ChartReports" runat="Server" Palette="BrightPastel" BackColor="#F3DFC1"
    Width="412px" Height="296px" BorderDashStyle="Solid" BackGradientStyle="TopBottom"
    BorderWidth="2" BorderColor="181, 64, 1" ImageType="Png">
    <Titles>
        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
            Text="Column Chart" Name="Title1" ForeColor="26, 59, 105">
        </asp:Title>
    </Titles>
    <Legends>
        <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
            Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False"
            Name="Default">
        </asp:Legend>
    </Legends>
    <BorderSkin SkinStyle="Emboss"></BorderSkin>
    <Series>
        <asp:Series Name="Series1" ChartType="Line" IsValueShownAsLabel="true">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
