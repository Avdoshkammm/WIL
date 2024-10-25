using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIL.Domain.Entities;
using WIL.Domain.Interfaces;
using WIL.Infrastructure.Data;

namespace WIL.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WILDBContext db;
        public UserRepository(WILDBContext _db)
        {
            db = _db;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            List<User> user = await db.Users.ToListAsync();
            return user;
        }
        public async Task<User> GetUserByID(int id)
        {
            User user = await db.Users.FindAsync(id);
            if(user == null)
            {
                Console.WriteLine($"User with id {id} is not found");
            }
            return user;
        }
        public async Task CreateUser(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
        }
        public async Task DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                Console.WriteLine($"User with id {id} is null");
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }
    }
}
