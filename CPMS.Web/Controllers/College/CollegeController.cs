using Microsoft.AspNetCore.Mvc;
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
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                var students = new List<CPMS.Web.Models.Student>();
                var collegeId = HttpContext.Session.GetString("LoggedInUserProfileId");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync($"https://localhost:7128/api/College/GetStudentDetailsByCollegeId?collegeId={collegeId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    students = JsonSerializer.Deserialize<List<CPMS.Web.Models.Student>>(apiResponse);
                    ViewData["Students"] = students;
                }
                ViewBag.CollegeId = collegeId;
                ViewBag.CollegeName = HttpContext.Session.GetString("LoggedInUserConcernName");
                ViewBag.CreatedBy = HttpContext.Session.GetString("LoggedInUserId");
                return View();
            }
            else
            {
                return View("../Login/Login");
            }
        }

        public IActionResult PlacementDetails()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                var placements = new List<CPMS.Web.Models.PlacementRequest>();
                var collegeId = HttpContext.Session.GetString("LoggedInUserProfileId");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync($"https://localhost:7128/api/Company/GetPlacementRequestByCollegeId?collegeId={collegeId}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    placements = JsonSerializer.Deserialize<List<CPMS.Web.Models.PlacementRequest>>(apiResponse);
                    ViewData["Placements"] = placements;
                }
                ViewBag.CollegeId = collegeId;
                ViewBag.CollegeName = HttpContext.Session.GetString("LoggedInUserConcernName");
                ViewBag.CreatedBy = HttpContext.Session.GetString("LoggedInUserId");
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
