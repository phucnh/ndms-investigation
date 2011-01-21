﻿using System;
using System.ComponentModel;

namespace NDMSInvestigation.Entities
{
	/// <summary>
	///		The data structure representation of the 'aspnet_PersonalizationAllUsers' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IAspnetPersonalizationAllUsers 
	{
		/// <summary>			
		/// PathId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "aspnet_PersonalizationAllUsers"</remarks>
		System.Guid PathId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Guid OriginalPathId { get; set; }
			
		
		
		/// <summary>
		/// PageSettings : 
		/// </summary>
		System.Byte[]  PageSettings  { get; set; }
		
		/// <summary>
		/// LastUpdatedDate : 
		/// </summary>
		System.DateTime  LastUpdatedDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

