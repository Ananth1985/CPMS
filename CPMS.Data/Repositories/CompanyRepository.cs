using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMS.Contracts.Models;

namespace CPMS.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly string _connectionString;
        public CompanyRepository()
        {
            var config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();
            _connectionString = config.GetConnectionString("TechathonConnectionStrings");
        }

        public string GetCompanyDetails(int? companyId)
        {
            List<Company> companys = new List<Company>();
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetCompanyDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Company company = new Company();
                    company.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                    //company.LoginId = (reader["LoginId"]) != DBNull.Value ? Convert.ToInt32(reader["LoginId"]) : null; 
                    company.CompanyName = Convert.ToString(reader["CompanyName"]);
                    company.Email = Convert.ToString(reader["Email"]);
                    company.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    company.Fax = Convert.ToString(reader["Fax"]);
                    company.Address = Convert.ToString(reader["Address"]);
                    company.State = Convert.ToString(reader["State"]);
                    company.City = Convert.ToString(reader["City"]);
                    company.Pincode = Convert.ToString(reader["Pincode"]);
                    company.Country = Convert.ToString(reader["Country"]);
                    company.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                    company.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;
                    company.ModifiedBy = (reader["ModifiedBy"]) != DBNull.Value ? Convert.ToInt32(reader["ModifiedBy"]) : null;
                    company.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null;
                    companys.Add(company);
                }
            }
            sqlConnection.Close();
            var jsonString = JsonConvert.SerializeObject(companys);
            return jsonString;
        }
    }
}
