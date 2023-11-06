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
        public DeliveryBoyController(IOrderService service)
        {
            _service = service;
        }
        public async Task<ActionResult> Dashboard()
        {
            var orders = await _service.GetAllOrders();
            var dasboard = new DeliveryDashboardViewModel
            {
                details = orders.Select(o => new DeliveryDetails
                {
                    DeliveryId = o.DeliveryDetails?.DeliveryID ?? 0,
                    OrderId = o.OrderID,
                    OrderedDate = o.CreatedDate.ToString("mm-dd-yyyy"),
                    DeliveryStatus = GetDeliveryStatus(o.DeliveryDetails.DeliveryStatus)

                }).ToList()
            };
            return View(dasboard);
        }

        private string GetDeliveryStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return "Pending";
                default:
                    return "Unassigned";
            }
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}