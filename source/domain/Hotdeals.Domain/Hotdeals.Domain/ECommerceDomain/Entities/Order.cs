using System;
using System.Collections.Generic;

#nullable disable

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class Order
    {
        public Order()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public long Id { get; set; }
        public string BilledTo { get; set; }
        public string ShippedTo { get; set; }
        public decimal OrderAmount { get; set; }
        public decimal? OrderDiscount { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
