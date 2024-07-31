using Event.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Event.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EventItem> EventItems { get; set; }
    }
}
