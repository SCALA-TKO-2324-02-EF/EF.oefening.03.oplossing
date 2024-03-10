using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.oefening._03.oplossing
{
    internal class Product
    {
        public string ProductCode { get; set; } = "";
        public string Beschrijving { get; set; } = "";

        public decimal Prijs { get; set; }

        public Product()
        {

        }

        public Product(string productcode, string beschrijving, decimal prijs)
        {
            ProductCode = productcode;
            Beschrijving = beschrijving;
            Prijs = prijs;
        }

        public virtual string WeergaveTekst()
        {
            return $"{ProductCode} | {Prijs.ToString("c")} | {Beschrijving}";
        }
    }
}
