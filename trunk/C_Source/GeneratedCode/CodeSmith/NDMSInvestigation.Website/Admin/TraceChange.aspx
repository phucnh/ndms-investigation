
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TraceChange.aspx.cs" Inherits="TraceChange" Title="TraceChange List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Trace Change List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TraceChangeDataSource"
				DataKeyNames="TraceId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TraceChange.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="NameOfTable" HeaderText="Name Of Table" SortExpression="[NameOfTable]"  />
				<asp:BoundField DataField="OldValue" HeaderText="Old Value" SortExpression="[OldValue]"  />
				<asp:BoundField DataField="NewValue" HeaderText="New Value" SortExpression="[NewValue]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TraceChange Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTraceChange" OnClientClick="javascript:location.href='TraceChangeEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:TraceChangeDataSource ID="TraceChangeDataSource" runat="server"
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
		</data:TraceChangeDataSource>
	    		
</asp:Content>



