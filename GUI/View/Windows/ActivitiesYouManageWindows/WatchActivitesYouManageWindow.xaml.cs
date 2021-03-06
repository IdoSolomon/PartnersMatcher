﻿using GUI.Controller;
using System.Windows;

namespace GUI.Windows.ActivitiesYouManageWindows
{
    /// <summary>
    /// Interaction logic for WatchActivitesYouManageWindow.xaml
    /// </summary>
    public partial class WatchActivitesYouManageWindow : Window
    {
        PartnersMatcherController controller;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="PMController">MVC controller</param>
        public WatchActivitesYouManageWindow(PartnersMatcherController PMController)
        {
            InitializeComponent();
            controller = PMController;
        }
    }
}
