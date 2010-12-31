<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master"
    AutoEventWireup="true" Inherits="Result" Title="Result List" CodeBehind="Result.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="ResultDataSource" DataKeyNames="UserId, GroupId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_Result.xls">
        <Columns>
            <%--<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				--%>
            <data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}"
                DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
            <data:HyperLinkField HeaderText="Group Id" DataNavigateUrlFormatString="QuestionGroupEdit.aspx?GroupId={0}"
                DataNavigateUrlFields="GroupId" DataContainer="GroupIdSource" DataTextField="GroupName" />
            <asp:BoundField DataField="GroupMark" HeaderText="Group Mark" SortExpression="[GroupMark]" />
            <asp:BoundField DataField="UpdateDay" DataFormatString="{0:d}" HtmlEncode="False"
                HeaderText="Update Day" SortExpression="[UpdateDay]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Result Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <%--<asp:Button runat="server" ID="btnResult" OnClientClick="javascript:location.href='ResultEdit.aspx'; return false;" Text="Add New"></asp:Button>--%>
    <data:ResultsDataSource ID="ResultDataSource" runat="server" SelectMethod="GetPaged"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:ResultsProperty Name="AspnetUsers" />
                <data:ResultsProperty Name="QuestionGroups" />
            </Types>
        </DeepLoadProperties>
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex"
                Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize"
                Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:ResultsDataSource>
</asp:Content>
