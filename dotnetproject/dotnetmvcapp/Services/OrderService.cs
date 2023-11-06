using dotnetCommonUtils.CommonModels;
using dotnetmvcapp.Models;
using System.Collections.Generic;

namespace dotnetmvcapp.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrders();
    }
    public class OrderService : IOrderService
    {
        private readonly IHttpClientService _httpClientService;
        public OrderService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var resp = await _httpClientService.Get<List<Order>>(RouteConstants.OrderServiceRoutes.GetAllOrders);
            return resp.data;
        }
    }
}
