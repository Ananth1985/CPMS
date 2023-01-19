using CPMS.Contracts.Models;
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
        public string GetLoginDetails(Login loginDetails)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetLoginDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = loginDetails.Email;
            command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = loginDetails.Password;
            command.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = loginDetails.Type;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "Login");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }

        


        public string GetTypeDetails(int TypeId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetTypeDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = TypeId;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "TypeDetails");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }

       

    }
}
