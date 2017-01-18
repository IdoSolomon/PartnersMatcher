using GUI.classes;
using GUI.Controller;
using System;
using System.Collections.Generic;
using System.Data;
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

            numOfParticipantsComboBox.ItemsSource = controller.GetNumOfParticipates();
            frequencyComboBox.ItemsSource = controller.GetFrequency();
            difficultyComboBox.ItemsSource = controller.GetDifficulty();

        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (areaComboBox.SelectedItem == null || fieldsComboBox.SelectedItem == null || startsOnDatePick.SelectedDate == null)
                MessageBox.Show("Missing data. You have to choose a place, an activity field and a start time.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Activity criteria = new Activity();
            criteria.location = areaComboBox.Text;
            criteria.field = fieldsComboBox.Text;
            if(numOfParticipantsComboBox.Text != null)
                criteria.numberOfParticipants = Convert.ToInt32(numOfParticipantsComboBox.Text);
            if (difficultyComboBox.SelectedItem != null)
                criteria.difficulty = difficultyComboBox.Text;
            if (startsOnDatePick.SelectedDate != null)
                criteria.startDate = (DateTime)startsOnDatePick.SelectedDate;
            if (endsOnDatePick.SelectedDate != null)
                criteria.endDate = (DateTime)endsOnDatePick.SelectedDate;
            bool[] days = new bool[7];
            days[0] = (bool)sunday.IsChecked;
            days[1] = (bool)monday.IsChecked;
            days[2] = (bool)tuesday.IsChecked;
            days[3] = (bool)wednesday.IsChecked;
            days[4] = (bool)thursday.IsChecked;
            days[5] = (bool)friday.IsChecked;
            days[6] = (bool)saturday.IsChecked;
            criteria.days = days;

            DataSet ds = controller.AdvSearch(criteria);
            // if (gendercombobox.text =! null || mixed)
            // if (ds.Tables[0].Rows.Count > 0)
            //for each activity in ds pull participants records and match against user criteria
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
