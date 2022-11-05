using System;
using System.Linq;
using NUnit.Framework.Constraints;
using Workshop.Common;

namespace Workshop.CSharp.ClassesObjects.ExercisesB
{
    [TestClass]
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
        public void IntPairs() {

            var intPtr = new IntPair(3,4);
            intPtr.Swap();

            var minMaxPair = IntPair.FindMaxMin(new int[] {1,2,3,4 });

            Console.WriteLine("min: " + minMaxPair.Value1 + " max: " + minMaxPair.Value2);

        }

        class IntPair
        {
            public int Value1 { get; private set; }
            public int Value2 { get; private set; }

            public IntPair() { }

            public IntPair(int value) {

                Value1 = Value2 = value;

            }

            public IntPair(int value1, int value2)
            {

                Value1 = value1;
                Value2 = value2;

            }

            public void Swap() {

                var temp = Value1;
                Value1 = Value2;
                Value2 = temp;

            }

            public static IntPair FindMaxMin(params int[] array) {

                if (array.Length==0)
                {
                    return new IntPair();
                }

                var min = array[0];
                var max = array[0];

                foreach (var item in array)
                {
                    if (item>max)
                    {
                        max = item;
                    }

                    if (item<min)
                    {
                        min = item;
                    }
                }

                return new IntPair(min, max);

            }
        }


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
        public void Employees() {

            var Pawel = new Employee("Pawel", new DateTime(2022,08, 01), 13);
            var Grzegorz = new Employee("Grzegorz", new DateTime(2021,10, 01), 14);
            var Darek = new Employee("Darek", new DateTime(2022,07, 01), 13);
            var Luca = new Employee("Luca", new DateTime(2012,08, 01), 24);

            Console.WriteLine("Pracownik " + Luca.Name + " zarabia " + Luca.Salary);
            Luca.GiveARise();
            Console.WriteLine("Pracownik " + Luca.Name + "  po podwyżce zarabia " + Luca.Salary);

            Console.WriteLine("Średnie zarobki w firmie " + CalculateAverageSalary(new Employee[] { Pawel, Luca, Darek, Grzegorz}));


        }


        class Employee
        {

            private decimal _salary;

            public string Name { get; private set; }
            public DateTime DateOfEmployment { get; private set; }

            public decimal Salary {
                get {
                    return _salary;
                }
                set {
                    if (value >0 && value>_salary)
                    {
                        _salary = value;
                    }
                }
            }


            public Employee(string name, DateTime dateOfEmployment, decimal salary)
            {
                Name = name;
                DateOfEmployment = dateOfEmployment;
                Salary = salary;
            }

            public void GiveARise() {
                Salary += Salary * 0.01m * (DateTime.Now.Year - DateOfEmployment.Year);
            }
            
        }

        static decimal CalculateAverageSalary(Employee[] array) {
            if (array.Length == 0)
            {
                return 0;
            }

            decimal sum = 0;
            foreach (var employee in array)
            {
                sum += employee.Salary;
            }

            return sum / array.Length;
        }

    }
}
