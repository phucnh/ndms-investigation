<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuestionGroupsEdit.aspx.cs" Inherits="QuestionGroupsEdit" Title="QuestionGroups Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Question Groups - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="GroupId" runat="server" DataSourceID="QuestionGroupsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuestionGroupsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuestionGroupsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>QuestionGroups not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:QuestionGroupsDataSource ID="QuestionGroupsDataSource" runat="server"
			SelectMethod="GetByGroupId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="GroupId" QueryStringField="GroupId" Type="String" />

			</Parameters>
		</data:QuestionGroupsDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewQuestionDetails1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewQuestionDetails1_SelectedIndexChanged"			 			 
			DataSourceID="QuestionDetailsDataSource1"
			DataKeyNames="QuestionId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_QuestionDetails.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="QuestionContent" HeaderText="Question Content" SortExpression="[QuestionContent]" />				
				<asp:BoundField DataField="QuestionSuggest" HeaderText="Question Suggest" SortExpression="[QuestionSuggest]" />				
				<asp:BoundField DataField="QuestionDescription" HeaderText="Question Description" SortExpression="[QuestionDescription]" />				
				<asp:BoundField DataField="OrderNumber" HeaderText="Order Number" SortExpression="[OrderNumber]" />				
				<data:HyperLinkField HeaderText="Group Id" DataNavigateUrlFormatString="QuestionGroupsEdit.aspx?GroupId={0}" DataNavigateUrlFields="GroupId" DataContainer="GroupIdSource" DataTextField="GroupName" />
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]" />				
				<asp:BoundField DataField="UpdatedDate" HeaderText="Updated Date" SortExpression="[UpdatedDate]" />				
				<asp:BoundField DataField="UpdatedBy" HeaderText="Updated By" SortExpression="[UpdatedBy]" />				
				<asp:BoundField DataField="QuestionTitle" HeaderText="Question Title" SortExpression="[QuestionTitle]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Question Details Found! </b>
				<asp:HyperLink runat="server" ID="hypQuestionDetails" NavigateUrl="~/admin/QuestionDetailsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:QuestionDetailsDataSource ID="QuestionDetailsDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:QuestionDetailsProperty Name="QuestionGroups"/> 
					<%--<data:QuestionDetailsProperty Name="QuestionAnswerCollection" />--%>
					<%--<data:QuestionDetailsProperty Name="AnswerIdAnswerDetailsCollection_From_QuestionAnswer" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:QuestionDetailsFilter  Column="GroupId" QueryStringField="GroupId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:QuestionDetailsDataSource>		
		
		<br />
		

</asp:Content>

