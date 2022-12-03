using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Workshop.CSharp.Data;
using Workshop.CSharp.Data.SampleData;
using Workshop.Common;

namespace Workshop.CSharp.CSharp3.ExercisesB
{
    //[TestClass]
    public class LinqExercises
    {
        // Uwagi:
        // - do wypisywania danych na ekran wykorzystac metode rozszerzajaca 'Workshop.Common.Extensions.Print(this object o)'
        // - dane na ktorych wykonywane sa zapytania pobierac za pomoca 'DataProvider.Products/Categories


        /// <summary>
        /// Zapytanie zwracajace ProductName i UnitPrice produktow ktorych UnitPrice jest wieksza od 50.
        /// (where, select)
        /// </summary>
        [TestMethod]
        public void WhereSelect()  {

            //var strings = new List<string>() { "one", "two", "three", "four", "five", "six" };

            //var result = strings.Where(m => m.Length > 3).Select(m=>new { Len = m.Length, Val = m }).ToList();

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            var result1 = DataProvider.Products
                .Where(p => p.UnitPrice > 10 && p.UnitPrice < 100)
                .Select(p => new {  p.UnitPrice, p.ProductName}).ToList();

            result1.Print();


        }

        /// <summary>
        /// Zapytanie zwracajace nazwy i wartosci calkowite (=UnitPrice*UnitsInStock) produktow, posortowane 
        /// malejaco po wartosciach calkowitych.
        /// (let, orderby, select)
        /// </summary>
        [TestMethod]
        public void LetOrderBy()  {

            var result = DataProvider.Products
                .Select(p => new { p.ProductName, Total = p.UnitPrice * p.UnitsInStock })
                .OrderBy(p => p.Total);


            //Wersja zapytania c#
            //var result2 = from p in DataProvider.Products
            //              let total = p.UnitPrice * p.UnitsInStock
            //              orderby total
            //              select p;

            result.Print();

        }

        /// <summary>
        /// Zapytanie zwracajace nazwy ProductName oraz nazwy CategoryName, posortowane po CategoryName
        /// a nastepnie po ProductName.
        /// (join, orderby, select)
        /// </summary>
        [TestMethod]
        public void Join()  {

            var result = DataProvider.Products.Join(DataProvider.Categories, p => p.CategoryID, c => c.CategoryID, (p, c) => new { Product = p, Category = c })
                .Select(m=> new { Cat = m.Category.CategoryName, Prod = m.Product.ProductName})
                .OrderBy(m => m.Cat)
                .ThenBy(m=>m.Prod)
                .Select(m => m.Prod).ToList();

            result.Print();


        }

        /// <summary>
        /// Zapytanie zwracajace druga piatke najdrozszych produktow.
        /// (orderby, skip, take)
        /// </summary>
        [TestMethod]
        public void TakeSkip()  {

            var result = DataProvider.Products
                .OrderByDescending(m => m.UnitPrice)
                .Skip(5)
                .Take(5);

                result.Print();

        }


        /// <summary>
        /// Napisac kod na ktory podstawie pliku XML z produktami (sciezka 'Path.Combine(Environment.CurrentDirectory, "Data/SampleData/Products.xml")'
        /// tworzy nowy plik XML zawierajacy informacje o produktach (id,name,unitsInStock) spelniajacych
        /// warunek 'UnitsInStock>100', posortowanych malejaco po UnitsInStock. Przykladowy plik wynikowy:        
        /// <Raport><Product id="73" name="Rod Kaviar" unitsInStock="101" /> ... </Raport>
        /// </summary>
        [TestMethod]
        public void LinqToXml()  {  }



    }
}
