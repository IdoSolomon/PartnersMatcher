using GUI.Controller;
using System.Windows;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for WatchYourPendingRequestsWindow.xaml
    /// </summary>
    public partial class WatchYourPendingRequestsWindow : Window
    {
        PartnersMatcherController controller;
        public WatchYourPendingRequestsWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
