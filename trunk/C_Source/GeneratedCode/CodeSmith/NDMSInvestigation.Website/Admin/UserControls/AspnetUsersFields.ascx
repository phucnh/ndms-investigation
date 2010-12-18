<%@ Control Language="C#" ClassName="AspnetUsersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMobileAlias" runat="server" Text="Mobile Alias:" AssociatedControlID="dataMobileAlias" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobileAlias" Text='<%# Bind("MobileAlias") %>' MaxLength="16"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsAnonymous" runat="server" Text="Is Anonymous:" AssociatedControlID="dataIsAnonymous" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsAnonymous" SelectedValue='<%# Bind("IsAnonymous") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastActivityDate" runat="server" Text="Last Activity Date:" AssociatedControlID="dataLastActivityDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastActivityDate" Text='<%# Bind("LastActivityDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastActivityDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataLastActivityDate" runat="server" Display="Dynamic" ControlToValidate="dataLastActivityDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationId" runat="server" Text="Application Id:" AssociatedControlID="dataApplicationId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataApplicationId" DataSourceID="ApplicationIdAspnetApplicationsDataSource" DataTextField="ApplicationName" DataValueField="ApplicationId" SelectedValue='<%# Bind("ApplicationId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AspnetApplicationsDataSource ID="ApplicationIdAspnetApplicationsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLoweredUserName" runat="server" Text="Lowered User Name:" AssociatedControlID="dataLoweredUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLoweredUserName" Text='<%# Bind("LoweredUserName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLoweredUserName" runat="server" Display="Dynamic" ControlToValidate="dataLoweredUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top" class="literal">Aspnet Roles:</td>
				<td>
					<asp:CheckBoxList ID="AspnetRolesList" runat="server"
						DataSourceID="AspnetRolesReferenceDataSource"
						DataTextField="RoleName"
						DataValueField="RoleId"
						RepeatColumns="4"
					/>				
					<data:AspnetRolesDataSource ID="AspnetRolesReferenceDataSource" runat="server" SelectMethod="GetAll"/>
					
					<data:AspnetUsersInRolesDataSource ID="AspnetUsersInRolesDataSource" runat="server" SelectMethod="GetByUserId" >
						<Parameters>							
							<asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
						</Parameters>
					</data:AspnetUsersInRolesDataSource>	
					
					<data:ManyToManyListRelationship ID="AspnetUsersInRolesRelationship" runat="server">
						<PrimaryMember runat="server" DataSourceID="AspnetUsersDataSource" EntityKeyName="UserId" />
						<LinkMember runat="server" DataSourceID="AspnetUsersInRolesDataSource" EntityKeyName="UserId" ForeignKeyName="RoleId" />
						<ReferenceMember runat="server" DataSourceID="AspnetRolesReferenceDataSource" ListControlID="AspnetRolesList" EntityKeyName="RoleId" />
					</data:ManyToManyListRelationship>					
				</td>
			</tr>			
			
		</table>

	</ItemTemplate>
</asp:FormView>


