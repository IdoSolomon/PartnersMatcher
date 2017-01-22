using System.Windows;
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
