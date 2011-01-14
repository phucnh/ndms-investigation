<%@ Page Language="C#" MasterPageFile="~/Shared/DefaultMaster.master" %>

<script runat="server">
    private void Page_Load()
    {
        Login1.Focus();
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <asp:Login ID="Login1" runat="server" CreateUserText="Register" CreateUserUrl="~/UserControl/Register.aspx" DestinationPageUrl="~/UserControl/UserEdit.aspx">
    </asp:Login>
    <asp:HyperLink runat="Server" Text="Forgot your password?" NavigateUrl="~/Administrator/authenticated/forgotpwd.aspx" />
</asp:Content>
