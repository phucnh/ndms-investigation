﻿#region Using directives

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
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="AspnetApplications"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsAspnetApplicationsProvider: WsAspnetApplicationsProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="WsAspnetApplicationsProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsAspnetApplicationsProvider(string url): base(url){}
	}
}
