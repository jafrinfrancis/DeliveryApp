using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetmvcapp.Services;
using dotnetmvcapp.Models;



namespace dotnetmvcapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService _service;
        public AdminController(IAccountService service)
        {
            _service=service;
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}