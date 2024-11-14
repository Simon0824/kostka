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
    class GrawKosci
    {
        public static int ILOSC_KOSCI = 5;
        public static int ILOSC_SCIAN_KOSCI = 6;
        public static int ILOSC_NIEZNANA = -1;
        public static string WYNIK_GRY = "Wynik gry: ";
        public static string WYNIK_LOSOWANIA = "Wynik tego losowania: ";
        public static string PLIK_KOSCI_JEDEN = "\\plik1.jpg";
        public static string PLIK_KOSCI_DWA = "\\plik2.jpg";
        public static string PLIK_KOSCI_TRZY = "\\plik3.jpg";
        public static string PLIK_KOSCI_CZTERY = "\\plik4.jpg";
        public static string PLIK_KOSCI_PIEC = "\\plik5.jpg";
        public static string PLIK_KOSCI_SZESC = "\\plik6.jpg";
        public static string PLIK_KOSCI_NIEZNANY = "\\pliknieznany.jpg";
        private int[] TablicaPowtorzen;
        public int[] TablicaWynikow;
        public int iloscPunktow { get; set; }
        public int iloscPunktowCalaGra { get; set; }

        public GrawKosci()
        {
            iloscPunktow = 0;
            iloscPunktowCalaGra = 0;
            TablicaPowtorzen = new int[ILOSC_SCIAN_KOSCI + 1];
            TablicaWynikow = new int[ILOSC_KOSCI];
        }

        private int losujpojedynczy()
        {
            Random losowa = new Random();
            return losowa.Next(1, ILOSC_SCIAN_KOSCI + 1);
        }

        private void obliczwyniki(int[] tablicarzutow)
        {
            iloscPunktow = 0;
            for (int i = 1; i < ILOSC_SCIAN_KOSCI + 1; i++)
            {
                if (tablicarzutow[i] > 1)
                {
                    iloscPunktow += tablicarzutow[i] = i;
                }
            }
            iloscPunktowCalaGra += iloscPunktow;
        }

        public void losujWszystko()
        {
            for (int i = 0; i < ILOSC_SCIAN_KOSCI; i++)
            {
                TablicaPowtorzen[i] = 0;
            }

            for(int i = 0; i< ILOSC_KOSCI; i++)
            {
                TablicaWynikow[i] = losujpojedynczy();
                TablicaPowtorzen[TablicaWynikow[i]]++;
            }
            obliczwyniki(TablicaPowtorzen);
        }

        public BitmapImage wyswietlObraz(int iloscOczek)
        {
            string sciezka;
            switch (iloscOczek)
            {
                case 1:
                    sciezka = PLIK_KOSCI_JEDEN;
                    break;
                case 2:
                    sciezka = PLIK_KOSCI_DWA;
                    break;
                case 3:
                    sciezka = PLIK_KOSCI_TRZY;
                    break;
                case 4:
                    sciezka = PLIK_KOSCI_CZTERY;
                    break;
                case 5:
                    sciezka = PLIK_KOSCI_PIEC;
                    break;
                case 6:
                    sciezka = PLIK_KOSCI_SZESC;
                    break;
                default:
                    sciezka = PLIK_KOSCI_NIEZNANY;
                    break;
            }
            return;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}