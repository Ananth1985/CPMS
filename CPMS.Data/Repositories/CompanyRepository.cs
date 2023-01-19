using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetCompanyDetails(int companyId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetCompanyDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = companyId;
            command.ExecuteScalar();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "CompanyDetails");
            sqlConnection.Close();
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(ds);
            return JSONresult;
        }
    }
}
