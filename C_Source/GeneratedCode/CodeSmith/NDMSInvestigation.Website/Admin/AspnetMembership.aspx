
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetMembership.aspx.cs" Inherits="AspnetMembership" Title="AspnetMembership List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Membership List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AspnetMembershipDataSource"
				DataKeyNames="UserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AspnetMembership.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="LastPasswordChangedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Password Changed Date" SortExpression="[LastPasswordChangedDate]"  />
				<asp:BoundField DataField="LastLockoutDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Lockout Date" SortExpression="[LastLockoutDate]"  />
				<asp:BoundField DataField="LastLoginDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Login Date" SortExpression="[LastLoginDate]"  />
				<data:BoundRadioButtonField DataField="IsLockedOut" HeaderText="Is Locked Out" SortExpression="[IsLockedOut]"  />
				<asp:BoundField DataField="CreateDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Create Date" SortExpression="[CreateDate]"  />
				<asp:BoundField DataField="FailedPasswordAnswerAttemptWindowStart" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Failed Password Answer Attempt Window Start" SortExpression="[FailedPasswordAnswerAttemptWindowStart]"  />
				<asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression=""  />
				<asp:BoundField DataField="FailedPasswordAnswerAttemptCount" HeaderText="Failed Password Answer Attempt Count" SortExpression="[FailedPasswordAnswerAttemptCount]"  />
				<asp:BoundField DataField="FailedPasswordAttemptCount" HeaderText="Failed Password Attempt Count" SortExpression="[FailedPasswordAttemptCount]"  />
				<asp:BoundField DataField="FailedPasswordAttemptWindowStart" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Failed Password Attempt Window Start" SortExpression="[FailedPasswordAttemptWindowStart]"  />
				<data:BoundRadioButtonField DataField="IsApproved" HeaderText="Is Approved" SortExpression="[IsApproved]"  />
				<asp:BoundField DataField="PasswordFormat" HeaderText="Password Format" SortExpression="[PasswordFormat]"  />
				<asp:BoundField DataField="PasswordSalt" HeaderText="Password Salt" SortExpression="[PasswordSalt]"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]"  />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="PasswordQuestion" HeaderText="Password Question" SortExpression="[PasswordQuestion]"  />
				<asp:BoundField DataField="PasswordAnswer" HeaderText="Password Answer" SortExpression="[PasswordAnswer]"  />
				<asp:BoundField DataField="LoweredEmail" HeaderText="Lowered Email" SortExpression="[LoweredEmail]"  />
				<asp:BoundField DataField="MobilePin" HeaderText="Mobile Pin" SortExpression="[MobilePIN]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AspnetMembership Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAspnetMembership" OnClientClick="javascript:location.href='AspnetMembershipEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:AspnetMembershipDataSource ID="AspnetMembershipDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetMembershipProperty Name="AspnetApplications"/> 
					<data:AspnetMembershipProperty Name="AspnetUsers"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AspnetMembershipDataSource>
	    		
</asp:Content>



