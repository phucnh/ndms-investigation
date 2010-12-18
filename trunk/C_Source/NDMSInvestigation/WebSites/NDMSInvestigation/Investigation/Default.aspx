<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NDMSInvestigation.Investigation.Views.InvestigationDefault"
    Title="Default" MasterPageFile="~/Shared/DefaultMaster.master" %>


<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        Investigation Default View</h1>
    <%--<data:QuestionGroupRepeater runat="Server" ID="QuestionGroupRepeater" DataSourceID="QuestionGroupDataSource">
        <ItemTemplate>
            <asp:TextBox runat="server" ID="dataGroupName" Text='<%# Bind("GroupName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
        </ItemTemplate>
    </data:QuestionGroupRepeater>
    <data:QuestionGroupDataSource ID="QuestionGroupDataSource" runat="server"
			SelectMethod="GetAll"
			EnablePaging="True"
			EnableSorting="True"
		>
		</data:QuestionGroupDataSource>--%>
    <%--<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataSourceID="QuestionGroupDataSource" DataKeyNames="GroupId" AllowMultiColumnSorting="false"
        DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_QuestionGroup.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="GroupDescription" HeaderText="Group Description" SortExpression="[GroupDescription]" />
            <asp:BoundField DataField="GroupName" HeaderText="Group Name" SortExpression="[GroupName]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No QuestionGroup Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnQuestionGroup" OnClientClick="javascript:location.href='QuestionGroupEdit.aspx'; return false;"
        Text="Add New"></asp:Button>--%>
    
</asp:Content>
