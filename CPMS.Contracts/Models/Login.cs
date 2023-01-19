using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Contracts.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string Email { get; set; }
             
        public string Password { get; set; }
                
        public int Type { get; set; }       

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
