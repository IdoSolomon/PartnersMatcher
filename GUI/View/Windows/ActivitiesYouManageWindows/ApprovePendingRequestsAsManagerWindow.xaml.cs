using GUI.Controller;
using System.Windows;

namespace GUI.Windows.ActivitiesYouManageWindows
{
    /// <summary>
    /// Interaction logic for ApprovePendingRequestsAsManagerWindow.xaml
    /// </summary>
    public partial class ApprovePendingRequestsAsManagerWindow : Window
    {
        PartnersMatcherController controller;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public ApprovePendingRequestsAsManagerWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
