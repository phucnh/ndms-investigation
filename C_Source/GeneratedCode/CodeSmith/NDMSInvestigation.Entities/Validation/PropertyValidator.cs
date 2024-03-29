﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.ComponentModel;
#endregion Using directives

namespace NDMSInvestigation.Entities.Validation
{
    /// <summary>
    /// Property Validator
    /// </summary>
	public class PropertyValidator : Validator, IValidationIntegrationProxy
	{
		#region Fields
		private object _objectToValidate;
		#endregion Fields
		
		#region Properties
		private string _propertyName;
		/// <summary>
		/// Gets the property name for the object being validated.
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
		}
		
        /// <summary>
        /// Gets the default message template.
        /// </summary>
        /// <value>The default message template.</value>
		protected override string DefaultMessageTemplate
		{
			get { return null; }
		}

		#region IValidationIntegrationProxy properties
		/// <summary>
        /// Gets a value indicating whether [provides custom value conversion].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [provides custom value conversion]; otherwise, <c>false</c>.
        /// </value>
		public bool ProvidesCustomValueConversion
		{
			get { return false; }
		}

		private string _ruleset;
        /// <summary>
        /// Gets the ruleset.
        /// </summary>
        /// <value>The ruleset.</value>
		public string Ruleset
		{
			get { return _ruleset ?? string.Empty; }
		}

		private ValidationSpecificationSource _specificationSource;
		/// <summary>
        /// Gets the specification source.
        /// </summary>
        /// <value>The specification source.</value>
		[DefaultValue(ValidationSpecificationSource.Both)]
		public ValidationSpecificationSource SpecificationSource
		{
			get { return _specificationSource; }
		}

        /// <summary>
        /// Gets the name of the validated property.
        /// </summary>
        /// <value>The name of the validated property.</value>
		public string ValidatedPropertyName
		{
			get { return _propertyName; }
		}

		private Type _typeToValidate;
		/// <summary>
        /// Gets the validated type.
        /// </summary>
        /// <value>The validated type.</value>
		public Type ValidatedType
		{
			get { return _typeToValidate; }
		}
		#endregion IValidationIntegrationProxy properties

		#endregion Properties
		
		#region Constructors
		/// <summary>
		/// Creates an instance of PropertyValidator
		/// </summary>
		/// <param name="objectToValidate">The object to validate.</param>
		/// <param name="propertyName">The property for objectToValidate</param>
		public PropertyValidator(object objectToValidate, string propertyName)
			: this(objectToValidate, propertyName, null)
		{
		}

		/// <summary>
		/// Creates an instance of PropertyValidator
		/// </summary>
		/// <param name="objectToValidate">The object to validate.</param>
		/// <param name="propertyName">The property for objectToValidate</param>
		/// <param name="ruleset">The optional ruleset to use for validation.</param>
		public PropertyValidator(object objectToValidate, string propertyName, string ruleset)
			: this(objectToValidate, propertyName, ruleset, ValidationSpecificationSource.Both)
		{
		}

		/// <summary>
		/// Creates an instance of PropertyValidator
		/// </summary>
		/// <param name="objectToValidate">The object to validate.</param>
		/// <param name="propertyName">The property for objectToValidate</param>
		/// <param name="ruleset">The optional ruleset to use for validation.</param>
		/// <param name="specificationSource">Whether to use validation rules from attributes, config file, or both.</param>
		public PropertyValidator(object objectToValidate, string propertyName, string ruleset, ValidationSpecificationSource specificationSource)
			:base(null, null)
		{
			_ruleset = ruleset;
			_typeToValidate = objectToValidate.GetType();
			_propertyName = propertyName;
			_specificationSource = specificationSource;
			_objectToValidate = objectToValidate;
		}
		#endregion Constructors

		#region IValidationIntegrationProxy Members
        /// <summary>
        /// Gets the member value access builder.
        /// </summary>
        /// <returns></returns>
		public MemberValueAccessBuilder GetMemberValueAccessBuilder()
		{
			return new PropertyValidatorValueAccessBuilder();
		}
		
        /// <summary>
        /// Gets the raw value.
        /// </summary>
        /// <returns></returns>
		public object GetRawValue()
		{
			PropertyInfo propertyInfo = _typeToValidate.GetProperty(_propertyName);
			return propertyInfo.GetValue(_objectToValidate, null);
		}        
		
		/// <summary>
        /// Performs the custom value conversion.
        /// </summary>
        /// <param name="e">The <see cref="T:Microsoft.Practices.EnterpriseLibrary.Validation.Integration.ValueConvertEventArgs"/> instance containing the event data.</param>
		public void PerformCustomValueConversion(ValueConvertEventArgs e)
		{
			throw new NotSupportedException("The method or operation is not supported.");
		}

		#endregion

		#region Internal methods
		/// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueAccessFailureMessage">The value access failure message.</param>
        /// <returns></returns>
		internal bool GetValue(out object value, out string valueAccessFailureMessage)
		{
			ValidationIntegrationHelper helper = new ValidationIntegrationHelper(this);

			return helper.GetValue(out value, out valueAccessFailureMessage);
		}
		#endregion Internal methods

		#region Protected methods
        /// <summary>
        /// Does the validate.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The current target.</param>
        /// <param name="key">The key.</param>
        /// <param name="validationResults">The validation results.</param>
		protected override void DoValidate(object objectToValidate, object currentTarget, string key, ValidationResults validationResults)
		{
			Validator validator = new ValidationIntegrationHelper(this).GetValidator();

			if (validator != null)
			{
				ValidationResults results = validator.Validate(this);

				if (!results.IsValid)
				{
					validationResults.AddAllResults(results);
				}
			}
		}
		#endregion Protected methods
	}
}
