using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakkerijShop.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Naam { get; set; }
        public string Categorie { get; set; }
        public decimal Prijs { get; set; }
    }
}
