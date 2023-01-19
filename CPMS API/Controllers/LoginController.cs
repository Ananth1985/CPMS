using CPMS.Contracts.Models;
using CPMS.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace CPMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ILoginService _iLoginService;

        public LoginController(ILoginService iLoginService)
        {
            _iLoginService = iLoginService;
        }

        [HttpPost]
        public string GetLoginDetails([FromBody] Login loginDetails)
        {
            return _iLoginService.GetLoginDetails(loginDetails);
        }
    }
}
