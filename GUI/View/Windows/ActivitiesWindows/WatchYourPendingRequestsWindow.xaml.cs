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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public WatchYourPendingRequestsWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
