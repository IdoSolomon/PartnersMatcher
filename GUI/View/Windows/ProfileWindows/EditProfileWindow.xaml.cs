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

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
