using CPMS.Contracts.Models;
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

        public string GetLoginDetails(Login loginDetails)
        {
            return _loginRepository.GetLoginDetails(loginDetails);
        }

        public string GetTypeDetails(int typeId)
        {
            return _loginRepository.GetTypeDetails(typeId);
        }
    }
}
