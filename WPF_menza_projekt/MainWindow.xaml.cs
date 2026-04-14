using System.Collections.ObjectModel;
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
using WPF_menza_projekt.models;

namespace WPF_menza_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static menza context = new menza();
        public ObservableCollection<vendeg> vendegek { get; set; } = new();
        public ObservableCollection<leves> levesek { get; set; } = new();
        public ObservableCollection<foetel> foetelek { get; set; } = new();
        public ObservableCollection<desszert> desszertek { get; set; } = new();
        public ObservableCollection<napietkezes> napietkezesek { get; set; } = new();
        public MainWindow()
        {
            DataContext = this;
            vendegekfrissitese();
            InitializeComponent();

        }

        private void hozzaadasbt_Click(object sender, RoutedEventArgs e)
        {
            if (hozzaadastb.Text.Trim() != "")
            {
                string ujNev = hozzaadastb.Text.Trim();

                if (context.vendegek.Any(x => x.nev == ujNev))
                {
                    MessageBox.Show("Ilyen nevű vendég már létezik!");
                    return;
                }

                vendeg vendeg = new()
                {
                    nev = ujNev,
                    diak = hozzaadascb.IsChecked == true
                };

                context.vendegek.Add(vendeg);
                context.SaveChanges();

                vendegekfrissitese();
                hozzaadastb.Text = "";
                hozzaadascb.IsChecked = false;
            }
            else
            {
                MessageBox.Show("nem lehet üres!");
            }
        }
        private void vendegekfrissitese()
        {
            vendegek.Clear();
            levesek.Clear();
            foetelek.Clear();
            desszertek.Clear();
            napietkezesek.Clear();
            foreach (var vendeg in context.vendegek)
            {
                vendegek.Add(vendeg);
            }
            foreach (var leves in context.levesek)
            {
                levesek.Add(leves);
            }
            foreach (var foetel in context.foetelek)
            {
                foetelek.Add(foetel);
            }
            foreach (var desszert in context.desszertek)
            {
                desszertek.Add(desszert);
            }
            foreach (var napietkezes in context.napietkezesek)
            {
                napietkezesek.Add(napietkezes);
            }
        }

        private void levesbt_Click(object sender, RoutedEventArgs e)
        {
            if (levestb.Text.Trim() != "")
            {
                string ujNev = levestb.Text.Trim();

                if (context.levesek.Any(x => x.nev == ujNev))
                {
                    MessageBox.Show("Ilyen leves már létezik!");
                    return;
                }

                context.levesek.Add(new leves()
                {
                    nev = ujNev
                });

                levestb.Text = "";
                context.SaveChanges();
            }
            else
                MessageBox.Show("nem lehet ures!");
            vendegekfrissitese();


        }

        private void foetelbt_Click(object sender, RoutedEventArgs e)
        {
            if (foeteltb.Text.Trim() != "")
            {
                string ujNev = foeteltb.Text.Trim();

                if (context.foetelek.Any(x => x.nev == ujNev))
                {
                    MessageBox.Show("Ilyen főétel már létezik!");
                    return;
                }

                context.foetelek.Add(new foetel()
                {
                    nev = ujNev
                });

                foeteltb.Text = "";
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("nem lehet ures!");
            }
            vendegekfrissitese();
        }

        private void desszertbt_Click(object sender, RoutedEventArgs e)
        {
            if (desszerttb.Text.Trim() != "")
            {
                string ujNev = desszerttb.Text.Trim();

                if (context.desszertek.Any(x => x.nev == ujNev))
                {
                    MessageBox.Show("Ilyen desszert már létezik!");
                    return;
                }

                context.desszertek.Add(new desszert()
                {
                    nev = ujNev
                });

                desszerttb.Text = "";
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("nem lehet ures!");
            }
            vendegekfrissitese();
        }

        private void napietkezesbt_Click(object sender, RoutedEventArgs e)
        {
            if (datumpicker.SelectedDate != null && foetelcb.SelectedItem != null && levescb.SelectedItem != null)
            {
                DateOnly datum = DateOnly.FromDateTime((DateTime)datumpicker.SelectedDate);

                if (context.napietkezesek.Any(x => x.datum == datum))
                {
                    MessageBox.Show("Erre a napra már van étkezés!");
                    return;
                }

                napietkezes napietkezes = new()
                {
                    datum = datum,
                    foetel = foetelcb.SelectedItem as foetel,
                    leves = levescb.SelectedItem as leves,
                    desszert = desszertcb.SelectedItem as desszert
                };

                context.napietkezesek.Add(napietkezes);
                context.SaveChanges();

                datumpicker.SelectedDate = null;
                levescb.SelectedItem = null;
                foetelcb.SelectedItem = null;
                desszertcb.SelectedItem = null;

                vendegekfrissitese();
            }
            else
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
            }
        }
        private void osszkapcsolasbt_Click(object sender, RoutedEventArgs e)
        {
            var selectedVendeg = vendegeklv.SelectedItem as vendeg;
            var selectedEtkezes = napietkeslv.SelectedItem as napietkezes;

            if (selectedVendeg == null || selectedEtkezes == null)
            {
                MessageBox.Show("Válassz ki egy vendéget és egy napi étkezést!");
                return;
            }

            bool jo = context.vendegnapietkezesek.Any(x =>
                x.vendegid == selectedVendeg.Id &&
                x.napietkezesid == selectedEtkezes.Id);

            if (jo)
            {
                MessageBox.Show("Ez már össze van kapcsolva!");
                return;
            }

            var kapcsolat = new vendegnapietkezes()
            {
                vendegid = selectedVendeg.Id,
                napietkezesid = selectedEtkezes.Id
            };

            context.vendegnapietkezesek.Add(kapcsolat);
            context.SaveChanges();

            MessageBox.Show("Sikeres összekapcsolás!");
        }
        private void vendegeklv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedVendeg = vendegeklv.SelectedItem as vendeg;

            if (selectedVendeg == null)
                return;


            var etkezesek = context.vendegnapietkezesek
                .Where(x => x.vendegid == selectedVendeg.Id)
                .Select(x => x.napietkezes)
                .ToList();

            vendegEtkezesLv.ItemsSource = etkezesek;
        }

    }
}