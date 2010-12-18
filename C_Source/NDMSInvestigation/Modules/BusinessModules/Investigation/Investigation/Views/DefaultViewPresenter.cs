using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeWeb;

namespace NDMSInvestigation.Investigation.Views
{
    public class DefaultViewPresenter : Presenter<IDefaultView>
    {
        private IInvestigationController _controller;

        public DefaultViewPresenter([CreateNew] IInvestigationController controller)
        {
            this._controller = controller;
        }
    }
}
