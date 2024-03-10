using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EF.oefening._03.oplossing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            Dialoog Dlg = new Dialoog();
            Dlg.Velden(true, "", "", 0, "");
            Dlg.TxtProductCode.Focus();
            if (Dlg.ShowDialog() == true)
            {
                string productCode = Dlg.TxtProductCode.Text.Trim();
                string beschrijving = Dlg.TxtBeschrijving.Text.Trim();
                decimal prijs = Dlg.Prijs;
                string veld = Dlg.TxtVeld.Text.Trim();

                if (Dlg.RbBoek.IsChecked.Value)
                {
                    LstProducten.Items.Add(new Boek(productCode, beschrijving, prijs, veld));
                }
                else
                {
                    LstProducten.Items.Add(new Software(productCode, beschrijving, prijs, veld));
                }

                LstProducten.SelectedIndex = -1;
                LstProducten.Items.Refresh();
            }
        }

        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Product uit lijst verwijderen ?", "Product verwijderen ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LstProducten.Items.Remove(LstProducten.SelectedItem);
                LstProducten.Items.Refresh();
            }
        }

        private void BtnBewerk_Click(object sender, RoutedEventArgs e)
        {
            Dialoog Dlg = new Dialoog();

            if (LstProducten.SelectedItem.GetType() == typeof(EF.oefening._03.oplossing.Software))
            {
                Software software = (Software)LstProducten.SelectedItem;
                Dlg.Velden(false, software.ProductCode, software.Beschrijving, software.Prijs, software.Versie);
            }
            else if (LstProducten.SelectedItem.GetType() == typeof(EF.oefening._03.oplossing.Boek))
            {
                Boek boek = (Boek)LstProducten.SelectedItem;
                Dlg.Velden(true, boek.ProductCode, boek.Beschrijving, boek.Prijs, boek.Auteur);
            }

            Dlg.TxtProductCode.Focus();

            if (Dlg.ShowDialog() == true)
            {
                string productCode = Dlg.TxtProductCode.Text.Trim();
                string beschrijving = Dlg.TxtBeschrijving.Text.Trim();
                decimal prijs = Dlg.Prijs;
                string veld = Dlg.TxtVeld.Text.Trim();

                if (LstProducten.SelectedItem.GetType() == typeof(EF.oefening._03.oplossing.Software))
                {
                    Software software = (Software)LstProducten.SelectedItem;
                    software.update(software.ProductCode, software.Beschrijving, software.Prijs, software.Versie);
                }
                else if (LstProducten.SelectedItem.GetType() == typeof(EF.oefening._03.oplossing.Boek))
                {
                    Boek boek = (Boek)LstProducten.SelectedItem;
                    boek.update(boek.ProductCode, boek.Beschrijving, boek.Prijs, boek.Auteur);
                }

                LstProducten.SelectedIndex = -1;
                LstProducten.Items.Refresh();
                ToggleKnoppen(false);
            }
        }

        private void LstProducten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstProducten.SelectedIndex != -1)
            {
                ToggleKnoppen(true);
            }
        }

        private void ToggleKnoppen(bool status)
        {
            BtnVerwijder.IsEnabled = status;
            BtnBewerk.IsEnabled = status;
        }
    }
}