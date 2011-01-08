<%@ Page Language="C#" Theme="Default" MasterPageFile="~/Shared/DefaultMaster.master"
    AutoEventWireup="true" Inherits="QuestionAnswer" Title="QuestionAnswer List"
    CodeBehind="QuestionAnswer.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DefaultContent" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1"
        PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="QuestionAnswerDataSource"
				DataKeyNames="QuestionId, AnswerId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_QuestionAnswer.xls"  		
			>
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
            <data:HyperLinkField HeaderText="Question Id" DataNavigateUrlFormatString="QuestionDetailsEdit.aspx?QuestionId={0}"
                DataNavigateUrlFields="QuestionId" DataContainer="QuestionIdSource" DataTextField="QuestionContent" SortExpression="[QuestionId]" />
            <data:HyperLinkField HeaderText="Answer Id" DataNavigateUrlFormatString="AnswerDetailsEdit.aspx?AnswerId={0}"
                DataNavigateUrlFields="AnswerId" DataContainer="AnswerIdSource" DataTextField="AnswerContent"
                SortExpression="[AnswerId]" />
            <asp:BoundField DataField="Mark" HeaderText="Mark" SortExpression="[Mark]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No QuestionAnswer Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnQuestionAnswer" OnClientClick="javascript:location.href='QuestionAnswerEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    <br />
    <br />
    <data:MultiFormView ID="FormView1" DataKeyNames="QuestionId, AnswerId" DefaultMode="Insert"
        runat="server" DataSourceID="QuestionAnswerDataSource">
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
        </FooterTemplate>
    </data:MultiFormView>
    <br />
    <data:QuestionAnswerDataSource ID="QuestionAnswerDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:QuestionAnswerProperty Name="AnswerDetails"/> 
					<data:QuestionAnswerProperty Name="QuestionDetails"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:QuestionAnswerDataSource>
</asp:Content>
