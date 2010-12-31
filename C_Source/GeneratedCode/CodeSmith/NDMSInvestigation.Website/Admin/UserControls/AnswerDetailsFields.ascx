<%@ Control Language="C#" ClassName="AnswerDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnswerContent" runat="server" Text="Answer Content:" AssociatedControlID="dataAnswerContent" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAnswerContent" Text='<%# Bind("AnswerContent") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAnswerContent" runat="server" Display="Dynamic" ControlToValidate="dataAnswerContent" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnswerMark" runat="server" Text="Answer Mark:" AssociatedControlID="dataAnswerMark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAnswerMark" Text='<%# Bind("AnswerMark") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAnswerMark" runat="server" Display="Dynamic" ControlToValidate="dataAnswerMark" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAnswerDescription" runat="server" Text="Answer Description:" AssociatedControlID="dataAnswerDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAnswerDescription" Text='<%# Bind("AnswerDescription") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
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
        <td class="literal"><asp:Label ID="lbldataUpdateDate" runat="server" Text="Update Date:" AssociatedControlID="dataUpdateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateDate" Text='<%# Bind("UpdateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateBy" runat="server" Text="Update By:" AssociatedControlID="dataUpdateBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateBy" Text='<%# Bind("UpdateBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


