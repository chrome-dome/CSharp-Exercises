using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Workshop.Common;

namespace Workshop.CSharp.Objectivity.ExercisesB
{
    //[TestClass]
    public class ObjectivityExercises
    {
        /// <summary>
        /// Napisac klase Class {Name:string, RoomNumber:int} reprezetnujaca przedmiot, a nastepnie:
        /// - przeciezyc metode ToString() zwracajaca informacje o przedmiocie
        /// - zaimplementowac interfejs ISaveable
        /// - zaimplementowac interfejs INotifyPropertyChanged (analogicznie do wczesniejszej klasy Customer)
        /// 
        /// Przetestowac dzialanie klasy z za pomoca SchoolManager.
        /// 
        /// Napisac klase 'ClassComparer : IComparer<Class>' porownujaca obiekty przedmiotow porownujac
        /// numery pokojow w ktorych sa prowadzone. Wykorzytac ClassComparer do posortowania tablicy przedmiotow
        /// za pomoca metody 'Array.Sort(tablica, comparer)'
        /// </summary>
        [TestMethod]
        public void ObjectsInterfaces()  {

            //var book = new Newspapper("Playstation", 48);
        }

        class Class: ISaveable, INotifyPropertyChanged
        {
            string Name { get; set; }
            public int RoomNumber { get; set; }

            public event PropertyChangedEventHandler? PropertyChanged;

            public override string ToString()
            {
                return Name;
            }

            public string Serialize()
            {
                throw new NotImplementedException();
            }

            public void Deserialize(string data)
            {
                throw new NotImplementedException();
            }
        }

        class ClassComparer : IComparer<Class>
        {
            private Array? result;
            private Array? comparer;

            public int Name { get; private set; }

            public void Compare(Class x, Class y)
            {
                //string result="";

                //if (x==y)
                //{
                //     result += "klasy są identyczne";
                //}

                Array.Sort(result, comparer);
            }

            int IComparer<Class>.Compare(Class? x, Class? y)
            {
                return Name;
            }
        }

        public interface IHasName
        {
            string Name { get; set; }
            string GetName();
        }


        abstract class Newspapper:IHasName
        {
            public string Name { get; set; }


            public override string ToString()
            {
                return Name;
            }

            public int Pages { get; set; }

            public Newspapper(string name, int pages)
            {
                Name = name;
                Pages = pages;
            }

            public abstract int getNumberOfPage();

            public virtual string GetName()
            {
                return Name;
            }
        }



        sealed class Magazine : Newspapper
        {
            public Magazine(string name, int pages) : base(name, pages)
            {
            }

            public override int getNumberOfPage()
            {
                return Pages;
            }

            public override string ToString()
            {
                return base.ToString();
            }

            public override string GetName()
            {
                return base.GetName();
            }
        }

    }
}
