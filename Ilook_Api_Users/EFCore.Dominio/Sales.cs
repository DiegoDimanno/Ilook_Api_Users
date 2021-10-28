using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Sales
    {
        public Sales()
        {
            SaleItens = new HashSet<SaleItens>();
        }

        public int IdSales { get; set; }
        public DateTime PurchaseDataSales { get; set; }
        public DateTime DeliveryDataSales { get; set; }
        public byte PaymentsSales { get; set; }
        public decimal ValueSales { get; set; }
        public string ObsSales { get; set; }
        public int EndSales { get; set; }
        public int UserSales { get; set; }

        public virtual Ends EndSalesNavigation { get; set; }
        public virtual Users UserSalesNavigation { get; set; }
        public virtual ICollection<SaleItens> SaleItens { get; set; }
    }
}
