using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapiapp.Models;
using dotnetapiapp.Common;
using Microsoft.EntityFrameworkCore;
using dotnetapiapp.Repository;

namespace dotnetapiapp.Domain
{
    public interface IOrderProcessor
    {
        public Task<Order> GetOrderByid(int id);
        public Task<List<Order>> GetAllOrders();
        public Task<Order> CreateOrder(Order order);
        public Task<Order> UpdateOrder(Order order);
        public Task<bool> DeleteOrder(int id);
        public Task<Delivery> GetDeliveryByid(int id);
        public Task<List<Delivery>> GetAllDeliveries();
        public Task<List<Delivery>> GetDeliveryByUserId(int id);
        public Task<Delivery> CreateDelivery(Delivery delivery);
        public Task<Delivery> UpdateDelivery(Delivery delivery);
        public Task<bool> DeleteDelivery(int id); 
        public Task<List<DeliveryStatusCount>> GetDashboardDetails(int userId);

    }
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderRepository _repo;
        public OrderProcessor(IOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task<Order> GetOrderByid(int id)
        {
            Order order = new Order();

            order = await _repo.GetOrderByid(id);
            if (order == null)
            {
                throw new CustomException("Order not Found");
            }
            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            orders = await _repo.GetAllOrders();
            if (orders == null)
            {
                throw new CustomException("Orders not Found");
            }
            return orders;
        }

        public async Task<Order> CreateOrder(Order order)
        {

            order = await _repo.CreateOrder(order);
            if (order == null)
            {
                throw new CustomException("Order not Found");
            }
            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {

            order = await _repo.UpdateOrder(order);
            if (order == null)
            {
                throw new CustomException("Order not Found");
            }
            return order;
        }

        public async Task<bool> DeleteOrder(int Id)
        {
            bool isDelete = await _repo.DeleteOrder(Id);
            return isDelete;
        }

        public async Task<Delivery> GetDeliveryByid(int id)
        {
            Delivery delivery = new Delivery();

            delivery = await _repo.GetDeliveryByid(id);
            if (delivery == null)
            {
                throw new CustomException("Delivery not Found");
            }
            return delivery;
        }

        public async Task<List<Delivery>> GetDeliveryByUserId(int id)
        {
            List<Delivery> deliveries = new List<Delivery>();

            deliveries = await _repo.GetDeliveryByUserId(id);
            if (deliveries == null)
            {
                throw new CustomException("Delivery not Found");
            }
            return deliveries;
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        {
            List<Delivery> deliveries = new List<Delivery>();

            deliveries = await _repo.GetAllDeliveries();
            if (deliveries == null)
            {
                throw new CustomException("deliveries not Found");
            }
            return deliveries;
        }

        public async Task<Delivery> CreateDelivery(Delivery delivery)
        {

            delivery = await _repo.CreateDelivery(delivery);
            if (delivery == null)
            {
                throw new CustomException("Delivery not Found");
            }
            return delivery;
        }

        public async Task<Delivery> UpdateDelivery(Delivery delivery)
        {

            delivery = await _repo.UpdateDelivery(delivery);
            if (delivery == null)
            {
                throw new CustomException("Delivery not Found");
            }
            return delivery;
        }

        public async Task<bool> DeleteDelivery(int Id)
        {
            bool isDelete = await _repo.DeleteDelivery(Id);
            return isDelete;
        }

        public async Task<List<DeliveryStatusCount>> GetDashboardDetails(int userId)
        {
            DashbordModel dashboard = new DashbordModel();
            List<DeliveryStatusCount> deliveryStatusCount = new List<DeliveryStatusCount>();
            List<Delivery> deliveries = new List<Delivery>();
            if(userId==null || userId==0)
            {
                deliveries = await _repo.GetAllDeliveries();
            }
            else
            {
                deliveries = await _repo.GetDeliveryByUserId(userId);
               
            }
            
            deliveryStatusCount = deliveries.GroupBy(n => n.DeliveryStatus)
                          .Select(n => new DeliveryStatusCount
                          {
                              DeliveryStatus = n.Key,
                              Count = n.Count()
                          })
                          .OrderBy(n => n.DeliveryStatus).ToList();



            return deliveryStatusCount;
        }
    }
}