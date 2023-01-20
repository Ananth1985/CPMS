using CPMS.Contracts.Models;
using CPMS.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace CPMS.API.Controllers
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
        [Route("GetLoginDetails")]
        public string GetLoginDetails([FromBody] Login loginDetails)
        {
            return _iLoginService.GetLoginDetails(loginDetails);
        }
    }
}
