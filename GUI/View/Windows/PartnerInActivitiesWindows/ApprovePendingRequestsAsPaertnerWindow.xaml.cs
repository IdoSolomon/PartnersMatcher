using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for ApprovePendingRequestsAsPaertnerWindow.xaml
    /// </summary>
    public partial class ApprovePendingRequestsAsPaertnerWindow : Window
    {
        PartnersMatcherController controller;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public ApprovePendingRequestsAsPaertnerWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
