using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Data
{
    public interface IPaymentApplicationDbContext
    {
        DbSet<Entities.Payment> Payment { get; set; }
        Task<int> SaveAppChanges();
    }
}
