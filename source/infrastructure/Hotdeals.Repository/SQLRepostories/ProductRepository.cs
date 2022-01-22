using Hotdeals.Application.Gateway;
using Hotdeals.Domain.ECommerceDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Repository.SQLRepostories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _sqlDbContext;
        public ProductRepository(EcommerceDbContext ecommerceContext)
        {
            _sqlDbContext = ecommerceContext;
        }
        public async Task<Products> AddAsync(Products product)
        {
            await _sqlDbContext.AddAsync(product);
            await _sqlDbContext.SaveChangesAsync();
            return product;
;       }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            //var products = _sqlDbContext.Products.FromSqlRaw("select * from Catalogue.Products").ToList();
            //return products;
            return await _sqlDbContext.Products.ToListAsync();
        }

        public async Task<Products> GetByIdAsync(string Id)
        {
            return await _sqlDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == Id);
        }

        public async Task<Products> RemoveAsync(string Id)
        {            
            var product = await GetByIdAsync(Id);
            _sqlDbContext.Products.Remove(product);
            await _sqlDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Products> UpdateAsync(Products product)
        {            
            _sqlDbContext.Products.Update(product);
            await _sqlDbContext.SaveChangesAsync();
            return product;
        }
    }
}
