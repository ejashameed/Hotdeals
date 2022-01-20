using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Hotdeals.Application.GetProductById
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = new GetProductByIdResponse
            {
                ProductId = request.ProductId,
                ProductName = "Dell Inspiron Laptop 5540"
            };

            return product;
        }
    }
}
