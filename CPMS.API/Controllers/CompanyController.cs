﻿using CPMS.Contracts.Models;
using CPMS.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace CPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("GetCompanyDetails")]
        public string GetCompanyDetails(int companyId)
        {
            return _companyService.GetCompanyDetails(companyId);
        }
    }
}
