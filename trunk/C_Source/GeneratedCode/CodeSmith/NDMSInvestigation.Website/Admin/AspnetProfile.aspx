
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetProfile.aspx.cs" Inherits="AspnetProfile" Title="AspnetProfile List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Profile List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetProfileDataSource"
				DataKeyNames="UserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetProfile.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="PropertyNames" HeaderText="Property Names" SortExpression=""  />
				<asp:BoundField DataField="PropertyValuesString" HeaderText="Property Values String" SortExpression=""  />
				<asp:BoundField DataField="PropertyValuesBinary" HeaderText="Property Values Binary" SortExpression="[PropertyValuesBinary]"  />
				<asp:BoundField DataField="LastUpdatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Updated Date" SortExpression="[LastUpdatedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetProfile Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetProfile" OnClientClick="javascript:location.href='AspnetProfileEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetProfileDataSource ID="AspnetProfileDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetProfileProperty Name="AspnetUsers"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetProfileDataSource>
	    		
</asp:Content>



