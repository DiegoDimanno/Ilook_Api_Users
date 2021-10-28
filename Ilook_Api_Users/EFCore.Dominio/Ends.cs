using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Ends
    {
        public Ends()
        {
            Sales = new HashSet<Sales>();
        }

        public int IdEnds { get; set; }
        public string CepEnds { get; set; }
        public string StreetEnds { get; set; }
        public string NeighEnds { get; set; }
        public string CityEnds { get; set; }
        public string UfEnds { get; set; }
        public string NumberEnds { get; set; }
        public string CompEnds { get; set; }
        public string ObsEnds { get; set; }
        public int UserEnds { get; set; }

        public virtual Users UserEndsNavigation { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
