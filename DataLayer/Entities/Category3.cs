using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Category3
    {
        public Category3()
        {
            Warehouse = new HashSet<Warehouse>();
        }

        public int IdCategory3 { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
