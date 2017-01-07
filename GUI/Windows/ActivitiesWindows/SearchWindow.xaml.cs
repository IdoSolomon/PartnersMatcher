using PartnersMatcher;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        PartnersMatcherModel model;
        public SearchWindow(ref PartnersMatcherModel PMModel)
        {
            InitializeComponent();
            model = PMModel;
            areaComboBox.ItemsSource = model.GeographicAreas;
            fieldsComboBox.ItemsSource = model.Fields;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (areaComboBox.Text == "" || fieldsComboBox.Text == "")
            {
                MessageBox.Show("Missing data. Please choose a place and an activity field.", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DataSet db = model.Search(areaComboBox.Text, fieldsComboBox.Text);
                
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
