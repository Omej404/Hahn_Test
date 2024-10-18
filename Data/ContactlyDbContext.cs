using HahnApp_MEJRHIRROU.Models;
using Microsoft.EntityFrameworkCore;

namespace HahnApp_MEJRHIRROU.Data
{
    public class ContactlyDbContext : DbContext
    {
        public ContactlyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
