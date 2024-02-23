using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Tabor> lista = new List<Tabor>();
            Console.WriteLine("Hello, World!");

            using (var reader = new StreamReader("taborok.txt"))
            {
                while (!reader.EndOfStream)
                {
                    lista.Add(new Tabor(reader.ReadLine()));
                }
            }
            //2. feladat
            Console.WriteLine($"2. feladat\nAz adatsorok száma: {lista.Count}");
            Console.WriteLine($"Az először rögzített tábor témája: {lista[0].tabortema}");
            Console.WriteLine($"Az utoljára rögzített tábor témája: {lista[lista.Count-1].tabortema}");
            //3. feladat
            Console.WriteLine("3. feladat");
            var f3 = lista.FindAll(v => v.tabortema == "zenei").ToList();
            if(f3.Count != 0)
            {
                foreach (var item in f3)
                {
                    Console.WriteLine($"Zenei tábor kezdődik: {item.kezdeshonap}. hó {item.kezdesnap}. napján");
                }
            }
            // 4.feladat
            Console.WriteLine("4. feladat");
            var f4 = lista.MaxBy(v => v.diakbetujel.Count());
            Console.WriteLine("Legnépszerűbbek: ");
            foreach (var item in lista)
            {
                if(item.diakbetujel.Count() == f4.diakbetujel.Count())
                {
                    Console.WriteLine($"{item.kezdeshonap} {item.kezdesnap} {item.tabortema}");
                }

            }

            // 6.feladat
            Console.WriteLine("6. feladat");
            Console.Write("hó:");
            int honapInput = int.Parse(Console.ReadLine());
            Console.Write("nap:");
            int napInput = int.Parse(Console.ReadLine());
            DateTime taborInput = new DateTime(2020, honapInput, napInput);
            DateTime nyarKezdet = new DateTime(2020, 6, 16);
            DateTime nyarVege = new DateTime(2020, 8, 31);
            var f6 = lista.FindAll(v => v.DateKezdes <= taborInput && v.DateVege >= taborInput).ToList();

            Console.WriteLine($"Ekkor épp {f6.Count} tábor tart.");

            //7.feladat
            Console.WriteLine("7. feladat");
            Console.Write("Adja meg egy tanuló betűjelét: ");
            string diakInput = Console.ReadLine();
            var f7 = lista.FindAll(lista => lista.diakbetujel.Contains(diakInput)).ToList();


            f7 = f7.OrderBy(v => v.kezdeshonap).ThenBy(v => v.kezdesnap).ToList();
            
            using(var writer = new StreamWriter("egytanulo.txt")) {
                foreach (var item in f7)
                {
                    writer.WriteLine($"{item.kezdeshonap}.{item.kezdesnap}-{item.vegehonap}.{item.vegenap}. {item.tabortema}");


                }
            }
            int overlap = 0;
            for (int i = 0; i < f7.Count; i++)
            {
                for (int j = 1; j < f7.Count - i; j++)
                {
                    if (f7[i].DateKezdes < f7[j].DateVege && f7[j].DateKezdes < f7[i].DateVege)
                    {
                        overlap++;
                    }
                }

            }
            if (overlap > 0)
            {
                Console.WriteLine("Nem mehet el mindegyik táborba.");
            }
            else
            {
                Console.WriteLine("Minden táborba elmehet.");
            }
            











            // 5.feladat
            int sorszam(int honap, int nap)
            {

                DateTime nyarKezdet = new DateTime(2020, 6, 16);
                DateTime nyarVege = new DateTime(2020, 8, 31);
                DateTime taborKezdet = new DateTime(2020, honap, nap);
                int napok = (taborKezdet - nyarKezdet).Days;
                return napok;
            }

        }

    }
}