
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetPersonalizationAllUsers.aspx.cs" Inherits="AspnetPersonalizationAllUsers" Title="AspnetPersonalizationAllUsers List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Personalization All Users List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetPersonalizationAllUsersDataSource"
				DataKeyNames="PathId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetPersonalizationAllUsers.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="LastUpdatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Updated Date" SortExpression="[LastUpdatedDate]"  />
				<asp:BoundField DataField="PageSettings" HeaderText="Page Settings" SortExpression="[PageSettings]"  />
				<data:HyperLinkField HeaderText="Path Id" DataNavigateUrlFormatString="AspnetPathsEdit.aspx?PathId={0}" DataNavigateUrlFields="PathId" DataContainer="PathIdSource" DataTextField="Path" />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetPersonalizationAllUsers Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetPersonalizationAllUsers" OnClientClick="javascript:location.href='AspnetPersonalizationAllUsersEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetPersonalizationAllUsersDataSource ID="AspnetPersonalizationAllUsersDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetPersonalizationAllUsersProperty Name="AspnetPaths"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetPersonalizationAllUsersDataSource>
	    		
</asp:Content>



