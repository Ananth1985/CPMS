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
using System.Diagnostics.Metrics;

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
            else
            {
                sqlConnection.Close();
                var jsonErrorString = JsonConvert.SerializeObject("Company Details Not Found.");
                return jsonErrorString;
            }
            sqlConnection.Close();
            var jsonString = JsonConvert.SerializeObject(companys, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return jsonString;
        }

        public string InsertPlacementRequest(PlacementRequest placementRequest)
        {
            try
            {
                using var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                using var command = new SqlCommand("InsertPlacementRequest", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CollegeId", SqlDbType.Int).Value = placementRequest.CollegeId;
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Value = placementRequest.CompanyId;
                command.Parameters.Add("@RequestedDate", SqlDbType.DateTime).Value = placementRequest.RequestedDate;
                command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = placementRequest.CreatedBy;
                command.Parameters.Add("@PlacementRequestId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                int PlacementRequestId = Convert.ToInt32(command.Parameters["@PlacementRequestId"].Value);
                sqlConnection.Close();
                InsertPlacementRequestDetails(PlacementRequestId, placementRequest.DepartmentIds, placementRequest.Arrears, placementRequest.CGPA, placementRequest.CreatedBy);
                var jsonString = JsonConvert.SerializeObject("Placement Request Inserted Successfully.");
                return jsonString;
            }
            catch (Exception exp)
            {
                var jsonString = JsonConvert.SerializeObject(exp.Message);
                return jsonString;
            }
        }

        public void InsertPlacementRequestDetails(int PlacementRequestId, string departmentIds, int arrears, decimal CGPA, int createdBy)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            string[] strArr = departmentIds.Split(',');
            for (int i = 0; i < strArr.Length; i++)
            {
                using var command = new SqlCommand("InsertPlacementRequestDetails", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PlacementRequestId", SqlDbType.Int).Value = PlacementRequestId;
                command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = Convert.ToInt64(strArr[i]);
                command.Parameters.Add("@Arrears", SqlDbType.Int).Value = arrears;
                command.Parameters.Add("@CGPA", SqlDbType.Decimal).Value = CGPA;
                command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = createdBy;
                command.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }

        public string InsertCompanyDetails(Company company)
        {
            try
            {
                string jsonString = string.Empty;
                using var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                using var command = new SqlCommand("InsertCompanyDetails", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = company.CompanyName;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = company.Email;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = company.PhoneNumber;
                command.Parameters.Add("@Fax", SqlDbType.VarChar).Value = company.Fax;
                command.Parameters.Add("@Address", SqlDbType.VarChar).Value = company.Address;
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = company.State;
                command.Parameters.Add("@City", SqlDbType.VarChar).Value = company.City;
                command.Parameters.Add("@Pincode", SqlDbType.NVarChar).Value = company.Pincode;
                command.Parameters.Add("@Country", SqlDbType.VarChar).Value = company.Country;
                command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = company.CreatedBy;
                command.Parameters.Add("@CompanyId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                int CompanyId = Convert.ToInt32(command.Parameters["@CompanyId"].Value);
                sqlConnection.Close();
                if (CompanyId > 0)
                    jsonString = JsonConvert.SerializeObject("Company Details Inserted Successfully.");
                else
                    jsonString = JsonConvert.SerializeObject("Company Name : " + company.CompanyName + " already exists.");
                return jsonString;
            }
            catch (Exception exp)
            {
                var jsonString = JsonConvert.SerializeObject(exp.Message);
                return jsonString;
            }
        }
    }
}
