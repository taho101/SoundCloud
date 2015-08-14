using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SoundCloud.Client
{
    public class PlaybackLogic
    {
        private SoundCloudClient client = new SoundCloudClient();

        public void LoadSong(ExecutedRoutedEventArgs e)
        {
            var record = e.Parameter;
            var response = client.GetStream(record.ToString());

            SoundCloudStream stream = new SoundCloudStream();
            stream.PlayMp3FromUrl(response.ResponseUri.ToString());
        }
    }
}
