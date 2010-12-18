<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AspnetApplicationsEdit.aspx.cs" Inherits="AspnetApplicationsEdit" Title="AspnetApplications Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Aspnet Applications - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ApplicationId" runat="server" DataSourceID="AspnetApplicationsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetApplicationsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AspnetApplicationsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AspnetApplications not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AspnetApplicationsDataSource ID="AspnetApplicationsDataSource" runat="server"
			SelectMethod="GetByApplicationId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ApplicationId" QueryStringField="ApplicationId" Type="String" />

			</Parameters>
		</data:AspnetApplicationsDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewAspnetPaths1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAspnetPaths1_SelectedIndexChanged"			 			 
			DataSourceID="AspnetPathsDataSource1"
			DataKeyNames="PathId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AspnetPaths.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<asp:BoundField DataField="Path" HeaderText="Path" SortExpression="[Path]" />				
				<asp:BoundField DataField="LoweredPath" HeaderText="Lowered Path" SortExpression="[LoweredPath]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Aspnet Paths Found! </b>
				<asp:HyperLink runat="server" ID="hypAspnetPaths" NavigateUrl="~/admin/AspnetPathsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AspnetPathsDataSource ID="AspnetPathsDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetPathsProperty Name="AspnetApplications"/> 
					<%--<data:AspnetPathsProperty Name="AspnetPersonalizationPerUserCollection" />--%>
					<%--<data:AspnetPathsProperty Name="AspnetPersonalizationAllUsers" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AspnetPathsFilter  Column="ApplicationId" QueryStringField="ApplicationId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AspnetPathsDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewAspnetMembership2" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAspnetMembership2_SelectedIndexChanged"			 			 
			DataSourceID="AspnetMembershipDataSource2"
			DataKeyNames="UserId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AspnetMembership.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="AspnetUsersEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="UserName" />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]" />				
				<asp:BoundField DataField="PasswordFormat" HeaderText="Password Format" SortExpression="[PasswordFormat]" />				
				<asp:BoundField DataField="PasswordSalt" HeaderText="Password Salt" SortExpression="[PasswordSalt]" />				
				<asp:BoundField DataField="MobilePin" HeaderText="Mobile Pin" SortExpression="[MobilePIN]" />				
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />				
				<asp:BoundField DataField="LoweredEmail" HeaderText="Lowered Email" SortExpression="[LoweredEmail]" />				
				<asp:BoundField DataField="PasswordQuestion" HeaderText="Password Question" SortExpression="[PasswordQuestion]" />				
				<asp:BoundField DataField="PasswordAnswer" HeaderText="Password Answer" SortExpression="[PasswordAnswer]" />				
				<asp:BoundField DataField="IsApproved" HeaderText="Is Approved" SortExpression="[IsApproved]" />				
				<asp:BoundField DataField="IsLockedOut" HeaderText="Is Locked Out" SortExpression="[IsLockedOut]" />				
				<asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="[CreateDate]" />				
				<asp:BoundField DataField="LastLoginDate" HeaderText="Last Login Date" SortExpression="[LastLoginDate]" />				
				<asp:BoundField DataField="LastPasswordChangedDate" HeaderText="Last Password Changed Date" SortExpression="[LastPasswordChangedDate]" />				
				<asp:BoundField DataField="LastLockoutDate" HeaderText="Last Lockout Date" SortExpression="[LastLockoutDate]" />				
				<asp:BoundField DataField="FailedPasswordAttemptCount" HeaderText="Failed Password Attempt Count" SortExpression="[FailedPasswordAttemptCount]" />				
				<asp:BoundField DataField="FailedPasswordAttemptWindowStart" HeaderText="Failed Password Attempt Window Start" SortExpression="[FailedPasswordAttemptWindowStart]" />				
				<asp:BoundField DataField="FailedPasswordAnswerAttemptCount" HeaderText="Failed Password Answer Attempt Count" SortExpression="[FailedPasswordAnswerAttemptCount]" />				
				<asp:BoundField DataField="FailedPasswordAnswerAttemptWindowStart" HeaderText="Failed Password Answer Attempt Window Start" SortExpression="[FailedPasswordAnswerAttemptWindowStart]" />				
				<asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="[Comment]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Aspnet Membership Found! </b>
				<asp:HyperLink runat="server" ID="hypAspnetMembership" NavigateUrl="~/admin/AspnetMembershipEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AspnetMembershipDataSource ID="AspnetMembershipDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetMembershipProperty Name="AspnetApplications"/> 
					<data:AspnetMembershipProperty Name="AspnetUsers"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AspnetMembershipFilter  Column="ApplicationId" QueryStringField="ApplicationId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AspnetMembershipDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewAspnetUsers3" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAspnetUsers3_SelectedIndexChanged"			 			 
			DataSourceID="AspnetUsersDataSource3"
			DataKeyNames="UserId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AspnetUsers.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]" />				
				<asp:BoundField DataField="LoweredUserName" HeaderText="Lowered User Name" SortExpression="[LoweredUserName]" />				
				<asp:BoundField DataField="MobileAlias" HeaderText="Mobile Alias" SortExpression="[MobileAlias]" />				
				<asp:BoundField DataField="IsAnonymous" HeaderText="Is Anonymous" SortExpression="[IsAnonymous]" />				
				<asp:BoundField DataField="LastActivityDate" HeaderText="Last Activity Date" SortExpression="[LastActivityDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Aspnet Users Found! </b>
				<asp:HyperLink runat="server" ID="hypAspnetUsers" NavigateUrl="~/admin/AspnetUsersEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AspnetUsersDataSource ID="AspnetUsersDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetUsersProperty Name="AspnetApplications"/> 
					<%--<data:AspnetUsersProperty Name="AspnetMembership" />--%>
					<%--<data:AspnetUsersProperty Name="AspnetProfile" />--%>
					<%--<data:AspnetUsersProperty Name="GroupIdQuestionGroupCollection_From_Result" />--%>
					<%--<data:AspnetUsersProperty Name="AspnetPersonalizationPerUserCollection" />--%>
					<%--<data:AspnetUsersProperty Name="AspnetUsersInRolesCollection" />--%>
					<%--<data:AspnetUsersProperty Name="User" />--%>
					<%--<data:AspnetUsersProperty Name="ResultCollection" />--%>
					<%--<data:AspnetUsersProperty Name="RoleIdAspnetRolesCollection_From_AspnetUsersInRoles" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AspnetUsersFilter  Column="ApplicationId" QueryStringField="ApplicationId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AspnetUsersDataSource>		
		
		<br />
		<data:EntityGridView ID="GridViewAspnetRoles4" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewAspnetRoles4_SelectedIndexChanged"			 			 
			DataSourceID="AspnetRolesDataSource4"
			DataKeyNames="RoleId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AspnetRoles.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Application Id" DataNavigateUrlFormatString="AspnetApplicationsEdit.aspx?ApplicationId={0}" DataNavigateUrlFields="ApplicationId" DataContainer="ApplicationIdSource" DataTextField="ApplicationName" />
				<asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="[RoleName]" />				
				<asp:BoundField DataField="LoweredRoleName" HeaderText="Lowered Role Name" SortExpression="[LoweredRoleName]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Aspnet Roles Found! </b>
				<asp:HyperLink runat="server" ID="hypAspnetRoles" NavigateUrl="~/admin/AspnetRolesEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AspnetRolesDataSource ID="AspnetRolesDataSource4" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AspnetRolesProperty Name="AspnetApplications"/> 
					<%--<data:AspnetRolesProperty Name="AspnetUsersInRolesCollection" />--%>
					<%--<data:AspnetRolesProperty Name="UserIdAspnetUsersCollection_From_AspnetUsersInRoles" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AspnetRolesFilter  Column="ApplicationId" QueryStringField="ApplicationId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AspnetRolesDataSource>		
		
		<br />
		

</asp:Content>

