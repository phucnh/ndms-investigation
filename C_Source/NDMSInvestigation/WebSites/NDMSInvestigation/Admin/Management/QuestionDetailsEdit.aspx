<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master" AutoEventWireup="true" Inherits="QuestionDetailsEdit" Title="QuestionDetails Edit" Codebehind="QuestionDetailsEdit.aspx.cs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="QuestionId" runat="server" DataSourceID="QuestionDetailsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/Management/UserControls/QuestionDetailsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/Management/UserControls/QuestionDetailsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>QuestionDetails not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:QuestionDetailsDataSource ID="QuestionDetailsDataSource" runat="server"
			SelectMethod="GetByQuestionId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="QuestionId" QueryStringField="QuestionId" Type="String" />

			</Parameters>
		</data:QuestionDetailsDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewQuestionAnswer1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewQuestionAnswer1_SelectedIndexChanged"			 			 
			DataSourceID="QuestionAnswerDataSource1"
			DataKeyNames="QuestionAnswerId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_QuestionAnswer.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Question Id" DataNavigateUrlFormatString="QuestionDetailsEdit.aspx?QuestionId={0}" DataNavigateUrlFields="QuestionId" DataContainer="QuestionIdSource" DataTextField="QuestionContent" />
				<data:HyperLinkField HeaderText="Answer Id" DataNavigateUrlFormatString="AnswerDetailsEdit.aspx?AnswerId={0}" DataNavigateUrlFields="AnswerId" DataContainer="AnswerIdSource" DataTextField="AnswerContent" />
				<asp:BoundField DataField="Mark" HeaderText="Mark" SortExpression="[Mark]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Question Answer Found! </b>
				<asp:HyperLink runat="server" ID="hypQuestionAnswer" NavigateUrl="~/admin/QuestionAnswerEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:QuestionAnswerDataSource ID="QuestionAnswerDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:QuestionAnswerProperty Name="AnswerDetails"/> 
					<data:QuestionAnswerProperty Name="QuestionDetails"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:QuestionAnswerFilter  Column="QuestionId" QueryStringField="QuestionId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:QuestionAnswerDataSource>		
		
		<br />
		

</asp:Content>

