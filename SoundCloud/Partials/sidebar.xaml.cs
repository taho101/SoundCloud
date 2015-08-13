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
        MainWindow _MainWindow = ((MainWindow)System.Windows.Application.Current.MainWindow);
        public sidebar()
        {
            InitializeComponent();
            _MainWindow._Sidebar = this;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (menulist.SelectedIndex)
                {
                    case 1:
                        _MainWindow.ContentFrame.Navigate(new Partials.discover());
                        break;
                    case 2:
                        _MainWindow.ContentFrame.Navigate(new Partials.Explore());
                        break;
                    case 3:
                        _MainWindow.ContentFrame.Navigate(new Partials.SearchResult());
                        break;
                    case 4:
                        _MainWindow.ContentFrame.Navigate(new Partials.SearchResult());
                        break;
                    default:
                        _MainWindow.ContentFrame.Navigate(new Partials.discover());
                        break;
                }
            }
            catch(Exception) { }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            menulist.SelectedIndex = 1;
        }
        public int _menulist {
            get { return menulist.SelectedIndex; }
            set { menulist.SelectedIndex = value; }
        }
    }
}
