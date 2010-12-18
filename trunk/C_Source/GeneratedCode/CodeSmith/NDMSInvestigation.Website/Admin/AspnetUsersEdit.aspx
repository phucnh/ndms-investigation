<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetUsersEdit.aspx.cs" Inherits="AspnetUsersEdit" Title="AspnetUsers Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Users - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="UserId" runat="server" DataSourceID="AspnetUsersDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetUsersFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetUsersFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AspnetUsers not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AspnetUsersDataSource ID="AspnetUsersDataSource" runat="server"
			SelectMethod="GetByUserId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />

			</Parameters>
		</data:AspnetUsersDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewAspnetPersonalizationPerUser1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAspnetPersonalizationPerUser1_SelectedIndexChanged"			 			 
			DataSourceID="AspnetPersonalizationPerUserDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AspnetPersonalizationPerUser.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Path Id" DataNavigateUrlFormatString="AspnetPathsEdit.aspx?PathId={0}" DataNavigateUrlFields="PathId" DataContainer="PathIdSource" DataTextField="Path" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="PageSettings" HeaderText="Page Settings" SortExpression="[PageSettings]" />				
				<asp:BoundField DataField="LastUpdatedDate" HeaderText="Last Updated Date" SortExpression="[LastUpdatedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Aspnet Personalization Per User Found! </b>
				<asp:HyperLink runat="server" ID="hypAspnetPersonalizationPerUser" NavigateUrl="~/admin/AspnetPersonalizationPerUserEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AspnetPersonalizationPerUserDataSource ID="AspnetPersonalizationPerUserDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetPersonalizationPerUserProperty Name="AspnetPaths"/> 
					<data:AspnetPersonalizationPerUserProperty Name="AspnetUsers"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AspnetPersonalizationPerUserFilter  Column="UserId" QueryStringField="UserId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AspnetPersonalizationPerUserDataSource>		
		
		<br />
		

</asp:Content>

