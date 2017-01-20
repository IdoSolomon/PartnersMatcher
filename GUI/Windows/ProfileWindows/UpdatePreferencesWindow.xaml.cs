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
using System.Text.RegularExpressions;
using GUI.classes;

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for UpdatePreferencesWindow.xaml
    /// </summary>
    public partial class UpdatePreferencesWindow : Window
    {
        PartnersMatcherController controller;
        Preference pref;
        public UpdatePreferencesWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            areaComboBox.ItemsSource = controller.GetGeographicAreas();
            numOfParticipantsComboBox.ItemsSource = controller.GetNumOfParticipates();
            frequencyComboBox.ItemsSource = controller.GetFrequency();
            difficultyComboBox.ItemsSource = controller.GetDifficulty();
            setTimeComboBox();

            pref = controller.GetUserPreference();

            setPrefs();
        }

        private void setPrefs()
        {
            if (pref.location != null)
                areaComboBox.Text = pref.location;
            if (pref.maxPrice > 0)
                priceTextbox.Text = pref.maxPrice.ToString();
            if (pref.gender != null)
                genderComboBox.Text = pref.gender;
            if (pref.frequency != null)
                frequencyComboBox.Text = pref.frequency;
            if (pref.numberOfParticipants > 0)
                numOfParticipantsComboBox.Text = pref.numberOfParticipants.ToString();
            if (pref.difficulty != null)
                difficultyComboBox.Text = pref.difficulty;
            if (pref.minAge > 0)
                minAgeTextbox.Text = pref.minAge.ToString();
            if (pref.maxAge > 0)
                maxAgeTextbox.Text = pref.maxAge.ToString();
            if (pref.startHour != null)
            {
                string hour = pref.startHour.ToString();
                string[] time = hour.Split(':');
                sHour.Text = time[0];
                sMinute.Text = time[1];
            }

            if (pref.endHour != null)
            {
                string hour = pref.endHour.ToString();
                string[] time = hour.Split(':');
                eHour.Text = time[0];
                eMinute.Text = time[1];
            }

            if (pref.smokes)
                smokes.IsChecked = true;
            if (pref.pet)
                pet.IsChecked = true;
            if (pref.days[0])
                sunday.IsChecked = true;
            if (pref.days[1])
                monday.IsChecked = true;
            if (pref.days[2])
                tuesday.IsChecked = true;
            if (pref.days[3])
                wednesday.IsChecked = true;
            if (pref.days[4])
                thursday.IsChecked = true;
            if (pref.days[5])
                friday.IsChecked = true;
            if (pref.days[6])
                saturday.IsChecked = true;
        }

        private void setTimeComboBox()
        {
            ObservableCollection<string> hours = new ObservableCollection<string>();
            ObservableCollection<string> minutes = new ObservableCollection<string>();

            for (int i = 0; i < 25; i++)
            {
                string time = "";
                if (i < 10)
                    time += "0";
                time += i.ToString();
                hours.Add(time);
            }

            for (int i = 0; i <= 60; i+=5)
            {
                string time = "";
                if (i < 10)
                    time += "0";
                time += i.ToString();
                minutes.Add(time);
            }

            sHour.ItemsSource = hours;
            sMinute.ItemsSource = minutes;
            eHour.ItemsSource = hours;
            sMinute.ItemsSource = minutes;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            //getprefs
            //setuserpreferences
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
