﻿using System;
using System.ComponentModel;

namespace NDMSInvestigation.Entities
{
	/// <summary>
	///		The data structure representation of the 'Result' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IResult 
	{
		/// <summary>			
		/// UserId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Result"</remarks>
		System.Guid UserId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Guid OriginalUserId { get; set; }
			
		/// <summary>			
		/// GroupId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Result"</remarks>
		System.Int32 GroupId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalGroupId { get; set; }
			
		
		
		/// <summary>
		/// GroupMark : 
		/// </summary>
		System.Int32?  GroupMark  { get; set; }
		
		/// <summary>
		/// UpdateDay : 
		/// </summary>
		System.DateTime?  UpdateDay  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


