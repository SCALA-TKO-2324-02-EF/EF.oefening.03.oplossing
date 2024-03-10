using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EF.oefening._03.oplossing
{
    /// <summary>
    /// Interaction logic for Dialoog.xaml
    /// </summary>
    public partial class Dialoog : Window
    {
        public Decimal Prijs = 0;
        public bool Bewaar = false;
        public Dialoog()
        {
            InitializeComponent();
        }

        public void Velden(bool boek, string productCode, string beschrijving, decimal prijs, string veldInhoud)
        {
            if (boek)
            {
                RbBoek.IsChecked = boek;
                LblVeld.Content = "Auteur";
            }
            else
            {
                RbSoftware.IsChecked = !boek;
                LblVeld.Content = "Versie";
            }

            TxtProductCode.Text = productCode;
            TxtBeschrijving.Text = beschrijving;
            TxtPrijs.Text = prijs.ToString();
            TxtVeld.Text = veldInhoud;
        }

        private void RbBoek_Click(object sender, RoutedEventArgs e)
        {
            LblVeld.Content = "Auteur";
        }

        private void RbSoftware_Click(object sender, RoutedEventArgs e)
        {
            LblVeld.Content = "Versie";
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnBewaar_Click(object sender, RoutedEventArgs e)
        {
            if (Decimal.TryParse(TxtPrijs.Text, out Prijs))
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Prijs is geen getal", "Fout prijs", MessageBoxButton.OK);
            }
        }
    }
}
