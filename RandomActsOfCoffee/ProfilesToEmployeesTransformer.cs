using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities;
using RandomActsOfCoffee.Entities.HrisApi;

namespace RandomActsOfCoffee
{
    public class ProfilesToEmployeesTransformer
    {
        public List<Employee> TransformProfilesToEmployees(IEnumerable<Profile> profiles)
        {
            var employees = new List<Employee>();

            foreach(Profile profile in profiles)
            {
                var employee = new Employee()
                {
                    Id = profile.id,
                    FirstName = profile.preferred_name != String.Empty ? profile.preferred_name : profile.first_name,
                    LastName = profile.last_name,
                    Email = profile.email,
                    StateWorksIn = profile.office.state_id
                };

                employees.Add(employee);
            }

            return employees;
        }
    }
}
