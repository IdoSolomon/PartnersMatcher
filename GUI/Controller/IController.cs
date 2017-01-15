using GUI.Model;
using GUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public interface IController
    {
        void SetModel(IModel model);
        void SetView(IView view);

        //move calling to model methods here
    }
}
