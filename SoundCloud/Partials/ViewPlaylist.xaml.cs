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
    /// Interaction logic for ViewPlaylist.xaml
    /// </summary>
    public partial class ViewPlaylist : Page
    {
        private SoundCloudClient client = new SoundCloudClient();
        public ViewPlaylist()
        {
            InitializeComponent();
        }
        public void Song_Click(object sender, RoutedEventArgs e)
        {
            var record = ((Button) e.OriginalSource).CommandParameter;
            var response = client.GetStream(record.ToString());

            SoundCloudStream stream = new SoundCloudStream(response.ResponseUri.ToString());
        }
        public void Song_DoubleClick(object parameter)
        {
            var getParameter = parameter as Button;
            var record = getParameter.CommandParameter;
            var response = client.GetStream(record.ToString());

            SoundCloudStream stream = new SoundCloudStream(response.ResponseUri.ToString());
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var record = e.Parameter;
            var response = client.GetStream(record.ToString());

            SoundCloudStream stream = new SoundCloudStream(response.ResponseUri.ToString());
        }

        private void trackList_Loaded(object sender, RoutedEventArgs e)
        {
            trackList.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheelH), true);
        }
        private void MyMouseWheelH(object sender, RoutedEventArgs e)
        {

            MouseWheelEventArgs eargs = (MouseWheelEventArgs)e;

            double x = (double)eargs.Delta;

            double y = instScroll.VerticalOffset;

            instScroll.ScrollToVerticalOffset(y - x);
        }
    }
}