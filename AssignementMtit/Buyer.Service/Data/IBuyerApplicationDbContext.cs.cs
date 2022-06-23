using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Buyer.Service.Data
{
    public interface IBuyerApplicationDbContext
    {

        DbSet<Entities.Buyer> Buyer { get; set; }
        Task<int> SaveAppChanges();
    }
}
