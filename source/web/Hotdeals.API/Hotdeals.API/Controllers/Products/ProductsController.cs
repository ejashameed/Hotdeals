using Hotdeals.API.common;
using Hotdeals.Application.ProductService.CreateProduct;
using Hotdeals.Application.ProductService.DeleteProduct;
using Hotdeals.Application.ProductService.GetProductByCategory;
using Hotdeals.Application.ProductService.GetProducts;
using Hotdeals.Application.ProductService.GetProductsById;
using Hotdeals.Application.ProductService.UpdateProduct;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand request)
        {
            var product = await _mediator.Send(request);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (DeleteProductCommand request)
        {
            var product = await _mediator.Send(request);
            return Ok(product);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetProductsByIdQuery request)
        {
            var product = await _mediator.Send(request);
            return Ok(product);
        }

        [HttpGet]
        [Route("GetByCategory")]
        public async Task<IActionResult> GetByCategory([FromQuery] GetProductByCategoryQuery request)
        {
            var products = await _mediator.Send(request);
            return Ok(products);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand request)
        {
            var product = await _mediator.Send(request);
            return Ok(product);
        }

    }
}
