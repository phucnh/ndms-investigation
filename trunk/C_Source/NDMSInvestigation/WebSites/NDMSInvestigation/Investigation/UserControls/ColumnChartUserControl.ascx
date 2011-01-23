<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColumnChartUserControl.ascx.cs"
    Inherits="NDMSInvestigation.Investigation.Views.ColumnChartUserControl" %>
<h1>
    Column Chart</h1>
<asp:HiddenField runat="Server" ID="hidUserId" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
<asp:Chart ID="ChartColumn" runat="Server" Palette="BrightPastel" BackColor="#F3DFC1"
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
        <asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="9" Name="Series1" ChartType="Column"
            BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="1">
            <EmptyPointStyle LegendText="N/A" />
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
            BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
            <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                WallWidth="0" IsClustered="False" />
            <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="C0" />
                <MajorGrid LineColor="64, 64, 64, 64" />
            </AxisY>
            <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" Format="MM-dd" />
                <MajorGrid LineColor="64, 64, 64, 64" />
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
<br />
<div>
    <asp:Label ID="lblSelectedTypeChart" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_PieChartTypeView %>"></asp:Label>
    <asp:DropDownList ID="ChartType" runat="server" AutoPostBack="True">
        <asp:ListItem Value="Column" Text="Column" Selected="True"></asp:ListItem>
        <asp:ListItem Value="Bar" Text="Bar"></asp:ListItem>
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="lblSelectedBarWidth" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_ColumnChartWidth %>"></asp:Label>
    <asp:DropDownList ID="BarWidthList" runat="server" AutoPostBack="True">
        <asp:ListItem Value="1.0">1.0</asp:ListItem>
        <asp:ListItem Value="0.8">0.8</asp:ListItem>
        <asp:ListItem Value="0.6" Selected="True">0.6</asp:ListItem>
        <asp:ListItem Value="0.4">0.4</asp:ListItem>
    </asp:DropDownList>
</div>
<div>
    <asp:Label ID="lbl3DView" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_ColumnChartView3D %>"></asp:Label>
    <asp:CheckBox ID="chkView3D" runat="Server" AutoPostBack="true" />
</div>
