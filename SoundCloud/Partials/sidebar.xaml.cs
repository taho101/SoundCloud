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
    /// Interaction logic for sidebar.xaml
    /// </summary>
    public partial class sidebar : Page
    {
        public sidebar()
        {
            InitializeComponent();
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MainWindow getMainWindow = new MainWindow();
                switch (menulist.SelectedIndex)
                {
                    case 1:
                        getMainWindow.ContentFrame.Navigate(new Partials.discover());
                        break;
                    case 2:
                        getMainWindow.ContentFrame.Navigate(new Partials.Explore());
                        break;
                }
            }
            catch(Exception) { }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            menulist.SelectedIndex = 1;
        }
        //object NavigationSystem = getMainWindow.FrameContent.ActualHeight;
    }
}
