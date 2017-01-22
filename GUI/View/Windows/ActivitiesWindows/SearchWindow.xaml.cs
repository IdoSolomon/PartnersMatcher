using GUI.Controller;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        PartnersMatcherController controller;
        public SearchWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            areaComboBox.ItemsSource = controller.GetGeographicAreas();
            fieldsComboBox.ItemsSource = controller.GetFields();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (areaComboBox.Text == "" || fieldsComboBox.Text == "")
            {
                MessageBox.Show("Missing data. Please choose a place and an activity field.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DataSet db = controller.Search(areaComboBox.Text, fieldsComboBox.Text);
                
                if (db.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching Activities were found.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    SearchResultsWindow sr = new SearchResultsWindow(db);
                    sr.ShowDialog();
                }

                db.Dispose();
            }
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void fieldsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void areaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
