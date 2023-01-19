using CPMS.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public string GetLoginDetails(string email, string password)
        {
            return _iLoginService.GetLoginDetails(email, password);
        }
    }
}
