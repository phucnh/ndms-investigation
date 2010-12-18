
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetUsers.aspx.cs" Inherits="AspnetUsers" Title="AspnetUsers List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Users List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetUsersDataSource"
				DataKeyNames="UserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetUsers.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MobileAlias" HeaderText="Mobile Alias" SortExpression="[MobileAlias]"  />
				<data:BoundRadioButtonField DataField="IsAnonymous" HeaderText="Is Anonymous" SortExpression="[IsAnonymous]"  />
				<asp:BoundField DataField="LastActivityDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Activity Date" SortExpression="[LastActivityDate]"  />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]"  />
				<asp:BoundField DataField="LoweredUserName" HeaderText="Lowered User Name" SortExpression="[LoweredUserName]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetUsers Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetUsers" OnClientClick="javascript:location.href='AspnetUsersEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetUsersDataSource ID="AspnetUsersDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetUsersProperty Name="AspnetApplications"/> 
					<%--<data:AspnetUsersProperty Name="AspnetMembership" />--%>
					<%--<data:AspnetUsersProperty Name="AspnetProfile" />--%>
					<%--<data:AspnetUsersProperty Name="GroupIdQuestionGroupCollection_From_Result" />--%>
					<%--<data:AspnetUsersProperty Name="AspnetPersonalizationPerUserCollection" />--%>
					<%--<data:AspnetUsersProperty Name="AspnetUsersInRolesCollection" />--%>
					<%--<data:AspnetUsersProperty Name="User" />--%>
					<%--<data:AspnetUsersProperty Name="ResultCollection" />--%>
					<%--<data:AspnetUsersProperty Name="RoleIdAspnetRolesCollection_From_AspnetUsersInRoles" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetUsersDataSource>
	    		
</asp:Content>



