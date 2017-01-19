using GUI.DataGridRecords;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SearchResultsWindow.xaml
    /// </summary>
    public partial class SearchResultsWindow : Window
    {
        ObservableCollection<ActivityRecord> RecommendedActivities = new ObservableCollection<ActivityRecord>();

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

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
