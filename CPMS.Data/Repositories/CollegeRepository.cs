using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CPMS.Contracts.Models;

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
            List<College> colleges = new List<College>();
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetCollegeDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CollegeId", SqlDbType.Int).Value = collegeId;           
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    College college = new College();
                    college.CollegeId = Convert.ToInt32(reader["CollegeId"]);
                    college.CollegeName = Convert.ToString(reader["CollegeName"]);
                    college.Email = Convert.ToString(reader["Email"]);
                    college.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    college.Fax = Convert.ToString(reader["Fax"]);
                    college.Address = Convert.ToString(reader["Address"]);
                    college.State = Convert.ToString(reader["State"]);
                    college.City = Convert.ToString(reader["City"]);
                    college.Pincode = Convert.ToString(reader["Pincode"]);
                    college.Country = Convert.ToString(reader["Country"]);
                    college.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                    college.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;
                    college.ModifiedBy = (reader["ModifiedBy"]) != DBNull.Value ? Convert.ToInt32(reader["ModifiedBy"]) : null; 
                    college.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null; 
                    colleges.Add(college);     
                }               
            }
            else
            {
                sqlConnection.Close();
                var jsonErrorString = JsonConvert.SerializeObject("College Details Not Found.");
                return jsonErrorString;
            }
            sqlConnection.Close();
            var jsonString = JsonConvert.SerializeObject(colleges, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return jsonString;
        }

        public string GetStudentDetails(int? studentId)
        {
            List<Student> students = new List<Student>();
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetStudentDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentId;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.CollegeId = Convert.ToInt32(reader["CollegeId"]);
                    student.CollegeName = Convert.ToString(reader["CollegeName"]);
                    student.FirstName = Convert.ToString(reader["FirstName"]);
                    student.MiddleName = Convert.ToString(reader["MiddleName"]);
                    student.LastName = Convert.ToString(reader["LastName"]);
                    student.Email = Convert.ToString(reader["Email"]);
                    student.GenderId = Convert.ToInt32(reader["GenderId"]);
                    student.Gender = Convert.ToString(reader["GenderName"]);
                    student.CGPA = Convert.ToDecimal(reader["CGPA"]);
                    student.NoofArrears = Convert.ToInt32(reader["NoofArrears"]);
                    student.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    student.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    student.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    student.Address = Convert.ToString(reader["Address"]);
                    student.State = Convert.ToString(reader["State"]);
                    student.City = Convert.ToString(reader["City"]);
                    student.Pincode = Convert.ToString(reader["Pincode"]);
                    student.Country = Convert.ToString(reader["Country"]);
                    student.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                    student.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;                 
                    students.Add(student);
                }
            }
            else
            {
                sqlConnection.Close();
                var jsonErrorString = JsonConvert.SerializeObject("Student Not Found.");
                return jsonErrorString;
            }
            sqlConnection.Close();
            var jsonString = JsonConvert.SerializeObject(students, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return jsonString;
        }

        public string GetDepartmentDetails(int? departmentId)
        {
            List<Department> departments = new List<Department>();
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetDepartmentDetails", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@departmentId", SqlDbType.Int).Value = departmentId;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    department.CollegeId = Convert.ToInt32(reader["CollegeId"]);
                    department.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    department.NoofStudents = Convert.ToInt32(reader["NoofStudents"]);
                    department.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    department.CreatedBy = (reader["CreatedBy"]) != DBNull.Value ? Convert.ToInt32(reader["CreatedBy"]) : null;
                    department.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;
                    department.ModifiedBy = (reader["ModifiedBy"]) != DBNull.Value ? Convert.ToInt32(reader["ModifiedBy"]) : null;
                    department.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null;
                    departments.Add(department);
                }
            }
            else
            {
                sqlConnection.Close();
                var jsonErrorString = JsonConvert.SerializeObject("Department Not Found.");
                return jsonErrorString;
            }
            sqlConnection.Close();
            var jsonString = JsonConvert.SerializeObject(departments, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return jsonString;
        }

        public string GetAllDepartmentByCollegeId(int collegeId)
        {
            List<Department> departments = new List<Department>();
            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            using var command = new SqlCommand("GetAllDepartmentByCollegeId", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CollegeId", SqlDbType.Int).Value = collegeId;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    department.CollegeId = Convert.ToInt32(reader["CollegeId"]);
                    department.CollegeName = Convert.ToString(reader["CollegeName"]);
                    department.DepartmentName = Convert.ToString(reader["DepartmentName"]);                  
                    department.NoofStudents = Convert.ToInt32(reader["NoofStudents"]);                   
                    department.CreatedBy = (reader["CreatedBy"]) != DBNull.Value ? Convert.ToInt32(reader["CreatedBy"]) : null;
                    department.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;
                    department.ModifiedBy = (reader["ModifiedBy"]) != DBNull.Value ? Convert.ToInt32(reader["ModifiedBy"]) : null;
                    department.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null;
                    departments.Add(department);
                }
            }
            else
            {
                sqlConnection.Close();
                var jsonErrorString = JsonConvert.SerializeObject("Department Not Found based on the college.");
                return jsonErrorString;
            }
            sqlConnection.Close();
            var jsonString = JsonConvert.SerializeObject(departments, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return jsonString;
        }

        public string InsertCollegeDetails(College college)
        {
            try
            {
                string jsonString = string.Empty;
                using var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                using var command = new SqlCommand("InsertCollegeDetails", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CollegeName", SqlDbType.VarChar).Value = college.CollegeName;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = college.Email;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = college.PhoneNumber;
                command.Parameters.Add("@Fax", SqlDbType.VarChar).Value = college.Fax;
                command.Parameters.Add("@Address", SqlDbType.VarChar).Value = college.Address;
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = college.State;
                command.Parameters.Add("@City", SqlDbType.VarChar).Value = college.City;
                command.Parameters.Add("@Pincode", SqlDbType.NVarChar).Value = college.Pincode;
                command.Parameters.Add("@Country", SqlDbType.VarChar).Value = college.Country;
                command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = college.CreatedBy;
                command.Parameters.Add("@CollegeId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                int CollegeId = Convert.ToInt32(command.Parameters["@CollegeId"].Value);
                sqlConnection.Close();
                if (CollegeId > 0)
                    jsonString = JsonConvert.SerializeObject("College Details Inserted Successfully.");
                else
                    jsonString = JsonConvert.SerializeObject("College Name : " + college.CollegeName + " already exists.");
                return jsonString;
            }
            catch (Exception exp)
            {
                var jsonString = JsonConvert.SerializeObject(exp.Message);
                return jsonString;
            }
        }

        public string InsertStudentDetails(Student student)
        {
            try
            {
                string jsonString = string.Empty;
                using var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                using var command = new SqlCommand("InsertStudentDetails", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = student.FirstName;
                command.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = student.MiddleName;
                command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = student.LastName;
                command.Parameters.Add("@GenderId", SqlDbType.Int).Value = student.GenderId;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = student.Email;
                command.Parameters.Add("@CGPA", SqlDbType.Decimal).Value = student.CGPA;
                command.Parameters.Add("@NoofArrears", SqlDbType.Int).Value = student.NoofArrears;               
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = student.PhoneNumber;               
                command.Parameters.Add("@Address", SqlDbType.VarChar).Value = student.Address;
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = student.State;
                command.Parameters.Add("@City", SqlDbType.VarChar).Value = student.City;
                command.Parameters.Add("@Pincode", SqlDbType.NVarChar).Value = student.Pincode;
                command.Parameters.Add("@Country", SqlDbType.VarChar).Value = student.Country;
                command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = student.CreatedBy;
                command.Parameters.Add("@CollegeId", SqlDbType.Int).Value = student.CollegeId;
                command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = student.DepartmentId;                
                command.Parameters.Add("@StudentId", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                int StudentId = Convert.ToInt32(command.Parameters["@StudentId"].Value);
                sqlConnection.Close();
                if (StudentId > 0)
                    jsonString = JsonConvert.SerializeObject("Student Details Inserted Successfully.");
                else
                    jsonString = JsonConvert.SerializeObject("Student Name : " + student.FirstName + " " + student.MiddleName + " " + student.LastName + " already exists.");
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
