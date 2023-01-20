using Microsoft.AspNetCore.Mvc;

namespace CPMS_Web.Controllers.Company
{
    public class CompanyController : Controller
    {
        public IActionResult CompanyCreation()
        {
            return View();
        }

        public IActionResult PlacementRequest()
        {
            return View();
        }
    }
}
