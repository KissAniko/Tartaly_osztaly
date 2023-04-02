using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace MyClass
{

    public class Tartaly
    {

    /* Egy téglatest alakú tartály adatait és viselkedését határozza meg a
     * tartály osztály, aminek a befejezése a feladat! */

    /* 1. feladat: Az osztály adattagjai a következők: (Minden adattag legyen 
     *             rejtett) - nev : karakterlánc (a tartály neve)
     *                      - a, b, c : int típusú (cm-ben a tartály élhosszai)
     *                      - aktLiter : double típusú (a tartályban lévő aktuális
     *                                   mennyiség literben) */
        string nev;
        int a, b, c;
        double aktLiter;

//------------------------------------------------------------------------------------------

        /* 2. feladat: Hozzon létre egy konstruktort, amely 4 paraméterrel rendelkezik
         *             (tartály neve és az élek hossza). Ezeket az értékeket adja át a 
         *             fenti rejtett attribútumoknak. Az aktLiter pedig 0-ra állítja. */

        public Tartaly(string nev, int a, int b, int c)
        {
            this.nev = nev;
            this.a = a;
            this.b = b;
            this.c = c;
            this.aktLiter=0;
        }

 //------------------------------------------------------------------------------------------

        /* 3. feladat:Fejezze be az elkezdett konstruktort! Ez a konstruktor egy 
         *            10x10x10 cm3 kocka alakú üres tartályt hoz létre és a paraméterként
         *            kapott nevet adja neki. */

        public Tartaly(String nev)
        {
            this.nev = nev;
            this.a = 10;
            this.b = 10;
            this.c = 10;
            this.aktLiter = 0;
        }
        
//------------------------------------------------------------------------------------------

        /* 4. feladat: Fejezze be az elkezdett jellemző (property) készítést. 
         *             Adja vissza a tartály cm3-ben mért térfogatát. */

        public double Terfogat
        {
            get { return this.a * this.b * this.c; }
            
        }

//-------------------------------------------------------------------------------------------

        /* 5. feladat: Készítsen visszatérési érték és paraméter nélküli metódusokat
         *             DuplazMeretet és TeljesLeengedes néven. A DuplazMeretet duplázza, 
         *             a tartály térfogat valamelyik él értékének változtatásával.
         *             A TeljesLeengedes pedig kiüríti a tartályt. */

        public void DuplazMeretet()
        {
            this.a *= 2;
        }
        public void TeljesLeengedes()
        {
            this.aktLiter = 0;
        }

//--------------------------------------------------------------------------------------------

        /* 6. feladat: Készítsen Toltottseg néven double típusú tulajdonságot (property).
         *             A tulajdonság visszaadja, hogy %-osan milyen szinten van tele a 
         *             tartály.  */

        public double Toltottseg
        {
            get { return (aktLiter / Terfogat / 1000) * 100; }
                // get => (this.aktLiter / Terfogat) * 10;
            }

//--------------------------------------------------------------------------------------------

        /* 7. feladat:Készítsen Tolt néven egyparaméteres visszatérési érték nélküli
         *            metódust. A double paraméterben kapott literrel növeli a tartályban
         *            lévő mennyiséget. Amennyiben ez a mennyiség nem fér a tartályba, 
         *            írjon ki hibaüzenetet és ne hajtsa végre a töltést. */

        public void Tolt(double mennyiseg)
        {
            if (Terfogat < this.aktLiter + mennyiseg)
            {
                Console.WriteLine("Nem lehet ennyit a tartályba tölteni!");
            }
            this.aktLiter += mennyiseg;
        }

//----------------------------------------------------------------------------------------------

        public string Info()
        {
            /* return String.Format("{0}:{1} cm3 = ({6} liter), töltöttsége:{2}%, ({7} liter)," +
                    " méretei:{3} x {4} x {5} cm", this.nev, this.Terfogat, this.Toltottseg * 100,
                    this.a, this.b, this.c, this.Terfogat / 1000, this.aktLiter); */

            return $"Neve:{this.nev};\nTérfogata:{this.Terfogat * 1000:n1} cm3; ({this.Terfogat:n2} liter);\n" +
                   $" töltöttsége: {this.Toltottseg:n2}%;\n Aktuális Mennyiség:{this.aktLiter:n2} liter;\n" +
                   $" méretei: {this.a}x{this.b}x{this.c} cm;";

        }

    }

}