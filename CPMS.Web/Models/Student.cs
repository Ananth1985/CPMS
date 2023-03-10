namespace CPMS.Web.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public int CollegeId { get; set; }

        public string? CollegeName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int GenderId { get; set; }

        public string? Gender { get; set; }

        public string Email { get; set; }

        public decimal CGPA { get; set; }

        public int NoofArrears { get; set; }

        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Pincode { get; set; }

        public string Country { get; set; }
    }
}
