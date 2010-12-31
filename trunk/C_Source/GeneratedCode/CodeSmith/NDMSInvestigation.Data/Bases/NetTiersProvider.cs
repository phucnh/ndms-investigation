
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using NDMSInvestigation.Entities;

#endregion

namespace NDMSInvestigation.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current CompanyDetailsProviderBase instance.
		///</summary>
		public virtual CompanyDetailsProviderBase CompanyDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetUsersInRolesProviderBase instance.
		///</summary>
		public virtual AspnetUsersInRolesProviderBase AspnetUsersInRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AnswerDetailsProviderBase instance.
		///</summary>
		public virtual AnswerDetailsProviderBase AnswerDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetWebEventEventsProviderBase instance.
		///</summary>
		public virtual AspnetWebEventEventsProviderBase AspnetWebEventEventsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionGroupsProviderBase instance.
		///</summary>
		public virtual QuestionGroupsProviderBase QuestionGroupsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionDetailsProviderBase instance.
		///</summary>
		public virtual QuestionDetailsProviderBase QuestionDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetUsersProviderBase instance.
		///</summary>
		public virtual AspnetUsersProviderBase AspnetUsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current QuestionAnswerProviderBase instance.
		///</summary>
		public virtual QuestionAnswerProviderBase QuestionAnswerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ResultsProviderBase instance.
		///</summary>
		public virtual ResultsProviderBase ResultsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetSchemaVersionsProviderBase instance.
		///</summary>
		public virtual AspnetSchemaVersionsProviderBase AspnetSchemaVersionsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetApplicationsProviderBase instance.
		///</summary>
		public virtual AspnetApplicationsProviderBase AspnetApplicationsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetMembershipProviderBase instance.
		///</summary>
		public virtual AspnetMembershipProviderBase AspnetMembershipProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetPathsProviderBase instance.
		///</summary>
		public virtual AspnetPathsProviderBase AspnetPathsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetPersonalizationAllUsersProviderBase instance.
		///</summary>
		public virtual AspnetPersonalizationAllUsersProviderBase AspnetPersonalizationAllUsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetRolesProviderBase instance.
		///</summary>
		public virtual AspnetRolesProviderBase AspnetRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetPersonalizationPerUserProviderBase instance.
		///</summary>
		public virtual AspnetPersonalizationPerUserProviderBase AspnetPersonalizationPerUserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TraceChangeProviderBase instance.
		///</summary>
		public virtual TraceChangeProviderBase TraceChangeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AspnetProfileProviderBase instance.
		///</summary>
		public virtual AspnetProfileProviderBase AspnetProfileProvider{get {throw new NotImplementedException();}}
		
		
	}
}
