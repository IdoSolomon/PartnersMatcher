using GUI.classes;
using GUI.Controller;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for AdvancedSearchWindow.xaml
    /// </summary>
    public partial class AdvancedSearchWindow : Window
    {
        PartnersMatcherController controller;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public AdvancedSearchWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            areaComboBox.ItemsSource = controller.GetGeographicAreas();
            fieldsComboBox.ItemsSource = controller.GetFields();
            numOfParticipantsComboBox.ItemsSource = controller.GetNumOfParticipates();
            frequencyComboBox.ItemsSource = controller.GetFrequency();
            difficultyComboBox.ItemsSource = controller.GetDifficulty();

        }
        
        /// <summary>
        /// validates user input and query DB for results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (areaComboBox.SelectedItem == null || fieldsComboBox.SelectedItem == null)
                MessageBox.Show("Missing data. You have to choose a place and an activity field.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                {
                Activity criteria = new Activity();
                criteria.location = areaComboBox.Text;
                criteria.field = fieldsComboBox.Text;
                if (numOfParticipantsComboBox.Text != "")
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
                if (genderComboBox.Text == "Men Only")
                    criteria.gender = "M";
                else if (genderComboBox.Text == "Women Only")
                    criteria.gender = "F";
                DataSet ds = controller.AdvSearch(criteria);
                if (ds.Tables[0].Rows.Count == 0)
                    MessageBox.Show("No matching activities were found.", "No match", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    SearchResultsWindow sr = new SearchResultsWindow(ds);
                    sr.ShowDialog();
                }
                ds.Dispose();
            }
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

        /// <summary>
        /// sets the earliest date selectable in endsOnDatePick as the date selected in startsOnEndPick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startsOnDatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            endsOnDatePick.DisplayDateStart = startsOnDatePick.SelectedDate;
        }
    }
}
