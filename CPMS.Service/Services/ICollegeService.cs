using CPMS.Contracts.Models;

namespace CPMS.Service.Services
{
    public interface ICollegeService
    {
        public string GetCollegeDetails(int? collegeId);

        public string GetStudentDetails(int? studentId);

        public string GetStudentDetailsByCollegeId(int collegeId);

        public string GetDepartmentDetails(int? departmentId);

        public string GetAllDepartmentByCollegeId(int collegeId);

        public string InsertCollegeDetails(College college);

        public string InsertStudentDetails(Student student);
    }
}
