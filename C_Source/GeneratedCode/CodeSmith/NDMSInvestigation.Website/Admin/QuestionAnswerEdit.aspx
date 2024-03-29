﻿<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="QuestionAnswerEdit.aspx.cs" Inherits="QuestionAnswerEdit" Title="QuestionAnswer Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Question Answer - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="QuestionId, AnswerId" runat="server" DataSourceID="QuestionAnswerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuestionAnswerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/QuestionAnswerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>QuestionAnswer not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:QuestionAnswerDataSource ID="QuestionAnswerDataSource" runat="server"
			SelectMethod="GetByQuestionIdAnswerId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="QuestionId" QueryStringField="QuestionId" Type="String" />
<asp:QueryStringParameter Name="AnswerId" QueryStringField="AnswerId" Type="String" />

			</Parameters>
		</data:QuestionAnswerDataSource>
		
		<br />


</asp:Content>

