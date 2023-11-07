using dotnetCommonUtils.CommonModels;
using dotnetmvcapp.Models;
using System.Collections.Generic;

namespace dotnetmvcapp.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order model);
        Task<bool> DeleteOrder(int id);
        public Task<List<Order>> GetAllOrders();
        Task<Delivery> UpdateDelivery(Delivery model);
        Task<Order> UpdateOrder(Order model);
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

        public async Task<Order> CreateOrder(Order model)
        {
            var resp = await _httpClientService.Post<Order>(RouteConstants.OrderServiceRoutes.CreateOrder,model);
            return resp.data;
        }

        public async Task<Order> UpdateOrder(Order model)
        {
            var resp = await _httpClientService.Put<Order>(RouteConstants.OrderServiceRoutes.UpdateOrder,model);
            return resp.data;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var resp = await _httpClientService.Delete<bool>(RouteConstants.OrderServiceRoutes.DeleteOrder.Replace("{id}",id.ToString()),null);
            return resp.data;
        }

        public async Task<Delivery> UpdateDelivery(Delivery model)
        {
            var resp = await _httpClientService.Put<Delivery>(RouteConstants.OrderServiceRoutes.UpdateDelivery, model);
            return resp.data;
        }
    }
}
