using GUI.DataGridRecords;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using GUI.Windows.ProfileWindows;
using GUI.Windows.ChatWindows;
using GUI.Windows.ActivitiesWindows;
using GUI.View;
using GUI.Controller;
using System.Data;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        PartnersMatcherController controller;
        ObservableCollection<ActivityRecord> RecommendedActivities;
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController"></param>
        public MainWindow(ref PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            //set view into controller here

            InitRecommendedActivities();

            locationComboBox.ItemsSource = controller.GetGeographicAreas();
            domainComboBox.ItemsSource = controller.GetFields();

            LoginWindow login = new LoginWindow(ref controller);
            login.ShowDialog();

            if (!controller.IsConnected())
                Close();
            else
            {
                controller.UpdateActivityNextId();
                this.ShowDialog();
            }
                

        }

        /// <summary>
        /// inits sample activities for recommended list
        /// </summary>
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


        #region 

        /// <summary>
        /// logic for edit profile button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditYourProfile_Click(object sender, RoutedEventArgs e)
        {
            EditProfileWindow win = new EditProfileWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for change password button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeYourPassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow win = new ChangePasswordWindow(controller);
            win.ShowDialog();

        }

        /// <summary>
        /// logic for update email button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateYourEmail_Click(object sender, RoutedEventArgs e)
        {
            UpdateEmailWindow win = new UpdateEmailWindow(controller);
            win.ShowDialog();

        }

        /// <summary>
        /// logic for update preferences button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatePreferences_Click(object sender, RoutedEventArgs e)
        {
            UpdatePreferencesWindow win = new UpdatePreferencesWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for logout button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            /*LoginWindow main = new LoginWindow(ref controller);
            main.Show();
            Close();*/

            LoginWindow login = new LoginWindow(ref controller);
            controller.SetConnected(false);
            this.Hide();
            login.ShowDialog();

            if (!controller.IsConnected())
                Close();
            else
                this.ShowDialog();
        }
        #endregion
        #region Activities

        /// <summary>
        /// logic for create new activity button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewActivity_Click(object sender, RoutedEventArgs e)
        {
            CreateNewActivityWindow win = new CreateNewActivityWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for create new field button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateNewField_Click(object sender, RoutedEventArgs e)
        {
            CreateNewFieldWindow win = new CreateNewFieldWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow win = new SearchWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for advanced search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchWindow win = new AdvancedSearchWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for watch pending requests button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchYourPendingRequests_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
        #region Activities You`re partner in

        /// <summary>
        /// logic for activities you're a partner in button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchAllActivitiesYourePartnerIn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// logic for pending requests as partner button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovePendingRequestsAsPaertner_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// logic for add bill to activity button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBillToActivirty_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// logic for pending payments button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PendingPayments_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// logic for payment history button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchYourPaymentsHistory_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// logic for pending contracts button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PendingContracts_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// logic for watch contracts you signed button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchAllContractsYouSigned_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        #endregion
        #region Activities You Manage

        /// <summary>
        /// logic for activities you manage button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatchActivitesYouManage_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// logic for approve requests button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApprovePendingRequestsAsManager_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// logic for new contract button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewContractToActivity_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// logic for new payment button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetNewPaymentInActivity_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        #endregion
        #region Chat

        /// <summary>
        /// logic for see all group messages button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeeAllConversations_Click(object sender, RoutedEventArgs e)
        {
            SeeAllConversationsWindow win = new SeeAllConversationsWindow(controller);
            win.ShowDialog();
        }

        /// <summary>
        /// logic for write new group message button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteNewGroupMessage_Click(object sender, RoutedEventArgs e)
        {
            WriteNewGroupMessageWindow win = new WriteNewGroupMessageWindow(controller);
            win.ShowDialog();
        }
        #endregion


        /// <summary>
        /// logic for search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (domainComboBox.SelectedItem == null || locationComboBox.SelectedItem == null)
                MessageBox.Show("Please select an activity field and location.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                DataSet db = controller.Search(locationComboBox.SelectedItem.ToString(), domainComboBox.SelectedItem.ToString());
                if(db.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching Activities were found.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    SearchResultsWindow sr = new SearchResultsWindow(db);
                    sr.ShowDialog();
                }
                db.Dispose();
            }     
        }

        /// <summary>
        /// logic for send request button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendJoiningRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }

}
