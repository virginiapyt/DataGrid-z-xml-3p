using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace DataGrid_z_xml_3p
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string plik1 = @"..\..\Dane\Produkty.xml"; //plik zrodlowy
        private string plik2 = @"..\..\Dane\Produkty2.xml"; //plik wynikowy
        private XElement wykazProduktow;
        public ObservableCollection<string> ListaMagazynow { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(plik1))
                wykazProduktow = XElement.Load(plik1);
            else MessageBox.Show("brak pliku");
            gridProdukty.DataContext = wykazProduktow;

            ListaMagazynow = new ObservableCollection<string>()
             {"Katowice_m1","Gliwice_m2", "Zabrze_m3" };
            mag.ItemsSource = ListaMagazynow;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wykazProduktow.Save(plik2);  // zapisanie danych do pliku wynikowego
            MessageBox.Show("Pomyślnie zapisano dane do pliku");
        }
    }
}
