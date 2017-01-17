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
using GUI.Controller;
using GUI.classes;

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for ViewProfileWindow.xaml
    /// </summary>
    public partial class ViewProfileWindow : Window
    {
        PartnersMatcherController controller;
        User _user;
        public ViewProfileWindow(ref PartnersMatcherController PMController, User user)
        {
            InitializeComponent();
            controller = PMController;
            _user = user;
            SetUser();
        }

        private void SetUser()
        {
            userNameTextBox.Text = _user.email;
            FirstNameTextBox.Text = _user.firstName;
            LastNameTextBox.Text = _user.lastName;
            dateTextBox.Text = _user.birthDate.ToShortDateString();
            SexTextBox.Text = _user.sex;
            PhoneTextBox.Text = _user.phoneNum;
            pet.IsChecked = _user.pet;
            smokes.IsChecked = _user.smokes;
            ResumeTextBox.Text = _user.resume;

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
