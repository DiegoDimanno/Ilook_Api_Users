using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Products
    {
        public Products()
        {
            Images = new HashSet<Images>();
            SaleItens = new HashSet<SaleItens>();
        }

        public int IdProducts { get; set; }
        public string NameProducts { get; set; }
        public int TypeProducts { get; set; }
        public int SaldoProducts { get; set; }
        public decimal PcostProducts { get; set; }
        public decimal PsaleProducts { get; set; }
        public string PredescProducts { get; set; }
        public string DescProducts { get; set; }
        public bool? AvailableProducts { get; set; }
        public bool? HighProducts { get; set; }
        public bool OrganicProducts { get; set; }
        public bool? ActiveProducts { get; set; }

        public virtual TypeProducts TypeProductsNavigation { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<SaleItens> SaleItens { get; set; }
    }
}
