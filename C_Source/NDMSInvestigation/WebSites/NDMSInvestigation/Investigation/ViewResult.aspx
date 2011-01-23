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
<%@ Register TagName="CircleChartUserControl" TagPrefix="uc1" Src="~/Investigation/UserControls/CircleChartUserControl.ascx" %>
<%@ Register TagName="ColumnChartUserControl" TagPrefix="uc1" Src="~/Investigation/UserControls/ColumnChartUserControl.ascx" %>
<%@ Register TagName="PieChartUserControl" TagPrefix="uc1" Src="~/Investigation/UserControls/PieChartUserControl.ascx" %>
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
                        <asp:DropDownList ID="ddlChartType" runat="Server" AutoPostBack="true" NDMSChartType="true"
                            OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="<%$ Resources:StringResource, Common_Text_ChooseType %>">
                            </asp:ListItem>
                            <asp:ListItem Value="1" Text="Circle Chart">
                            </asp:ListItem>
                            <asp:ListItem Value="2" Text="Column Chart"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Pie Chart"></asp:ListItem>
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
    <asp:Panel ID="pnlChartViewDetails" runat="Server">
        <asp:UpdatePanel ID="updatePanelChartControl" runat="Server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="vertical-align: middle; text-align: center;">
                    <%--<uc1:ChartUserControl runat="Server" ID="ChartUserControl1" />--%>
                    <asp:Panel ID="pnlCircleChart" runat="Server" NDMSCircleChartControl="true">
                        <uc1:CircleChartUserControl ID="CircleChartUserControl" runat="Server" Visible="false" />
                    </asp:Panel>
                    <asp:Panel ID="pnlColumnChart" runat="Server" NDMSColumnChartControl="true">
                        <uc1:ColumnChartUserControl ID="ColumnChartUserControl" runat="Server" Visible="false" />
                    </asp:Panel>
                    <asp:Panel ID="pnlPieChart" runat="Server" NDMSPieChartControl="true">
                        <uc1:PieChartUserControl ID="PieChartUserControl" runat="Server" Visible="false" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlChartType" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <cc1:CollapsiblePanelExtender ID="collapseChartViewPanel" runat="Server" TargetControlID="pnlChartViewDetails"
        ExpandControlID="pnlChartView" CollapseControlID="pnlChartView" Collapsed="false"
        TextLabelID="lblChartViewCollapse" ImageControlID="imgCollaspe3" ExpandedImage="~/Shared/images/collapse_blue.jpg"
        CollapsedImage="~/Shared/images/expand_blue.jpg" SuppressPostBack="true" SkinID="collapsiblepaneldemo"
        ExpandedText="<%$ Resources:StringResource, Common_Text_CollapseText %>" CollapsedText="<%$ Resources:StringResource, Common_Text_ExpandText %>">
    </cc1:CollapsiblePanelExtender>
</asp:Content>
