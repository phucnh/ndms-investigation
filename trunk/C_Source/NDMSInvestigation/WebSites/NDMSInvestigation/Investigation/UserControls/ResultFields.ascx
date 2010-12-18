<%@ Control Language="C#" ClassName="ResultFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataGroupMark" runat="server" Text="Group Mark:" AssociatedControlID="dataGroupMark" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataGroupMark" Text='<%# Bind("GroupMark") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataGroupMark" runat="server" Display="Dynamic" ControlToValidate="dataGroupMark"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <%--<tr>
                <td class="literal">
                    <asp:Label ID="lbldataUpdateDay" runat="server" Text="Update Day:" AssociatedControlID="dataUpdateDay" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataUpdateDay" Text='<%# Bind("UpdateDay", "{0:d}") %>'
                        MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateDay" runat="server"
                            SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
                </td>
            </tr>--%>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdAspnetUsersDataSource"
                        DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:AspnetUsersDataSource ID="UserIdAspnetUsersDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataGroupId" runat="server" Text="Group Id:" AssociatedControlID="dataGroupId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataGroupId" DataSourceID="GroupIdQuestionGroupDataSource"
                        DataTextField="GroupName" DataValueField="GroupId" SelectedValue='<%# Bind("GroupId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:QuestionGroupDataSource ID="GroupIdQuestionGroupDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
