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
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                return View();
            }
            else
            {
                return View("../Login/Login");
            }
        }
        public IActionResult Logout()
        {
            return View("Login");
        }
    }
}
