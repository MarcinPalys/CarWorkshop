using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWrokshopDbContext : IdentityDbContext
    {
        public CarWrokshopDbContext(DbContextOptions<CarWrokshopDbContext> options) : base(options)
        {
            
        }
        public DbSet<CarWorkshop.Domain.Entities.CarWorkshop> carWorkshops { get; set; }
        public DbSet<CarWorkshop.Domain.Entities.CarWorkshopService> services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarWorkshop.Domain.Entities.CarWorkshop>().
                OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<CarWorkshop.Domain.Entities.CarWorkshop>()
                .HasMany(c => c.Services)
                .WithOne(s => s.CarWorkshop)
                .HasForeignKey(s => s.CarWorkshopId);
               
        }
    }
}
