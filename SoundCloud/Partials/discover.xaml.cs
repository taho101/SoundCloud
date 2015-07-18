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

using RestSharp;
using SoundCloud.Client;
using SoundCloud.Objects;
using SoundCloud.Logic;

namespace SoundCloud.Partials
{
    /// <summary>
    /// Interaction logic for discover.xaml
    /// </summary>
    public partial class discover : Page
    {
        public discover()
        {
            InitializeComponent();
        }

        //only for test puropses for now
        public void setTracks()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.UserId))
            {
                var client = new SoundCloudClient();

                List<Track> tracks = client.GetTracks();

                foreach (var track in tracks)
                {
                    var response = client.GetStream(track.stream_url);

                    SoundCloudStream stream = new SoundCloudStream(response.ResponseUri.ToString());
                    break;
                }
            }
        }
    }
}
