using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Data.Repositories
{
    public interface ICompanyRepository
    {
        public string GetCompanyDetails(int companyId);
    }
}
