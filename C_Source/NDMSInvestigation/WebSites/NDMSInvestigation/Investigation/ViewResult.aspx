<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewResult.aspx.cs" Inherits="NDMSInvestigation.Investigation.Views.ViewResult"
    Title="ViewResult" MasterPageFile="~/Shared/DefaultMaster.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Import Namespace="NDMSInvestigation.Entities" %>
<%--<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        ViewResult</h1>
    <asp:HiddenField runat="Server" ID="hidUserId" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <asp:Repeater runat="Server" ID="rptResultDataSource" DataSourceID="ResultDataSource"
        DataMember="GroupId">
        <ItemTemplate>
            <div>
                <div style="width: 10%; float: left; clip: rect(auto, 5%, auto, 5%); text-align: right;">
                    <asp:Literal runat="Server" ID="ltrGroupName" Text='<%# DataBinder.Eval(((Result)Container.DataItem).GroupIdSource,"GroupName") %>' />&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <div style="width: 90%; float: right; clip: rect(auto, 5%, auto, 5%)">
                    <asp:Literal runat="Server" ID="ltrMark" Text='<%# Bind("GroupMark") %>' />
                </div>
                <br />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <br />
    <data:ResultDataSource runat="Server" ID="ResultDataSource" SelectMethod="GetByUserId"
        EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:ResultProperty Name="AspnetUsers" />
                <data:ResultProperty Name="QuestionGroup" />
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <asp:ControlParameter Name="UserId" DbType="String" ControlID="hidUserId" />
        </Parameters>
    </data:ResultDataSource>
    <div style="vertical-align: middle; text-align: center;">
        <asp:Chart ID="ChartResult" runat="server" Height="500px" Width="500px" ImageType="Png"
            Palette="BrightPastel" BackColor="#F3DFC1" BorderColor="181, 64, 1" BorderDashStyle="Solid"
            BackGradientStyle="TopBottom" BorderWidth="2">
            <Titles>
                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                    Text="Your Company Result" ForeColor="26, 59, 105">
                </asp:Title>
            </Titles>
            <%--<Legends>
                <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                    Alignment="Far">
                    <Position Y="74.08253" Height="14.23021" Width="19.34047" X="74.73474"></Position>
                </asp:Legend>
            </Legends>--%>
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
    </div>
</asp:Content>
