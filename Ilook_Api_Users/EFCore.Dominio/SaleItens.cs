using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class SaleItens
    {
        public int IdSalesItens { get; set; }
        public int ProductSalesItens { get; set; }
        public int QtdSalesItens { get; set; }
        public decimal PriceSalesItens { get; set; }
        public int SaleSalesItens { get; set; }

        public virtual Products ProductSalesItensNavigation { get; set; }
        public virtual Sales SaleSalesItensNavigation { get; set; }
    }
}
