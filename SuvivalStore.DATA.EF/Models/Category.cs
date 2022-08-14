using System;
using System.Collections.Generic;

namespace SuvivalStore.DATA.EF.Models
{
    public partial class Category
    {
        public Category()
        {
            Gears = new HashSet<Gear>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public virtual ICollection<Gear> Gears { get; set; }
    }
}
