using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.Objects
{
    class Track
    {
        public int id {get; set;}

        public string created_at { get; set; }

        public int user_id { get; set; }

        public User user { get; set; }

        public string title { get; set; }

        public string permalink_url { get; set; }

        public string uri { get; set; }

        public string artwork_url { get; set; }

        public string description { get; set; }

        //missing representation of "label"

        public int duration { get; set; }

        public string genre { get; set; }

        public string release_day { get; set; }

        public string release_month { get; set; }

        public string release_year { get; set; }

        public bool streamable { get; set; }

        public string stream_url { get; set; }
    }
}
