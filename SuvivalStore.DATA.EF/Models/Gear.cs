using System;
using System.Collections.Generic;

namespace SuvivalStore.DATA.EF.Models
{
    public partial class Gear
    {
        public Gear()
        {
            OrderGears = new HashSet<OrderGear>();
        }

        public int GearId { get; set; }
        public string GearName { get; set; } = null!;
        public string? GearDescription { get; set; }
        public decimal? GearPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public bool? IsDiscontinued { get; set; }
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }
        public string? GearImage { get; set; }

        public virtual Category? Category { get; set; }
        public virtual GearStatus? Status { get; set; }
        public virtual ICollection<OrderGear> OrderGears { get; set; }
    }
}
