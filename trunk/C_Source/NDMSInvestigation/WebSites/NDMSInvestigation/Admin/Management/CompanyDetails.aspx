<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master"
    AutoEventWireup="true" CodeFile="CompanyDetails.aspx.cs" Inherits="CompanyDetails"
    Title="CompanyDetails List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="CompanyDetailsDataSource" DataKeyNames="UserId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_User.xls">
        <Columns>
            <%--<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				--%>
            <asp:BoundField DataField="Director" HeaderText="Director" SortExpression="[Director]" />
            <asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" SortExpression="[EmployeeNumber]" />
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]" />
            <asp:BoundField DataField="District" HeaderText="District" SortExpression="[District]" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />
            <%--<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />--%>
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />
            <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="[Fax]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No User Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <%--<asp:Button runat="server" ID="btnUser" OnClientClick="javascript:location.href='UserEdit.aspx'; return false;" Text="Add New"></asp:Button>--%>
    <data:CompanyDetailsDataSource ID="CompanyDetailsDataSource" runat="server" SelectMethod="GetPaged"
        EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
            <Types>
                <data:CompanyDetailsProperty Name="AspnetUsers" />
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
    </data:CompanyDetailsDataSource>
</asp:Content>
