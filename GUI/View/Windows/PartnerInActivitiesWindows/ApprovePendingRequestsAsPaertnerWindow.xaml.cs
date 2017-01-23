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
        public ApprovePendingRequestsAsPaertnerWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
