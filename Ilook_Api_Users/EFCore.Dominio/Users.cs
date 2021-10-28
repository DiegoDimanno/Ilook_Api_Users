using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Dominio
{
    public partial class Users
    {
        public Users()
        {
            Ends = new HashSet<Ends>();
            Sales = new HashSet<Sales>();
        }

        public int IdUsers { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string NameUsers { get; set; }
        public DateTime NascUsers { get; set; }
        public string RgUsers { get; set; }
        public string CpfUsers { get; set; }
        public string PhoneUsers { get; set; }
        public string CelUsers { get; set; }
        public bool? ActiveUsers { get; set; }

        public virtual ICollection<Ends> Ends { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
