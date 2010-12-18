<%@ Control Language="C#" ClassName="QuestionDetailsFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <%--<tr>
                <td class="literal">
                    <asp:Label ID="lbldataGroupId" runat="server" Text="Group Id:" AssociatedControlID="dataGroupId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataGroupId" DataSourceID="GroupIdQuestionGroupDataSource"
                        DataTextField="GroupName" DataValueField="GroupId" SelectedValue='<%# Bind("GroupId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                    <data:QuestionGroupDataSource ID="GroupIdQuestionGroupDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>--%>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataOrderNumber" runat="server" Text="Order Number:" AssociatedControlID="dataOrderNumber" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataOrderNumber" Text='<%# Bind("OrderNumber") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataOrderNumber" runat="server" Display="Dynamic" ControlToValidate="dataOrderNumber"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataQuestionContent" runat="server" Text="Question Content:" AssociatedControlID="dataQuestionContent" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataQuestionContent" Text='<%# Bind("QuestionContent") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataQuestionSuggest" runat="server" Text="Question Suggest:" AssociatedControlID="dataQuestionSuggest" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataQuestionSuggest" Text='<%# Bind("QuestionSuggest") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataQuestionDescription" runat="server" Text="Question Description:"
                        AssociatedControlID="dataQuestionDescription" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataQuestionDescription" Text='<%# Bind("QuestionDescription") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
