using PartnersMatcher;
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
        PartnersMatcherModel model;
        public AdvancedSearchWindow(ref PartnersMatcherModel PMModel)
        {
            InitializeComponent();
            model = PMModel;
            areaComboBox.ItemsSource = model.GeographicAreas;
            fieldsComboBox.ItemsSource = model.Fields;
            //achange to data time
            /*startOnComboBox.ItemsSource = model.StartOn;
            endOnComboBox.ItemsSource = model.StartOn;*/

            numOfParticipatesComboBox.ItemsSource = model.NumOfParticipates;
            frequencyComboBox.ItemsSource = model.Frequency;
            difficultyComboBox.ItemsSource = model.Difficulty;

        }


        private void GroupComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(fieldsComboBox.SelectedItem == null)
                MessageBox.Show("Missing data. You can choose an activity before you choose a field!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                activitiesComboBox.ItemsSource = model.Activities[fieldsComboBox.SelectedItem.ToString()];
                activitiesComboBox.Items.Refresh();
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if(areaComboBox.SelectedItem == null || fieldsComboBox.SelectedItem == null)
                MessageBox.Show("Missing data. You have to choose a place, an activity field, an activity and a start time!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("MUST TO IMPLEMENT!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
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
