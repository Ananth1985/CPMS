using Microsoft.AspNetCore.Mvc;

namespace CPMS_Web.Controllers.College
{
    public class CollegeController : Controller
    {
        public IActionResult CollegeCreation()
        {
            return View();
        }
    }
}
