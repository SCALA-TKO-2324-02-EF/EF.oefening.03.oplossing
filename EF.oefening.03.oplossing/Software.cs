using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.oefening._03.oplossing
{
    internal class Software : Product
    {
        public string Versie { get; set; } = "";
        public Software()
        {

        }

        public Software(string productcode, string beschrijving, decimal prijs, string versie)
        {
            ProductCode = productcode;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Versie = versie;
        }

        public override string WeergaveTekst()
        {
            return $"[-SOFT-] {base.WeergaveTekst} ({Versie})";
        }

        public override string ToString()
        {
            string prijs = base.Prijs.ToString("c");
            return $"[-SOFT-] {base.ProductCode} | {base.Beschrijving} | {prijs} ({Versie})";
        }
        public void update(string productCode, string beschrijving, decimal prijs, string versie)
        {
            ProductCode = productCode;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Versie = versie;
        }
    }
}
