using System;
using System.Collections.Generic;
using System.Data;
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

namespace GUI.Windows.ActivitiesWindows
{
    /// <summary>
    /// Interaction logic for SearchResultsWindow.xaml
    /// </summary>
    public partial class SearchResultsWindow : Window
    {
        public SearchResultsWindow(DataSet dbSearchResults)
        {
            InitializeComponent();
            //if(dbSearchResults.Tables[0].Rows.Count == 0)
        }
    }
}
