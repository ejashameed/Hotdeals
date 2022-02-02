using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Application.GetProductById
{
    public class GetProductByIdRequest: IRequest<GetProductByIdResponse>
    {
        public long Id { get; set;}
    }
}
