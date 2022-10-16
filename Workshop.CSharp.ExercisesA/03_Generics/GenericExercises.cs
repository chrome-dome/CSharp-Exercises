using System;
using System.Collections.Generic;
using System.IO.Ports;
using Workshop.Common;

namespace Workshop.CSharp.CSharp2.ExercisesB
{
//    [TestClass]
    public class GenericExercises
    {
        /// <summary>
        /// Napisac klase Pair<T> analogiczna dla IntPair zastepujac typ 'int' typem 'T'.
        /// 
        /// Napisac kod testujacy dzialanie klasy.
        /// </summary>
        [TestMethod]
        public void GenericPairs() { }
        
        /// <summary>
        /// Napisac metode 'Dictionary<int,int> Histogram(List<string> items)' ktora zlicza ilosc elementow 
        /// o takiej samej dlugosci. Przykladowo dla list { "a", "aa", "aa", "aaaa"} wynikiem jest 
        /// { {1,1} , {2,2} , {4,1} }
        /// 
        /// 
        /// Napisac metode 'Dictionary<int, List<string>> GroupByLength(List<string> items)' ktora grupuje
        /// elementy po ich dlugosci. Przykladowo dla list { "a", "aa", "aa", "aaaa"} wynikiem jest
        /// { {1, {"a"}} , {2,{"aa","aa"}} , {4,{"aaaa"}} }
        /// 
        /// 
        /// Zdefiniowac typ wyliczeniowy Condition {Greater,Lower,Equal}
        /// 
        /// Napisac metode 'List<int> Filter(List<int> items, int value, Condition condition)"
        /// zwracajaca liste skladajaca sie z elementow rownych/mniejszych/wiekszych od 
        /// przekazanego parametru 'value'        
        /// </summary>
        [TestMethod]
        public void GenericCollections() { }
    }
}
