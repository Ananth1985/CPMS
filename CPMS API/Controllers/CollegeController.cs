using CPMS.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public string GetCollegeDetails(int collegeId)
        {
            return _collegeService.GetCollegeDetails(collegeId);
        }
        [HttpPost]
        public string GetStudentDetails(int studentId)
        {
            return _collegeService.GetStudentDetails(studentId);
        }
        [HttpPost]
        public string GetDepartmentDetails(int departmentId)
        {
            return _collegeService.GetDepartmentDetails(departmentId);
        }
    }
}
