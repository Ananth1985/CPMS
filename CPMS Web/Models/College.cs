using System.ComponentModel.DataAnnotations;

namespace CPMS_Web.Models
{
    public class College
    {
        public int Id { get; set; }

        [Required]
        public string CollegeName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set;}

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string State { get; set;}
        
        [Required]        
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Pincode { get; set; }
    }    
}
