using System;
using System.Collections.Generic;

#nullable disable

namespace Hotdeals.Domain.ECommerceDomain.Entities
{
    public partial class Delivery
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long OrderItemId { get; set; }
        public DateTime TargetDeliveryDate { get; set; }
        public decimal DeliveryCost { get; set; }
        public DateTime? ActualDeliveryDatde { get; set; }
        public string DeliveryStatus { get; set; }

        public virtual Order Order { get; set; }
        public virtual OrderItem OrderItem { get; set; }
    }
}
