using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace NDMSInvestigation.WCSF
{
    public class Utility
    {
        /// <summary>
        /// Gets the user id.
        /// </summary>
        /// <returns></returns>
        public static String GetUserId()
        {
            if (Membership.GetUser() != null)
                return Membership.GetUser().ProviderUserKey.ToString();

            return string.Empty;
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="controlID">The control ID.</param>
        /// <returns></returns>
        public static Control GetControl(Page page, String controlID)
        {
            System.Collections.Generic.IList<Control> foundControl = NDMSInvestigation.Web.UI.FormUtil.GetControls(page, controlID);

            if (foundControl.Count != 0)
            {
                return foundControl[0];
            }
            else
            {
                return null;
            }
        }
    }
}
