using Hardcodet.Wpf.TaskbarNotification;
using NAudio.Wave;
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
        //boolean markers for playback
        private bool songPaused = false;

        public Partials.sidebar _Sidebar;

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(new Partials.ViewPlaylist());
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
            if (this != null && this.Visibility == Visibility.Hidden)
            {                
                this.Show();
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void CloseSoundcloud_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            _Sidebar._menulist = 3;
        }

        //currently not working as intended
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            WaveOut playback = Properties.Settings.Default.Playback;

            if (playback != null)
            {
                if (this.songPaused == true)
                {
                    playback.Play();
                    this.songPaused = false;
                }
                else
                {
                    playback.Pause();
                    this.songPaused = true;
                }
            }
        }
    }
}
