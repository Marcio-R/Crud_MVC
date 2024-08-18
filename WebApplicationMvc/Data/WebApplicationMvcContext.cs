using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Data
{
    public class WebApplicationMvcContext : DbContext
    {
        public WebApplicationMvcContext (DbContextOptions<WebApplicationMvcContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationMvc.Models.Produto> Produto { get; set; } = default!;
    }
}
