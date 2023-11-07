using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetmvcapp.Services;
using dotnetmvcapp.Models;
using dotnetmvcapp.ViewModels;



namespace dotnetmvcapp.Controllers
{
    public class DeliveryBoyController : Controller
    {
        private readonly IOrderService _service;
        private readonly IAccountService _accountService;
        public DeliveryBoyController(IOrderService service, IAccountService accountService)
        {
            _service = service;
            _accountService = accountService;
        }
        public async Task<ActionResult> Dashboard()
        {
            var token= HttpContext.Session.GetString("AuthToken");
            var name = HttpContext.Session.GetString("UserName");
            var email = HttpContext.Session.GetString("Email");
            var orders = await _service.GetAllOrders();
            var dasboard = new DeliveryDashboardViewModel
            {
                details = orders.Select(o => new DeliveryDetails
                {
                    DeliveryId = o.Delivery?.Id ?? 0,
                    OrderId = o.Id,
                    OrderedDate = o.CreatedDate.ToLongDateString(),
                    DeliveryStatus = GetDeliveryStatus(o.Delivery.DeliveryStatus)

                }).ToList()
            };
            return View(dasboard);
        }

        private string GetDeliveryStatus(DeliveryStatus status)
        {
            switch (status)
            {
                case DeliveryStatus.Pending:
                    return "Pending";
                default:
                    return "Unassigned";
            }
        }

        public IActionResult Edit(DeliveryDetails model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(DeliveryDetails model)
        {
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

    }
}