using System;
using System.Linq;
using NUnit.Framework.Constraints;
using Workshop.Common;

namespace Workshop.CSharp.ClassesObjects.ExercisesB
{
    //[TestClass]
    public class ClassesObjectsExercises
    {
        /// <summary>
        /// Zdefiniowac klase IntPair { Value1:int, Value2:int } posiadajaca:
        /// - 3 konstruktury:
        /// -- domyslny
        /// -- przyjmujacy dwa parametry value1 i value2 ustawiajace wlasciwosci Value1 i Value2
        /// -- przyjmujacy jeden parametr value ustawiajacy wlasciwosci Value1 i Value2
        /// - metode instancyjna 'Swap()' zamieniajaca wartosci Value1 i Value2 
        /// 
        /// Napisac metode statyczna 'IntPair FindMaxMin(int[])' znajdujaca maksymalna i minimalna wartosc
        /// przekazanej tabicy zwracajac obiekt 'IntPair(min,max)'
        /// 
        /// Napisac kod testujacy dzialanie klasy oraz metody.
        /// </summary>
        [TestMethod]
        public void IntPairs() { }


        /// <summary>
        /// Zdefiniowac klase Employee {Name:string, DateOfEmployment:DateTime, Salary:decimal} posiadajaca:
        /// - konstruktor ustawiajacy wlasciwosc DateOfEmployment, ktorej nie mozna zmienic po zainicjowaniu w konstruktorze
        /// - wlasciwosc Salary uniemozliwiajaca ustawienie pensji mniejszej jak 0 oraz mniejszej jak aktualna wartosc pesja 
        /// (mozna dac jedynie podwyzke :) )        
        /// - instancyjna metode GiveARise() dajaca powyzke o procent rowny ilosci przepracowanych lat.
        /// - statyczna metode 'decimal CalculateAverageSalary(Employee[])' liczaca srednia pensje dla przekazanej tablicy pracownikow.
        /// 
        /// Napisac kod testujacy dzialanie klasy.
        /// </summary>
        [TestMethod]
        public void Employees() { }
    }
}
