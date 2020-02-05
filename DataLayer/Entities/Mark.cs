using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Mark
    {
        public Mark()
        {
            Warehouse = new HashSet<Warehouse>();
        }

        public int IdMark { get; set; }
        public string MarkName { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
