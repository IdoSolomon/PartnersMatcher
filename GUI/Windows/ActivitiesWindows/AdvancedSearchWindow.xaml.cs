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

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for AdvancedSearchWindow.xaml
    /// </summary>
    public partial class AdvancedSearchWindow : Window
    {
        PartnersMatcherController controller;
        public AdvancedSearchWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            areaComboBox.ItemsSource = controller.GetGeographicAreas();
            fieldsComboBox.ItemsSource = controller.GetFields();
            //achange to data time
            /*startOnComboBox.ItemsSource = controller.StartOn;
            endOnComboBox.ItemsSource = controller.StartOn;*/

            numOfParticipatesComboBox.ItemsSource = controller.GetNumOfParticipates();
            frequencyComboBox.ItemsSource = controller.GetFrequency();
            difficultyComboBox.ItemsSource = controller.GetDifficulty();

        }


        private void GroupComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(fieldsComboBox.SelectedItem == null)
                MessageBox.Show("Missing data. You must choose an activity before you choose a field.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                activitiesComboBox.ItemsSource = controller.GetActivities()[fieldsComboBox.SelectedItem.ToString()];
                activitiesComboBox.Items.Refresh();
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if(areaComboBox.SelectedItem == null || fieldsComboBox.SelectedItem == null)
                MessageBox.Show("Missing data. You have to choose a place, an activity field, an activity and a start time.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void startsOnDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            endsOnDatePick.DisplayDateStart = startsOnDatePick.SelectedDate;
        }
    }
}
