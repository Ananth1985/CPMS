using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CPMS.Web.Models
{
    public class College
    {
        [JsonProperty("CollegeId")]
        public int CollegeId { get; set; }

        [Required]
        [JsonProperty]
        public string CollegeName { get; set; }
        [Required]
        [JsonProperty]
        public string Email { get; set; }
        [Required]
        [JsonProperty]
        public string PhoneNumber { get; set; }
        [JsonProperty("Fax")]
        public string FaxNumber { get; set;}

        [Required]
        [JsonProperty]
        public string Address { get; set; }
        
        [Required]
        [JsonProperty]
        public string State { get; set;}
        
        [Required]
        [JsonProperty]
        public string City { get; set; }

        [Required]
        [JsonProperty]
        public string Country { get; set; }

        [Required]
        [JsonProperty]
        public string Pincode { get; set; }
    }    

}
