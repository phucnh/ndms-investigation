<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CircleChartUserControl.ascx.cs"
    Inherits="NDMSInvestigation.Investigation.Views.CircleChartUserControl" %>
<h1>
    Circle Chart
</h1>
<asp:HiddenField runat="Server" ID="hidUserId" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
<asp:Chart ID="ChartCircle" runat="server" Height="500px" Width="500px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
    ImageType="Png" Palette="BrightPastel" BackColor="#F3DFC1" BorderColor="181, 64, 1"
    BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2">
    <Titles>
        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
            Text="" ForeColor="26, 59, 105">
        </asp:Title>
    </Titles>
    <Legends>
        <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
            Alignment="Far">
            <Position Y="74.08253" Height="14.23021" Width="19.34047" X="74.73474"></Position>
        </asp:Legend>
    </Legends>
    <BorderSkin SkinStyle="Emboss"></BorderSkin>
    <Series>
        <asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="9" Name="Series1" ChartType="Radar"
            BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="1">
            <EmptyPointStyle LegendText="N/A" />
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
            BackColor="OldLace" ShadowColor="Transparent">
            <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                WallWidth="0" IsClustered="False" />
            <Position Y="15" Height="78" Width="88" X="5"></Position>
            <AxisY LineColor="64, 64, 64, 64">
                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                <MajorGrid LineColor="64, 64, 64, 64" />
                <MajorTickMark Size="0.6" />
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
    <asp:Label ID="lblRadarType" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_RadarChartTypeView %>"></asp:Label>
    <asp:DropDownList ID="ddlRadarType" runat="Server" AutoPostBack="true">
        <asp:ListItem Value="0" Text="Area">
        </asp:ListItem>
        <asp:ListItem Value="1" Text="Line" Selected="True">
        </asp:ListItem>
        <asp:ListItem Value="2" Text="Marker">
        </asp:ListItem>
    </asp:DropDownList>
</div>
