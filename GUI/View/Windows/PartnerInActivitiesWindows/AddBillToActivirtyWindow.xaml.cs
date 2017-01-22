using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for AddBillToActivirtyWindow.xaml
    /// </summary>
    public partial class AddBillToActivirtyWindow : Window
    {
        PartnersMatcherController controller;
        public AddBillToActivirtyWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
