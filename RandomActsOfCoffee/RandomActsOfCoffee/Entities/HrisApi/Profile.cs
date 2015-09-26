using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomActsOfCoffee.Entities.HrisApi
{
    public class Profile
    {
        public string id { get; set; }
        public string email { get; set; }
        public string preferred_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_status { get; set; }
        public Office office { get; set; }
    }
}
