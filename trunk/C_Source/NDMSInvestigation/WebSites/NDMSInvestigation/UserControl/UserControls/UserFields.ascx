<%@ Control Language="C#" ClassName="UserFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <div>
            <span>
                <div>
                    <asp:Label ID="lbldataCompanyName" runat="server" Text="Company Name:" AssociatedControlID="dataCompanyName" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataCompanyName" Text='<%# Bind("CompanyName") %>'
                        TextMode="SingleLine" Width="250px"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataDirector" runat="server" Text="Director:" AssociatedControlID="dataDirector" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataDirector" Text='<%# Bind("Director") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataEmployeeNumber" runat="server" Text="Employee Number:" AssociatedControlID="dataEmployeeNumber" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataEmployeeNumber" Text='<%# Bind("EmployeeNumber") %>'></asp:TextBox>
                    <asp:RangeValidator ID="RangeVal_dataEmployeeNumber" runat="server" Display="Dynamic"
                        ControlToValidate="dataEmployeeNumber" ErrorMessage="Invalid value" MaximumValue="2147483647"
                        MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataPhone" runat="server" Text="Phone:" AssociatedControlID="dataPhone" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataPhone" Text='<%# Bind("Phone") %>' MaxLength="32"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataFax" runat="server" Text="Fax:" AssociatedControlID="dataFax" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataFax" Text='<%# Bind("Fax") %>' MaxLength="32"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataCountry" runat="server" Text="Country:" AssociatedControlID="dataCountry" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataCountry" Text='<%# Bind("Country") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataCity" Text='<%# Bind("City") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataDistrict" runat="server" Text="District:" AssociatedControlID="dataDistrict" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataDistrict" Text='<%# Bind("District") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox>
                </div>
            </span><span>
                <div>
                    <asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>' TextMode="SingleLine"
                        Width="250px"></asp:TextBox>
                </div>
            </span>
            <%--<span>
                <div>
                    <asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" />
                </div>
                <div>
                    <data:EntityDropDownList runat="server" ID="dataUserId" DataSourceID="UserIdAspnetUsersDataSource"
                        DataTextField="UserName" DataValueField="UserId" SelectedValue='<%# Bind("UserId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:AspnetUsersDataSource ID="UserIdAspnetUsersDataSource" runat="server" SelectMethod="GetAll" />
                </div>
            </span>--%>
        </div>
    </ItemTemplate>
</asp:FormView>
