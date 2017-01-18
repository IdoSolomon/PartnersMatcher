using System;
using System.Collections.Generic;
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
using GUI.Controller;
using GUI.classes;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for SingleActivityWindow.xaml
    /// </summary>
    public partial class SingleActivityWindow : Window
    {
        PartnersMatcherController controller;
        Activity _activity;
        public SingleActivityWindow(ref PartnersMatcherController PMController, Activity activity)
        {
            InitializeComponent();
            controller = PMController;
            _activity = activity;
            SetActivity();
        }

        private void SetActivity()
        {
            nameTextBox.Text = _activity.name;
            areaTextBox.Text = _activity.location;
            fieldsTextBox.Text = _activity.field;
            startsOnTextBox.Text = _activity.startDate.ToShortDateString();
            priceTextBox.Text = _activity.price.ToString() + "₪";
            frequencyTextBox.Text = _activity.frequency;
            numOfParticipantsTextBox.Text = _activity.numberOfParticipants.ToString();
            difficultyTextBox.Text = _activity.difficulty;
            endsOnTextBox.Text = _activity.endDate.ToShortDateString();
            endsHourTextBox.Text = _activity.startTime.ToString();
            startHourTextBox.Text = _activity.endTime.ToString();

            bool[] days = _activity.days;
            sunday.IsChecked = days[0];
            monday.IsChecked = days[1];
            tuesday.IsChecked = days[2];
            wednesday.IsChecked = days[3];
            thursday.IsChecked = days[4];
            friday.IsChecked = days[5];
            saturday.IsChecked = days[6];
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
