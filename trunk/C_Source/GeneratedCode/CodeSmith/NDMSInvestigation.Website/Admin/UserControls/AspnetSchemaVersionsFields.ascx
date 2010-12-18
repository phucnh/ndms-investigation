<%@ Control Language="C#" ClassName="AspnetSchemaVersionsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsCurrentVersion" runat="server" Text="Is Current Version:" AssociatedControlID="dataIsCurrentVersion" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsCurrentVersion" SelectedValue='<%# Bind("IsCurrentVersion") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompatibleSchemaVersion" runat="server" Text="Compatible Schema Version:" AssociatedControlID="dataCompatibleSchemaVersion" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompatibleSchemaVersion" Text='<%# Bind("CompatibleSchemaVersion") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCompatibleSchemaVersion" runat="server" Display="Dynamic" ControlToValidate="dataCompatibleSchemaVersion" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeature" runat="server" Text="Feature:" AssociatedControlID="dataFeature" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFeature" Text='<%# Bind("Feature") %>' MaxLength="128"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFeature" runat="server" Display="Dynamic" ControlToValidate="dataFeature" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


