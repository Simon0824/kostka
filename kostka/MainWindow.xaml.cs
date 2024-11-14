﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        public int iloscPunktow { get; set; };
        public int iloscPunktowCalaGra { get; set; };
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}