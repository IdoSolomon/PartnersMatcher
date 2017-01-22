using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GUI.Controller;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        PartnersMatcherController controller;

        public LoginWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            if (!controller.dbConnect())
            {
                MessageBox.Show("Failed to connect to DB." + System.Environment.NewLine + "Please ensure that you have the Microsoft Access Database Engine 2010 Redistributable (or higher) installed.", "DB Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //Close();
            }
            else
            {
                controller.dbClose();
                UserNameBox.Text = "m@gmail.com";
                PasswordBox.Password = "1234";
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //for testing purposes
            if (UserNameBox.Text != "guest" || PasswordBox.Password != "guest")
            {

                if (UserNameBox.Text == "")
                {
                    System.Windows.MessageBox.Show("Please enter your Email address.", "No Email", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (!controller.emailCheck(UserNameBox.Text))
                {
                    System.Windows.MessageBox.Show("Please enter a valid Email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (PasswordBox.Password == "")
                {
                    System.Windows.MessageBox.Show("Please enter your password.", "No Password", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if(!controller.ValidateUser(UserNameBox.Text, PasswordBox.Password))
                {
                    System.Windows.MessageBox.Show("The user name and/or password entered are incorrect.", "Wrong Username or Password", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }
            //MainWindow main = new MainWindow(ref controller);
            //main.Show();
            controller.SetConnected(true);
            controller.SetUser(UserNameBox.Text);
            Close();
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow sign = new SignUpWindow(ref controller);
            sign.ShowDialog();
        }
    }
}
