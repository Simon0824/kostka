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
using System.Resources;

namespace kostka
{
    public partial class MainWindow : Window
    {
        private int ogolnywynik = 0;
        public MainWindow()
        {
            InitializeComponent();
            kostki.ValueChanged += (s, e) => ilosckostek.Text = ((int)kostki.Value).ToString();
            sciany.ValueChanged += (s, e) => iloscscian.Text = ((int)sciany.Value).ToString();
        }

        private void Rzut(object sender, RoutedEventArgs e)
        {
            int kostkailosc = (int)kostki.Value;
            int scianyilosc = (int)sciany.Value;
            kosteczkiwynik.Children.Clear();
            Random random = new Random();
            int[] rzuty = new int[scianyilosc];
            for (int i = 0; i < scianyilosc; i++)
            {
                rzuty[i] = random.Next(1, scianyilosc + 1);
                kosteczkiwynik.Children.Add(wyswietlaniezdjec(rzuty[i]));
            }

            int rzutywynik = rzuty.Sum();

            wynikrzutu.Text = rzutywynik.ToString();
            ogolnywynik += rzutywynik;
            wynikogolny.Text = ogolnywynik.ToString();

        }

        private void ResetGry(object sender, RoutedEventArgs e)
        {
            wynikrzutu.Text = "0";
            wynikogolny.Text="0";
            kostki .Value = 0;
            sciany.Value = 0;
            kosteczkiwynik.Children.Clear();
        }

        private Image wyswietlaniezdjec(int wartosc)
        {
            return new Image
            {
            };
            }
    }
    }
