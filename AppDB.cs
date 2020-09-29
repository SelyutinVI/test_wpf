using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TEST.Models;

namespace WPF_TEST
{
    class AppDB : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<MyUsers> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestWPF;Trusted_Connection=True;");
        }
    }
}
