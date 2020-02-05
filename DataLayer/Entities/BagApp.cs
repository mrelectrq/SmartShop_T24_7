using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class BagApp
    {
        public int BasketId { get; set; }
        public int? ProductNumber { get; set; }
        public DateTime? DateProductApp { get; set; }
        public string ProductStatus { get; set; }
        public string ProductStatusWork { get; set; }
        public DateTime? DateSoldOver { get; set; }
        public decimal? ProductFinallPrice { get; set; }

        public virtual Warehouse ProductNumberNavigation { get; set; }
    }
}
