using CPMS.Contracts.Models;
using CPMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Service.Services
{
    public class CollegeService : ICollegeService
    {
        readonly ICollegeRepository _collegeRepository;
        public CollegeService(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public string GetCollegeDetails(int? collegeId)
        {
            return _collegeRepository.GetCollegeDetails(collegeId);
        }

        public string GetStudentDetails(int? studentId)
        {
            return _collegeRepository.GetStudentDetails(studentId);
        }

        public string GetDepartmentDetails(int? departmentId)
        {
            return _collegeRepository.GetDepartmentDetails(departmentId);
        }

        public string GetAllDepartmentByCollegeId(int collegeId)
        {
            return _collegeRepository.GetAllDepartmentByCollegeId(collegeId);
        }


    }
}
