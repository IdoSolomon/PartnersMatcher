using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Controller;
using GUI.View;
using GUI.Model;

namespace PartnersMatcher.Controller
{
    public class PartnersMatcherController : IController
    {
        private IModel m_model;
        private IView m_view;

        public void SetModel(IModel model)
        {
            m_model = model;
        }

        public void SetView(IView view)
        {
            m_view = view;
        }
    }
}
