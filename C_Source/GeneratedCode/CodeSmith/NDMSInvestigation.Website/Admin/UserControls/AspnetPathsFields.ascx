<%@ Control Language="C#" ClassName="AspnetPathsFields" %>

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
        <td class="literal"><asp:Label ID="lbldataPathId" runat="server" Text="Path Id:" AssociatedControlID="dataPathId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataPathId" Value='<%# Bind("PathId") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPath" runat="server" Text="Path:" AssociatedControlID="dataPath" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPath" Text='<%# Bind("Path") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPath" runat="server" Display="Dynamic" ControlToValidate="dataPath" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLoweredPath" runat="server" Text="Lowered Path:" AssociatedControlID="dataLoweredPath" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLoweredPath" Text='<%# Bind("LoweredPath") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLoweredPath" runat="server" Display="Dynamic" ControlToValidate="dataLoweredPath" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


