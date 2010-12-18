<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetPersonalizationAllUsersEdit.aspx.cs" Inherits="AspnetPersonalizationAllUsersEdit" Title="AspnetPersonalizationAllUsers Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Personalization All Users - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PathId" runat="server" DataSourceID="AspnetPersonalizationAllUsersDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetPersonalizationAllUsersFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetPersonalizationAllUsersFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AspnetPersonalizationAllUsers not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AspnetPersonalizationAllUsersDataSource ID="AspnetPersonalizationAllUsersDataSource" runat="server"
			SelectMethod="GetByPathId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PathId" QueryStringField="PathId" Type="String" />

			</Parameters>
		</data:AspnetPersonalizationAllUsersDataSource>
		
		<br />

		

</asp:Content>

