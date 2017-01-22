using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for WatchAllActivitiesYourePartnerInWindow.xaml
    /// </summary>
    public partial class WatchAllActivitiesYourePartnerInWindow : Window
    {
        PartnersMatcherController controller;
        public WatchAllActivitiesYourePartnerInWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
