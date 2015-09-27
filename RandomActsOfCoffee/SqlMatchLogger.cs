using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using RandomActsOfCoffee.Entities;
using System.Data;

namespace RandomActsOfCoffee
{
    public class SqlMatchLogger : IMatchLogger
    {
        private readonly List<Match> _preexistingMatches;

        public SqlMatchLogger()
        {
            _preexistingMatches = new List<Match>();

            //grab all of the preexisting matches
            var query = "SELECT EmployeeOneId, EmployeeTwoId FROM Matches";
            var connectionString = ConfigurationManager.ConnectionStrings["RandomActsOfCoffee"].ConnectionString;
            var datatable = new DataTable();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    connection.Open();
                    adapter.Fill(datatable);
                }
            }

            foreach (DataRow row in datatable.Rows)
            {
                var match = new Match()
                {
                    EmployeeOne = new Employee() { Id = ((Guid)row["EmployeeOneId"]).ToString() },
                    EmployeeTwo = new Employee() { Id = ((Guid)row["EmployeeTwoId"]).ToString() },
                };
                _preexistingMatches.Add(match);
            }
        }

        public void LogMatches(IEnumerable<Match> matches)
        {
            //log them to the Matches table
            var matchesTable = new DataTable();
            matchesTable.Columns.Add("EmployeeOneId", System.Type.GetType("System.Guid"));
            matchesTable.Columns.Add("EmployeeTwoId", System.Type.GetType("System.Guid"));

            foreach(var match in matches)
            {
                matchesTable.Rows.Add(match.EmployeeOne.Id, match.EmployeeTwo.Id);
            }

            var connectionString = ConfigurationManager.ConnectionStrings["RandomActsOfCoffee"].ConnectionString;
            using (var bulkCopy = new SqlBulkCopy(connectionString))
            {
                bulkCopy.DestinationTableName = "Matches";
                bulkCopy.WriteToServer(matchesTable);
            }
        }

        public Boolean IsAPreexistingMatch(Match match)
        {
            foreach(var preexistingMatch in _preexistingMatches)
            {
                if (preexistingMatch.EmployeeOne.Id == match.EmployeeOne.Id && preexistingMatch.EmployeeTwo.Id == match.EmployeeTwo.Id)
                    return true;
                else if (preexistingMatch.EmployeeOne.Id == match.EmployeeTwo.Id && preexistingMatch.EmployeeTwo.Id == match.EmployeeOne.Id)
                    return true;
            }
            return false;
        }
    }
}
