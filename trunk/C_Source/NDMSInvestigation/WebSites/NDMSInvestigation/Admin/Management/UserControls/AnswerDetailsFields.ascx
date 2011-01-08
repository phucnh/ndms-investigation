<%@ Control Language="C#" ClassName="AnswerDetailsFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAnswerContent" runat="server" Text="Answer Content:" AssociatedControlID="dataAnswerContent" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAnswerContent" Text='<%# Bind("AnswerContent") %>'
                        MaxLength="1024"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAnswerMark" runat="server" Text="Answer Mark:" AssociatedControlID="dataAnswerMark" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAnswerMark" Text='<%# Bind("AnswerMark") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataAnswerMark" runat="server" Display="Dynamic" ControlToValidate="dataAnswerMark"
                        ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAnswerDescription" runat="server" Text="Answer Description:"
                        AssociatedControlID="dataAnswerDescription" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataAnswerDescription" Text='<%# Bind("AnswerDescription") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
