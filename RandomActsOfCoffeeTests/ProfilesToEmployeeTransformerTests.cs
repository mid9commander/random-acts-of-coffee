using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.CompareNetObjects;
using RandomActsOfCoffee;
using RandomActsOfCoffee.Entities;
using RandomActsOfCoffee.Entities.HrisApi;

namespace RandomActsOfCoffeeTests
{
    [TestFixture]
    public class ProfilesToEmployeeTransformerTests
    {
        [TestCase(default(String), "Homer")]
        [TestCase("Homey", "Homey")]
        public void TransformProfileToEmployee(String apiPreferredName, String transformedFirstName)
        {
            //arrange
            Profile apiHomer = GetApiHomer(apiPreferredName);
            Employee expectedHomer = GetExpectedHomer(transformedFirstName);

            //act
            var transformer = new ProfilesToEmployeesTransformer();
            var profiles = new List<Profile>() { apiHomer };
            Employee transformedHomer = transformer
                .TransformProfilesToEmployees(profiles)
                .Single();

            //assert
            Assert.That(transformedHomer, IsDeeplyEqual.To(expectedHomer));
        }

        private Profile GetApiHomer(String preferredName)
        {
            return new Profile()
            {
                id = "8f8f0bd5-06fd-4652-91e6-45d1f97458ea",
                email = "ChunkyLover53@aol.com",
                preferred_name = preferredName,
                first_name = "Homer",
                last_name = "Simpson",
                user_status = "active",
                office = new Office() {  state_id = "OR" }
            };
        }

        private Employee GetExpectedHomer(String firstName)
        {
            return new Employee()
            {
                Id = "8f8f0bd5-06fd-4652-91e6-45d1f97458ea",
                FirstName = firstName,
                LastName = "Simpson",
                Email = "ChunkyLover53@aol.com",
                StateWorksIn = "OR"
            };
        }
    }
}
