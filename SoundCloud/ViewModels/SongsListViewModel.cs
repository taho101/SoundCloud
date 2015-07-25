using SoundCloud.Client;
using SoundCloud.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.ViewModels
{
    class SongsListViewModel : ViewModelBase
    {

        private SoundCloudClient client = new SoundCloudClient();
        private ObservableCollection<Track> _results = new ObservableCollection<Track>();

        public ObservableCollection<Track> Results
        {
            get 
            {
                _results = client.GetTracks();

                return _results; 
            }
            set { SetProperty(ref _results, value, "Results"); }
        }

    }
}
