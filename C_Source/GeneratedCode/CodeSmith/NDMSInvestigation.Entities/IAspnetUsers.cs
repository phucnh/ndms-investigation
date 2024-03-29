﻿using System;
using System.ComponentModel;

namespace NDMSInvestigation.Entities
{
	/// <summary>
	///		The data structure representation of the 'aspnet_Users' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IAspnetUsers 
	{
		/// <summary>			
		/// UserId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "aspnet_Users"</remarks>
		System.Guid UserId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Guid OriginalUserId { get; set; }
			
		
		
		/// <summary>
		/// ApplicationId : 
		/// </summary>
		System.Guid  ApplicationId  { get; set; }
		
		/// <summary>
		/// UserName : 
		/// </summary>
		System.String  UserName  { get; set; }
		
		/// <summary>
		/// LoweredUserName : 
		/// </summary>
		System.String  LoweredUserName  { get; set; }
		
		/// <summary>
		/// MobileAlias : 
		/// </summary>
		System.String  MobileAlias  { get; set; }
		
		/// <summary>
		/// IsAnonymous : 
		/// </summary>
		System.Boolean  IsAnonymous  { get; set; }
		
		/// <summary>
		/// LastActivityDate : 
		/// </summary>
		System.DateTime  LastActivityDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties
	

		/// <summary>
		///	Holds a  AspnetMembership entity object
		///	which is related to this object through the relation _aspnetMembershipUserId
		/// </summary>
		AspnetMembership AspnetMembership { get; set; }
	

		/// <summary>
		///	Holds a  AspnetProfile entity object
		///	which is related to this object through the relation _aspnetProfileUserId
		/// </summary>
		AspnetProfile AspnetProfile { get; set; }

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table groupIdQuestionGroupsCollectionFromResults
		/// </summary>	
		TList<QuestionGroups> GroupIdQuestionGroupsCollection_From_Results { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _aspnetPersonalizationPerUserUserId
		/// </summary>	
		TList<AspnetPersonalizationPerUser> AspnetPersonalizationPerUserCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _aspnetUsersInRolesUserId
		/// </summary>	
		TList<AspnetUsersInRoles> AspnetUsersInRolesCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _resultsUserId
		/// </summary>	
		TList<Results> ResultsCollection {  get;  set;}	
	

		/// <summary>
		///	Holds a  CompanyDetails entity object
		///	which is related to this object through the relation _companyDetailsUserId
		/// </summary>
		CompanyDetails CompanyDetails { get; set; }

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table roleIdAspnetRolesCollectionFromAspnetUsersInRoles
		/// </summary>	
		TList<AspnetRoles> RoleIdAspnetRolesCollection_From_AspnetUsersInRoles { get; set; }	

		#endregion Data Properties

	}
}


