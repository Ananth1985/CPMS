using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CPMS.Data.Repositories
{
    public class CollegeRepository : ICollegeRepository
    {
        readonly string _connectionString;
        public CollegeRepository()
        {
            var config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();
            _connectionString = config.GetConnectionString("TechathonConnectionStrings");
        }
        public string GetCollegeDetails(int? collegeId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetCollegeDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CollegeId", SqlDbType.Int).Value = collegeId;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "CollegeDetails");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }

        public string GetStudentDetails(int? studentId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetStudentDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentId;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "StudentDetails");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }

        public string GetDepartmentDetails(int? departmentId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetDepartmentDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = departmentId;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "DepartmentDetails");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }

        public string GetAllDepartmentByCollegeId(int collegeId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetAllDepartmentByCollegeId", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CollegeId", SqlDbType.Int).Value = collegeId;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "DepartmentDetails");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }
    }
}
