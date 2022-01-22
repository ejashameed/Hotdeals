using Hotdeals.Domain.ECommerceDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.Gateway
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(string Id);
        Task<Products> AddAsync(Products product);
        Task<Products> UpdateAsync(Products product);
        Task<Products> RemoveAsync(string Id);
    }

}
