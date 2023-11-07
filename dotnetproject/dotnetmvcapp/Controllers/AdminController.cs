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
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        public AdminController(IOrderService orderService,IAccountService accountService)
        {
            _accountService=accountService;
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
                    EstablishmentDate = o.Delivery.EstablishmentDate,
                    DeliveryStatus = o.Delivery.DeliveryStatus,
                    DeliveryStatusString = o.Delivery.DeliveryStatus.ToString(),
                    CustomerName = o.CustomerName,
                    ContactNumber = o.ContactNumber,
                    Location = o.Location,
                    Amount = o.Amount,
                    OrderType = o.OrderType
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

        public async Task<IActionResult> Delete(DeliveryDetails model)
        {
            var resp = await _orderService.DeleteOrder(model.OrderId);
            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var user = await _accountService.GetUserDetailsById(userId);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UserDetails model)
        {
            await _accountService.Update(model);
            return RedirectToAction("Profile");
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddOrderDetails()
        {
           var order = new DeliveryDetails();
           return View(order);
        }
        [HttpPost]
        public async Task<ActionResult> AddOrderDetails(DeliveryDetails model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    ContactNumber = model.ContactNumber,
                    CustomerName = model.CustomerName,
                    Amount = model.Amount,
                    OrderType = model.OrderType,
                    Location = model.Location,
                    Delivery = new Delivery()
                    {
                        DeliveryStatus = model.DeliveryStatus,
                        EstablishmentDate = model.EstablishmentDate,
                        userId = 0
                    }
                };
                var response = await _orderService.CreateOrder(order);
                if (response != null)
                {
                    return RedirectToAction("Dashboard", "Admin");

                }
                return View();
            }

            OrderType selectedOrderType = model.OrderType;

            return View(model);
        }
    }
}