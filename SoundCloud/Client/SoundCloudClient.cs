using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace SoundCloud.Client
{
    class SoundCloudClient
    {

        private RestClient client;

        public SoundCloudClient()
        {
            client = new RestClient(Properties.Settings.Default.APIUrl);
        }
    }
}
