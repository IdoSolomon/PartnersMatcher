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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GUI.Windows.ProfileWindows;
using GUI.Windows.PartnerInActivitiesWindows;
using GUI.Windows.ChatWindows;
using GUI.Windows.ActivitiesYouManageWindows;
using GUI.Windows.ActivitiesWindows;
using System.Data;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PartnersMatcherModel model;
        ObservableCollection<ActivityRecord> RecommendedActivities;
        

        public MainWindow(ref PartnersMatcherModel PMModel)
        {
            InitializeComponent();
            model = PMModel;
            InitRecommendedActivities();

            locationComboBox.ItemsSource = model.GeographicAreas;
            domainComboBox.ItemsSource = model.Fields;

        }

        private void InitRecommendedActivities()
        {
            RecommendedActivities = new ObservableCollection<ActivityRecord>();
            ActivityRecord activity1 = new ActivityRecord("Sport", "Playing soccer", "Playing soccer for beginners", "Beer Sheva", new DateTime(2017, 1, 1), "Weekly", "Sunday");
            ActivityRecord activity2 = new ActivityRecord("Relationship", "Dating", "I`m single attractive man and I want to meet someone", "Beer Sheva", new DateTime(2017, 12, 5), "One time event", "Monday");
            ActivityRecord activity3 = new ActivityRecord("Residence", "Roomates", "I`m single attractive man and I want to live with someone", "Beer Sheva", new DateTime(2017, 1, 1), "Conitnuos", "Friday");
            RecommendedActivities.Add(activity1);
            RecommendedActivities.Add(activity2);
            RecommendedActivities.Add(activity3);
            RecommendedActivitiesGrid.ItemsSource = RecommendedActivities;
        }


        #region Profile
        private void EditYourProfile_Click(object sender, RoutedEventArgs e)
        {
            EditProfileWindow win = new EditProfileWindow(ref model);
            win.ShowDialog();
        }

        private void ChangeYourPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow win = new ChangePasswordWindow(ref model);
            win.ShowDialog();

        }

        private void UpdateYourEmail_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmailWindow win = new UpdateEmailWindow(ref model);
            win.ShowDialog();

        }

        private void UpdatePreferences_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow main = new LoginWindow(ref model);
            main.Show();
            Close();
        }
        #endregion
        #region Activities
        private void CreateNewActivity_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow win = new SearchWindow(ref model);
            win.ShowDialog();
        }

        private void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchWindow win = new AdvancedSearchWindow(ref model);
            win.ShowDialog();
        }

        private void WatchYourPendingRequests_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
        #region Activities You`re partner in
        private void WatchAllActivitiesYourePartnerIn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void ApprovePendingRequestsAsPaertner_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void AddBillToActivirty_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void PendingPayments_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void WatchYourPaymentsHistory_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void PendingContracts_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void WatchAllContractsYouSigned_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        #endregion
        #region Activities You Manage
        private void WatchActivitesYouManage_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ApprovePendingRequestsAsManager_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void AddNewContractToActivity_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SetNewPaymentInActivity_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        #endregion
        #region Chat
        private void SeeAllConversations_Click(object sender, RoutedEventArgs e)
        {
            SeeAllConversationsWindow win = new SeeAllConversationsWindow(ref model);
            win.ShowDialog();
        }

        private void WriteNewGroupMessage_Click(object sender, RoutedEventArgs e)
        {
            WriteNewGroupMessageWindow win = new WriteNewGroupMessageWindow(ref model);
            win.ShowDialog();
        }
        #endregion



        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (domainComboBox.SelectedItem == null || locationComboBox.SelectedItem == null)
                MessageBox.Show("Missing data. You have to choose a place, an activity field, an activity and a start time!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                DataSet db = model.Search(locationComboBox.SelectedItem.ToString(), domainComboBox.SelectedItem.ToString());
                SearchResultsWindow sr = new SearchResultsWindow(db);
                sr.ShowDialog();
                db.Dispose();
            }     
        }

        private void SendJoiningRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
