
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetUsersInRoles.aspx.cs" Inherits="AspnetUsersInRoles" Title="AspnetUsersInRoles List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Users In Roles List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetUsersInRolesDataSource"
				DataKeyNames="UserId, RoleId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetUsersInRoles.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<data:HyperLinkField HeaderText="Role Id" DataNavigateUrlFormatString="AspnetRolesEdit.aspx?RoleId={0}" DataNavigateUrlFields="RoleId" DataContainer="RoleIdSource" DataTextField="RoleName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetUsersInRoles Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetUsersInRoles" OnClientClick="javascript:location.href='AspnetUsersInRolesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetUsersInRolesDataSource ID="AspnetUsersInRolesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetUsersInRolesProperty Name="AspnetRoles"/> 
					<data:AspnetUsersInRolesProperty Name="AspnetUsers"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetUsersInRolesDataSource>
	    		
</asp:Content>



