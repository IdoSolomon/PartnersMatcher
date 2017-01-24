using GUI.Controller;
using System.Windows;

namespace GUI.Windows.ChatWindows
{
    /// <summary>
    /// Interaction logic for WriteNewGroupMessageWindow.xaml
    /// </summary>
    public partial class WriteNewGroupMessageWindow : Window
    {
        PartnersMatcherController controller;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public WriteNewGroupMessageWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            GroupComboBox.Items.Add("Scumbag lawyer renting his apartment");
            GroupComboBox.Items.Add("Protesting against Mondays");
            GroupComboBox.Items.Add("Protesting for Mondays");
        }

        /// <summary>
        /// submit changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
