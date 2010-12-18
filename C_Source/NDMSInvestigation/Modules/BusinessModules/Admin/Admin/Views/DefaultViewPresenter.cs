using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace NDMSInvestigation.Admin.Views
{
    public class DefaultViewPresenter : Presenter<IDefaultView>
    {
        private IAdminController _controller;

        public DefaultViewPresenter([CreateNew] IAdminController controller)
        {
            this._controller = controller;
        }
    }
}
