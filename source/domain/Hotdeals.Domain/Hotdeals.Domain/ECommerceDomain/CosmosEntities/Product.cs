using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Domain.ECommerceDomain.CosmosEntities
{

    public class Product
    {
        
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public string IsActive { get; set; }
        

    }
}
