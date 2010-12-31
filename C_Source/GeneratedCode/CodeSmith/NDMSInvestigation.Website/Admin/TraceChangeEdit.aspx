<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TraceChangeEdit.aspx.cs" Inherits="TraceChangeEdit" Title="TraceChange Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Trace Change - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="TraceId" runat="server" DataSourceID="TraceChangeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TraceChangeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TraceChangeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>TraceChange not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:TraceChangeDataSource ID="TraceChangeDataSource" runat="server"
			SelectMethod="GetByTraceId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="TraceId" QueryStringField="TraceId" Type="String" />

			</Parameters>
		</data:TraceChangeDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewCompanyDetails1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewCompanyDetails1_SelectedIndexChanged"			 			 
			DataSourceID="CompanyDetailsDataSource1"
			DataKeyNames="CompanyId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CompanyDetails.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />				
				<asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="[Phone]" />				
				<asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="[Fax]" />				
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />				
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]" />				
				<asp:BoundField DataField="EmployeeNumber" HeaderText="Employee Number" SortExpression="[EmployeeNumber]" />				
				<asp:BoundField DataField="Director" HeaderText="Director" SortExpression="[Director]" />				
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]" />				
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]" />				
				<asp:BoundField DataField="District" HeaderText="District" SortExpression="[District]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="UpdatedDate" HeaderText="Updated Date" SortExpression="[UpdatedDate]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="CurrentTotalMark" HeaderText="Current Total Mark" SortExpression="[CurrentTotalMark]" />				
				<data:HyperLinkField HeaderText="Trace Change" DataNavigateUrlFormatString="TraceChangeEdit.aspx?TraceId={0}" DataNavigateUrlFields="TraceId" DataContainer="TraceChangeSource" DataTextField="NameOfTable" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Company Details Found! </b>
				<asp:HyperLink runat="server" ID="hypCompanyDetails" NavigateUrl="~/admin/CompanyDetailsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CompanyDetailsDataSource ID="CompanyDetailsDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CompanyDetailsProperty Name="AspnetUsers"/> 
					<data:CompanyDetailsProperty Name="TraceChange"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CompanyDetailsFilter  Column="TraceChange" QueryStringField="TraceId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CompanyDetailsDataSource>		
		
		<br />
		

</asp:Content>

