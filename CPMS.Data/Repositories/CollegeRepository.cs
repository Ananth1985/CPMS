﻿using Newtonsoft.Json;
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
            var jsonString = JsonConvert.SerializeObject(colleges);
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
                    student.CollegeId = Convert.ToInt32(reader["CollegeId"]);
                    student.FirstName = Convert.ToString(reader["FirstName"]);
                    student.LastName = Convert.ToString(reader["LastName"]);
                    student.Email = Convert.ToString(reader["Email"]);
                    student.GenderId = Convert.ToInt32(reader["GenderId"]);
                    student.CGPA = Convert.ToDecimal(reader["CGPA"]);
                    student.NoofArrears = Convert.ToInt32(reader["NoofArrears"]);
                    student.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    student.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    student.Address = Convert.ToString(reader["Address"]);
                    student.State = Convert.ToString(reader["State"]);
                    student.City = Convert.ToString(reader["City"]);
                    student.Pincode = Convert.ToString(reader["Pincode"]);
                    student.Country = Convert.ToString(reader["Country"]);
                    student.CreatedBy = Convert.ToInt32(reader["CreatedBy"]);
                    student.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : null;
                    student.ModifiedBy = (reader["ModifiedBy"]) != DBNull.Value ? Convert.ToInt32(reader["ModifiedBy"]) : null;
                    student.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? Convert.ToDateTime(reader["ModifiedDate"]) : null;
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
            var jsonString = JsonConvert.SerializeObject(students);
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
            var jsonString = JsonConvert.SerializeObject(departments);
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
            var jsonString = JsonConvert.SerializeObject(departments);
            return jsonString;
        }
    }
}
