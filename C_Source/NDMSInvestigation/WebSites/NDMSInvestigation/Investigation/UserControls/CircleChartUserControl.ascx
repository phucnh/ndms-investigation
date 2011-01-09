<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CircleChartUserControl.ascx.cs" Inherits="NDMSInvestigation.Investigation.Views.CircleChartUserControl" %>

<h1>CircleChartUserControl</h1>


<asp:Chart ID="ChartCircle" runat="server">
    <Series>
        <asp:Series Name="Series1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
