using System.Windows;
using GUI.Controller;
using GUI.classes;
using System;
using System.Windows.Media;
using System.Windows.Controls;

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
            fieldsComboBox.ItemsSource = controller.GetFields();
            frequencyComboBox.ItemsSource = controller.GetFrequency();
            difficultyComboBox.ItemsSource = controller.GetDifficulty();
            genderComboBox.ItemsSource = controller.GetGenders();
        }

        private void NewFieldBtn_Click(object sender, RoutedEventArgs e)
        {
            fieldsComboBox.IsDropDownOpen = false;
            CreateNewFieldWindow win = new CreateNewFieldWindow(ref controller);
            win.ShowDialog();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            Activity activity = new Activity();
            if (!ValidateFields(ref activity))
                return;
            controller.CreateNewActivity(activity);
            System.Windows.MessageBox.Show("The new activity was create successfuly.", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Close();
        }

        private bool ValidateFields(ref Activity activity)
        {
            bool validationSucceeded = true;
            string errMasg = String.Empty;
            if (activityNameTextBox.Text == "")
            {
             if(errMasg==String.Empty)
                errMasg ="Please enter activity name.";
                validationSucceeded =  false;
                activityNameTextBox.Background = Brushes.Salmon ;
            }
            else
            {
                activityNameTextBox.Background = Brushes.White;
                activity.name = activityNameTextBox.Text;
            }
            if (locationTextBox.Text == "")
            {
                if(errMasg==String.Empty)
                errMasg ="Please enter location.";
                validationSucceeded =  false;
                locationTextBox.Background = Brushes.Salmon;

            }
            else
            {
                activity.location = locationTextBox.Text;
                locationTextBox.Background = Brushes.White;
            }
            if (fieldsComboBox.SelectedItem == null)
            {
                if(errMasg==String.Empty)
                errMasg ="Please choose a field.\nIf there us no field which match to your activity, please click on 'new field' button";
                validationSucceeded =  false;
                fieldsComboBox.Background = Brushes.Salmon;

            }
            else
            {
                activity.field = fieldsComboBox.SelectedItem.ToString();
                fieldsComboBox.Background = Brushes.White;

            }
            if (genderComboBox.SelectedItem == null)
            {
                if(errMasg==String.Empty)
                    errMasg ="Please choose a participates gender.";
                validationSucceeded =  false;
                genderComboBox.Background = Brushes.Salmon;

            }
            else
            {
                activity.gender = genderComboBox.SelectedItem.ToString();
                genderComboBox.Background = Brushes.White;
            }
            if (startsOnDatePick.SelectedDate == null)
            {
                if(errMasg==String.Empty)
                    errMasg ="Please choose a start day.";
                validationSucceeded =  false;
                startsOnDatePick.Background = Brushes.Salmon;

            }
            else
                startsOnDatePick.Background = Brushes.White;
            if (endsOnDatePick.SelectedDate == null)
            {
                if(errMasg==String.Empty)
                    errMasg ="Please choose an end day.";
                validationSucceeded =  false;
                endsOnDatePick.Background = Brushes.Salmon;

            }
            else
                endsOnDatePick.Background = Brushes.White;
            if(validationSucceeded)
            {
                    activity.startDate = startsOnDatePick.SelectedDate.Value.Date;
                    activity.endDate = endsOnDatePick.SelectedDate.Value.Date;

            }

            if(activity.startDate > activity.endDate)
            {
                if(errMasg==String.Empty)
                    errMasg ="Activity`s end date must be after its beginning date.";
                validationSucceeded =  false;
                startsOnDatePick.Background = Brushes.Salmon;
                endsOnDatePick.Background = Brushes.Salmon;
            }
            else
            {
                startsOnDatePick.Background = Brushes.White;
                endsOnDatePick.Background = Brushes.White;
            }
            int startHours = -1, startMinutes = -1, endHours = -1, endMinutes = -1; 
            if (!validHour(startHourTextBox, ref startHours, ref startMinutes,ref errMasg) || !validHour(endHourTextBox, ref endHours, ref endMinutes, ref errMasg))
                validationSucceeded =  false;
             if(validationSucceeded)
            {
                activity.startTime = new TimeSpan(startHours, startMinutes, 0);
                activity.endTime = new TimeSpan(endHours, endMinutes, 0);
             }
             if (frequencyComboBox.SelectedItem == null)
             {
                 if (errMasg == String.Empty)
                     errMasg = "Please choose a frequency.\nIf there us no field which match to your activity, please click on 'new field' button";
                 validationSucceeded = false;
                 frequencyComboBox.Background = Brushes.Salmon;

             }
             else
             {
                 activity.frequency = frequencyComboBox.SelectedItem.ToString();
                 frequencyComboBox.Background = Brushes.White;
             }
            if (numOfParticipantstTextBox.Text == "")
            {
                if(errMasg==String.Empty)
                    errMasg ="Please enter the expected numer of participants.";
                validationSucceeded =  false;
                numOfParticipantstTextBox.Background = Brushes.Salmon;
            }
            else
                numOfParticipantstTextBox.Background = Brushes.White;

            int numOfParticipants = -1;
            if (!int.TryParse(numOfParticipantstTextBox.Text, out numOfParticipants) || numOfParticipants < 2)
            {
                if (errMasg == String.Empty)
                    errMasg = "Please enter the expected numer of participants.\nThe number must be a positive number larger than 1";
                validationSucceeded = false;
                numOfParticipantstTextBox.Background = Brushes.Salmon;
            }
            else
            {
                numOfParticipantstTextBox.Background = Brushes.White;
                activity.numberOfParticipants = numOfParticipants;
            }
            if (difficultyComboBox.SelectedItem == null)
            {
                if (errMasg == String.Empty)
                    errMasg = "Please choose a difficalty.";
                validationSucceeded = false;
                difficultyComboBox.Background = Brushes.Salmon;

            }
            else
            {
                activity.difficulty = difficultyComboBox.SelectedItem.ToString();
                difficultyComboBox.Background = Brushes.White;

            }
            if (costTextBox.Text == "")
            {
                if(errMasg==String.Empty)
                    errMasg ="Please enter the cost of the activity.\n iIf the actuvity is free, please enter 0.";
                validationSucceeded =  false;
                costTextBox.Background = Brushes.Salmon;
            }
            else
                costTextBox.Background = Brushes.White;
            double price = -1;
            if(!double.TryParse(costTextBox.Text, out price) || price < 0)
            {
                if(errMasg==String.Empty)
                    errMasg ="Please enter the cost.\nThe cost must be a positive number";
                validationSucceeded =  false;
                costTextBox.Background = Brushes.Salmon;

            }
            else
                costTextBox.Background = Brushes.White;
            if (!validDays())
            {
                if (errMasg == String.Empty)
                    errMasg = "Please choose at least one day activity occurs";

            }
            else
            {
                activity.days = days;

            }
            if(validationSucceeded)
            {
                activity.price = price;
                
            }


            //check if the start time accutd before end time
            if (startsOnDatePick.SelectedDate == endsOnDatePick.SelectedDate && (activity.startTime>=activity.endTime))
            {
                if(errMasg==String.Empty)
                    errMasg ="Activity`s end time must come after start time .";
                validationSucceeded =  false;
                endHourTextBox.Background = Brushes.Salmon;
            }
            else if(validationSucceeded)
                endHourTextBox.Background = Brushes.White;


            if (validationSucceeded == false)
                MessageBox.Show(errMasg, "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Exclamation);



            return validationSucceeded;
        }

        private bool validDays()
        {
            int numOfDays = 0;
            for (int i = 0; i < days.Length; i++)
                if (days[i])
                    numOfDays++;
            return numOfDays > 0;
        }


        private bool validHour(TextBox txtBox, ref int hours, ref int minutes, ref string errMsg)
        {
            string text = txtBox.Text;
            if (text == "")
            {
                if (errMsg == String.Empty)
                    errMsg = "Please enter the start and end time of the activity.\nTime`s format: HH:MM";
                txtBox.Background = Brushes.Salmon;
                return false;
            }
            if (!text.Contains(":"))
            {
                if (errMsg == String.Empty)
                    errMsg = "Please enter a valid hour\nTime`s format: HH:MM";
                txtBox.Background = Brushes.Salmon;
                return false;
            }
            string[] splitTime = text.Split(':');
            if (!int.TryParse(splitTime[0], out hours) || hours < 0 || hours > 24)
            {
                if (errMsg == String.Empty)
                    errMsg = "Please enter a valid hour.\nTime`s format: HH:MM";
                txtBox.Background = Brushes.Salmon;
                return false;
            }
            if (!int.TryParse(splitTime[1], out minutes) || minutes < 0 || minutes > 60)
            {
                if (errMsg == String.Empty)
                    errMsg = "Please enter a valid minutes\nTime`s format: HH:MM";
                txtBox.Background = Brushes.Salmon;
                return false;
            }
            txtBox.Background = Brushes.White;
            return true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region days`
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

        private void fieldsComboBox_DropDownOpened(object sender, EventArgs e)
        {
            fieldsComboBox.ItemsSource = controller.GetFields();
        }
    }
}
