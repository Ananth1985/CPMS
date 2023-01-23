using CPMS.Contracts.Models;
using CPMS.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("GetCompanyDetails")]
        public string GetCompanyDetails(int? companyId = null)
        {
            return _companyService.GetCompanyDetails(companyId);
        }

        [HttpGet]
        [Route("GetPlacementRequestByCollegeId")]
        public string GetPlacementRequestByCollegeId(int collegeId)
        {
            return _companyService.GetPlacementRequestByCollegeId(collegeId);
        }

        [HttpPost]
        [Route("InsertPlacementRequest")]
        public string InsertPlacementRequest(PlacementRequest placementRequest)
        {
            return _companyService.InsertPlacementRequest(placementRequest);
        }

        [HttpPost]
        [Route("InsertCompanyDetails")]
        public string InsertCompanyDetails(Company company)
        {
            return _companyService.InsertCompanyDetails(company);
        }
    }
}
