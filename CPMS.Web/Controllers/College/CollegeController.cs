using Microsoft.AspNetCore.Mvc;

namespace CPMS.Web.Controllers.College
{
    public class CollegeController : Controller
    {
        public IActionResult CollegeCreation()
        {
            return View();
        }

        public IActionResult CollegeLandingPage()
        {
            HttpContext.Session.SetString("IsLoggedIn", "true");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IsLoggedIn", "false");
            return View("Login");
        }
    }
}
