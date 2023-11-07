using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetmvcapp.Services;
using dotnetmvcapp.Models;
using System.Reflection;



namespace dotnetmvcapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService _service;
        private readonly IOrderService _orderService;
        public AdminController(IOrderService orderService,IAccountService service)
        {
            _service=service;
            _orderService = orderService;
        }
        public ActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddOrderDetails()
        {
        //    var orderTypes = Enum.GetNames(typeof(OrderType)).Select(x => new SelectListItem { Text = x, Value = x }).ToList();
        //    ViewData["OrderType"] = orderTypes;

           var enumData = from OrderType e in Enum.GetValues(typeof(OrderType))  
            select new   
            {   
            ID = (int)e,   
            Name = e.ToString()   
            };  
           //ViewBag.OrderType=new SelectList(enumData,"ID","Name");  
    
            var order = new Order();
           return View(order);
        }
        [HttpPost]
        public async Task<ActionResult> AddOrderDetails(Order model )
        {
            if(ModelState.IsValid)
            {       var response=await _orderService.CreateOrder(model);
                    if(response!=null)
                    {
                        return RedirectToAction("Dashboard","Admin");
                        
                    }
                    return View();
            }

            OrderType selectedOrderType = model.OrderType;
           
            return View(model);
        }
    }
}