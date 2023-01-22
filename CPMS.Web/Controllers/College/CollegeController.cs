using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
//using Newtonsoft.Json;

namespace CPMS.Web.Controllers.College
{
    public class CollegeController : Controller
    {
        public IActionResult College()
        {
            var students = new List<CPMS.Web.Models.Student>();
            HttpClient client = new HttpClient();
            List<SelectListItem> collegeList = new List<SelectListItem>();
            HttpResponseMessage response = client.GetAsync("https://localhost:7128/api/College/GetStudentDetails").Result;
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = response.Content.ReadAsStringAsync().Result;
                students = JsonSerializer.Deserialize<List<CPMS.Web.Models.Student>>(apiResponse);
                //for (int i = 0; i < students.Count; i++)
                //{
                //    collegeList.Add(new SelectListItem { Text = colleges[i].CollegeName.ToString(), Value = colleges[i].CollegeId.ToString() });
                //}
                ViewData["Students"] = students;
            }
            return View();
        }
        public IActionResult CollegeCreation()
        {
            return View();
        }
        
    }
}
