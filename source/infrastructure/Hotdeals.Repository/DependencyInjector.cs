using Hotdeals.Application.Gateway;
using Hotdeals.Repository.SQLRepostories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Repository
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<HotdealsCommerceContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
