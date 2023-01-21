using CPMS.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Data.Repositories
{
    public interface ICompanyRepository
    {
        public string GetCompanyDetails(int? companyId);

        public string InsertPlacementRequest(PlacementRequest placementRequest);

        public string InsertCompanyDetails(Company company);
    }
}
