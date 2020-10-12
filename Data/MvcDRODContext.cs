using DROD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DROD.Data
{
    public class MvcDRODContext: DbContext
    {
        public MvcDRODContext(DbContextOptions<MvcDRODContext > options): base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Items> Items { get; set; }
    }
}
