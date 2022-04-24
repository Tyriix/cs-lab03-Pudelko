using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using cs_lab03_Pudelko.BoxLib;
using Rozszerzenie;

namespace cs_lab03_Pudelko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Constructors
            Pudelko box1 = new Pudelko(6.11, 2.31, 3.754, UnitOfMeasure.meter);
            Pudelko box2 = new Pudelko(1, 2, 3, UnitOfMeasure.centimeter);
            Pudelko box3 = new Pudelko(6110, 2310, 3754, UnitOfMeasure.milimeter);
            Pudelko box4 = new Pudelko(2.531, 3.644, 7.11);
            Pudelko box5 = new Pudelko(9.112, 5.213);

            List<Pudelko> boxList = new List<Pudelko> {box1, box2, box3, box4, box5};
            #endregion

            #region BoxDescription
            Console.WriteLine("Pudelko #1:");
            Console.WriteLine(box1.ToString());
            Console.WriteLine(box1.ToString("cm"));
            Console.WriteLine(box1.ToString("mm"));
            Console.WriteLine($"Pole pudełka wynosi: {box1.Pole}");
            Console.WriteLine($"Objętość pudełka wynosi: {box1.Objetosc}");
            Console.WriteLine();
            Console.WriteLine("Pudelko #2:");
            Console.WriteLine(box2.ToString());
            Console.WriteLine(box2.ToString("cm"));
            Console.WriteLine(box2.ToString("mm"));
            Console.WriteLine($"Pole pudełka wynosi: {box2.Pole}");
            Console.WriteLine($"Objętość pudełka wynosi: {box2.Objetosc}");
            Console.WriteLine();
            Console.WriteLine("Pudelko #3:");
            Console.WriteLine(box3.ToString());
            Console.WriteLine(box3.ToString("cm"));
            Console.WriteLine(box3.ToString("mm"));
            Console.WriteLine($"Pole pudełka wynosi: {box3.Pole}");
            Console.WriteLine($"Objętość pudełka wynosi: {box3.Objetosc}");
            Console.WriteLine();
            #endregion

            #region Equals/Operators
            Console.WriteLine($"Pudelko #1 jest równe pudełku #2: {box1.Equals(box2)}");
            Console.WriteLine($"Pudelko #1 jest równe pudełku #3: {box1.Equals(box3)}");
            Console.WriteLine($"Nowe pudełko, które pomieści pudełko #1 oraz pudełko #2: {(box1 + box2).ToString()}");
            Console.WriteLine($"Hash pudełka #1: {box1.GetHashCode()}");
            Console.WriteLine();
            #endregion

            #region Lists
            Console.WriteLine($"Lista nieposortowanych pudełek:");
            foreach (var box in boxList)
            {
                Console.WriteLine(box);
            }
            Console.WriteLine();

            Console.WriteLine($"Lista posortowanych pudełek:");

            boxList.Sort();
            foreach (var box in boxList)
            {
                Console.WriteLine(box);
            }
            #endregion

        }
    }
}
