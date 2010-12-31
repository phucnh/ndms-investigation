<%@ Control Language="C#" ClassName="CompanyDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdAspnetUsersDataSource" DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:AspnetUsersDataSource ID="UserIdAspnetUsersDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyName" runat="server" Text="Company Name:" AssociatedControlID="dataCompanyName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyName" Text='<%# Bind("CompanyName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhone" runat="server" Text="Phone:" AssociatedControlID="dataPhone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFax" runat="server" Text="Fax:" AssociatedControlID="dataFax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFax" Text='<%# Bind("Fax") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmployeeNumber" runat="server" Text="Employee Number:" AssociatedControlID="dataEmployeeNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmployeeNumber" Text='<%# Bind("EmployeeNumber") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataEmployeeNumber" runat="server" Display="Dynamic" ControlToValidate="dataEmployeeNumber" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDirector" runat="server" Text="Director:" AssociatedControlID="dataDirector" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDirector" Text='<%# Bind("Director") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountry" runat="server" Text="Country:" AssociatedControlID="dataCountry" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCountry" Text='<%# Bind("Country") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCity" Text='<%# Bind("City") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDistrict" runat="server" Text="District:" AssociatedControlID="dataDistrict" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDistrict" Text='<%# Bind("District") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdatedDate" runat="server" Text="Updated Date:" AssociatedControlID="dataUpdatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdatedDate" Text='<%# Bind("UpdatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrentTotalMark" runat="server" Text="Current Total Mark:" AssociatedControlID="dataCurrentTotalMark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCurrentTotalMark" Text='<%# Bind("CurrentTotalMark") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCurrentTotalMark" runat="server" Display="Dynamic" ControlToValidate="dataCurrentTotalMark" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTraceChange" runat="server" Text="Trace Change:" AssociatedControlID="dataTraceChange" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTraceChange" DataSourceID="TraceChangeTraceChangeDataSource" DataTextField="NameOfTable" DataValueField="TraceId" SelectedValue='<%# Bind("TraceChange") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:TraceChangeDataSource ID="TraceChangeTraceChangeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


