
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetRoles.aspx.cs" Inherits="AspnetRoles" Title="AspnetRoles List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Roles List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetRolesDataSource"
				DataKeyNames="RoleId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetRoles.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="LoweredRoleName" HeaderText="Lowered Role Name" SortExpression="[LoweredRoleName]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="[RoleName]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetRoles Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetRoles" OnClientClick="javascript:location.href='AspnetRolesEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetRolesDataSource ID="AspnetRolesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetRolesProperty Name="AspnetApplications"/> 
					<%--<data:AspnetRolesProperty Name="AspnetUsersInRolesCollection" />--%>
					<%--<data:AspnetRolesProperty Name="UserIdAspnetUsersCollection_From_AspnetUsersInRoles" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetRolesDataSource>
	    		
</asp:Content>



