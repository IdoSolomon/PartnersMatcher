using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.ComponentModel;
using GUI.Controller;
using System.Data.OleDb;
using System.Data;
using GUI.Windows.ProfileWindows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        PartnersMatcherController controller;
        BackgroundWorker bgworker;
        string user;
        string pass;
        public SignUpWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            //LocationComboBox.ItemsSource = controller.GetGeographicAreas();
            bgworker = new BackgroundWorker();
            bgworker.DoWork += bgworker_DoWork;
            bgworker.WorkerReportsProgress = true;
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean sent = controller.SendRegistrationMail(user, pass);
            if(!sent)
                System.Windows.MessageBox.Show("SMTP service is blocked on this computer." + System.Environment.NewLine + "Please check your anti-virus software blocking rules.", "SMTP Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] data = new string[12];
            data[0] = FirstNameTextBox.Text;
            data[1] = LastNameTextBox.Text;
            data[2] = EmailTextBox.Text;
            data[3] = PasswordBox1.Password;
            data[4] = PasswordBox2.Password;
            data[5] = DatePick.SelectedDate.Value.Date.ToShortDateString();
            data[6] = SexComboBox.Text;
            data[7] = PhoneTextBox.Text;
            data[8] = LocationTextBox.Text;
            data[9] = SmokingComboBox.Text;
            data[10] = PetComboBox.Text;
            data[11] = ResumeTextBox.Text;

            if (!ValidateFields(data))
                return;

            if (controller.dbConnect())
            {
                controller.InsertToUserTable(data);
                controller.dbClose();
                user = data[2];
                pass = data[3];
                bgworker_DoWork(sender, null);
                System.Windows.MessageBox.Show("The registration process was ended successfuly.", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Failed to connect to DB.", "DB Error", MessageBoxButton.OK, MessageBoxImage.Information);

            //System.Windows.MessageBox.Show("The complete system will feature an Activity Domain Selection window after sign up.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            UpdatePreferencesWindow win = new UpdatePreferencesWindow(ref controller);
            win.ShowDialog();
        }

        #region validation
        private Boolean ValidateFields(string[] data)
        {
            if (data[0] == "")
            {
                System.Windows.MessageBox.Show("Please enter your first name.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[1] == "")
            {
                System.Windows.MessageBox.Show("Please enter your last name.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[2] == "" || !controller.emailCheck(data[2]))
            {
                System.Windows.MessageBox.Show("Please enter a valid Email address.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (controller.emailExists(data[2]))
            {
                System.Windows.MessageBox.Show("This Email address is already in use.", "Email Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[3] == "")
            {
                System.Windows.MessageBox.Show("Please enter your password.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[4] == "")
            {
                System.Windows.MessageBox.Show("Please confirm your password.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[3] != data[4])
            {
                System.Windows.MessageBox.Show("Passwords do not match. Please reconfirm your password.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[5] == "")
            {
                System.Windows.MessageBox.Show("Please enter your birth date.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[6] == "")
            {
                System.Windows.MessageBox.Show("Please select your sex.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[7] == "")
            {
                System.Windows.MessageBox.Show("Please enter your phone number.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[8] == "")
            {
                System.Windows.MessageBox.Show("Please select your location.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[9] == "")
            {
                System.Windows.MessageBox.Show("Please select your smoking preference.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[10] == "")
            {
                System.Windows.MessageBox.Show("Please state whether you own a pet.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (data[11] == "")
            {
                System.Windows.MessageBox.Show("Please enter your resume.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ActivityBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
