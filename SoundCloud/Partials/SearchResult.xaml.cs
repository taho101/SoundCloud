using SoundCloud.Client;
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
        public SearchResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Song stream event handler
        /// </summary>
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var logic = new PlaybackLogic();
            logic.LoadSong(e);
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
