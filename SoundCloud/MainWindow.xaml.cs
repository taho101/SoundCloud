using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SoundCloud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(new Partials.SearchResult());

            /*TaskbarIcon tbi = new TaskbarIcon();
            Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/YourReferencedAssembly;component/YourPossibleSubFolder/YourResourceFile.ico")).Stream;
            tbi.Icon = new System.Drawing.Icon(iconStream);
            tbi.ToolTipText = "hello world";*/
        }

        public Frame ContentFrame
        {
            get { return this.FrameContent; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //This is just static shit will be removed once its dynamic
            loginbtn.Visibility = Visibility.Collapsed;
            Logged_in_ui.Visibility = Visibility.Visible;
        }

        private void MainPlayer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void TaskbarIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void CloseSoundcloud_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
