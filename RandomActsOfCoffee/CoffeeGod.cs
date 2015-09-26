using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities;
using RandomActsOfCoffee.Entities.HrisApi;

namespace RandomActsOfCoffee
{
    class CoffeeGod
    {
        public void ArrangeRandomActsOfCoffee(IMatchAlerter matchAlerter)
        {
            var consumer = new HrisApiConsumer();
            ProfilesIndex profilesIndex = consumer.GetProfilesIndex("namely");
            List<Profile> profiles = profilesIndex.profiles.Where(p => p.user_status == "active").ToList();

            var transformer = new ProfilesToEmployeesTransformer();
            List<Employee> employees = transformer.TransformProfilesToEmployees(profiles);

            var matchMaker = new MatchMaker();
            var matches = matchMaker.GetMatches(employees, 100);
            matchAlerter.AlertMatches(matches);
        }
    }
}
