using Microsoft.EntityFrameworkCore;
using Payment.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Data
{
    public class PaymentApplicationDbContext : DbContext,IPaymentApplicationDbContext
    {
        public DbSet<Entities.Payment> Payment { get; set; }
       
        public PaymentApplicationDbContext(DbContextOptions<PaymentApplicationDbContext> options) : base(options)
        {

        }

        public async Task<int> SaveAppChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Payment>().HasData(
                new Entities.Payment()
                { id = 1, customerId = "10", cardType = "Debit", cardNo = "1234567890", amount = "5000", description = "imergency payment" },
                new Entities.Payment()
                { id = 2, customerId = "20", cardType = "Credit", cardNo = "99900033", amount = "7800", description = "bill payment" },
                new Entities.Payment()
                { id = 3, customerId = "30", cardType = "Debit", cardNo = "44455666", amount = "9100", description = "notmal payment" },
                new Entities.Payment()
                { id = 4, customerId = "4", cardType = "Credit", cardNo = "77711123", amount = "8000", description = "bank payment" });
        }
    
    }
}
