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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public SearchWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            areaComboBox.ItemsSource = controller.GetGeographicAreas();
            fieldsComboBox.ItemsSource = controller.GetFields();
        }

        /// <summary>
        /// validate user input and query DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
