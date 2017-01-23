﻿using GUI.Controller;
using System.Windows;

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for PendingPaymentsWindow.xaml
    /// </summary>
    public partial class PendingPaymentsWindow : Window
    {
        PartnersMatcherController controller;
        public PendingPaymentsWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
