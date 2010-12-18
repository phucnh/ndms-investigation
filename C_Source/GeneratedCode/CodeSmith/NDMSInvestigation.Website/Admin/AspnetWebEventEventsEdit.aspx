<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetWebEventEventsEdit.aspx.cs" Inherits="AspnetWebEventEventsEdit" Title="AspnetWebEventEvents Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Web Event Events - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="EventId" runat="server" DataSourceID="AspnetWebEventEventsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetWebEventEventsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetWebEventEventsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AspnetWebEventEvents not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AspnetWebEventEventsDataSource ID="AspnetWebEventEventsDataSource" runat="server"
			SelectMethod="GetByEventId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="EventId" QueryStringField="EventId" Type="String" />

			</Parameters>
		</data:AspnetWebEventEventsDataSource>
		
		<br />

		

</asp:Content>

