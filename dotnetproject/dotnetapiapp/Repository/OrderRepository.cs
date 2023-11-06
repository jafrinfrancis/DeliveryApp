using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapiapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapiapp.Repository
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrderByid(int id);
        public Task<List<Order>> GetAllOrders();
        public Task<Order> CreateOrder(Order order);
        public Task<Order> UpdateOrder(Order order);
        public Task<bool> DeleteOrder(int Id);
        public Task<Delivery> GetDeliveryByid(int id);
        public Task<List<Delivery>> GetAllDeliveries();
        public Task<Delivery> CreateDelivery(Delivery delivery);
        public Task<Delivery> UpdateDelivery(Delivery delivery);
        public Task<bool> DeleteDelivery(int Id);
        public Task<List<Delivery>> GetDeliveryByUserId(int id);
    }
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(OrderDeliveryDbContext context) : base(context)
        {

        }
        public async Task<Order> GetOrderByid(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var orders = _context.Orders.ToList<Order>();
            return orders;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.CreatedDate = DateTime.UtcNow;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            order.ModifiedDate = DateTime.UtcNow;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return order;
        }

        public async Task<bool> DeleteOrder(int Id)
        {
            var order = await _context.Orders.FindAsync(Id); ;
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return true;
        }

        public async Task<Delivery> GetDeliveryByid(int id)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(o => o.Id == id);
            return delivery;
        }

        public async Task<List<Delivery>> GetDeliveryByUserId(int id)
        {
            List<Delivery> delivery = new List<Delivery>();
            delivery = _context.Deliveries.Where(o => o.userId == id).ToList<Delivery>();
            return delivery;
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        {
            var deliveries = _context.Deliveries.ToList<Delivery>();
            return deliveries;
        }

        public async Task<Delivery> CreateDelivery(Delivery delivery)
        {
            delivery.EstablishmentDate = DateTime.UtcNow;
            delivery.CreatedDate = DateTime.UtcNow;
            _context.Deliveries.Add(delivery);
            _context.SaveChanges();
            return delivery;
        }

        public async Task<Delivery> UpdateDelivery(Delivery delivery)
        {
            // delivery.EstablishmentDate = DateTime.UtcNow;
            delivery.ModifiedDate = DateTime.UtcNow;
            _context.Deliveries.Update(delivery);
            _context.SaveChanges();
            return delivery;
        }
        public async Task<bool> DeleteDelivery(int Id)
        {
            var delivery = await _context.Deliveries.FindAsync(Id); ;
            _context.Deliveries.Remove(delivery);
            _context.SaveChanges();
            return true;
        }
    }
}