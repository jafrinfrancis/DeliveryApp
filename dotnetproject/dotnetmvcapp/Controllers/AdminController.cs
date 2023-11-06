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

        [HttpPost]
        public async Task<ActionResult> Register(Register model )
        {
            if(ModelState.IsValid)
            {       var response=await _service.Register(model);
                    Console.WriteLine("Test 1");
                    Console.WriteLine(response.ErrorMessage);
                    if(response!=null)
                    {
                        Console.WriteLine("Test 1");
                        return RedirectToAction("Index","Home");
                        
                    }
                    return View();
            }
           
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}