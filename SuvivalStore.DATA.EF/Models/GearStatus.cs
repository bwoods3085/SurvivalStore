using System;
using System.Collections.Generic;

namespace SuvivalStore.DATA.EF.Models
{
    public partial class GearStatus
    {
        public GearStatus()
        {
            Gears = new HashSet<Gear>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Gear> Gears { get; set; }
    }
}
