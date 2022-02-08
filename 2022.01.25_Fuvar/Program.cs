using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_01_24_Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();
            File.ReadAllLines("fuvar.csv").Skip(1).ToList().ForEach((s) => fuvarok.Add(new Fuvar(s)));

            Console.WriteLine($"3. feladat: {fuvarok.Count} fuvar");

            int fuvarSzam = fuvarok.Where((f) => f.taxiAzonosito == 6185).Count();
            double fuvarBevetel = 0;
            fuvarok.ForEach((f) => {
                if (f.taxiAzonosito == 6185)
                {
                    fuvarBevetel += (f.borravalo + f.viteldij);
                }
            });

            Console.WriteLine($"4. feladat: {fuvarSzam} alatt: {fuvarBevetel}$");

            /*Dictionary<string, int> engedelyezettFizetesiModok = new Dictionary<string, int>();
            fuvarok.ForEach((f) => {
                if (!engedelyezettFizetesiModok.ContainsKey(f.fizetesMod)) {
                    engedelyezettFizetesiModok.Add(f.fizetesMod, 1);
                } else {
                    engedelyezettFizetesiModok[f.fizetesMod]++;
                }
            });
            Console.WriteLine("5. feladat:");
            foreach (var e in engedelyezettFizetesiModok) {
                Console.WriteLine($"\t{e.Key}: {e.Value} fuvar");
            }*/

            fuvarok.GroupBy((f) => f.fizetesMod).Select((x) => new {
                fizetésMód = x.Key,
                db = x.Count()
            }).ToList().ForEach((f) => {
                Console.WriteLine($"\t{f.fizetésMód}: {f.db} fuvar");
            });

            double osszKilometer = 0;

            fuvarok.ForEach((f) => {
                osszKilometer += (f.megtettTavolsag * 1.6);
            });

            Console.WriteLine($"6. feladat: {osszKilometer.ToString("F2")}km");

            Fuvar leghosszabbFuvar = fuvarok.OrderBy((f) => f.utazasIdotartama).Last();

            Console.WriteLine("7. feladat: Leghosszabb fuvar:");
            Console.WriteLine($"\tFuvar hossza: {leghosszabbFuvar.utazasIdotartama} másodperc");
            Console.WriteLine($"\tTaxi azonosító: {leghosszabbFuvar.taxiAzonosito}");
            Console.WriteLine($"\tMegtett távolság: {leghosszabbFuvar.megtettTavolsag.ToString("F1")} km");
            Console.WriteLine($"\tViteldíj: {leghosszabbFuvar.viteldij}$");

            Console.WriteLine("8. feladat: hiba.txt");
            List<string> kiirandoHibak = new List<string>();
            kiirandoHibak.Add("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");

            fuvarok.ForEach((f) => {
                if (f.utazasIdotartama > 0 && f.viteldij > 0 && f.megtettTavolsag == 0)
                {
                    kiirandoHibak.Add($"{f.taxiAzonosito};{f.utazasIdopontja};{f.utazasIdotartama};{f.megtettTavolsag};{f.viteldij};{f.borravalo};{f.fizetesMod}");
                }
            });

            File.WriteAllLines("hiba.txt", kiirandoHibak);

            Console.ReadKey();
        }
    }
}