using GUI.DataGridRecords;
using PartnersMatcher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for UpdatePreferencesWindow.xaml
    /// </summary>
    public partial class UpdatePreferencesWindow : Window
    {
        PartnersMatcherModel model;
        ObservableCollection<ActivityCatagory> activities;
        public UpdatePreferencesWindow(ref PartnersMatcherModel PMModel)
        {
            InitializeComponent();
            model = PMModel;
            InitCatagories();
            CatagoryGrid.ItemsSource = activities;
        }

        private void InitCatagories()
        {
            activities = new ObservableCollection<ActivityCatagory>();
            activities.Add(new ActivityCatagory("Blimp Watching"));
            activities.Add(new ActivityCatagory("Proffesional Napping"));
            activities.Add(new ActivityCatagory("Paperclip Modeling"));
            activities.Add(new ActivityCatagory("Coffee Drinking"));
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
