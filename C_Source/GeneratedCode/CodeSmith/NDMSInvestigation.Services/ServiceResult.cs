﻿
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation;

using NDMSInvestigation.Entities;
using NDMSInvestigation.Entities.Validation;

namespace NDMSInvestigation.Services
{
	/// <summary>
	/// The class provides a notification pattern for the processor execution.
	/// </summary>
	public class ServiceResult
	{
		private Dictionary<ProcessorBase, ValidationResults>  processBrokenRuleLists;
        private Dictionary<ProcessorBase, Exception> exceptionList = null;
		private List<IProcessorResult> processorResultList = null;

		/// <summary>
		///    Determines whethere the containing service, has errors.
		/// </summary>
		public virtual bool HasErrors
		{
			get
			{ 
				//unhandled exception
				if (ExceptionList.Count > 0)
					return true; 
					
				//or process just failed.
				foreach (IProcessorResult processorResult in ProcessorResultList)
				{
					if (processorResult == null || !processorResult.Result)
						return true;
				}
				return false;
			}
		}
	
		/// <summary>
		///    Provides a string of errors accumulated with a new line of delimeted errors.
		/// </summary>
		public virtual string Error
		{
			get
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				
				foreach (KeyValuePair<ProcessorBase, Exception> excPair in ExceptionList)
				{
					if (excPair.Value != null)
					{
						sb.Append(excPair.Value.Message.Replace("\n", ""));
						sb.Append("\n");
					}
				}
				
				for(int i = 0; i < ProcessorResultList.Count; i++)
				{
					if (processorResultList[i] == null)
						continue;
					foreach(KeyValuePair<Type, ValidationResults> kvp in processorResultList[i].BrokenRulesLists)
					{	
						foreach(ValidationResult result in kvp.Value)
						{
							sb.Append(result.Message);
						}
					}
				}
				
				return sb.ToString();
			}
		}
		
		/// <summary>
		///    Provides an aggregated group of BrokenRuleList for each of the executed processes.
		/// </summary>
		public virtual Dictionary<ProcessorBase, ValidationResults> ProcessBrokenRuleLists
		{
			get
			{
				if ( processBrokenRuleLists == null )
					processBrokenRuleLists = new Dictionary<ProcessorBase, ValidationResults>();

				return processBrokenRuleLists;
			}
		}
		
		/// <summary>
		///    Determines whethere the containing processs results that were enlisted in the service.
		/// </summary>
		public virtual List<IProcessorResult> ProcessorResultList
		{	
			get
			{
				if (processorResultList == null)
					processorResultList = new List<IProcessorResult>();
				
				return processorResultList;
			}
		}
		
		/// <summary>
		///	Provides the List of UnHandled Exceptions that occured during processing.
		/// </summary>
		///<value>A list of rules that were broken in the process</value>		
		public virtual Dictionary<ProcessorBase, Exception> ExceptionList 
		{	
			get
			{
				if(exceptionList == null)
					exceptionList = new Dictionary<ProcessorBase, Exception>();
                return exceptionList;
			}
		}
	}
}
