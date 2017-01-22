using GUI.Controller;
using System.Windows;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for CreateNewFieldWindow.xaml
    /// </summary>
    public partial class CreateNewFieldWindow : Window
    {
        private PartnersMatcherController controller;

        public CreateNewFieldWindow(PartnersMatcherController PMController)
        {
            controller = PMController;
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreatehBtn_Click(object sender, RoutedEventArgs e)
        {
            if (fieldNameTextBox.Text == "")
                System.Windows.MessageBox.Show("Please enter field name.", "Missing Field", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else if (controller.FiledExist(fieldNameTextBox.Text))
                System.Windows.MessageBox.Show("Please enter another field name.\nThis Field already exist.", "Field Exist", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            else {
                controller.CreateNewField(fieldNameTextBox.Text);
                System.Windows.MessageBox.Show("The new field was create successfuly.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                controller.GetFields();
                Close();
            }

        }
    }
}
