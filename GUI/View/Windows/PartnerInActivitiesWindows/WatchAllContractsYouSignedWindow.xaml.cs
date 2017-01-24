using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for WatchAllContractsYouSignedWindow.xaml
    /// </summary>
    public partial class WatchAllContractsYouSignedWindow : Window
    {
        PartnersMatcherController controller;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public WatchAllContractsYouSignedWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
