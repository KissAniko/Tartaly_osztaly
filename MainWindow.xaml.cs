using Microsoft.Win32;
using MyClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Tartaly_osztaly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List<MyClass.Tartaly> tartalyok = new List<MyClass.Tartaly>();               // amíg nem mőködött a using MyClass,
                                                                                        // addig csak ezzel tudtam dolgozni.
                                                                                        // a fájlkezelésnél adta be a usingot,
                                                                                        // utána megint át kellett alakítani.
        List<Tartaly> tartalyok = new List<Tartaly>();
        public MainWindow()
        {
            InitializeComponent();
            rdoTeglatest.IsChecked = true; // ezt az inicializálást NEM SZABAD ELFELEJTENI!

            // MyClass.Tartaly  .... ezzel működik.
        }

//-----------------------------------------------------------------------------------------------
        private bool Ellenorzes()
        {
            int a = 0;
            int b = 0;
            int c = 0;
                       
            string nev = Convert.ToString(txtTestNev.Text);
            if ( nev == "")
            {
                MessageBox.Show("Nem adott meg nevet!");
                return false;
            }

            if (rdoTeglatest.IsChecked == true)
            {
                try
                {
                    a = Convert.ToInt32(txtA.Text);
                    b = Convert.ToInt32(txtB.Text);
                    c = Convert.ToInt32(txtC.Text);
                                      
                }
                catch (FormatException)
                {
                    MessageBox.Show("Nem jó a formátum!");
                  /*  txtA.Text = "";
                      txtB.Text = "";
                      txtC.Text = "";  */                                       
                    return false;
                }

                if (a <= 0 || b <= 0 || c <= 0)
                {
                    MessageBox.Show("Nem lehet a szám értéke 0 vagy annál kisebb!");
                    txtA.Text = "";
                    txtB.Text = "";
                    txtC.Text = "";

                    return false;
                }                
            }
            return true;
        }
//------------------------------------------------------------------------------------------------
        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {

            // MyClass.Tartaly ujTartaly;
            Tartaly ujTartaly;

            if (Ellenorzes())

            {
                if (rdoKocka.IsChecked == true)
                {
                    // Jelenleg a paraméterek adottak(10x10x10), ezért a testnek itt csak a neve kell(txtTextNev.Text)
                    //  ujTartaly = new MyClass.Tartaly(txtTestNev.Text);
                    ujTartaly = new Tartaly(txtTestNev.Text);
                }
                else
                {
                    //  ujTartaly = new MyClass.Tartaly(txtTestNev.Text, int.Parse(txtA.Text), int.Parse(txtB.Text), int.Parse(txtC.Text));
                    ujTartaly = new Tartaly(txtTestNev.Text, int.Parse(txtA.Text), int.Parse(txtB.Text), int.Parse(txtC.Text));
                }
                tartalyok.Add(ujTartaly); // MVVM 

                // a Tartaly.cs-ben van az Info metódus, itt azt a függvényt kell meghívni...mert abban vannak a leírások.
                lbTartaly.Items.Add(ujTartaly.Info()); // Megjelenítő vezérlőegység Items-en keresztül

            }

        }
//-----------------------------------------------------------------------------------------------
        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtA.Text = "10";
            txtB.Text = "10";
            txtC.Text = "10";
            txtA.IsEnabled = false;  // IsEnabled = tiltás
            txtB.IsEnabled = false;
            txtC.IsEnabled = false;
        }
        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtA.IsEnabled = true;
            txtB.IsEnabled = true;
            txtC.IsEnabled = true;
        }
//------------------------------------------------------------------------------------------------       
        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            /*
             OpenFileDialog rogzit = new OpenFileDialog();
             rogzit.ShowDialog();
             rogzit.FileName = @"";
           //  Tartaly TartalyInfo = new Tartaly();
             string[] TartalyArray;   */


            if (lbTartaly.Items.Count == 0)
            {
                MessageBox.Show("Nincs menthető adat.");
                return;
            }
            else
            {
                MessageBox.Show("Az adatok mentésre kerültek");
            }
            StreamReader sr = new StreamReader("mentettadatok.txt", encoding: Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                lbTartaly.Items.Add(sr.ReadLine());
            }
            sr.Close();

            /*
             // MENTÉS CSV FÁJLBA ....???

            List<Tartaly> kivalasztottList = new List<Tartaly>();

            StreamWriter sw = new StreamWriter("tartalyadatok.csv");  */


            /* MENTÉS TXT FÁJLBA
             * 
             * string TartalyLista = $"Neve:{txtTestNev.Text};\nA él={txtA.Text} cm;\nB él={txtB.Text} cm;\nC él={txtC.Text} cm \n " +
               $"Aktuális liter:{0}";   

               StreamWriter sw = new StreamWriter("testadatok.txt");
               sw.WriteLine(TartalyLista);
               sw.Close();
               MessageBox.Show("Az adatok mentésre kerültek.");   //  ( Csak az utolsó adatokat menti el!)  */
        }

