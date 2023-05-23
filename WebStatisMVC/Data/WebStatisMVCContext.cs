using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStatisMVC.Models;

namespace WebStatisMVC.Data
{
    public class WebStatisMVCContext : DbContext
    {
        public WebStatisMVCContext (DbContextOptions<WebStatisMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Articles> Articles { get; set; } = default!;
    }
}
