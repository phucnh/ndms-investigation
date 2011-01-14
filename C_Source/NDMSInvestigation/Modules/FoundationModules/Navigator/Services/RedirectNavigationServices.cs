using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace NDMSInvestigation.Navigator.Services
{
    public class RedirectNavigationServices : INavigator
    {
        public void NavigateUrl(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }
    }
}
