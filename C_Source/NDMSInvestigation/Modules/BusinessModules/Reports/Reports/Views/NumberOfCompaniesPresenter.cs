using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;
using Microsoft.Practices;

using NDMSInvestigation.Services;
using NDMSInvestigation.Entities;

namespace NDMSInvestigation.Reports.Views
{
    public class NumberOfCompaniesPresenter : Presenter<INumberOfCompaniesView>
    {

        // NOTE: Uncomment the following code if you want ObjectBuilder to inject the module controller
        //       The code will not work in the Shell module, as a module controller is not created by default
        //
        private IReportsController _controller;
        private CompanyDetailsService _companyDetailsService;


        /// <summary>
        /// Initializes a new instance of the <see cref="NumberOfCompaniesPresenter"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="companyDetailsService">The company details service.</param>
        public NumberOfCompaniesPresenter(
             [CreateNew] IReportsController controller,
             [ServiceDependency] CompanyDetailsService companyDetailsService)
        {
         	_controller = controller;
             _companyDetailsService = companyDetailsService;
        }

        public override void OnViewLoaded()
        {
            View.BindChartData();
        }

        public virtual void BindChartData()
        {
            View.BindChartData();
        }

        public override void OnViewInitialized()
        {
            // TODO: Implement code that will be executed the first time the view loads
        }

        /// <summary>
        /// Gets the number of companies.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfCompanies()
        {
            return _companyDetailsService.GetAll().Count;
        }

        public int GetNumberOfCompaniesInSpecificYear(int specificYear)
        {
            TList<CompanyDetails> companyDetailsCollection = _companyDetailsService.GetAll();
            Microsoft.Practices.CompositeWeb.Utility.Guard.ArgumentNotNull(companyDetailsCollection, "companyDetaislCollection");

            TList<CompanyDetails> companyDetailsByYear = new TList<CompanyDetails>();

            foreach (CompanyDetails companyDetais in companyDetailsCollection)
            {
                if ((companyDetais.CreatedDate == null) &&
                    (!companyDetais.CreatedDate.HasValue))
                    continue;

                DateTime _dateTime = companyDetais.CreatedDate.Value;

                if (_dateTime.Year == specificYear)
                    companyDetailsByYear.Add(companyDetais);
            }

            return companyDetailsByYear.Count;
        }

        /// <summary>
        /// Calculates the year array.
        /// </summary>
        /// <param name="numberOfYears">The number of years.</param>
        /// <returns></returns>
        public List<int> CalculateYears(int numberOfYears)
        {
            if (numberOfYears < 1) return null;

            List<int> years = new List<int>();
            DateTime _now = DateTime.Now;

            do
            {
                years.Add(DateTime.Now.Year - numberOfYears + 1);
            } while (--numberOfYears > 0);

            return years;
        }

        public List<int> CalculateCompanies(int numberOfYears)
        {
            if (numberOfYears < 1) return null;

            List<int> companies = new List<int>();
            DateTime _now = DateTime.Now;

            do
            {
                companies.Add(
                    GetNumberOfCompaniesInSpecificYear(DateTime.Now.Year - numberOfYears + 1));
            } while (--numberOfYears > 0);

            return companies;
        }

        // TODO: Handle other view events and set state in the view
    }
}




