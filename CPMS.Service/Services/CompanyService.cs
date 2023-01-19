using CPMS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Service.Services
{
    public class CompanyService : ICompanyService
    {
        readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        public string GetCompanyDetails(int companyId)
        {
            return _companyRepository.GetCompanyDetails(companyId);
        }
    }
}
