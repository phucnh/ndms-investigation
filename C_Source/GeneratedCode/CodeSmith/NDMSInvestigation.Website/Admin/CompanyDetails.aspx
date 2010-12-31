
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CompanyDetails.aspx.cs" Inherits="CompanyDetails" Title="CompanyDetails List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Company Details List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CompanyDetailsDataSource"
				DataKeyNames="CompanyId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CompanyDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]"  />
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]"  />
				<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="[Fax]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]"  />
				<asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" SortExpression="[EmployeeNumber]"  />
				<asp:BoundField DataField="Director" HeaderText="Director" SortExpression="[Director]"  />
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<asp:BoundField DataField="District" HeaderText="District" SortExpression="[District]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="UpdatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Updated Date" SortExpression="[UpdatedDate]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="CurrentTotalMark" HeaderText="Current Total Mark" SortExpression="[CurrentTotalMark]"  />
				<data:HyperLinkField HeaderText="Trace Change" DataNavigateUrlFormatString="TraceChangeEdit.aspx?TraceId={0}" DataNavigateUrlFields="TraceId" DataContainer="TraceChangeSource" DataTextField="NameOfTable" />
			</Columns>
			<EmptyDataTemplate>
				<b>No CompanyDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCompanyDetails" OnClientClick="javascript:location.href='CompanyDetailsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CompanyDetailsDataSource ID="CompanyDetailsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CompanyDetailsProperty Name="AspnetUsers"/> 
					<data:CompanyDetailsProperty Name="TraceChange"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CompanyDetailsDataSource>
	    		
</asp:Content>



