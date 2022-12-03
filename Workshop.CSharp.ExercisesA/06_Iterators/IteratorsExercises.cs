using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Workshop.Common;

namespace Workshop.CSharp.CSharp2.ExercisesB_
{
    [TestClass]
    public class IteratorsExercises
    {
        private string SolutionFolder  { get {  return Environment.CurrentDirectory.Replace(@"\bin\Debug",""); } }

        /// <summary>
        /// Napisac metode iteratora 'IEnumerable<FileInfo> GetFileSequence(string folderPath)' ktora 
        /// zwraca liste plikow znajdujacych sie we wskazanym folderze i wszystkich podfolderach.
        /// 
        /// Uwaga: skorzystac jedynie z funkcji 'Directory.GetFiles(path)' oraz 'Directory.GetDirectories(path)'
        /// oraz rekurencji.
        /// 
        /// Napisc kod testujacy metode dla 'SolutionFolder'.
        /// </summary>
        [TestMethod]
        public void GetFileSequenceRunner()  {  }


        /// <summary>
        /// Wykorzystac napisana wczesniej metode 'GetFileSequence' aby znalezc:
        /// 
        /// - nazwy plikow wiekszych od 100000 (rezultat typu IEnumerable<string>)
        /// - 10 plikow ostatnio zmodyfikowanych (rezultat typu IEnumerable<FileInfo>)
        /// - sume wielkosci plikow z rozszerzem *.cs (rezultat typu long)
        /// - stworzyc slownik ktorego kluczem bedzie pelna sciezka pliku a wartoscia jego rozmiar
        /// (rezultat typu IDictionary<string,long>)
        /// </summary>
        [TestMethod]
        public void EnumerableMethods()  {  }

        /// <summary>
        /// Napisac metode rozszerzajaca 'void Rename(this FileInfo fileInfo, string newName)'  {  }
        /// 
        /// Uwaga: skrzystac z metody fileInfo.MoveTo oraz klasy Path przy wyliczaniu nowej pelnej scieki pliku
        /// </summary>
        [TestMethod]
        public void ExtensionMethod()  {  }

    }

}
