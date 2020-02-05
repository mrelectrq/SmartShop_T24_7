using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class ProductProprietes
    {
        public int IdProduct { get; set; }
        public string ProprietyName { get; set; }
        public string ProprietyDescription { get; set; }

        public virtual Warehouse IdProductNavigation { get; set; }
    }
}
