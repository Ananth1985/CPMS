using Microsoft.AspNetCore.Mvc;
using CPMS.Web.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPMS.Web.Controllers.Company
{
    public class CompanyController : Controller
    {
        public IActionResult CompanyCreation()
        {
            return View();
        }

        public IActionResult PlacementRequest()
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
            }
                return View();

            
        }
        
    }
}
