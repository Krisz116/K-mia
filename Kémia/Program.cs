using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Kémia
{
    class Program
    {
        class Statisztika
        {
            string year , nev, felfedezo, vegyjel;
            int rendszam;

            public string Year { get => year; set => year = value; }
            public string Nev { get => nev; set => nev = value; }
            public string Vegyjel { get => vegyjel; set => vegyjel = value; }
            public int Rendszam { get => rendszam; set => rendszam = value; }
            public string Felfedezo { get => felfedezo; set => felfedezo = value; }

            public Statisztika(string year, string nev, string vegyjel, int rendszam, string felfedezo)
            {
                Year = year;
                Nev = nev;
                Vegyjel = vegyjel;
                Rendszam = rendszam;
                Felfedezo = felfedezo;
            }

            public Statisztika(string adatsor)
            {
                string[] adatok = adatsor.Split(';');
                Year = adatok[0];
                Nev = adatok[1];
                Vegyjel = adatok[2];
                Rendszam = int.Parse(adatok[3]);
                Felfedezo = adatok[4];
            }
        }
        static List<Statisztika> lista = new List<Statisztika>();
        static void Main(string[] args)
        {

           

            using (StreamReader beolvasas = new StreamReader("felfedezesek.csv", Encoding.Default ))
            {
                beolvasas.ReadLine();
                while (!beolvasas.EndOfStream)
                {
                    lista.Add(new Statisztika(beolvasas.ReadLine()));
                }
            }

            Console.WriteLine($"3.feladat: {lista.Count}");       
            Console.WriteLine($"4.feladat: Felfedezések száma az ókorban: {lista.FindAll(a => a.Year == "Ókor").Count}");
            feladat5();
            
            
            feladat6(); 
           

            Console.ReadKey();
        }
        static string bekeresvegyjel = "";
        private static void feladat5()
        {
            Console.WriteLine("5.feladat: Adjon meg egy vegyjelet");
            bekeresvegyjel = Console.ReadLine();
            while (!Regex.IsMatch(bekeresvegyjel, @"^[a-zA-Z]{1-2}$"))
            {
                Console.WriteLine("5.feladat: Adjon meg egy vegyjelet");
                bekeresvegyjel = Console.ReadLine();
            }
        }

        private static void feladat6()
        {
            bool vanvegyjel = false;
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine("6.feladat: Keresés");
                if (lista[i].Vegyjel.ToUpper() == bekeresvegyjel )
                {
                    vanvegyjel = true;
                    Console.WriteLine($"az elem vegyjele:{lista[i].Vegyjel}");
                    Console.WriteLine($"Az elem neve: {lista[i].Nev}");
                    Console.WriteLine($"Remdszama: {lista[i].Rendszam}");
                    Console.WriteLine($"Felfedezés éve : {lista[i].Year}");
                    Console.WriteLine($"Felfedező: {lista[i].Felfedezo}");
                }
            }
        }
    }
}
