using System;
using System.Collections.Generic;

namespace WebApi
{
    public partial class Vozidlo
    {
        public string Rzv { get; set; }
        public int VozidloId { get; set; }
        public char VyrobekOzn { get; set; }
        public int? ZakaznikId { get; set; }

        public virtual Vyrobek VyrobekOznNavigation { get; set; }
        public virtual Zakaznik Zakaznik { get; set; }
    }
}
