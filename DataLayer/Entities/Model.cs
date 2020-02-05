using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Model
    {
        public Model()
        {
            Warehouse = new HashSet<Warehouse>();
        }

        public int IdModel { get; set; }
        public string ModelName { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
