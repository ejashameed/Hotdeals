using Hotdeals.API.common;
using Hotdeals.Application;
using Hotdeals.Application.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Hotdeals.API.Controllers
{
    public class ProductsController : HotdealsBaseController
    {
        public ProductsController(IServiceProvider serviceProvider):base(serviceProvider)
        {

        }
                           
        [HttpGet("{id}")] // users/id
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var request = new GetProductByIdRequest { ProductId = id };
            var product = await _mediator.Send(request);
            return Ok(product);
        }
    }
}

