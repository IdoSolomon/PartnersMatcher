using PartnersMatcher;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            PartnersMatcherModel model = new PartnersMatcherModel();
            LoginWindow main = new LoginWindow(ref model);
            main.Show();
        }
    }
}
