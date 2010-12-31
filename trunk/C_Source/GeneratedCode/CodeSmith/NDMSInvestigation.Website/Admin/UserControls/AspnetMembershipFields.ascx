<%@ Control Language="C#" ClassName="AspnetMembershipFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationId" runat="server" Text="Application Id:" AssociatedControlID="dataApplicationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataApplicationId" DataSourceID="ApplicationIdAspnetApplicationsDataSource" DataTextField="ApplicationName" DataValueField="ApplicationId" SelectedValue='<%# Bind("ApplicationId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AspnetApplicationsDataSource ID="ApplicationIdAspnetApplicationsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdAspnetUsersDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AspnetUsersDataSource ID="UserIdAspnetUsersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassword" runat="server" Text="Password:" AssociatedControlID="dataPassword" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassword" runat="server" Display="Dynamic" ControlToValidate="dataPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPasswordFormat" runat="server" Text="Password Format:" AssociatedControlID="dataPasswordFormat" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPasswordFormat" Text='<%# Bind("PasswordFormat") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPasswordFormat" runat="server" Display="Dynamic" ControlToValidate="dataPasswordFormat" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataPasswordFormat" runat="server" Display="Dynamic" ControlToValidate="dataPasswordFormat" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPasswordSalt" runat="server" Text="Password Salt:" AssociatedControlID="dataPasswordSalt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPasswordSalt" Text='<%# Bind("PasswordSalt") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPasswordSalt" runat="server" Display="Dynamic" ControlToValidate="dataPasswordSalt" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMobilePin" runat="server" Text="Mobile Pin:" AssociatedControlID="dataMobilePin" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobilePin" Text='<%# Bind("MobilePin") %>' MaxLength="16"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLoweredEmail" runat="server" Text="Lowered Email:" AssociatedControlID="dataLoweredEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLoweredEmail" Text='<%# Bind("LoweredEmail") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPasswordQuestion" runat="server" Text="Password Question:" AssociatedControlID="dataPasswordQuestion" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPasswordQuestion" Text='<%# Bind("PasswordQuestion") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPasswordAnswer" runat="server" Text="Password Answer:" AssociatedControlID="dataPasswordAnswer" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPasswordAnswer" Text='<%# Bind("PasswordAnswer") %>' MaxLength="128"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsApproved" runat="server" Text="Is Approved:" AssociatedControlID="dataIsApproved" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsApproved" SelectedValue='<%# Bind("IsApproved") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsLockedOut" runat="server" Text="Is Locked Out:" AssociatedControlID="dataIsLockedOut" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsLockedOut" SelectedValue='<%# Bind("IsLockedOut") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateDate" runat="server" Text="Create Date:" AssociatedControlID="dataCreateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateDate" Text='<%# Bind("CreateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataCreateDate" runat="server" Display="Dynamic" ControlToValidate="dataCreateDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastLoginDate" runat="server" Text="Last Login Date:" AssociatedControlID="dataLastLoginDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastLoginDate" Text='<%# Bind("LastLoginDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastLoginDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastLoginDate" runat="server" Display="Dynamic" ControlToValidate="dataLastLoginDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastPasswordChangedDate" runat="server" Text="Last Password Changed Date:" AssociatedControlID="dataLastPasswordChangedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastPasswordChangedDate" Text='<%# Bind("LastPasswordChangedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastPasswordChangedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastPasswordChangedDate" runat="server" Display="Dynamic" ControlToValidate="dataLastPasswordChangedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastLockoutDate" runat="server" Text="Last Lockout Date:" AssociatedControlID="dataLastLockoutDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastLockoutDate" Text='<%# Bind("LastLockoutDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastLockoutDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastLockoutDate" runat="server" Display="Dynamic" ControlToValidate="dataLastLockoutDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFailedPasswordAttemptCount" runat="server" Text="Failed Password Attempt Count:" AssociatedControlID="dataFailedPasswordAttemptCount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFailedPasswordAttemptCount" Text='<%# Bind("FailedPasswordAttemptCount") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFailedPasswordAttemptCount" runat="server" Display="Dynamic" ControlToValidate="dataFailedPasswordAttemptCount" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataFailedPasswordAttemptCount" runat="server" Display="Dynamic" ControlToValidate="dataFailedPasswordAttemptCount" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFailedPasswordAttemptWindowStart" runat="server" Text="Failed Password Attempt Window Start:" AssociatedControlID="dataFailedPasswordAttemptWindowStart" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFailedPasswordAttemptWindowStart" Text='<%# Bind("FailedPasswordAttemptWindowStart", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFailedPasswordAttemptWindowStart" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataFailedPasswordAttemptWindowStart" runat="server" Display="Dynamic" ControlToValidate="dataFailedPasswordAttemptWindowStart" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFailedPasswordAnswerAttemptCount" runat="server" Text="Failed Password Answer Attempt Count:" AssociatedControlID="dataFailedPasswordAnswerAttemptCount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFailedPasswordAnswerAttemptCount" Text='<%# Bind("FailedPasswordAnswerAttemptCount") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFailedPasswordAnswerAttemptCount" runat="server" Display="Dynamic" ControlToValidate="dataFailedPasswordAnswerAttemptCount" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataFailedPasswordAnswerAttemptCount" runat="server" Display="Dynamic" ControlToValidate="dataFailedPasswordAnswerAttemptCount" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFailedPasswordAnswerAttemptWindowStart" runat="server" Text="Failed Password Answer Attempt Window Start:" AssociatedControlID="dataFailedPasswordAnswerAttemptWindowStart" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFailedPasswordAnswerAttemptWindowStart" Text='<%# Bind("FailedPasswordAnswerAttemptWindowStart", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFailedPasswordAnswerAttemptWindowStart" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataFailedPasswordAnswerAttemptWindowStart" runat="server" Display="Dynamic" ControlToValidate="dataFailedPasswordAnswerAttemptWindowStart" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataComment" runat="server" Text="Comment:" AssociatedControlID="dataComment" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataComment" Text='<%# Bind("Comment") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


