using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace NDMSInvestigation.UserControl.Views
{
    public class DefaultViewPresenter : Presenter<IDefaultView>
    {
        private IUserControlController _controller;

        public DefaultViewPresenter([CreateNew] IUserControlController controller)
        {
            this._controller = controller;
        }
    }
}
