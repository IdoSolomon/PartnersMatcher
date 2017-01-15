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

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for DomainSelectionWindow.xaml
    /// </summary>
    public partial class DomainSelectionWindow : Window
    {
        PartnersMatcherController controller;
        public DomainSelectionWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
