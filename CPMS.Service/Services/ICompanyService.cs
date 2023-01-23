using CPMS.Contracts.Models;

namespace CPMS.Service.Services
{
    public interface ICompanyService
    {
        public string GetCompanyDetails(int? CompanyId);

        public string GetPlacementRequestByCollegeId(int CollegeId);

        public string InsertPlacementRequest(PlacementRequest placementRequest);

        public string InsertCompanyDetails(Company company);
    }
}
