
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master" AutoEventWireup="true" Inherits="AnswerDetails" Title="AnswerDetails List" Codebehind="AnswerDetails.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AnswerDetailsDataSource"
				DataKeyNames="AnswerId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AnswerDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="AnswerDescription" HeaderText="Answer Description" SortExpression="[AnswerDescription]"  />
				<asp:BoundField DataField="AnswerMark" HeaderText="Answer Mark" SortExpression="[AnswerMark]"  />
				<asp:BoundField DataField="AnswerContent" HeaderText="Answer Content" SortExpression="[AnswerContent]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AnswerDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAnswerDetails"  OnClientClick="javascript:location.href='AnswerDetailsEdit.aspx'; return false;"  Text="Add New"></asp:Button>
		<data:AnswerDetailsDataSource ID="AnswerDetailsDataSource" runat="server"
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
		</data:AnswerDetailsDataSource>
	    		
</asp:Content>



