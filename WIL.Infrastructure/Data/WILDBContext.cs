using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIL.Domain.Entities;

namespace WIL.Infrastructure.Data
{
    public class WILDBContext : DbContext
    {
        public WILDBContext(DbContextOptions<WILDBContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
