
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotdeals.Domain.ECommerceDomain.Entities;

namespace Hotdeals.Application.Gateway
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(long Id);
        Task<IEnumerable<Product>> GetByCategory(long Id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(long Id);
    }

}
