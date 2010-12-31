<%@ Control Language="C#" ClassName="TraceChangeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNameOfTable" runat="server" Text="Name Of Table:" AssociatedControlID="dataNameOfTable" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNameOfTable" Text='<%# Bind("NameOfTable") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOldValue" runat="server" Text="Old Value:" AssociatedControlID="dataOldValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOldValue" Text='<%# Bind("OldValue") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewValue" runat="server" Text="New Value:" AssociatedControlID="dataNewValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNewValue" Text='<%# Bind("NewValue") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


