using Microsoft.AspNetCore.Mvc;

namespace CPMS_Web.Controllers.Company
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
