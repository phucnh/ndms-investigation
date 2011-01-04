#region Using directives

using System;

#endregion

namespace NDMSInvestigation.Entities
{	
	///<summary>
	/// An object representation of the 'CompanyDetails' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class CompanyDetails : CompanyDetailsBase
	{		
		#region Constructors

		///<summary>
		/// Creates a new <see cref="CompanyDetails"/> instance.
		///</summary>
		public CompanyDetails():base(){}

        public CompanyDetails(
            Guid userId,
            string companyName,
            string phone,
            string fax,
            string email,
            string address,
            int employeeNumber,
            string director,
            string country,
            string city,
            string district
            )
            : base()
        {
            base.UserId = userId;
            base.CompanyName = companyName;
            base.Phone = phone;
            base.Fax = fax;
            base.Email = email;
            base.Address = address;
            base.EmployeeNumber = employeeNumber;
            base.Director = director;
            base.Country = country;
            base.City = city;
            base.District = district;
        }
		
		#endregion
	}
}
