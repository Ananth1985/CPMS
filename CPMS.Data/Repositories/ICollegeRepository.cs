using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Data.Repositories
{
    public interface ICollegeRepository
    {
        public string GetCollegeDetails(int? collegeId);

        public string GetStudentDetails(int? studentId);

        public string GetDepartmentDetails(int? departmentId);

        public string GetAllDepartmentByCollegeId(int collegeId);
    }
}
