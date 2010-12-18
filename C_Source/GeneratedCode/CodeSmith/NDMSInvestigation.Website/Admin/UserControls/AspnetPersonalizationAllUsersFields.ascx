<%@ Control Language="C#" ClassName="AspnetPersonalizationAllUsersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastUpdatedDate" runat="server" Text="Last Updated Date:" AssociatedControlID="dataLastUpdatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastUpdatedDate" Text='<%# Bind("LastUpdatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastUpdatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastUpdatedDate" runat="server" Display="Dynamic" ControlToValidate="dataLastUpdatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPageSettings" runat="server" Text="Page Settings:" AssociatedControlID="dataPageSettings" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataPageSettings" Value='<%# Bind("PageSettings") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPathId" runat="server" Text="Path Id:" AssociatedControlID="dataPathId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPathId" DataSourceID="PathIdAspnetPathsDataSource" DataTextField="Path" DataValueField="PathId" SelectedValue='<%# Bind("PathId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AspnetPathsDataSource ID="PathIdAspnetPathsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


