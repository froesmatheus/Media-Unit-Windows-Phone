using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace PhoneApp1
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void RateThisApp_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketPlaceReviewTask = new MarketplaceReviewTask();
            marketPlaceReviewTask.Show();
        }
    }
}