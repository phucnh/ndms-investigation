<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvestigationPage.aspx.cs"
    Inherits="NDMSInvestigation.Investigation.Views.InvestigationPage" Title="InvestigationPage"
    MasterPageFile="~/Shared/DefaultMaster.master" %>

<%@ Import Namespace="NDMSInvestigation.Entities" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        InvestigationPage</h1>
    <asp:HiddenField runat="Server" ID="hidUserId" Value='<%# NDMSInvestigation.WCSF.Utility.GetUserId() %>' />
    <%--<data:EntityDropDownList runat="Server" DataSourceID="QuestionAnswerDataSource" ID="ddlQuestionAnswer"
        OnDataBinding="ddlQuestionAnswer_DataBinding" OnDataBound="ddlQuestionAnswer_DataBound" />--%>
    <asp:Repeater runat="Server" DataSourceID="QuestionGroupDataSource" DataMember="GroupId"
        ID="rptQuestionGroup">
        <ItemTemplate>
            <div>
                <div>
                    <div>
                        <asp:HiddenField runat="Server" Value='<%# Bind("GroupId") %>' ID="hidGroupId" />
                        <asp:Label CssClass="group_text_name" runat="Server" ID="lblGroupName" Text='<%# Eval("GroupName") %>' />
                    </div>
                    <div>
                        <asp:Label CssClass="group_text_desc" runat="Server" ID="lblGroupDesc" Text='<%# Eval("GroupDescription") %>' />
                    </div>
                    <br />
                </div>
                <div>
                    <asp:Repeater runat="Server" ID="rptQuestionDetails" DataMember="QuestionId" DataSourceID="QuestionDetailsDataSource"
                        OnItemDataBound="rptQuestionDetails_ItemDataBound">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="Server" ID="hidQuestionId" Value='<%# Eval("QuestionId") %>' />
                                <asp:Label CssClass="question_text_content" runat="Server" ID="lblQuestionContent" Text='<%# Eval("QuestionContent") %>' /></div>
                            <div>
                                <asp:Label CssClass="question_text_suggest" runat="Server" ID="lblQuestionSuggest" Text='<%# Eval("QuestionSuggest") %>' /></div>
                            <br />
                            <%--<asp:Repeater runat="Server" ID="rptQuestionAnswer" DataSourceID="QuestionAnswerDataSource">
                                <ItemTemplate>
                                    <asp:HiddenField runat="Server" ID="hidAnswerId" Value='<%# Bind("AnswerId") %>' />
                                    <data:EntityDropDownList DataMember="AnswerId" AppendNullItem="false" DataTextField="AnswerContent"
                                        DataValueField="AnswerMark" runat="Server" ID="ddlAnswerDetails" DataSourceID="AnswerDetailsDataSource" />
                                    <data:AnswerDetailsDataSource runat="Server" ID="AnswerDetailsDataSource" SelectMethod="GetByAnswerId">
                                        <Parameters>
                                            <asp:ControlParameter runat="Server" ControlID="hidAnswerId" Name="AnswerId" Type="Int32" />
                                        </Parameters>
                                    </data:AnswerDetailsDataSource>
                                </ItemTemplate>
                            </asp:Repeater>--%>
                            <%--DataTextField='<%# GetAnswerContent(Int32.Parse(Eval("AnswerId").ToString())) %>'--%>
                            <%--<data:EntityDropDownList Width="800px" runat="Server" ID="ddlQuestionAnswer" />--%>
                            <asp:RadioButtonList runat="Server" ID="rblQuestionAnswer" />
                            <br />
                            <br />
                            <data:QuestionAnswerDataSource runat="Server" ID="QuestionAnswerDataSource" SelectMethod="GetByQuestionId">
                                <Parameters>
                                    <asp:ControlParameter runat="Server" ControlID="hidQuestionId" Name="QuestionId" />
                                </Parameters>
                            </data:QuestionAnswerDataSource>
                            <%--<%# DataBinder.Eval(((NDSMInvestigation.Entities.QuestionAnswer)Container.DataItem).AnswerIdSource,"AnswerContent") %>--%>
                            <%--<%# GetAnswerContent(Int32.Parse(Eval("AnswerId"))) %>--%>
                            <%--<cc1:DropDownExtender ID="ddlAnswerDetails_DropDownExtender" runat="server" DynamicServicePath=""
                                Enabled="True" TargetControlID="ddlQuestionAnswer">
                            </cc1:DropDownExtender>--%>
                        </ItemTemplate>
                    </asp:Repeater>
                    <data:QuestionDetailsDataSource ID="QuestionDetailsDataSource" runat="Server" SelectMethod="GetByGroupId">
                        <Parameters>
                            <asp:ControlParameter runat="Server" ControlID="hidGroupId" Name="GroupId" Type="Int32" />
                        </Parameters>
                    </data:QuestionDetailsDataSource>
                </div>
            </div>
            <hr />
            <br />
        </ItemTemplate>
    </asp:Repeater>
    <data:QuestionGroupsDataSource ID="QuestionGroupDataSource" runat="server" SelectMethod="GetAll">
        <Parameters>
            <data:CustomParameter Name="OrderByClause" Value="OrderNumber" ConvertEmptyStringToNull="false" />
        </Parameters>
    </data:QuestionGroupsDataSource>
    <br />
    <br />
    <asp:Button  runat="Server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>
