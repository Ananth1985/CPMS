using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Service.Services
{
    public interface ICollegeService
    {
        public string GetCollegeDetails(int collegeId);

        public string GetStudentDetails(int studentId);

        public string GetDepartmentDetails(int departmentId);
    }
}
