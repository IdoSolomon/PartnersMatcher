using GUI.DataGridRecords;
using GUI.Controller;
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
        PartnersMatcherController controller;
        ObservableCollection<ActivityCatagory> activities;
        public UpdatePreferencesWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            InitCatagories();
            //CatagoryGrid.ItemsSource = activities;
        }

        private void InitCatagories()
        {
            activities = new ObservableCollection<ActivityCatagory>();
            activities.Add(new ActivityCatagory("Blimp Watching"));
            activities.Add(new ActivityCatagory("Proffesional Napping"));
            activities.Add(new ActivityCatagory("Paperclip Modeling"));
            activities.Add(new ActivityCatagory("Coffee Drinking"));
        }



        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
