using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapiapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapiapp.Repository
{
    public interface IAccountRepository{
        public Task<User> GetUserByEmail(string email);
        public Task<User> CreateUser(User model);
        public Task<User> GetUserById(int id);
        public Task<User> UpdateUser(User model);
        Task<List<User>> GetAllUsers();
    }
    public class AccountRepository : RepositoryBase,IAccountRepository
    {
        public AccountRepository(OrderDeliveryDbContext context):base(context)
        {

        }

        public async Task<User> GetUserByEmail(string email){
            var user = await _context.Users.FirstOrDefaultAsync(o=>o.Email == email);
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(o => o.Id == id);
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var user = await _context.Users.ToListAsync();
            return user;
        }

        public async Task<User> CreateUser(User model){
            model.CreatedDate = DateTime.UtcNow;
            _context.Users.Add(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<User> UpdateUser(User model)
        {
            model.ModifiedDate = DateTime.UtcNow;
            _context.Users.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}