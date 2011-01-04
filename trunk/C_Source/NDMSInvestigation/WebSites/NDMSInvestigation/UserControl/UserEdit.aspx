<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="NDMSInvestigation.UserControl.Views.UserEdit"
    Title="UserEdit" MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        UserEdit</h1>
    <data:MultiFormView ID="FormView1" DataKeyNames="CompanyId" runat="server" DefaultMode="Edit"
        DataSourceID="CompanyDetailsDataSource" OnItemCommand="FormView1_ItemCommand">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/UserControl/UserControls/UserFields.ascx" />
        </EditItemTemplatePaths>
        <%--<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/UserControl/UserControls/UserFields.ascx" />
			</InsertItemTemplatePaths>--%>
        <EmptyDataTemplate>
            <b>User not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <%--<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />--%>
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
        </FooterTemplate>
    </data:MultiFormView>
    <asp:HiddenField ID="hidUserId" runat="Server" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <asp:Label ID="test" runat="Server" Text='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <data:CompanyDetailsDataSource ID="CompanyDetailsDataSource" runat="server" SelectMethod="GetByUserId">
        <Parameters>
            <asp:ControlParameter Name="UserId" ControlID="hidUserId" DbType="Guid" PropertyName="Value"
                runat="Server" />
            <%--<asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />--%>
        </Parameters>
    </data:CompanyDetailsDataSource>
    <br />
</asp:Content>
