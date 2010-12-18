<%@ Control Language="C#" ClassName="AspnetRolesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataLoweredRoleName" runat="server" Text="Lowered Role Name:" AssociatedControlID="dataLoweredRoleName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLoweredRoleName" Text='<%# Bind("LoweredRoleName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLoweredRoleName" runat="server" Display="Dynamic" ControlToValidate="dataLoweredRoleName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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
        <td class="literal"><asp:Label ID="lbldataRoleName" runat="server" Text="Role Name:" AssociatedControlID="dataRoleName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRoleName" Text='<%# Bind("RoleName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRoleName" runat="server" Display="Dynamic" ControlToValidate="dataRoleName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td valign="top" class="literal">Aspnet Users:</td>
				<td>
					<asp:CheckBoxList ID="AspnetUsersList" runat="server"
						DataSourceID="AspnetUsersReferenceDataSource"
						DataTextField="UserName"
						DataValueField="UserId"
						RepeatColumns="4"
					/>				
					<data:AspnetUsersDataSource ID="AspnetUsersReferenceDataSource" runat="server" SelectMethod="GetAll"/>
					
					<data:AspnetUsersInRolesDataSource ID="AspnetUsersInRolesDataSource" runat="server" SelectMethod="GetByRoleId" >
						<Parameters>							
							<asp:QueryStringParameter Name="RoleId" QueryStringField="RoleId" Type="String" />
						</Parameters>
					</data:AspnetUsersInRolesDataSource>	
					
					<data:ManyToManyListRelationship ID="AspnetUsersInRolesRelationship" runat="server">
						<PrimaryMember runat="server" DataSourceID="AspnetRolesDataSource" EntityKeyName="RoleId" />
						<LinkMember runat="server" DataSourceID="AspnetUsersInRolesDataSource" EntityKeyName="RoleId" ForeignKeyName="UserId" />
						<ReferenceMember runat="server" DataSourceID="AspnetUsersReferenceDataSource" ListControlID="AspnetUsersList" EntityKeyName="UserId" />
					</data:ManyToManyListRelationship>					
				</td>
			</tr>			
			
		</table>

	</ItemTemplate>
</asp:FormView>


