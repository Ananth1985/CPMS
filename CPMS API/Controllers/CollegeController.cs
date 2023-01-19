using CPMS.Contracts.Models;
using CPMS.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace CPMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        readonly ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            _collegeService = collegeService;
        }
         
        [HttpPost]
        [Route("GetCollegeDetails")]
        public string GetCollegeDetails(int collegeId)
        {
            return _collegeService.GetCollegeDetails(collegeId);
        }

        [HttpPost]
        [Route("GetStudentDetails")]
        public string GetStudentDetails(int studentId)
        {
            return _collegeService.GetStudentDetails(studentId);
        }

        [HttpPost]
        [Route("GetDepartmentDetails")]
        public string GetDepartmentDetails(int departmentId)
        {
            return _collegeService.GetDepartmentDetails(departmentId);
        }
    }
}
