using System.Windows;
using GUI.Controller;


namespace GUI.Windows.ActivitiesYouManageWindows
{
    /// <summary>
    /// Interaction logic for AddNewContractToActivityWindow.xaml
    /// </summary>
    public partial class AddNewContractToActivityWindow : Window
    {
        PartnersMatcherController controller;
        public AddNewContractToActivityWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
