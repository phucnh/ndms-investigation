
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuestionDetails.aspx.cs" Inherits="QuestionDetails" Title="QuestionDetails List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Question Details List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="QuestionDetailsDataSource"
				DataKeyNames="QuestionId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_QuestionDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Group Id" DataNavigateUrlFormatString="QuestionGroupEdit.aspx?GroupId={0}" DataNavigateUrlFields="GroupId" DataContainer="GroupIdSource" DataTextField="GroupName" />
				<asp:BoundField DataField="OrderNumber" HeaderText="Order Number" SortExpression="[OrderNumber]"  />
				<asp:BoundField DataField="QuestionDescription" HeaderText="Question Description" SortExpression="[QuestionDescription]"  />
				<asp:BoundField DataField="QuestionContent" HeaderText="Question Content" SortExpression="[QuestionContent]"  />
				<asp:BoundField DataField="QuestionSuggest" HeaderText="Question Suggest" SortExpression="[QuestionSuggest]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No QuestionDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnQuestionDetails" OnClientClick="javascript:location.href='QuestionDetailsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:QuestionDetailsDataSource ID="QuestionDetailsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:QuestionDetailsProperty Name="QuestionGroup"/> 
					<%--<data:QuestionDetailsProperty Name="QuestionAnswerCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:QuestionDetailsDataSource>
	    		
</asp:Content>



