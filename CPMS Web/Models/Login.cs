using System.ComponentModel.DataAnnotations;

namespace CPMS_Web.Models
{
    public class Login
    {
        [Required]
        public string EmailAddress  { get; set; }

        [Required]  
        public string Password { get; set; }

        [Required]  
        public int Type { get; set; }
                
        public int Id { get; set; }
    }
}
