<%@ Control Language="C#" ClassName="AspnetApplicationsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLoweredApplicationName" runat="server" Text="Lowered Application Name:" AssociatedControlID="dataLoweredApplicationName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLoweredApplicationName" Text='<%# Bind("LoweredApplicationName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLoweredApplicationName" runat="server" Display="Dynamic" ControlToValidate="dataLoweredApplicationName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationName" runat="server" Text="Application Name:" AssociatedControlID="dataApplicationName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataApplicationName" Text='<%# Bind("ApplicationName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataApplicationName" runat="server" Display="Dynamic" ControlToValidate="dataApplicationName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


