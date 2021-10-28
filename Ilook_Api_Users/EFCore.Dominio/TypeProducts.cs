using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class TypeProducts
    {
        public TypeProducts()
        {
            Products = new HashSet<Products>();
        }

        public int IdType { get; set; }
        public string NameType { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
