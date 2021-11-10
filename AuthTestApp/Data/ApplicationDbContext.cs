using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthTestApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Ticket { get; set; }

    }

}
