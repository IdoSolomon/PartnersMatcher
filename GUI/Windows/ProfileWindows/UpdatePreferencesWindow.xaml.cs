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
            if (pref.sex != null)
            {
                if (pref.sex == "M")
                    genderComboBox.Text = "Men Only";
                else if (pref.sex == "F")
                    genderComboBox.Text = "Women Only";
            }
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

            for (int i = 0; i < 24; i++)
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
            GetPrefs();
            if(controller.SetUserPreferences(pref))
            {
                System.Windows.MessageBox.Show("Preference update complete.", "Date Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else System.Windows.MessageBox.Show("Preference update failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void GetPrefs()
        {
            if (areaComboBox.Text != "")
                pref.location = areaComboBox.Text;
            if (priceTextbox.Text != null)
                pref.maxPrice = Convert.ToInt32(priceTextbox.Text);
            if (genderComboBox.Text != "")
            {
                if(genderComboBox.Text == "Men Only")
                    pref.sex = "M";
                else if (genderComboBox.Text == "Women Only")
                    pref.sex = "F";
            }
            if (frequencyComboBox.Text != "")
                pref.frequency = frequencyComboBox.Text;
            if (numOfParticipantsComboBox.Text != "")
                pref.numberOfParticipants = Convert.ToInt32(numOfParticipantsComboBox.Text);
            if (difficultyComboBox.Text != "")
                pref.difficulty = difficultyComboBox.Text;
            if (minAgeTextbox.Text != null)
                pref.minAge = Convert.ToInt32(minAgeTextbox.Text);
            if (maxAgeTextbox.Text != null)
                pref.maxAge = Convert.ToInt32(maxAgeTextbox.Text);
            if (sHour.Text != "" && sMinute.Text != "")
                pref.startHour = new TimeSpan(Convert.ToInt32(sHour.Text), Convert.ToInt32(sMinute.Text), 0);

            if (eHour.Text != "" && eMinute.Text != "")
                pref.endHour = new TimeSpan(Convert.ToInt32(eHour.Text), Convert.ToInt32(sMinute.Text), 0);

            if (smokes.IsChecked == true)
                pref.smokes = true;
            else pref.smokes = false;
            if (pet.IsChecked == true)
                pref.pet = true;
            else pref.pet = false;
            if (sunday.IsChecked == true)
                pref.days[0] = true;
            else pref.days[0] = false;
            if (monday.IsChecked == true)
                pref.days[1] = true;
            else pref.days[1] = false;
            if (tuesday.IsChecked == true)
                pref.days[2] = true;
            else pref.days[2] = false;
            if (wednesday.IsChecked == true)
                pref.days[3] = true;
            else pref.days[3] = false;
            if (thursday.IsChecked == true)
                pref.days[4] = true;
            else pref.days[4] = false;
            if (friday.IsChecked == true)
                pref.days[5] = true;
            else pref.days[5] = false;
            if (saturday.IsChecked == true)
                pref.days[6] = true;
            else pref.days[6] = false;

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
