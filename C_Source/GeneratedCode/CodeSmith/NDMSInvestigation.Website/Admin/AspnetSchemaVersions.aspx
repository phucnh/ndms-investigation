
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetSchemaVersions.aspx.cs" Inherits="AspnetSchemaVersions" Title="AspnetSchemaVersions List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Schema Versions List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetSchemaVersionsDataSource"
				DataKeyNames="Feature, CompatibleSchemaVersion"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetSchemaVersions.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Feature" HeaderText="Feature" SortExpression="[Feature]" ReadOnly="True" />
				<asp:BoundField DataField="CompatibleSchemaVersion" HeaderText="Compatible Schema Version" SortExpression="[CompatibleSchemaVersion]" ReadOnly="True" />
				<data:BoundRadioButtonField DataField="IsCurrentVersion" HeaderText="Is Current Version" SortExpression="[IsCurrentVersion]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetSchemaVersions Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetSchemaVersions" OnClientClick="javascript:location.href='AspnetSchemaVersionsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetSchemaVersionsDataSource ID="AspnetSchemaVersionsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetSchemaVersionsDataSource>
	    		
</asp:Content>



