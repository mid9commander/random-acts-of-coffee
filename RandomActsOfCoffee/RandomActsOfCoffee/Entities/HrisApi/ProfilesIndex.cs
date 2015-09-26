using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomActsOfCoffee.Entities.HrisApi
{
    public class ProfilesIndex
    {
        public List<Profile> profiles { get; set; }

        public ProfilesIndex()
        {   
            profiles = new List<Profile>();
        }
    }
}
