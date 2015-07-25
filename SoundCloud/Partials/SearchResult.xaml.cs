﻿using SoundCloud.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoundCloud.Partials
{
    /// <summary>
    /// Interaction logic for SearchResult.xaml
    /// </summary>
    public partial class SearchResult : Page
    {
        private SoundCloudClient client = new SoundCloudClient();

        public SearchResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Song stream event handler
        /// </summary>
        public void Song_Click(object sender, RoutedEventArgs e)
        {
            var record = ((Button) e.OriginalSource).CommandParameter;
            var response = client.GetStream(record.ToString());

            SoundCloudStream stream = new SoundCloudStream(response.ResponseUri.ToString());
        }
    }
}