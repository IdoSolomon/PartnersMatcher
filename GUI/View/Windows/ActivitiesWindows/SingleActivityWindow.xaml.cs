using System.Windows;
using GUI.classes;

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for SingleActivityWindow.xaml
    /// </summary>
    public partial class SingleActivityWindow : Window
    {
        Activity _activity;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="activity">activity</param>
        public SingleActivityWindow(Activity activity)
        {
            InitializeComponent();
            _activity = activity;
            SetActivity();
        }

        /// <summary>
        /// sets activity details into window
        /// </summary>
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
