using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Contracts.Models
{
    public class Company
    {
        public int Id { get; set; }
        
        public int LoginId { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Pincode { get; set; }

        public string Country { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
