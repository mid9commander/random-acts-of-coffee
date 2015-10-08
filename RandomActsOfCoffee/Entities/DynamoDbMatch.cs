using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;

namespace RandomActsOfCoffee.Entities
{
    [DynamoDBTable("RandomActsOfCoffee_Matches")]
    class DynamoDbMatch
    {
        public DynamoDbMatch()
        {
            MatchGuid = Guid.NewGuid().ToString();
        }

        [DynamoDBHashKey]
        public String MatchGuid { get; set; }
        public String EmployeeOneGuid { get; set; }
        public String EmployeeTwoGuid { get; set; }
    }
}
