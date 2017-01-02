﻿using PartnersMatcher;
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

namespace GUI.Windows.PartnerInActivitiesWindows
{
    /// <summary>
    /// Interaction logic for PendingPaymentsWindow.xaml
    /// </summary>
    public partial class PendingPaymentsWindow : Window
    {
        PartnersMatcherModel model;
        public PendingPaymentsWindow(ref PartnersMatcherModel PMModel)
        {
            InitializeComponent();
            model = PMModel;
        }
    }
}