using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GUI.Controller;


namespace GUI.Windows.ActivitiesYouManageWindows
{
    /// <summary>
    /// Interaction logic for AddNewContractToActivityWindow.xaml
    /// </summary>
    public partial class AddNewContractToActivityWindow : Window
    {
        PartnersMatcherController controller;
        public AddNewContractToActivityWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
