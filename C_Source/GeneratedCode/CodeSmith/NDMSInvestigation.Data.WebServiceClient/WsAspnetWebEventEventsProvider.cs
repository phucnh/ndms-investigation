#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;
using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;

#endregion

namespace NDMSInvestigation.Data.WebServiceClient
{
	///<summary>
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="AspnetWebEventEvents"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsAspnetWebEventEventsProvider: WsAspnetWebEventEventsProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="WsAspnetWebEventEventsProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsAspnetWebEventEventsProvider(string url): base(url){}
	}
}
