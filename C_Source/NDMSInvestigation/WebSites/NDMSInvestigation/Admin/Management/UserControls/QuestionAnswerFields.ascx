<%@ Control Language="C#" ClassName="QuestionAnswerFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMark" runat="server" Text="Mark:" AssociatedControlID="dataMark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMark" Text='<%# Bind("Mark") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMark" runat="server" Display="Dynamic" ControlToValidate="dataMark" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnswerId" runat="server" Text="Answer Id:" AssociatedControlID="dataAnswerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAnswerId" DataSourceID="AnswerIdAnswerDetailsDataSource" DataTextField="AnswerContent" DataValueField="AnswerId" SelectedValue='<%# Bind("AnswerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:AnswerDetailsDataSource ID="AnswerIdAnswerDetailsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuestionId" runat="server" Text="Question Id:" AssociatedControlID="dataQuestionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataQuestionId" DataSourceID="QuestionIdQuestionDetailsDataSource" DataTextField="QuestionContent" DataValueField="QuestionId" SelectedValue='<%# Bind("QuestionId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:QuestionDetailsDataSource ID="QuestionIdQuestionDetailsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


