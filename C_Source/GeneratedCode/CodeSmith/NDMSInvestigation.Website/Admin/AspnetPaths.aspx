
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetPaths.aspx.cs" Inherits="AspnetPaths" Title="AspnetPaths List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Paths List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetPathsDataSource"
				DataKeyNames="PathId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetPaths.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="LoweredPath" HeaderText="Lowered Path" SortExpression="[LoweredPath]"  />
				<asp:BoundField DataField="Path" HeaderText="Path" SortExpression="[Path]"  />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetPaths Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetPaths" OnClientClick="javascript:location.href='AspnetPathsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetPathsDataSource ID="AspnetPathsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetPathsProperty Name="AspnetApplications"/> 
					<%--<data:AspnetPathsProperty Name="AspnetPersonalizationPerUserCollection" />--%>
					<%--<data:AspnetPathsProperty Name="AspnetPersonalizationAllUsers" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetPathsDataSource>
	    		
</asp:Content>



