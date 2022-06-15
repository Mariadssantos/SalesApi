using MarcusDesafio.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcusDesafio.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {}
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sales> Sales { get; set; }
    }
}
