using System;
using System.Collections.Generic;

namespace WebApi
{
    public partial class Zakaznik
    {
        public Zakaznik()
        {
            Vozidlo = new HashSet<Vozidlo>();
        }

        public int ZakaznikId { get; set; }
        public string Jmeno { get; set; }

        public virtual ICollection<Vozidlo> Vozidlo { get; set; }
    }
}
