using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace CPMS.Web.Controllers.College
{
    public class CollegeController : Controller
    {
        public IActionResult CollegeCreation()
        {
            return View();
        }

        public IActionResult College()
        {
            HttpContext.Session.SetString("IsLoggedIn", "true");
            var students = new List<CPMS.Web.Models.Student>();
            HttpClient client = new HttpClient();
            List<SelectListItem> collegeList = new List<SelectListItem>();
            HttpResponseMessage response = client.GetAsync("https://localhost:7128/api/College/GetStudentDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = response.Content.ReadAsStringAsync().Result;
                students = JsonSerializer.Deserialize<List<CPMS.Web.Models.Student>>(apiResponse);
                ViewData["Students"] = students;
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IsLoggedIn", "false");
            return View("Login");
        }
    }
}
