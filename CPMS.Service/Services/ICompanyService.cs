using CPMS.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Service.Services
{
    public interface ICompanyService
    {
        public string GetCompanyDetails(int? CompanyId);

        public string InsertPlacementRequest(PlacementRequest placementRequest);

        public string InsertCompanyDetails(Company company);
    }
}
