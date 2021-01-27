using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mjesuscode1lab.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mjesuscode1lab.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}
