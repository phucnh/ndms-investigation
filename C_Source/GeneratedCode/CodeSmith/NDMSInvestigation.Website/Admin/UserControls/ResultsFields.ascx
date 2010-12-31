<%@ Control Language="C#" ClassName="ResultsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdAspnetUsersDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AspnetUsersDataSource ID="UserIdAspnetUsersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGroupId" runat="server" Text="Group Id:" AssociatedControlID="dataGroupId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataGroupId" DataSourceID="GroupIdQuestionGroupsDataSource" DataTextField="GroupName" DataValueField="GroupId" SelectedValue='<%# Bind("GroupId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:QuestionGroupsDataSource ID="GroupIdQuestionGroupsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGroupMark" runat="server" Text="Group Mark:" AssociatedControlID="dataGroupMark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGroupMark" Text='<%# Bind("GroupMark") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataGroupMark" runat="server" Display="Dynamic" ControlToValidate="dataGroupMark" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTestTimes" runat="server" Text="Test Times:" AssociatedControlID="dataTestTimes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTestTimes" Text='<%# Bind("TestTimes") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTestTimes" runat="server" Display="Dynamic" ControlToValidate="dataTestTimes" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


