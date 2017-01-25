using GUI.Controller;
using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        PartnersMatcherController controller;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public EditProfileWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            //dummy values
            FirstNameTextBox.Text = "Mitzy";
            LastNameTextBox.Text = "Hatulson";
            DatePick.SelectedDate = new DateTime(2010, 4, 1);
            SexComboBox.Text = "Female";
            PhoneTextBox.Text = "08-6461600";
            ResumeTextBox.Text = "Is a cat, Meow.";
        }

        /// <summary>
        /// submits the changes
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

        /// <summary>
        /// forces numarical input-only on certain textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
