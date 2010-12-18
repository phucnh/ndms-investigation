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
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="User"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsUserProvider: WsUserProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="WsUserProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsUserProvider(string url): base(url){}
	}
}
