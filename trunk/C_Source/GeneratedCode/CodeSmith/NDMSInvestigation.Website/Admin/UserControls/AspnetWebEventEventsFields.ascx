<%@ Control Language="C#" ClassName="AspnetWebEventEventsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventId" runat="server" Text="Event Id:" AssociatedControlID="dataEventId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventId" Text='<%# Bind("EventId") %>' MaxLength="32"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEventId" runat="server" Display="Dynamic" ControlToValidate="dataEventId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventTimeUtc" runat="server" Text="Event Time Utc:" AssociatedControlID="dataEventTimeUtc" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventTimeUtc" Text='<%# Bind("EventTimeUtc", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEventTimeUtc" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataEventTimeUtc" runat="server" Display="Dynamic" ControlToValidate="dataEventTimeUtc" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventTime" runat="server" Text="Event Time:" AssociatedControlID="dataEventTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventTime" Text='<%# Bind("EventTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEventTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataEventTime" runat="server" Display="Dynamic" ControlToValidate="dataEventTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventType" runat="server" Text="Event Type:" AssociatedControlID="dataEventType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventType" Text='<%# Bind("EventType") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEventType" runat="server" Display="Dynamic" ControlToValidate="dataEventType" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventSequence" runat="server" Text="Event Sequence:" AssociatedControlID="dataEventSequence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventSequence" Text='<%# Bind("EventSequence") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEventSequence" runat="server" Display="Dynamic" ControlToValidate="dataEventSequence" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEventSequence" runat="server" Display="Dynamic" ControlToValidate="dataEventSequence" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventOccurrence" runat="server" Text="Event Occurrence:" AssociatedControlID="dataEventOccurrence" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventOccurrence" Text='<%# Bind("EventOccurrence") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEventOccurrence" runat="server" Display="Dynamic" ControlToValidate="dataEventOccurrence" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEventOccurrence" runat="server" Display="Dynamic" ControlToValidate="dataEventOccurrence" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventCode" runat="server" Text="Event Code:" AssociatedControlID="dataEventCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventCode" Text='<%# Bind("EventCode") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEventCode" runat="server" Display="Dynamic" ControlToValidate="dataEventCode" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEventCode" runat="server" Display="Dynamic" ControlToValidate="dataEventCode" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEventDetailCode" runat="server" Text="Event Detail Code:" AssociatedControlID="dataEventDetailCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEventDetailCode" Text='<%# Bind("EventDetailCode") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEventDetailCode" runat="server" Display="Dynamic" ControlToValidate="dataEventDetailCode" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEventDetailCode" runat="server" Display="Dynamic" ControlToValidate="dataEventDetailCode" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMessage" runat="server" Text="Message:" AssociatedControlID="dataMessage" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMessage" Text='<%# Bind("Message") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationPath" runat="server" Text="Application Path:" AssociatedControlID="dataApplicationPath" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataApplicationPath" Text='<%# Bind("ApplicationPath") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataApplicationVirtualPath" runat="server" Text="Application Virtual Path:" AssociatedControlID="dataApplicationVirtualPath" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataApplicationVirtualPath" Text='<%# Bind("ApplicationVirtualPath") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMachineName" runat="server" Text="Machine Name:" AssociatedControlID="dataMachineName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMachineName" Text='<%# Bind("MachineName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMachineName" runat="server" Display="Dynamic" ControlToValidate="dataMachineName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequestUrl" runat="server" Text="Request Url:" AssociatedControlID="dataRequestUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRequestUrl" Text='<%# Bind("RequestUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExceptionType" runat="server" Text="Exception Type:" AssociatedControlID="dataExceptionType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExceptionType" Text='<%# Bind("ExceptionType") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDetails" runat="server" Text="Details:" AssociatedControlID="dataDetails" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDetails" Text='<%# Bind("Details") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


