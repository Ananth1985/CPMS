using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Contracts.Models
{
    public class Department
    {
        public int CollegeId { get; set; }

        public string CollegeName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        
        public int NoofStudents { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
