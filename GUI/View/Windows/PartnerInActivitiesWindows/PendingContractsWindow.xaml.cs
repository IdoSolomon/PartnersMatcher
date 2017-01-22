using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for PendingContractsWindow.xaml
    /// </summary>
    public partial class PendingContractsWindow : Window
    {
        PartnersMatcherController controller;
        public PendingContractsWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
