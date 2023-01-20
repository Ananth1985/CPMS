using System.ComponentModel.DataAnnotations;

namespace CPMS.Web.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Pincode { get; set; }
    }
}
