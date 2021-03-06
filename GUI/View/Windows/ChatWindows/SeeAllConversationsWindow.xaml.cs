﻿using GUI.DataGridRecords;
using GUI.Controller;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace GUI.Windows.ChatWindows
{
    /// <summary>
    /// Interaction logic for SeeAllConversationsWindow.xaml
    /// </summary>
    public partial class SeeAllConversationsWindow : Window
    {
        PartnersMatcherController controller;
        ObservableCollection<GroupMessageRecord> messages1;
        ObservableCollection<GroupMessageRecord> messages2;
        ObservableCollection<GroupMessageRecord> messages3;
        ObservableCollection<GroupMessageRecord> empty;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public SeeAllConversationsWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
            GroupComboBox.Items.Add("Scumbag lawyer renting his apartment");
            GroupComboBox.Items.Add("Protesting against Mondays");
            GroupComboBox.Items.Add("Protesting for Mondays");
            empty = new ObservableCollection<GroupMessageRecord>();
            InitCollections();
        }

        /// <summary>
        /// inits sample message collections
        /// </summary>
        private void InitCollections()
        {
            messages1 = new ObservableCollection<GroupMessageRecord>();
            messages2 = new ObservableCollection<GroupMessageRecord>();
            messages3 = new ObservableCollection<GroupMessageRecord>();

            messages1.Add(new GroupMessageRecord("Israeli", "Israel", "Rent is due", new DateTime(2016, 12, 24, 20, 0, 0), "Give me your money, punk."));
            messages1.Add(new GroupMessageRecord("Israeli", "Israel", "Rent is due now", new DateTime(2016, 12, 24, 20, 0, 0), "Give me your money, punk, now."));
            messages1.Add(new GroupMessageRecord("Israeli", "Israel", "Rent is due now, seriously", new DateTime(2016, 12, 24, 20, 0, 0), "Give me your money, punk, now, seriously."));

            messages2.Add(new GroupMessageRecord("Student", "A", "Down with Mondays", new DateTime(2016, 12, 24, 20, 0, 0), "We have our reasons."));
            messages2.Add(new GroupMessageRecord("Student", "A", "Screw Mondays", new DateTime(2016, 12, 24, 20, 0, 0), "No we don't."));
            messages2.Add(new GroupMessageRecord("Student", "A", "We want cake", new DateTime(2016, 12, 24, 20, 0, 0), "Caaaaaaake."));

            messages3.Add(new GroupMessageRecord("Student", "B", "Go Mondays", new DateTime(2016, 12, 24, 20, 0, 0), "Something something Mondays."));
            messages3.Add(new GroupMessageRecord("Student", "B", "Yay Mondays", new DateTime(2016, 12, 24, 20, 0, 0), "Yay."));
            messages3.Add(new GroupMessageRecord("Student", "B", "We want cake", new DateTime(2016, 12, 24, 20, 0, 0), "Caaaaaaake."));
        }

        /// <summary>
        /// open message creation dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This service is not available at the moment.", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// change message grid contents according to combobox selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (GroupComboBox.Text == "Scumbag lawyer renting his apartment")
            {
                MessagesGrid.ItemsSource = messages1;
                MessagesGrid.Items.Refresh();
            }
            else if (GroupComboBox.Text == "Protesting against Mondays")
            {
                MessagesGrid.ItemsSource = messages2;
                MessagesGrid.Items.Refresh();
            }
            else if (GroupComboBox.Text == "Protesting for Mondays")
            {
                MessagesGrid.ItemsSource = messages3;
                MessagesGrid.Items.Refresh();
            }
        }
    }
}
