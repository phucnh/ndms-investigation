﻿#region Using Directives
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Data;
#endregion

namespace NDMSInvestigation.Services
{
	/// <summary>
	/// The base class that each component business domain service of the model implements.
	/// </summary>
	[CLSCompliant(true)]
	public abstract partial class ServiceViewBase<Entity> : ServiceViewBaseCore<Entity>
        where Entity : new()
	{

	}
}
