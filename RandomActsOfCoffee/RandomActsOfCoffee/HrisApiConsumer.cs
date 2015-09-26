using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities.HrisApi;
using System.Net;
using Newtonsoft.Json;

namespace RandomActsOfCoffee
{
    public class HrisApiConsumer
    {
        private readonly String accessToken = "105c4cc2db5d58ba859a698caf3530ea";

        public ProfilesIndex GetProfilesIndex(String subdomain)
        {
            var url = String.Format("https://{0}.stage6.namely.com/api/v1/profiles.json?access_token={1}&limit=all", subdomain, accessToken);

            //the test environment won't have a trusted certificate
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            //get JSON and deseralize it
            ProfilesIndex profilesIndex;
            using (var client = new WebClient())
            {
                var json = client.DownloadString(url);
                profilesIndex = JsonConvert.DeserializeObject<ProfilesIndex>(json);
            }
            return profilesIndex;
        }
    }
}
