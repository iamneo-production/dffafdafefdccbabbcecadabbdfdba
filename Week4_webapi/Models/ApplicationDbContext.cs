using Microsoft.EntityFrameworkCore;
using Week4_webapi.Models;

namespace Week4_webapi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for other entities as needed
    }
}
