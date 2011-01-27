using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace NDMSInvestigation.Reports.Views
{
    public class DefaultViewPresenter : Presenter<IDefaultView>
    {
        private IReportsController _controller;

        public DefaultViewPresenter([CreateNew] IReportsController controller)
        {
            this._controller = controller;
        }

    }
}
