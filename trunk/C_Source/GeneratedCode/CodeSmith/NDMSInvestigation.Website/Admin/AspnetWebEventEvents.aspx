
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetWebEventEvents.aspx.cs" Inherits="AspnetWebEventEvents" Title="AspnetWebEventEvents List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Web Event Events List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetWebEventEventsDataSource"
				DataKeyNames="EventId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetWebEventEvents.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="EventId" HeaderText="Event Id" SortExpression="[EventId]" ReadOnly="True" />
				<asp:BoundField DataField="EventTimeUtc" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Event Time Utc" SortExpression="[EventTimeUtc]"  />
				<asp:BoundField DataField="EventTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Event Time" SortExpression="[EventTime]"  />
				<asp:BoundField DataField="EventType" HeaderText="Event Type" SortExpression="[EventType]"  />
				<asp:BoundField DataField="EventSequence" HeaderText="Event Sequence" SortExpression="[EventSequence]"  />
				<asp:BoundField DataField="EventOccurrence" HeaderText="Event Occurrence" SortExpression="[EventOccurrence]"  />
				<asp:BoundField DataField="EventCode" HeaderText="Event Code" SortExpression="[EventCode]"  />
				<asp:BoundField DataField="EventDetailCode" HeaderText="Event Detail Code" SortExpression="[EventDetailCode]"  />
				<asp:BoundField DataField="Message" HeaderText="Message" SortExpression="[Message]"  />
				<asp:BoundField DataField="ApplicationPath" HeaderText="Application Path" SortExpression="[ApplicationPath]"  />
				<asp:BoundField DataField="ApplicationVirtualPath" HeaderText="Application Virtual Path" SortExpression="[ApplicationVirtualPath]"  />
				<asp:BoundField DataField="MachineName" HeaderText="Machine Name" SortExpression="[MachineName]"  />
				<asp:BoundField DataField="RequestUrl" HeaderText="Request Url" SortExpression="[RequestUrl]"  />
				<asp:BoundField DataField="ExceptionType" HeaderText="Exception Type" SortExpression="[ExceptionType]"  />
				<asp:BoundField DataField="Details" HeaderText="Details" SortExpression=""  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetWebEventEvents Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetWebEventEvents" OnClientClick="javascript:location.href='AspnetWebEventEventsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetWebEventEventsDataSource ID="AspnetWebEventEventsDataSource" runat="server"
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
		</data:AspnetWebEventEventsDataSource>
	    		
</asp:Content>



