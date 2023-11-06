using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;


namespace dotnetmvcapp.Controllers
{
    public class HomeController : Controller 
    {
        private readonly IAccountService _accountService;
        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }
      
        public IActionResult Index()
        {
          return View();
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login login)
        {
            if (ModelState.IsValid)
            {
                // Validate the login credentials
                // You can use your service or repository to check the credentials here
                var response =await _accountService.Login(login);

                if (response.IsSuccess)
                {
                    var data = response.data;
                    HttpContext.Session.SetString("AuthToken", data.Token);
                    HttpContext.Session.SetString("UserName", data.UserName);
                    HttpContext.Session.SetString("Email", data.Email);

                    // Redirect to the dashboard page
                    return RedirectToAction("Dashboard", "DeliveryBoy");
                }
                else
                {
                    ModelState.AddModelError("Password", response.ErrorMessage);
                }
            }
            return View(login);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Register model )
        {
            if(ModelState.IsValid)
            {       var response=await _accountService.Register(model);
                    if(response!=null)
                    {
                        return RedirectToAction("Index","Home");
                        
                    }
                    return View();
            }
           
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()   
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Test()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index");
        }
    }
}