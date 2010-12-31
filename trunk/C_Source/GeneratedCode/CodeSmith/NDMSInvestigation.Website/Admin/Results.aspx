
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Results.aspx.cs" Inherits="Results" Title="Results List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Results List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ResultsDataSource"
				DataKeyNames="UserId, GroupId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Results.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<data:HyperLinkField HeaderText="Group Id" DataNavigateUrlFormatString="QuestionGroupsEdit.aspx?GroupId={0}" DataNavigateUrlFields="GroupId" DataContainer="GroupIdSource" DataTextField="GroupName" />
				<asp:BoundField DataField="GroupMark" HeaderText="Group Mark" SortExpression="[GroupMark]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="TestTimes" HeaderText="Test Times" SortExpression="[TestTimes]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Results Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnResults" OnClientClick="javascript:location.href='ResultsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ResultsDataSource ID="ResultsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ResultsProperty Name="AspnetUsers"/> 
					<data:ResultsProperty Name="QuestionGroups"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ResultsDataSource>
	    		
</asp:Content>



