using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for WatchYourPaymentsHistoryWindow.xaml
    /// </summary>
    public partial class WatchYourPaymentsHistoryWindow : Window
    {
        PartnersMatcherController controller;
        public WatchYourPaymentsHistoryWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
