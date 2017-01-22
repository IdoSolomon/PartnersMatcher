using GUI.Controller;
using System.Windows;

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for UpdateEmailWindow.xaml
    /// </summary>
    public partial class UpdateEmailWindow : Window
    {
        PartnersMatcherController controller;
        public UpdateEmailWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
