using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        readonly string _connectionString;
        public LoginRepository()
        {
            var config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();
            _connectionString = config.GetConnectionString("TechathonConnectionStrings");
        }
        public string GetLoginDetails(string email, string password)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetLoginDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("email", email);
            command.Parameters.AddWithValue("password", password);
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "Login");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }
    }
}
