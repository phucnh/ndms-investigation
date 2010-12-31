
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetPersonalizationPerUser.aspx.cs" Inherits="AspnetPersonalizationPerUser" Title="AspnetPersonalizationPerUser List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Personalization Per User List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetPersonalizationPerUserDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetPersonalizationPerUser.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[Id]" ReadOnly="True" />
				<data:HyperLinkField HeaderText="Path Id" DataNavigateUrlFormatString="AspnetPathsEdit.aspx?PathId={0}" DataNavigateUrlFields="PathId" DataContainer="PathIdSource" DataTextField="Path" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="PageSettings" HeaderText="Page Settings" SortExpression="[PageSettings]"  />
				<asp:BoundField DataField="LastUpdatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Updated Date" SortExpression="[LastUpdatedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetPersonalizationPerUser Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetPersonalizationPerUser" OnClientClick="javascript:location.href='AspnetPersonalizationPerUserEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetPersonalizationPerUserDataSource ID="AspnetPersonalizationPerUserDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetPersonalizationPerUserProperty Name="AspnetPaths"/> 
					<data:AspnetPersonalizationPerUserProperty Name="AspnetUsers"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetPersonalizationPerUserDataSource>
	    		
</asp:Content>



