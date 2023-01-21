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
            string jsonString = string.Empty;
            List <Login> logins = new List<Login>();
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetLoginDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = loginDetails.Email;
            command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = loginDetails.Password;
            command.Parameters.Add("@TypeId", SqlDbType.Int).Value = loginDetails.TypeId;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Login login = new Login();
                    login.LoginId = Convert.ToInt32(reader["LoginId"]);
                    login.Email = Convert.ToString(reader["Email"]);
                    login.Password = Convert.ToString(reader["Password"]);
                    login.TypeId = Convert.ToInt32(reader["TypeId"]);
                    login.ProfileId = Convert.ToInt32(reader["ProfileId"]);
                    login.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                    login.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;
                    login.ModifiedBy = (reader["ModifiedBy"]) != DBNull.Value ? Convert.ToInt32(reader["ModifiedBy"]) : null;
                    login.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null;
                    logins.Add(login);
                }
            }
            else
            {
                sqlConnection.Close();
                jsonString = JsonConvert.SerializeObject("User Not Found");
                return jsonString;
            }
            sqlConnection.Close();
            jsonString = JsonConvert.SerializeObject(logins);
            return jsonString;
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
