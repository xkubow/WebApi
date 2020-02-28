using System;
using System.Collections.Generic;

namespace WebApi
{
    public partial class Vyrobek
    {
        public Vyrobek()
        {
            Vozidlo = new HashSet<Vozidlo>();
        }

        public char VyrobekOzn { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Vozidlo> Vozidlo { get; set; }
    }
}
