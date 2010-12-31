using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices.CompositeWeb.Interfaces;
using Microsoft.Practices.CompositeWeb.Services;
using Microsoft.Practices.CompositeWeb.Configuration;
using Microsoft.Practices.CompositeWeb.EnterpriseLibrary.Services;

namespace NDMSInvestigation.Admin
{
    public class AdminModuleInitializer : ModuleInitializer
    {
        private const string AuthorizationSection = "compositeWeb/authorization";

        public override void Load(CompositionContainer container)
        {
            base.Load(container);

            AddGlobalServices(container.Parent.Services);
            AddModuleServices(container.Services);
            RegisterSiteMapInformation(container.Services.Get<ISiteMapBuilderService>(true));

            container.RegisterTypeMapping<IAdminController, AdminController>();
        }

        protected virtual void AddGlobalServices(IServiceCollection globalServices)
        {
            // TODO: add a service that will be visible to any module
        }

        protected virtual void AddModuleServices(IServiceCollection moduleServices)
        {
            // TODO: add a service that will be visible to this module
        }

        protected virtual void RegisterSiteMapInformation(ISiteMapBuilderService siteMapBuilderService)
        {
            SiteMapNodeInfo moduleNode = new SiteMapNodeInfo("Admin", "~/Admin/Default.aspx", "Admin");
            siteMapBuilderService.AddNode(moduleNode);

            SiteMapNodeInfo managementNode = new SiteMapNodeInfo("Management", "~/Admin/Management/Default.aspx", "Management");
            siteMapBuilderService.AddNode(managementNode);

            //add modulenode childs
            SiteMapNodeInfo allUsersNode = new SiteMapNodeInfo("AllUser", "~/Admin/admin/access/users.aspx", "All User");
            siteMapBuilderService.AddNode(allUsersNode, moduleNode);
            SiteMapNodeInfo addUsersNode = new SiteMapNodeInfo("AddUser", "~/Admin/admin/access/add_user.aspx", "Add User");
            siteMapBuilderService.AddNode(addUsersNode, moduleNode);
            SiteMapNodeInfo rolesNode = new SiteMapNodeInfo("Roles", "~/Admin/admin/access/roles.aspx", "Roles");
            siteMapBuilderService.AddNode(rolesNode, moduleNode);
            SiteMapNodeInfo usersByRoleNode = new SiteMapNodeInfo("usersByRole", "~/Admin/admin/access/users_by_role.aspx", "Users By Role");
            siteMapBuilderService.AddNode(usersByRoleNode, moduleNode);
            SiteMapNodeInfo accessRulesNode = new SiteMapNodeInfo("accessRules", "~/Admin/admin/access/access_rules.aspx", "Access Rules Node");
            siteMapBuilderService.AddNode(accessRulesNode, moduleNode);
            SiteMapNodeInfo accessRuleSummaryNode = new SiteMapNodeInfo("accessRuleSummary", "~/Admin/admin/access/access_rule_summary.aspx", "Access Rule Summary");
            siteMapBuilderService.AddNode(accessRuleSummaryNode, moduleNode);

            //add managementnode childs
            SiteMapNodeInfo questionGroupNode = new SiteMapNodeInfo("QuestionGroup", "~/Admin/Management/QuestionGroup.aspx", "Question Group");
            siteMapBuilderService.AddNode(questionGroupNode, managementNode);
            SiteMapNodeInfo questionGroupEditNode = new SiteMapNodeInfo("QuestionGroupEdit", "~/Admin/Management/QuestionGroupEdit.aspx", "Question Group Edit");
            siteMapBuilderService.AddNode(questionGroupEditNode, questionGroupNode);

            SiteMapNodeInfo questionDetailsNode = new SiteMapNodeInfo("QuestionDetails", "~/Admin/Management/QuestionDetails.aspx", "Question Details");
            siteMapBuilderService.AddNode(questionDetailsNode, managementNode);
            SiteMapNodeInfo questionDetailsEditNode = new SiteMapNodeInfo("QuestionDetailsEdit", "~/Admin/Management/QuestionDetailsEdit.aspx", "Question Details Edit");
            siteMapBuilderService.AddNode(questionDetailsEditNode, questionDetailsNode);

            SiteMapNodeInfo answerDetailsNode = new SiteMapNodeInfo("AnswerDetails", "~/Admin/Management/AnswerDetails.aspx", "Answer Details");
            siteMapBuilderService.AddNode(answerDetailsNode, managementNode);
            SiteMapNodeInfo answerDetailsEditNode = new SiteMapNodeInfo("AnswerDetailsEdit", "~/Admin/Management/AnswerDetailsEdit.aspx", "Answer Details Edit");
            siteMapBuilderService.AddNode(answerDetailsEditNode, answerDetailsNode);


            SiteMapNodeInfo questionAnswerNode = new SiteMapNodeInfo("QuestionAnswer", "~/Admin/Management/QuestionAnswer.aspx", "Question Answer");
            siteMapBuilderService.AddNode(questionAnswerNode, managementNode);
            SiteMapNodeInfo questionAnswerEditNode = new SiteMapNodeInfo("QuestionAnswerEdit", "~/Admin/Management/QuestionAnswerEdit.aspx", "Question Answer Edit");
            siteMapBuilderService.AddNode(questionAnswerEditNode, questionAnswerNode);

            SiteMapNodeInfo resultNode = new SiteMapNodeInfo("Result", "~/Admin/Management/Result.aspx", "Results");
            siteMapBuilderService.AddNode(resultNode, managementNode);
            SiteMapNodeInfo userNode = new SiteMapNodeInfo("CompanyDetails", "~/Admin/Management/CompanyDetails.aspx", "Company Details");
            siteMapBuilderService.AddNode(userNode, managementNode);

            // TODO: register other site map nodes that Admin module might provide            
        }

        public override void Configure(IServiceCollection services, System.Configuration.Configuration moduleConfiguration)
        {
            IAuthorizationRulesService authorizationRuleService = services.Get<IAuthorizationRulesService>();
            if (authorizationRuleService != null)
            {
                AuthorizationConfigurationSection authorizationSection = moduleConfiguration.GetSection(AuthorizationSection) as AuthorizationConfigurationSection;
                if (authorizationSection != null)
                {
                    foreach (AuthorizationRuleElement ruleElement in authorizationSection.ModuleRules)
                    {
                        authorizationRuleService.RegisterAuthorizationRule(ruleElement.AbsolutePath, ruleElement.RuleName);
                    }
                }
            }
        }
    }
}
