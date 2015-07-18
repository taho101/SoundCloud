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

        [Obsolete("This method is unfinished, therefore obsolete. Do not use")]
        public void Connect()
        {
            var request = this.SetRequest("connect", Method.GET);

            request.AddParameter("response_type", "token");

            var response = this.client.Execute(request);

        }


        /// <summary>
        /// Fetches list of thracks from the SoundCloud API
        /// </summary>
        public List<Track> GetTracks()
        {
            var request = this.SetRequest("tracks", Method.GET);

            var response = this.client.Execute<List<Track>>(request);

            return response.Data;
        }


        /// <summary>
        /// Adds standard parameters to the API request
        /// </summary>
        protected RestRequest SetRequest(string call, Method method)
        {
            var request = new RestRequest(call, method);

            request.AddParameter("client_id", Properties.Settings.Default.ClientID);

            return request;
        }
    }
}
