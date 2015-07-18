using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundCloud.Client;

namespace SoundCloud.Tests
{
    [TestClass]
    class APITests
    {
        SoundCloudClient client;

        [TestInitialize]
        public void initAPI()
        {
            client = new SoundCloudClient();
        }


        [TestMethod]
        public void TestListing()
        {
            var items = client.GetTracks();

            Assert.AreNotEqual(items, null);
        }

    }
}
