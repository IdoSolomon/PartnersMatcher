using GUI.Controller;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Text.RegularExpressions;
using GUI.classes;
using System.Collections;

namespace GUI.Windows.ProfileWindows
{
    /// <summary>
    /// Interaction logic for UpdatePreferencesWindow.xaml
    /// </summary>
    public partial class UpdatePreferencesWindow : Window
    {
        PartnersMatcherController controller;
        Preference pref;
        public UpdatePreferencesWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            ObservableCollection<string> locations = controller.GetGeographicAreas();
            areaComboBox.ItemsSource = AddEmptyOption(locations, "Anywhere");
            frequencyComboBox.ItemsSource = AddEmptyOption(controller.GetFrequency(),"All Frequencies");
            difficultyComboBox.ItemsSource = controller.GetDifficulty();
            setTimeComboBox();

            pref = controller.GetUserPreference();

            setPrefs();
        }

        private ObservableCollection<string> AddEmptyOption(ObservableCollection<string> options,string defaultiveOption)
        {
            ObservableCollection<string> results = new ObservableCollection<string>();
            results.Add(defaultiveOption);
            foreach (string s in options)
                results.Add(s);
            return results;
        }

        private void setPrefs()
        {
            if (pref.location != null)
                areaComboBox.Text = pref.location;
            else
                areaComboBox.SelectedIndex = -1;
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
            string errMsg = String.Empty;
            if (!ValidateAllParametersSubmitted(ref errMsg))
            {
                System.Windows.MessageBox.Show(errMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            //GetPrefs();
            if(controller.SetUserPreferences(pref))
            {
                System.Windows.MessageBox.Show("Preference update complete.", "Date Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else System.Windows.MessageBox.Show("Preference update failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private bool ValidateAllParametersSubmitted(ref string errMsg)
        {
            bool validationSucceeded = true;
            string missingProperty;
            if (!String.IsNullOrEmpty(areaComboBox.Text))
                pref.location = areaComboBox.Text;
            int price=1;
            if (!String.IsNullOrEmpty(priceTextbox.Text) &&  (! Int32.TryParse(priceTextbox.Text,out price) || price<0))
            {
                missingProperty = "price";
                if (String.IsNullOrEmpty(errMsg))
                    errMsg = String.Format("Please submit your preferred {0}. Price must be a non negative number", missingProperty);
                validationSucceeded = false;
                priceTextbox.Background = Brushes.Salmon;
            }
            else 
            {
                if (!String.IsNullOrEmpty(priceTextbox.Text))
                    pref.maxPrice = price;
                priceTextbox.Background = Brushes.White;
            }
            
            if (!String.IsNullOrEmpty(genderComboBox.Text) )
            {
                if (genderComboBox.Text == "Men Only")
                    pref.sex = "M";
                else if (genderComboBox.Text == "Women Only")
                    pref.sex = "F";
            }

            if (!String.IsNullOrEmpty(frequencyComboBox.Text))
            {
                pref.frequency = frequencyComboBox.Text;
                frequencyComboBox.Background = Brushes.White;
            }

            if (!String.IsNullOrEmpty(numOfParticipantsComboBox.Text))
            {
                pref.frequency = frequencyComboBox.Text;
            }
            int numOfParticipants = -1;
            if (!String.IsNullOrEmpty(numOfParticipantsComboBox.Text) && (!Int32.TryParse(priceTextbox.Text, out numOfParticipants) || numOfParticipants <= 1))
            {
                errMsg = "Please submit your preffered number of participants. This number must be a positive integer larger than 1.";
                validationSucceeded = false;
                numOfParticipantsComboBox.Background = Brushes.Salmon;
            }
            else
            {
                if (!String.IsNullOrEmpty(numOfParticipantsComboBox.Text))
                    pref.numberOfParticipants = numOfParticipants;
                priceTextbox.Background = Brushes.White;
            }

            if (!String.IsNullOrEmpty(difficultyComboBox.Text))
                pref.difficulty = difficultyComboBox.Text;
            int minAge = -1;
            if (!String.IsNullOrEmpty(minAgeTextbox.Text) && (!Int32.TryParse(minAgeTextbox.Text, out minAge) || minAge <= 0))
            {
                errMsg = "Please submit your preffered number of min age. This number must be a positive integer..";
                validationSucceeded = false;
                minAgeTextbox.Background = Brushes.Salmon;
            }
            else 
            {
                if (!String.IsNullOrEmpty(minAgeTextbox.Text))
                    pref.minAge = minAge;
                minAgeTextbox.Background = Brushes.White;
            }
            int maxAge = -1;
            if (!String.IsNullOrEmpty(maxAgeTextbox.Text) && (!Int32.TryParse(maxAgeTextbox.Text, out maxAge) || maxAge <= 0))
            {
                errMsg = "Please submit your preffered number of max age. This number must be a positive integer..";
                validationSucceeded = false;
                maxAgeTextbox.Background = Brushes.Salmon;
            }
            else 
            {
                if (!String.IsNullOrEmpty(maxAgeTextbox.Text))
                    pref.maxAge = maxAge;
                maxAgeTextbox.Background = Brushes.White;
            }
            if (!String.IsNullOrEmpty(sHour.Text) && !String.IsNullOrEmpty(sMinute.Text))
                pref.startHour = new TimeSpan(Convert.ToInt32(sHour.Text), Convert.ToInt32(sMinute.Text), 0);
            if (!String.IsNullOrEmpty(eHour.Text) && !String.IsNullOrEmpty(eMinute.Text))
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

            return validationSucceeded;
        }

        private void GetPrefs()
        {
            if (!String.IsNullOrEmpty(areaComboBox.Text))
                pref.location = areaComboBox.Text;
            if (!String.IsNullOrEmpty(priceTextbox.Text))
                pref.maxPrice = Convert.ToInt32(priceTextbox.Text);
            if (!String.IsNullOrEmpty(genderComboBox.Text))
            {
                if(genderComboBox.Text == "Men Only")
                    pref.sex = "M";
                else if (genderComboBox.Text == "Women Only")
                    pref.sex = "F";
            }
            if (!String.IsNullOrEmpty(frequencyComboBox.Text))
                pref.frequency = frequencyComboBox.Text;
            if (!String.IsNullOrEmpty(numOfParticipantsComboBox.Text))
                pref.numberOfParticipants = Convert.ToInt32(numOfParticipantsComboBox.Text);
            if (!String.IsNullOrEmpty(difficultyComboBox.Text))
                pref.difficulty = difficultyComboBox.Text;
            if (!String.IsNullOrEmpty(minAgeTextbox.Text))
                pref.minAge = Convert.ToInt32(minAgeTextbox.Text);
            if (!String.IsNullOrEmpty(maxAgeTextbox.Text))
                pref.maxAge = Convert.ToInt32(maxAgeTextbox.Text);
            if (!String.IsNullOrEmpty(sHour.Text) && !String.IsNullOrEmpty(sMinute.Text))
                pref.startHour = new TimeSpan(Convert.ToInt32(sHour.Text), Convert.ToInt32(sMinute.Text), 0);

            if (!String.IsNullOrEmpty(eHour.Text) && !String.IsNullOrEmpty(eMinute.Text))
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
