using Microsoft.AspNetCore.Mvc;
using CPMS.Web.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text.Json;

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
           var list = new List<CPMS.Web.Models.College>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://localhost:7128/api/College/GetCollegeDetails?collegeId").Result;  
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = response.Content.ReadAsStringAsync().Result;
                list = JsonSerializer.Deserialize<List<CPMS.Web.Models.College>>(apiResponse);
            }
            return View();
        }

        
    }
}
