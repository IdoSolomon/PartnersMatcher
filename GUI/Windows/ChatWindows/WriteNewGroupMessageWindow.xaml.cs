using GUI.Controller;
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

namespace GUI.Windows.ChatWindows
{
    /// <summary>
    /// Interaction logic for WriteNewGroupMessageWindow.xaml
    /// </summary>
    public partial class WriteNewGroupMessageWindow : Window
    {
        PartnersMatcherController controller;
        public WriteNewGroupMessageWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            GroupComboBox.Items.Add("Scumbag lawyer renting his apartment");
            GroupComboBox.Items.Add("Protesting against Mondays");
            GroupComboBox.Items.Add("Protesting for Mondays");
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
