using System;
using System.Collections.Generic;

namespace SuvivalStore.DATA.EF.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderGears = new HashSet<OrderGear>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? OrderDate { get; set; }
        public string? ShipToName { get; set; }
        public string? ShipToAddress { get; set; }
        public string? ShipToCity { get; set; }
        public string? ShipToState { get; set; }
        public string? ShipToZip { get; set; }
        public string? ShipToPhone { get; set; }

        public virtual UserDetail User { get; set; } = null!;
        public virtual ICollection<OrderGear> OrderGears { get; set; }
    }
}
