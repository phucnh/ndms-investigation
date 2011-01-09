<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewResult.aspx.cs" Inherits="NDMSInvestigation.Investigation.Views.ViewResult"
    Title="ViewResult" MasterPageFile="~/Shared/DefaultMaster.master" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Import Namespace="NDMSInvestigation.Entities" %>
<%--<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit.WCSFExtensions" Namespace="AjaxControlToolkit.WCSFExtensions"
    TagPrefix="cc2" %>
    <%@ Register TagName="ChartUserControl" TagPrefix="uc1" Src="~/Investigation/UserControls/ChartUserControlBase.ascx" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        <asp:Literal ID="litHeader" runat="Server"></asp:Literal>
    </h1>
    <asp:HiddenField runat="Server" ID="hidUserId" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <hr />
    <!-- Panel hien thi ket qua phong van -->
    <asp:Panel ID="panelCompanyDetailsHeader" runat="server" CssClass="collapsePanelHeader"
        Height="30px">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; margin-left: 0px;">
                <font color="#003399">
                    <asp:Label ID="lblCompanyDetailsPanel" runat="server" Text="<%$ Resources:StringResource, ViewResult_Text_CompanyDetailsHeader %>"></asp:Label>
                </font>
            </div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="lblCompanyDetailsPanelCollapse" runat="server" ForeColor="#003399"></asp:Label>
            </div>
            <div style="float: right; vertical-align: middle;">
                <asp:ImageButton ID="imgCollaspe" OnClientClick="return false;" runat="server" ImageUrl="~/Shared/images/expand_blue.jpg" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlCompanyDetails" runat="Server">
        <div>
            <asp:GridView ID="grdResultCompany" runat="Server" AllowPaging="true" AllowSorting="true"
                DataSourceID="ResultDataSource" HorizontalAlign="Center" Height="100%" Width="100%"
                HeaderStyle-Width="100%" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center"
                AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center" RowStyle-Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:StringResource, ViewResult_Text_GroupNameHeader %>"
                        SortExpression="[Group Name]">
                        <ItemTemplate>
                            <asp:Literal runat="Server" ID="ltrGroupName" Text='<%# DataBinder.Eval(((Results)Container.DataItem).GroupIdSource,"GroupName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:StringResource, ViewResult_Text_GroupMarkHeader %>"
                        SortExpression="[GroupMark]">
                        <ItemTemplate>
                            <asp:Literal runat="Server" ID="ltrMark" Text='<%# Bind("GroupMark") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:StringResource, ViewResult_Text_TestTimesHeader %>"
                        SortExpression="[TestTimes]">
                        <ItemTemplate>
                            <asp:Literal runat="Server" ID="ltrTestTimes" Text='<%# Bind("TestTimes") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:StringResource, ViewResult_Text_CreatedDateHeader %>"
                        SortExpression="[CreatedDate]">
                        <ItemTemplate>
                            <asp:Literal runat="Server" ID="ltrCreatedDate" Text='<%# Bind("CreatedDate") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>
    <cc1:CollapsiblePanelExtender ID="collapseCompanyDetailsPanel" runat="Server" TargetControlID="pnlCompanyDetails"
        ExpandControlID="panelCompanyDetailsHeader" CollapseControlID="panelCompanyDetailsHeader"
        Collapsed="false" TextLabelID="lblCompanyDetailsPanelCollapse" ImageControlID="imgCollaspe"
        ExpandedImage="~/Shared/images/collapse_blue.jpg" CollapsedImage="~/Shared/images/expand_blue.jpg"
        SuppressPostBack="true" SkinID="collapsiblepaneldemo" ExpandedText="<%$ Resources:StringResource, Common_Text_CollapseText %>"
        CollapsedText="<%$ Resources:StringResource, Common_Text_ExpandText %>">
    </cc1:CollapsiblePanelExtender>
    <br />
    <hr />
    <data:ResultsDataSource runat="Server" ID="ResultDataSource" SelectMethod="GetByUserId"
        EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:ResultsProperty Name="AspnetUsers" />
                <data:ResultsProperty Name="QuestionGroups" />
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <asp:ControlParameter Name="UserId" DbType="String" ControlID="hidUserId" />
        </Parameters>
    </data:ResultsDataSource>
    <!-- Panel hien thi cac tuy chon nang cao -->
    <asp:Panel ID="pnlAdvancedOptions" runat="server" CssClass="collapsePanelHeader"
        Height="30px">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; margin-left: 0px;">
                <font color="#003399">
                    <asp:Label ID="lnlAdvancedOptionsHeader" runat="server" Text="<%$ Resources:StringResource, ViewResult_Text_AdvancedOptionsHeader %>"></asp:Label>
                </font>
            </div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="lblAdvancedOptionsCollapse" runat="server" ForeColor="#003399"></asp:Label>
            </div>
            <div style="float: right; vertical-align: middle;">
                <asp:ImageButton ID="imgCollaspe2" OnClientClick="return false;" runat="server" ImageUrl="~/Shared/images/expand_blue.jpg" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlAdvancedOptionsDetails" runat="Server">
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <asp:Literal ID="ltrChartType" runat="Server" Text="<%$ Resources:StringResource, ViewResult_Text_ChartType %>"></asp:Literal>
                        <asp:DropDownList ID="ddlChartType" runat="Server" 
                            onselectedindexchanged="ddlChartType_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Choose...">
                            </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <cc1:CollapsiblePanelExtender ID="collapseAdvancedOptionsPanel" runat="Server" TargetControlID="pnlAdvancedOptionsDetails"
        ExpandControlID="pnlAdvancedOptions" CollapseControlID="pnlAdvancedOptions" Collapsed="true"
        TextLabelID="lblAdvancedOptionsCollapse" ImageControlID="imgCollaspe2" ExpandedImage="~/Shared/images/collapse_blue.jpg"
        CollapsedImage="~/Shared/images/expand_blue.jpg" SuppressPostBack="true" SkinID="collapsiblepaneldemo"
        ExpandedText="<%$ Resources:StringResource, Common_Text_CollapseText %>" CollapsedText="<%$ Resources:StringResource, Common_Text_ExpandText %>">
    </cc1:CollapsiblePanelExtender>
    <br />
    <hr />
    <!-- Panel hien thi Chart -->
    <asp:Panel ID="pnlChartView" runat="server" CssClass="collapsePanelHeader" Height="30px">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; margin-left: 0px;">
                <font color="#003399">
                    <asp:Label ID="lblChartViewHeader" runat="server" Text="<%$ Resources:StringResource, ViewResult_Text_ChartViewHeader %>"></asp:Label>
                </font>
            </div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="lblChartViewCollapse" runat="server" ForeColor="#003399"></asp:Label>
            </div>
            <div style="float: right; vertical-align: middle;">
                <asp:ImageButton ID="imgCollaspe3" OnClientClick="return false;" runat="server" ImageUrl="~/Shared/images/expand_blue.jpg" />
            </div>
        </div>
    </asp:Panel>
    <%--phuc add 20110109--%>
    <uc1:ChartUserControl runat="Server" ID="ChartUserControl1" />
    <%--end phuc add 20110109--%>
    <asp:Panel ID="pnlChartViewDetails" runat="Server">
        <div style="vertical-align: middle; text-align: center;">
            <%--<asp:Chart ID="ChartResult" runat="server" Height="500px" Width="500px" ImageType="Png"
                Palette="BrightPastel" BackColor="#F3DFC1" BorderColor="181, 64, 1" BorderDashStyle="Solid"
                BackGradientStyle="TopBottom" BorderWidth="2">
                <Titles>
                    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                        Text="Your Company Result" ForeColor="26, 59, 105">
                    </asp:Title>
                </Titles>--%>
                <%--<Legends>
                <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                    Alignment="Far">
                    <Position Y="74.08253" Height="14.23021" Width="19.34047" X="74.73474"></Position>
                </asp:Legend>
            </Legends>--%>
                <%--<BorderSkin SkinStyle="Emboss"></BorderSkin>
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
            </asp:Chart>--%>
        </div>
    </asp:Panel>
    <cc1:CollapsiblePanelExtender ID="collapseChartViewPanel" runat="Server" TargetControlID="pnlChartViewDetails"
        ExpandControlID="pnlChartView" CollapseControlID="pnlChartView" Collapsed="true"
        TextLabelID="lblChartViewCollapse" ImageControlID="imgCollaspe3" ExpandedImage="~/Shared/images/collapse_blue.jpg"
        CollapsedImage="~/Shared/images/expand_blue.jpg" SuppressPostBack="true" SkinID="collapsiblepaneldemo"
        ExpandedText="<%$ Resources:StringResource, Common_Text_CollapseText %>" CollapsedText="<%$ Resources:StringResource, Common_Text_ExpandText %>">
    </cc1:CollapsiblePanelExtender>
</asp:Content>
