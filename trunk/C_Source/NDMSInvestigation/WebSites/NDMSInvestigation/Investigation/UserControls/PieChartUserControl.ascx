<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PieChartUserControl.ascx.cs"
    Inherits="NDMSInvestigation.Investigation.Views.PieChartUserControl" %>
<h1>
    Pie Chart</h1>
<asp:HiddenField runat="Server" ID="hidUserId" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
<asp:Chart ID="ChartPie" runat="Server" Palette="BrightPastel" BackColor="WhiteSmoke"
    Height="296px" Width="412px" BorderDashStyle="Solid" BackSecondaryColor="White"
    BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
    <Titles>
        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
            Text="Pie Chart" Name="Title1" ForeColor="26, 59, 105">
        </asp:Title>
    </Titles>
    <Legends>
        <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold"
            IsTextAutoFit="False" Name="Default" LegendStyle="Row">
        </asp:Legend>
    </Legends>
    <BorderSkin SkinStyle="Emboss"></BorderSkin>
    <Series>
        <asp:Series Name="Series1" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
            BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
            <Area3DStyle Rotation="0" />
            <AxisY LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid LineColor="64, 64, 64, 64" />
            </AxisY>
            <AxisX LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid LineColor="64, 64, 64, 64" />
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
<br />
<div>
    <asp:Label ID="lblPieChartType" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_PieChartTypeView %>"></asp:Label>
    <asp:DropDownList ID="ddlPieChartType" runat="Server" AutoPostBack="true">
        <asp:ListItem Value="0" Text="Doughnut"></asp:ListItem>
        <asp:ListItem Value="1" Text="Pie" Selected="True"></asp:ListItem>
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="lblShowLegend" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_PieChartLegendShow %>"></asp:Label>
    <asp:DropDownList ID="ddlShowLegend" runat="Server" AutoPostBack="true">
        <asp:ListItem Value="Inside" Text="Bên trong" Selected="True"></asp:ListItem>
        <asp:ListItem Value="Outside" Text="Bên ngoài"></asp:ListItem>
        <asp:ListItem Value="Disabled" Text="Ẩn"></asp:ListItem>
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="lbl3DView" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_ColumnChartView3D %>"></asp:Label>
    <asp:CheckBox ID="chk3DView" runat="Server" AutoPostBack="true" />
</div>
