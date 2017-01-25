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
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public UpdateEmailWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
        
        /// <summary>
        /// submits the change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
