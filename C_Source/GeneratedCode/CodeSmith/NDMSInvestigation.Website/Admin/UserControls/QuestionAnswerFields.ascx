<%@ Control Language="C#" ClassName="QuestionAnswerFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuestionId" runat="server" Text="Question Id:" AssociatedControlID="dataQuestionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataQuestionId" DataSourceID="QuestionIdQuestionDetailsDataSource" DataTextField="QuestionContent" DataValueField="QuestionId" SelectedValue='<%# Bind("QuestionId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:QuestionDetailsDataSource ID="QuestionIdQuestionDetailsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnswerId" runat="server" Text="Answer Id:" AssociatedControlID="dataAnswerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAnswerId" DataSourceID="AnswerIdAnswerDetailsDataSource" DataTextField="AnswerContent" DataValueField="AnswerId" SelectedValue='<%# Bind("AnswerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AnswerDetailsDataSource ID="AnswerIdAnswerDetailsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMark" runat="server" Text="Mark:" AssociatedControlID="dataMark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMark" Text='<%# Bind("Mark") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMark" runat="server" Display="Dynamic" ControlToValidate="dataMark" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedBy" runat="server" Text="Created By:" AssociatedControlID="dataCreatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedBy" Text='<%# Bind("CreatedBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateDated" runat="server" Text="Update Dated:" AssociatedControlID="dataUpdateDated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateDated" Text='<%# Bind("UpdateDated", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateDated" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdatedBy" runat="server" Text="Updated By:" AssociatedControlID="dataUpdatedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedBy" Text='<%# Bind("UpdatedBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


