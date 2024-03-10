using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.oefening._03.oplossing
{
    internal class Boek : Product
    {
        public string Auteur { get; set; } = "";
        public Boek()
        {

        }

        public Boek(string productcode, string beschrijving, decimal prijs, string auteur)
        {
            ProductCode = productcode;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Auteur = auteur;
        }

        public override string WeergaveTekst()
        {
            return $"[-BOEK-] {base.WeergaveTekst()} ({Auteur})";
        }

        public override string ToString()
        {
            string prijs = base.Prijs.ToString("c");
            return $"[-BOEK-] {base.ProductCode} | {base.Beschrijving} | {Prijs} ({Auteur})";
        }

        public void update(string productCode, string beschrijving, decimal prijs, string auteur)
        {
            ProductCode = productCode;
            Beschrijving = beschrijving;
            Prijs = prijs;
            Auteur = auteur;
        }
    }
}
