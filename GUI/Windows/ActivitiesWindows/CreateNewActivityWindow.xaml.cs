using System.Windows;
using GUI.Controller;
using GUI.classes;
using System;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for CreateNewActivityWindow.xaml
    /// </summary>
    public partial class CreateNewActivityWindow : Window
    {
        private PartnersMatcherController controller;
        private bool[] days;


        public CreateNewActivityWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            days = new bool[7];
        }

        private void NewFieldBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            Activity activity = new Activity();
            if (!ValidateFields(ref activity))
                return;
            controller.CreateNewActivity(activity);
         }

        private bool ValidateFields(ref Activity activity)
        {
            if (activityNameTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("Please enter activity name.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.name = activityNameTextBox.Text;
            if (locationTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("Please enter location.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.location = locationTextBox.Text;
            if (fieldsComboBox.SelectedItem.ToString() == "")
            {
                System.Windows.MessageBox.Show("Please choose a field.\nIf there us no field which match to your activity, please click on 'new field' button", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.field = fieldsComboBox.SelectedItem.ToString();
            if (genderComboBox.SelectedItem.ToString() == "")
            {
                System.Windows.MessageBox.Show("Please choose a participates gender.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.gender = genderComboBox.SelectedItem.ToString();
            if (startsOnDatePick.SelectedDate.Value.Date.ToShortDateString() == "")
            {
                System.Windows.MessageBox.Show("Please choose a start day.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.startDate = startsOnDatePick.SelectedDate.Value.Date;
            if (endsOnDatePick.SelectedDate.Value.Date.ToShortDateString() == "")
            {
                System.Windows.MessageBox.Show("Please choose an end day.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            int startHours = -1, startMinutes = -1, endHours = -1, endMinutes = -1; 
            if (!validHour(startHourTextBox.Text, ref startHours, ref startMinutes) || !validHour(endHourTextBox.Text, ref endHours, ref endMinutes))
                return false;
            activity.startTime = new TimeSpan(startHours, startMinutes, 0);
            activity.startTime = new TimeSpan(endHours, endMinutes, 0);

            activity.endDate = endsOnDatePick.SelectedDate.Value.Date;
            if (frequencyComboBox.SelectedItem.ToString() == "")
            {
                System.Windows.MessageBox.Show("Please choose a frequency.\nIf there us no field which match to your activity, please click on 'new field' button", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.frequency = frequencyComboBox.SelectedItem.ToString();
            if (numOfParticipantsComboBox.SelectedItem.ToString() == "")
            {
                System.Windows.MessageBox.Show("Please choose the expected numer of participants.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.numberOfParticipants = int.Parse(numOfParticipantsComboBox.SelectedItem.ToString());
            if (difficultyComboBox.SelectedItem.ToString() == "")
            {
                System.Windows.MessageBox.Show("Please choose a difficalty.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.difficulty = difficultyComboBox.SelectedItem.ToString();
            if (costTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("Please enter the cost of the activity.\n iIf the actuvity is free, please enter 0.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            double price = -1;
            if(!double.TryParse(costTextBox.Text, out price) || price < 0)
            {
                System.Windows.MessageBox.Show("Please enter the cost.\nThe cost must be a positive number", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            activity.price = price;
            activity.days = days;
            return true;
        }

        private bool validHour(string text, ref int hours, ref int minutes)
        {
            if (startHourTextBox.Text == "")
            {
                System.Windows.MessageBox.Show("Please enter the start hour of the activity.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (!startHourTextBox.Text.Contains(":"))
            {
                System.Windows.MessageBox.Show("Please enter a valid hour", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            string[] splitTime = text.Split(':');
            if (!int.TryParse(splitTime[0], out hours) || hours < 0 || hours > 24)
            {
                System.Windows.MessageBox.Show("Please enter a valid hour", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            if (!int.TryParse(splitTime[1], out minutes) || minutes < 0 || minutes > 60)
            {
                System.Windows.MessageBox.Show("Please enter a valid minutes", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region days
        private void sunday_Checked(object sender, RoutedEventArgs e)
        {
            days[0] = true;
        }

        private void sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[0] = false;
        }

        private void monday_Checked(object sender, RoutedEventArgs e)
        {
            days[1] = true;
        }

        private void monday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[1] = false;
        }

        private void tuesday_Checked(object sender, RoutedEventArgs e)
        {
            days[2] = true;
        }

        private void tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[2] = false;
        }

        private void wednesday_Checked(object sender, RoutedEventArgs e)
        {
            days[3] = true;
        }

        private void wednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[3] = false;
        }

        private void thursday_Checked(object sender, RoutedEventArgs e)
        {
            days[4] = true;
        }

        private void thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[4] = false;
        }

        private void friday_Checked(object sender, RoutedEventArgs e)
        {
            days[5] = true;
        }

        private void friday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[5] = false;
        }

        private void saturday_Checked(object sender, RoutedEventArgs e)
        {
            days[6] = true;
        }

        private void saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            days[6] = false;
        }
        #endregion
    }
}
