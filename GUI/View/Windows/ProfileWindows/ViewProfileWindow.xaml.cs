using System.Windows;
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
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        /// <param name="user">user profile</param>
        public ViewProfileWindow(PartnersMatcherController PMController, User user)
        {
            InitializeComponent();
            controller = PMController;
            _user = user;
            SetUser();
        }

        /// <summary>
        /// sets user details into window
        /// </summary>
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
