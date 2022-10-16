using System;
using System.Collections.Generic;
using System.ComponentModel;
using Workshop.Common;

namespace Workshop.CSharp.CSharp2.ExercisesB
{
//    [TestClass]
    public class DelegatesExercises
    {
        /// <summary>
        /// Posortowac liste napisow po ich dlugosci wykorzystujac metode listy 'Sort(Comparison<T> comparison)'
        /// 
        ///
        /// Zaimplementowac nastepujace metody:
        /// - 'List<T> Where<T>(List<T> items, Func<T,bool> predicate)' dzialajaca analogicznie do metody listy FindAll
        /// - 'T First<T>(List<T> items, Func<T, bool> predicate)' dzialajaca analogicznie do metody listy Find
        /// 
        /// Podpowiedzi: 
        /// - w dowolnym miejscu w kodzie metody mozemy wywolac "return wartosc;" przerywajac jej dzialanie i zwracajac wynik
        /// - wyrazenie 'default(nazwa_typu)' zwraca domyslna wartosc dla przekazanego typu
        ///
        /// Napisac kod testujacy dzialanie metod.
        /// </summary>
        [TestMethod]
        public void Delegates()  {  }




        /// <summary>
        /// Zdefiniowac klase Customer{Name:string,Address:string} posiadajca zdarzenie 
        /// 'event PropertyChangedEventHandler PropertyChanged' informujace o zmienia wartosci kazdej 
        /// z wlasciwoci.
        /// 
        /// delegat PropertyChangedEventHandler znajduje sie w w przestrzeni nazw 'System.ComponentModel' 
        /// 
        /// Napisac kod testujacy dzialanie zdarzenia.
        /// </summary>
        [TestMethod]
        public void Events()  {  }

    }
}
