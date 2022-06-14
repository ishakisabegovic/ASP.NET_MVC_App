using ASP.NET_MVC_App.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_MVC_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
