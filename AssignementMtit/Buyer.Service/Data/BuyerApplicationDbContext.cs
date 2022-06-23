using Buyer.Service.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buyer.Service.Data
{
    public class BuyerApplicationDbContext : DbContext,IBuyerApplicationDbContext
    {
        public DbSet<Entities.Buyer> Buyer { get; set; }
     
        public BuyerApplicationDbContext(DbContextOptions<BuyerApplicationDbContext> options) : base(options)
        {

        }

        public async Task<int> SaveAppChanges()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Buyer>().HasData(
                new Entities.Buyer()
                {Id = 1, Name = "Binnie", City = "Colombo", Contact = "1234567890", Email = "binnie@gmail.com", Address = "ishi residencies" },
                new Entities.Buyer()
                {Id = 2, Name = "Lucas", City = "Sweden", Contact = "12345675590", Email = "lucas@gmail.com", Address = "lucas residencies" },
                new Entities.Buyer()
                {Id = 3, Name = "Casper", City = "Austrailia", Contact = "12346675590", Email = "casper@gmail.com", Address = "Casper residencies" });
        }
    }
}

