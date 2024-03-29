﻿<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master"
    AutoEventWireup="true" Inherits="QuestionAnswerEdit" Title="QuestionAnswer Edit"
    CodeBehind="QuestionAnswerEdit.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <data:MultiFormView ID="FormView1" DataKeyNames="QuestionId" runat="server"
        DataSourceID="QuestionAnswerDataSource">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/Management/UserControls/QuestionAnswerFields.ascx" />
        </EditItemTemplatePaths>
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/Management/UserControls/QuestionAnswerFields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>QuestionAnswer not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
        </FooterTemplate>
    </data:MultiFormView>
    <data:QuestionAnswerDataSource ID="QuestionAnswerDataSource" runat="server" SelectMethod="GetByQuestionIdAnswerId">
        <Parameters>
            <asp:QueryStringParameter Name="QuestionId" QueryStringField="QuestionId" Type="String" />
            <asp:QueryStringParameter Name="AnswerId" QueryStringField="AnswerId" Type="String" />
        </Parameters>
    </data:QuestionAnswerDataSource>
    <br />
</asp:Content>
