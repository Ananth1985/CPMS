﻿using CPMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CPMS.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("IsLoggedIn", "false");
            return View("Login");
        }

        public IActionResult Submit(Login objLogin)
        {
            return View("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IsLoggedIn", "false");
            HttpContext.Session.SetString("LoggedInUserEmail", "");
            HttpContext.Session.SetString("LoggedInUserId", "");
            HttpContext.Session.SetString("LoggedInUserType", "");
            return View("Login");
        }

        [HttpGet]
        public void SetSessionItem(string Email,string LoginId,string TypeId)
        {
            HttpContext.Session.SetString("LoggedInUserEmail", Email);
            HttpContext.Session.SetString("LoggedInUserId", LoginId);
            HttpContext.Session.SetString("LoggedInUserType", TypeId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
