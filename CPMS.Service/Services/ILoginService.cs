using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Service.Services
{
    public interface ILoginService
    {
        public string GetLoginDetails(string email, string password);
    }
}
