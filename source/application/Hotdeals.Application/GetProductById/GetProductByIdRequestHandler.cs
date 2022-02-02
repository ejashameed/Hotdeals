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
                Id = request.Id,
                Name = "Dell Inspiron Laptop 5540",
                Description = "Dell laptop - 16GB RAM, 512 SSD, I 7- 10H2OU",
                Price= 4865,
                IsActive = "Y"               
    };

            return product;
        }
    }
}
