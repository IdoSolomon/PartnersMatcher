using PartnersMatcher;
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

namespace GUI.Windows.ActivitiesYouManageWindows
{
    /// <summary>
    /// Interaction logic for AddNewContractToActivityWindow.xaml
    /// </summary>
    public partial class AddNewContractToActivityWindow : Window
    {
        PartnersMatcherModel model;
        public AddNewContractToActivityWindow(ref PartnersMatcherModel PMModel)
        {
            InitializeComponent();
            model = PMModel;
        }
    }
}
