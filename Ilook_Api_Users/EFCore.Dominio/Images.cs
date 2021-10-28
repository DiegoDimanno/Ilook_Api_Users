using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Images
    {
        public int IdImages { get; set; }
        public string PathImages { get; set; }
        public int ProductImages { get; set; }

        public virtual Products ProductImagesNavigation { get; set; }
    }
}
