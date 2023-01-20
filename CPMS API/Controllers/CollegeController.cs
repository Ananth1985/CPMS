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
         
        [HttpGet]
        [Route("GetCollegeDetails")]
        public string GetCollegeDetails(int? collegeId = null)
        {
            return _collegeService.GetCollegeDetails(collegeId);
        }

        [HttpGet]
        [Route("GetStudentDetails")]
        public string GetStudentDetails(int? studentId = null)
        {
            return _collegeService.GetStudentDetails(studentId);
        }

        [HttpGet]
        [Route("GetDepartmentDetails")]
        public string GetDepartmentDetails(int departmentId)
        {
            return _collegeService.GetDepartmentDetails(departmentId);
        }

        [HttpGet]
        [Route("GetAllDepartmentByCollegeId")]
        public string GetAllDepartmentByCollegeId(int collegeId)
        {
            return _collegeService.GetAllDepartmentByCollegeId(collegeId);
        }
    }
}
