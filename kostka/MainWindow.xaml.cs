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
        private int ogolnywynik = 0; //przypisanie ogólnemu wynikowi początkowej wartości 0
        public MainWindow()
        {
            InitializeComponent();
            int kostkailosc = (int)kostki.Value; //przypisanie ilości kostek oraz ścian wartości z suwaków
            int scianyilosc = (int)sciany.Value;
            if (kostkailosc == 1 || scianyilosc == 4) //jeśli ilość kostek jest 1 lub ilość ścian jest 4 to ma sie pokazać domyślny kwadrat
            {
                kosteczkiwynik.Children.Add(WyswietlDomyslnyKwadrat());
            }
            kostki.ValueChanged += (s, e) => ilosckostek.Text = ((int)kostki.Value).ToString(); //przypisanie textblockowi wartości z suwaków
            sciany.ValueChanged += (s, e) => iloscscian.Text = ((int)sciany.Value).ToString();
        }

        private void Rzut(object sender, RoutedEventArgs e)
        {
            int kostkailosc = (int)kostki.Value;
            int scianyilosc = (int)sciany.Value;


            kosteczkiwynik.Children.Clear(); 
            Random random = new Random(); // losowanie kości
            int[] rzuty = new int[kostkailosc];
            for (int i = 0; i < kostkailosc; i++)
            {
                rzuty[i] = random.Next(1, kostkailosc + 1); 
                kosteczkiwynik.Children.Add(Wyswietlaniezdjec(rzuty[i])); //wyświetlenie zdjęć dla odpowiednich liczb
            }
            Dictionary<int, int> powtorzenia = new Dictionary<int, int>(); //liczenie powtórzeń za pomocą słownika
            foreach (int rzut in rzuty)
            {
                if (powtorzenia.ContainsKey(rzut))
                    powtorzenia[rzut]++;
                else
                    powtorzenia[rzut] = 1;
            }
            int rzutywynik = 0; //przypisanie początkowego wyniku rzutu
            foreach (var rzucik in powtorzenia) //sumowanie powtórzeń
            {
                if (rzucik.Value > 1)
                    rzutywynik += rzucik.Key * rzucik.Value;
            }
            wynikrzutu.Text = rzutywynik.ToString(); //liczenie punktów rzutu oraz ogólnych
            ogolnywynik += rzutywynik;
            wynikogolny.Text = ogolnywynik.ToString();

        }

        private void ResetGry(object sender, RoutedEventArgs e)
        {
            wynikrzutu.Text = "0"; //resetowanie wyników oraz wartości
            wynikogolny.Text = "0";
            kostki.Value = 0;
            sciany.Value = 0;
            kosteczkiwynik.Children.Clear();
            kosteczkiwynik.Children.Add(WyswietlDomyslnyKwadrat());
        }

        private Image Wyswietlaniezdjec(int wartosc) //tworzenie obrazu dla konkretnych wyników
        {
                return new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/Resource/plik{wartosc}.jfif")),
                    Width = 40,
                    Height = 40,
                    Margin = new Thickness(5)
                };
        }
        private Image WyswietlDomyslnyKwadrat() //tworzenie obrazu gdy wartość jest jeszcze nie ustawiona
        {
            return new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Resource/pliknieznany.jpg")),
                Width = 40,
                Height = 40,
                Margin = new Thickness(5)
            };
        }

    }
    }
