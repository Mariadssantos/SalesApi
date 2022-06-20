using MarcusDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcusDesafio.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {}
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<MarcusDesafio.Models.User>? User { get; set; }
    }
}
