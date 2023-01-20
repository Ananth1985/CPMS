using Microsoft.AspNetCore.Mvc;
using CPMS.Web.Models;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Policy;

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
            List<string>  collegeList = new List<string>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7128/api");

            // Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("/College/GetCollegeDetails?collegeId=1").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadFromJsonAsync<CPMS.Web.Models.College[]>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    //Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return View();
        }
    }
}
