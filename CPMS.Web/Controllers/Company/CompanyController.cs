using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPMS.Web.Controllers.Company
{
    public class CompanyController : Controller
    {
        public IActionResult CompanyCreation()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                ViewBag.CreatedBy = HttpContext.Session.GetString("LoggedInUserId");
                return View();
            }
            else
            {
                return View("../Login/Login");
            }
        }

        public IActionResult PlacementRequest()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                var colleges = new List<CPMS.Web.Models.College>();
                HttpClient client = new HttpClient();
                List<SelectListItem> collegeList = new List<SelectListItem>();
                HttpResponseMessage response = client.GetAsync("https://localhost:7128/api/College/GetCollegeDetails?collegeId").Result;
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    colleges = JsonSerializer.Deserialize<List<CPMS.Web.Models.College>>(apiResponse);
                    for (int i = 0; i < colleges.Count; i++)
                    {
                        collegeList.Add(new SelectListItem { Text = colleges[i].CollegeName.ToString(), Value = colleges[i].CollegeId.ToString() });
                    }
                    ViewData["colleges"] = collegeList;
                    ViewBag.CompanyName = HttpContext.Session.GetString("LoggedInUserConcernName");
                    ViewBag.CompanyId = HttpContext.Session.GetString("LoggedInUserProfileId");
                    ViewBag.CreatedBy = HttpContext.Session.GetString("LoggedInUserId");
                }
                return View();
            }
            else
            {
                return View("../Login/Login");
            }

        }

        public IActionResult Company()
        {
            if (HttpContext.Session.GetString("IsLoggedIn") == "true")
            {
                ViewBag.CompanyName = HttpContext.Session.GetString("LoggedInUserConcernName");
                return View("Company");
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
