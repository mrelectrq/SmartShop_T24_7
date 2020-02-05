using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Category1
    {
        public Category1()
        {
            Warehouse = new HashSet<Warehouse>();
        }

        public int IdCategory1 { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
