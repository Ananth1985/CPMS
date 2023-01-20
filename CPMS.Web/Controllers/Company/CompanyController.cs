using Microsoft.AspNetCore.Mvc;

namespace CPMS.Web.Controllers.Company
{
    public class CompanyController : Controller
    {
        public IActionResult CompanyCreation()
        {
            return View();
        }
    }
}
