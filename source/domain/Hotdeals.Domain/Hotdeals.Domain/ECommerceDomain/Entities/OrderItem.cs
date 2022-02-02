using System;
using System.Collections.Generic;

#nullable disable

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public long Id { get; set; }
        public long OrderId { get; set; }
        public long OrderItemId { get; set; }
        public decimal OrderItemQuantity { get; set; }
        public decimal? OrderItemPrice { get; set; }
        public decimal OrderItemNetAmount { get; set; }
        public long? OrderItemDeliveryId { get; set; }
        public DateTime? OrderItemDeliveryDate { get; set; }
        public decimal? OrderItemDeliveryCost { get; set; }
        public decimal? OrderItemGrossAmount { get; set; }
        public string OrderItemDeliveryStatus { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
