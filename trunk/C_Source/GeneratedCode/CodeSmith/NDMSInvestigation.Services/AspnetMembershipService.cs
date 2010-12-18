	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Entities.Validation;

using NDMSInvestigation.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace NDMSInvestigation.Services
{		
	/// <summary>
	/// An component type implementation of the 'aspnet_Membership' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AspnetMembershipService : NDMSInvestigation.Services.AspnetMembershipServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the AspnetMembershipService class.
		/// </summary>
		public AspnetMembershipService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace
