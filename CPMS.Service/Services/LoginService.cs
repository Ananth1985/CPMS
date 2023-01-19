using CPMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Service.Services
{
    public class LoginService : ILoginService
    {
        readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public string GetLoginDetails(string email, string password)
        {
            return _loginRepository.GetLoginDetails(email, password);
        }
    }
}
