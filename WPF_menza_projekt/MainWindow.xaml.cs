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
            if(hozzaadastb.Text.Trim() != "")
            { 
                vendeg vendeg = new()
                {
                    nev = hozzaadastb.Text,
                    diak = (bool)hozzaadascb.IsChecked
                };
                context.vendegek.Add(vendeg);
                context.SaveChanges();
                vendegekfrissitese();
                hozzaadastb.Text = "";
                hozzaadascb.IsChecked = false;
            }
            else
                MessageBox.Show("nem lehet ures!");
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
                context.levesek.Add(new leves()
                {
                    nev = levestb.Text
                });
                levestb.Text = "";
                context.SaveChanges();
            }
            else
                MessageBox.Show("nem lehet ures!");
            
        }

        private void foetelbt_Click(object sender, RoutedEventArgs e)
        {
            if (foeteltb.Text.Trim() != "")
            {
                context.foetelek.Add(new foetel()
                {
                    nev = foeteltb.Text
                });
                foeteltb.Text = "";
                context.SaveChanges();
            }
            else
                MessageBox.Show("nem lehet ures!");
            
        }

        private void desszertbt_Click(object sender, RoutedEventArgs e)
        {
            if (desszerttb.Text.Trim() != "")
            {
                context.desszertek.Add(new desszert()
                {
                    nev = desszerttb.Text
                });
                desszerttb.Text = "";
                context.SaveChanges();
            }
            else
                MessageBox.Show("nem lehet ures!");
            
        }

        private void napietkezesbt_Click(object sender, RoutedEventArgs e)
        {
            if (datumpicker != null && foetelcb != null && levescb != null)
            {
                napietkezes napietkezes = new()
                {
                    
                    datum = DateOnly.FromDateTime((DateTime)datumpicker.SelectedDate),
                    foetel = foetelcb.SelectedItem as foetel,
                    leves = levescb.SelectedItem as leves,
                    desszert = desszertcb.SelectedItem as desszert
                }; 
                context.napietkezesek.Add(napietkezes);
                datumpicker.SelectedDate = null;
                levescb.SelectedItem = null;    
                foetelcb.SelectedItem = null;
                desszertcb.SelectedItem = null;
                context.SaveChanges();
            }
        }
    }
}