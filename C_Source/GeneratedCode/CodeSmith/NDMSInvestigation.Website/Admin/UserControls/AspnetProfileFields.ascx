<%@ Control Language="C#" ClassName="AspnetProfileFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPropertyValuesBinary" runat="server" Text="Property Values Binary:" AssociatedControlID="dataPropertyValuesBinary" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataPropertyValuesBinary" Value='<%# Bind("PropertyValuesBinary") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastUpdatedDate" runat="server" Text="Last Updated Date:" AssociatedControlID="dataLastUpdatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastUpdatedDate" Text='<%# Bind("LastUpdatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastUpdatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastUpdatedDate" runat="server" Display="Dynamic" ControlToValidate="dataLastUpdatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPropertyValuesString" runat="server" Text="Property Values String:" AssociatedControlID="dataPropertyValuesString" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPropertyValuesString" Text='<%# Bind("PropertyValuesString") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPropertyValuesString" runat="server" Display="Dynamic" ControlToValidate="dataPropertyValuesString" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
        <td class="literal"><asp:Label ID="lbldataPropertyNames" runat="server" Text="Property Names:" AssociatedControlID="dataPropertyNames" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPropertyNames" Text='<%# Bind("PropertyNames") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPropertyNames" runat="server" Display="Dynamic" ControlToValidate="dataPropertyNames" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


