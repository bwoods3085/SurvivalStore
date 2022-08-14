using System;
using System.Collections.Generic;

namespace SuvivalStore.DATA.EF.Models
{
    public partial class OrderGear
    {
        public int OrderGearId { get; set; }
        public int GearId { get; set; }
        public int OrderId { get; set; }
        public short? Quantity { get; set; }
        public decimal? GearPrice { get; set; }

        public virtual Gear Gear { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
