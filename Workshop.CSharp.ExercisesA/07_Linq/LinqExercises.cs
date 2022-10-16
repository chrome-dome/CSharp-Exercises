using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Workshop.CSharp.Data;
using Workshop.CSharp.Data.SampleData;
using Workshop.Common;

namespace Workshop.CSharp.CSharp3.ExercisesB
{
//    [TestClass]
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
        public void WhereSelect()  {  }

        /// <summary>
        /// Zapytanie zwracajace nazwy i wartosci calkowite (=UnitPrice*UnitsInStock) produktow, posortowane 
        /// malejaco po wartosciach calkowitych.
        /// (let, orderby, select)
        /// </summary>
        [TestMethod]
        public void LetOrderBy()  {  }

        /// <summary>
        /// Zapytanie zwracajace nazwy ProductName oraz nazwy CategoryName, posortowane po CategoryName
        /// a nastepnie po ProductName.
        /// (join, orderby, select)
        /// </summary>
        [TestMethod]
        public void Join()  {  }

        /// <summary>
        /// Zapytanie zwracajace druga piatke najdrozszych produktow.
        /// (orderby, skip, take)
        /// </summary>
        [TestMethod]
        public void TakeSkip()  {  }


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
