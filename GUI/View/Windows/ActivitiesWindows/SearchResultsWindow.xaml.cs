using GUI.classes;
using GUI.DataGridRecords;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for SearchResultsWindow.xaml
    /// </summary>
    public partial class SearchResultsWindow : Window
    {
        ObservableCollection<ActivityRecord> RecommendedActivities = new ObservableCollection<ActivityRecord>();

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="dbSearchResults">results</param>
        public SearchResultsWindow(DataSet dbSearchResults)
        {
            InitializeComponent();
            for (int i = 0; i < dbSearchResults.Tables[0].Rows.Count; i++)
            {
                ActivityRecord activity = new ActivityRecord(dbSearchResults.Tables[0].Rows[i]);
                RecommendedActivities.Add(activity);
            }
            RecommendedActivitiesGrid.ItemsSource = RecommendedActivities;

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
        /// call a single activity window on activity selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            ActivityRecord obj = ((FrameworkElement)sender).DataContext as ActivityRecord;
            Activity act = new Activity();
            act.name = obj.Activity;
            act.field = obj.Catagory;
            act.numberOfParticipants = obj.NumOfParticipate;
            act.location = obj.Place;
            act.startDate = obj.StartsOn;
            act.endDate = obj.FinishOn;
            act.startTime = obj.StartHour;
            act.endTime = obj.FinishHour;
            act.difficulty = obj.Difficulty;
            act.price = Convert.ToDouble(obj.Price);
            act.frequency = obj.Frequency;
            bool[] days = new bool[7];
            days[0] = obj.Sunday;
            days[1] = obj.Monday;
            days[2] = obj.Tuesday;
            days[3] = obj.Wednesday;
            days[4] = obj.Thursday;
            days[5] = obj.Friday;
            days[6] = obj.Saturday;
            act.days = days;

            SingleActivityWindow saw = new SingleActivityWindow(act);
            saw.ShowDialog();
        }
    }
}
