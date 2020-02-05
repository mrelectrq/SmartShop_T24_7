using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            BagApp = new HashSet<BagApp>();
            ProductProprietes = new HashSet<ProductProprietes>();
        }

        public int IdProduct { get; set; }
        public int? IdCategory1 { get; set; }
        public int? IdCategory2 { get; set; }
        public int? IdCategory3 { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductStatement { get; set; }
        public int? ProductQuantity { get; set; }
        public int? IdMark { get; set; }
        public int? IdModel { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateOutbox { get; set; }
        public string AditionalComment { get; set; }
        public string HeadInfo { get; set; }

        public virtual Category1 IdCategory1Navigation { get; set; }
        public virtual Category2 IdCategory2Navigation { get; set; }
        public virtual Category3 IdCategory3Navigation { get; set; }
        public virtual Mark IdMarkNavigation { get; set; }
        public virtual Model IdModelNavigation { get; set; }
        public virtual ICollection<BagApp> BagApp { get; set; }
        public virtual ICollection<ProductProprietes> ProductProprietes { get; set; }
    }
}
