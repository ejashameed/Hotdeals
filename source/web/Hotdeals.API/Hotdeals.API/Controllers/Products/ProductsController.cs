using Hotdeals.API.common;
using Hotdeals.Application.ProductService.GetProducts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hotdeals.API.Controllers.Products
{
    public class ProductsController: HotdealsBaseController
    {
        public ProductsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductsQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}
