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
        private readonly HotdealsCommerceContext _sqlDbContext;
        public ProductRepository(HotdealsCommerceContext hotdealsCommerceContext)
        {
            _sqlDbContext = hotdealsCommerceContext;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _sqlDbContext.Products.AddAsync(product);
            //await _sqlDbContext.AddAsync(product);
            await _sqlDbContext.SaveChangesAsync();
            //get category info
            var category = await _sqlDbContext.Categories.FindAsync(product.CategoryId);
            if (category != null)
            {
                product.Category = category;
            }
            return product;
;       }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            //var products = _sqlDbContext.Products.FromSqlRaw("select p.*,t.TagName from Catalogue.Products p left join Catalogue.ProductTags t on p.Id = t.ProductId").ToList();

            var products = await (from p in _sqlDbContext.Products
                                join c in _sqlDbContext.Categories on p.CategoryId equals c.Id into pc
                                from p1 in pc.DefaultIfEmpty() 
                                
                                join t in _sqlDbContext.ProductTags on p1.Id equals t.ProductId into pt
                                from p2 in pt.DefaultIfEmpty()

                                select new Product
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Description = p.Description,
                                    CategoryId = p.CategoryId,
                                    Price = p.Price,
                                    IsActive = p.IsActive,
                                    Category = p.Category,
                                    ProductTags = p.ProductTags
                                }).ToListAsync();


            // this will generte inner join
            //var products = _sqlDbContext.Products
            //        .Include(c =>c.Category)
            //        .Include(t => t.ProductTags)
            //        .ToList();
            return products;

            //return products;
            //return await _sqlDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategory(long Id)
        {
            IEnumerable<Product> products = await (from p in _sqlDbContext.Products
                            join c in _sqlDbContext.Categories on p.CategoryId equals c.Id into j1
                            from j2 in j1.DefaultIfEmpty()

                            join j3 in _sqlDbContext.ProductTags on p.Id equals j3.Id into j4
                            from j5 in j4.DefaultIfEmpty()
                            select new Product
                            {
                               Id = p.Id,
                               Name = p.Name,
                               Description = p.Description,
                               CategoryId = p.CategoryId,
                               Price = p.Price,
                               IsActive = p.IsActive,
                               ProductTags = p.ProductTags,
                               Category = p.Category,
                            })
                            .Where(p => p.CategoryId == Id)
                            .ToListAsync();
            
            return products; 
        }

        public async Task<Product> GetByIdAsync(long Id)
        {
            //return await _sqlDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

            //var product = _sqlDbContext.Products.Find(Id);

            //var product = await (from p in _sqlDbContext.Products where p.Id == Id select p).FirstOrDefaultAsync();

            Product product = await (from p in _sqlDbContext.Products
                                     join c in _sqlDbContext.Categories on p.CategoryId equals c.Id into j1
                                     from j2 in j1.DefaultIfEmpty()

                                     join j3 in _sqlDbContext.ProductTags on j2.Id equals j3.ProductId into j4
                                     from j5 in j4.DefaultIfEmpty()                                     
                                     
                                select new Product
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Description = p.Description,
                                    CategoryId = p.CategoryId,
                                    Price = p.Price,
                                    IsActive = p.IsActive,    
                                    ProductTags = p.ProductTags,
                                    Category = p.Category,
                                })
                                .Where(p=> p.Id == Id)
                                .FirstOrDefaultAsync();


            //var product = await _sqlDbContext.Products
            //                .Join(_sqlDbContext.Categories, 
            //                    p => p.CategoryId,
            //                    c => c.Id,
            //                    (p, c) => new { p, c })
            //                .Join(_sqlDbContext.ProductTags,
            //                    pt => pt.p.Id,
            //                    t => t.ProductId,
            //                    (pt, t) => new { pt, t })
            //                .Where(s=> s.pt.p.Id == Id)
            //                .ToListAsync();

            return product;                    
        }

        public async Task<Product> RemoveAsync(long Id)
        {            
            var product = await GetByIdAsync(Id);
            _sqlDbContext.Products.Remove(product);
            await _sqlDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {            
            _sqlDbContext.Products.Update(product);
            await _sqlDbContext.SaveChangesAsync();
            return product;
        }
    }
}
