using Microsoft.EntityFrameworkCore;
using SPI_Cancellation_Service.Domain.models;

namespace SPI_Cancellation_Service.Infrastructure.repositories
{
    public class AuroraDbContext : DbContext
    {
        
        public AuroraDbContext (DbContextOptions<AuroraDbContext> options)
            : base(options)
        {
        }

        public DbSet<KeyEntity> key { get; set; } // Replace with your actual entity
    }
}