//------------------------------------------------------------------------------------------------
        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartaly.Items.Count == 0)
            {
                MessageBox.Show("Nincs törölhető adat!");
            }
            else
            {
                lbTartaly.Items.Clear();
            }
        }   

//-------------------------------------------------------------------------------------------------          
        private void btnDuplaMeret_Click(object sender, RoutedEventArgs e)
        {
            if (Ellenorzes())
            {
                int a = Convert.ToInt32(txtA.Text);
                int b = Convert.ToInt32(txtB.Text);
                int c = Convert.ToInt32(txtC.Text);
                int terfogatKetszerese = (a * b * c * 2);
                lbTartaly.Items.Add("Térfogat kétszerese:" + terfogatKetszerese + "liter");
            }           
        }
//------------------------------------------------------------------------------------------------
        private void txtPluszLiter_TextChanged(object sender, TextChangedEventArgs e)
        {

            
            int a = Convert.ToInt32(txtA.Text);
            int b = Convert.ToInt32(txtB.Text);
            int c = Convert.ToInt32(txtC.Text);
            int szam = Convert.ToInt32(txtPluszLiter.Text);

          
            double terfogat = a * b * c;
            double elsomeres = terfogat + szam;
               
                lbTartaly.Items.Add("Térfogat és a hozzáadott mennyiség:" + terfogat + "+" + szam + "=" + elsomeres + "liter");

    /*      
                double masodikmeres = 0;
                masodikmeres = (terfogat * 2) + szam;
                lbTartaly.Items.Add("Térfogat kétszerese és a hozzáadott mennyiség:" + terfogat * 2 + "+" + szam + "=" + masodikmeres + "liter");

                double harmadikmeres = 0;
                harmadikmeres = (terfogat + szam) * 2;
                lbTartaly.Items.Add("Térfogat megnövelt mennyiségének kétszerese:" + terfogat + "+" + szam + "* 2 =" + harmadikmeres + "liter");  */          
            
           if (szam<=0)
           {
                MessageBox.Show("A szám nem lehet 0 vagy annál kisebb!");                
           }
                                               
        }
           
    }
}


/* JAVÍTANI! : - Nem számolja a %-ot
 *             - mentésnél csak az utolsó adatot menti el, illetve rögzítésnél nincs kiíratva az aktLiter adat... 
 *               ... és nem csv fájlba van mentve.
 *             - nincs Grid-elve a 2. oszlop alsó sora (a képből kimennek a gombok)
 *             - DuplaMeretnél, az adat és a liter kiíratásakor egybeolvad, nincs szóköz.
               - A pluszLiter-nél beírtam, de nincs kiíratva az az adat, mikor megduplázzuk a térfogat mennyiségét.
                   .. ezt úgy akartam megcsinálni, hogy ha rákattintunk a duplázóra, akkor írja ki ezeket az adatokat is
               - a bekért PluszLiter egyből kiíródik listára, nem pedig a Tölt nevű gombot használja. 

   ELVÉGZETT FELADATOK: - Számok ellenőrzése : a mező üresen nem maradhat, minusz és 0 nem lehet.
 *                      - Név ellenőrzése : a mező üresen nem maradhat
 *                      - Rádiógombok : felváltva működnek
                        - Felvesz : az adatokat listába teszi 
                        - Kocka : saját értékkel rendelkezik, ( a mezőkben beírt érték nem változtatható meg) 
                        - Téglatest : bekért adatok kellenek, ( a kocka adatai törlődnek) 
                        - Rögzít : jelenleg txt állományba menti az adatokat.
                        - Ürít : kiüríti a teljes listát
                        - DuplaMéret : megduplázza a térfogat mennyiségét
                        - Plusz liter : hozzáad bekért mennyiséget, amivel nő a térfogat mennyisége
*/
                        
           
