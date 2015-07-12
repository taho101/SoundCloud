using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using System.Windows;
using SoundCloud.Objects;

namespace SoundCloud.Client
{
    class SoundCloudClient
    {

        private RestClient client;

        public SoundCloudClient()
        {
            this.client = new RestClient(Properties.Settings.Default.APIUrl);
        }

        public void Connect()
        {
            var request = this.SetRequest("connect", Method.GET);

            request.AddParameter("response_type", "token");

            var response = this.client.Execute(request);

        }

        public List<Track> GetTracks()
        {
            var request = this.SetRequest("tracks", Method.GET);

            var response = this.client.Execute<List<Track>>(request);

            return response.Data;
        }

        protected RestRequest SetRequest(string call, Method method)
        {
            var request = new RestRequest(call, method);

            request.AddParameter("client_id", Properties.Settings.Default.ClientID);

            return request;
        }
    }
}
