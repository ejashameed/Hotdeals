using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class Products
    {
        [Key]
        public string ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
