using CPMS.Contracts.Models;
using CPMS.Data.Repositories;

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

        public string GetStudentDetailsByCollegeId(int collegeId)
        {
            return _collegeRepository.GetStudentDetailsByCollegeId(collegeId);
        }

        public string GetDepartmentDetails(int? departmentId)
        {
            return _collegeRepository.GetDepartmentDetails(departmentId);
        }

        public string GetAllDepartmentByCollegeId(int collegeId)
        {
            return _collegeRepository.GetAllDepartmentByCollegeId(collegeId);
        }

        public string InsertCollegeDetails(College college)
        {
            return _collegeRepository.InsertCollegeDetails(college);
        }

        public string InsertStudentDetails(Student student)
        {
            return _collegeRepository.InsertStudentDetails(student);
        }
    }
}
