using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp_Ghiuzan_Denis_Rp.Models;

namespace Asp_Ghiuzan_Denis_Rp.Data
{
    public class Asp_Ghiuzan_Denis_RpContext : DbContext
    {
        public Asp_Ghiuzan_Denis_RpContext (DbContextOptions<Asp_Ghiuzan_Denis_RpContext> options)
            : base(options)
        {
        }

        public DbSet<Asp_Ghiuzan_Denis_Rp.Models.Movie> Movie { get; set; }
    }
}
