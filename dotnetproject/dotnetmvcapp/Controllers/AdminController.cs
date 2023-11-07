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
using dotnetmvcapp.ViewModels;


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
        public async Task<ActionResult> Dashboard()
        {
            var orders = await _orderService.GetAllOrders();
            var dasboard = new DeliveryDashboardViewModel
            {
                details = orders.Select(o => new DeliveryDetails
                {
                    DeliveryId = o.Delivery?.Id ?? 0,
                    OrderId = o.Id,
                    OrderedDate = o.CreatedDate.ToLongDateString(),
                    DeliveryStatus = GetDeliveryStatus(o.Delivery.DeliveryStatus),
                    CustomerName = o.CustomerName,
                    ContactNumber = o.ContactNumber,
                    Location = o.Location,
                    Amount = o.Amount,
                    OrderType = o.OrderType.ToString()
                }).ToList()
            };
            return View(dasboard);
        }

        private string GetDeliveryStatus(DeliveryStatus status){
            return status.ToString();
        }

        public ActionResult EditOrderDetails(DeliveryDetails model)
        {
           return View(model);
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