<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master" AutoEventWireup="true" Inherits="ResultEdit" Title="Result Edit" Codebehind="ResultEdit.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="UserId, GroupId" runat="server" DataSourceID="ResultDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/Management/UserControls/ResultFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/Management/UserControls/ResultFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Result not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ResultDataSource ID="ResultDataSource" runat="server"
			SelectMethod="GetByUserIdGroupId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
<asp:QueryStringParameter Name="GroupId" QueryStringField="GroupId" Type="String" />

			</Parameters>
		</data:ResultDataSource>
		
		<br />


</asp:Content>

