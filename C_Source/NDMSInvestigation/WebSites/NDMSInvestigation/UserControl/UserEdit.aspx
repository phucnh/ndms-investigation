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
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="~/UserControl/UserControls/UserFields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>User not found!</b>
            <br />
            <br />
            <%--<asp:Button ID="CreateNew" runat="server" CausesValidation="True" Text="Create"  />--%>
            <dx:ASPxButton ID="CreateNew" CausesValidation="false" runat="server" Text="Create"
                OnClick="InsertButton_Click">
            </dx:ASPxButton>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" Visible='<%# (FormView1.CurrentMode == FormViewMode.Insert)?true:false %>' />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" Visible='<%# (FormView1.CurrentMode == FormViewMode.Edit)?true:false %>' />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
            <%--<table cellpadding="0" cellspacing="0">
                <td>
                    <dx:ASPxButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Insert" Visible='<%# (FormView1.CurrentMode == FormViewMode.Insert)?true:false %>' />
                </td>
                <td>
                    <dx:ASPxButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update" Visible='<%# (FormView1.CurrentMode == FormViewMode.Edit)?true:false %>' />
                </td>
                <td>&nbsp;&nbsp;</td>
                <td>
                    <dx:ASPxButton ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel" />
                </td>
            </table>--%>
        </FooterTemplate>
    </data:MultiFormView>
    <asp:HiddenField ID="hidUserId" runat="Server" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <asp:Label ID="test" runat="Server" Text='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <data:CompanyDetailsDataSource ID="CompanyDetailsDataSource" runat="server" SelectMethod="GetByUserId"
        OnInserting="CompanyDetailsDataSource_Inserting">
        <Parameters>
            <asp:ControlParameter Name="UserId" ControlID="hidUserId" DbType="Guid" PropertyName="Value"
                runat="Server" />
            <%--<asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />--%>
        </Parameters>
    </data:CompanyDetailsDataSource>
    <br />
</asp:Content>
