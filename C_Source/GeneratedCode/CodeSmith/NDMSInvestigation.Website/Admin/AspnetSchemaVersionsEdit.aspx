<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetSchemaVersionsEdit.aspx.cs" Inherits="AspnetSchemaVersionsEdit" Title="AspnetSchemaVersions Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Schema Versions - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Feature, CompatibleSchemaVersion" runat="server" DataSourceID="AspnetSchemaVersionsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetSchemaVersionsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetSchemaVersionsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AspnetSchemaVersions not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AspnetSchemaVersionsDataSource ID="AspnetSchemaVersionsDataSource" runat="server"
			SelectMethod="GetByFeatureCompatibleSchemaVersion"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Feature" QueryStringField="Feature" Type="String" />
<asp:QueryStringParameter Name="CompatibleSchemaVersion" QueryStringField="CompatibleSchemaVersion" Type="String" />

			</Parameters>
		</data:AspnetSchemaVersionsDataSource>
		
		<br />


</asp:Content>

