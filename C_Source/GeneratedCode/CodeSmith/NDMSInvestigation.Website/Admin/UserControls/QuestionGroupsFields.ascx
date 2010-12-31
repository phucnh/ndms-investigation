<%@ Control Language="C#" ClassName="QuestionGroupsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataGroupName" runat="server" Text="Group Name:" AssociatedControlID="dataGroupName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGroupName" Text='<%# Bind("GroupName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGroupDescription" runat="server" Text="Group Description:" AssociatedControlID="dataGroupDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGroupDescription" Text='<%# Bind("GroupDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrderNumber" runat="server" Text="Order Number:" AssociatedControlID="dataOrderNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrderNumber" Text='<%# Bind("OrderNumber") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOrderNumber" runat="server" Display="Dynamic" ControlToValidate="dataOrderNumber" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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
        <td class="literal"><asp:Label ID="lbldataUpdatedDate" runat="server" Text="Updated Date:" AssociatedControlID="dataUpdatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedDate" Text='<%# Bind("UpdatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
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


