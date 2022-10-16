using System;
using System.Collections.Generic;
using System.IO;


namespace Workshop.CSharp.Objectivity
{
    // Interfejs opisuje API obiektu czyli jakie member'y (wlasciwosci, metody,... bez pol)
    // powinien posiadac typ (jedynie sygnatury, bez implementacji).
    // Typ implementujac interfejs musi zaimplementowac wszystkie member'y.
    // Interfejs czesciowo rozwiazuje 'problem' braku wielokrotnego dziedziczenia w .NET.
    
    // konwencja: nazwy interfejsow zaczynaja sie od 'I'
    public interface ISaveable
    {
        string Serialize();
        void Deserialize(string data);
    }

    // abstract - klasa abstrakcyjna
    // - nie mozna stworzyc instancji takiej klasy (blad kompilacji)
    // - klasa taka moze posiadac niezaimplementowane member'y (wlasciwosci, metody, ...), 
    // nastepnie klasa dziedziczaca po niej musi je zaimplementowac, w przeciwnym 
    // razie staje sie takze abstrakcyjna

    public abstract class Person : /*object,*/ ISaveable    // kazdy typ domyslnie dziedziczy po System.Object
    {
        #region ...
        
        
        public string Name { get; set; }
        //abstract public string PhoneNumber { get; }       // przykladowy abstrakcyjny member

        protected Person() { }
        protected Person(string name)
        {
            Name = name;
        }

        // override - przeciazenie metody wirtualnej bazowego typu Object
        public override string ToString()   
        {
            return string.Format("Osoba o nazwie {0}", Name);
        }



        // virtual - metoda  wirtualna ktora moze byc przeciazana (zaimplmentowana) 
        // w klasach dziedziczacych

        #endregion

        public virtual string Serialize()
        {
            return Name;
        }
        public virtual void Deserialize(string data)
        {
            Name = data;
        }
    }

    // sealed - zablokowanie dalszego dziedziczenia
    public sealed class Student : Person 
    {
        public List<string> Classes { get; set; }

        // konstruktury nie sa dziedziczone 
        public Student()
            : base()    // wywolanie bazowego konstruktora (tutaj zbytecznie bo domyslnie wywola sie bazowy)
        {
            Classes = new List<string>();
        }
        public Student(string name, List<string> classses)
            : base(name)
        {
            Classes = classses;
        }

        public override string ToString()
        {
            return string.Format("Uczen '{0}' uczestniczy w {1} zajeciach", Name, Classes.Count);
        }
                
        public override string Serialize()
        {
            var baseData = base.Serialize();            // wywolanie bazowej metody            
            return baseData + '|' + string.Join(",", Classes);            
        }
        public override void Deserialize(string data)
        {
            var parts = data.Split('|');
            
            base.Deserialize(parts[0]);                 // ustawienie bazowej metody
            Classes.AddRange(parts[1].Split(','));
        }
    }


    public class Teacher : Person
    {
        public string ClassName { get; set; }
        
        public Teacher() { }
        public Teacher(string name, string className)
        {
            Name = name;
            ClassName = className;
        }

        public override string ToString()
        {
            return string.Format("Nauczyciel '{0}' prowadzi '{1}'", Name, ClassName);
        }
  
        public override string Serialize()
        {
            var baseData = base.Serialize();            // wywolanie bazowej metody            
            return baseData + '|' + ClassName;
        }
        public override void Deserialize(string data)
        {
            var parts = data.Split('|');
            base.Deserialize(parts[0]);                 
            ClassName = parts[1];
        }
    }


    

    // klasa statyczna poniewaz wszystkie metody sa statyczne
    public static class SchoolManager
    {
        private const string DataFile= "school.txt";
        private const string MetadataFile = "school.metadata.txt";

        public static void PrintAll(IEnumerable<object> objects)  //interfejs            
        {
            int i = 0;
            foreach (object entity in objects) // IEnumerable
                Console.WriteLine("{0}. {1}", i++, entity.ToString()); // polimorfizm
        }

        public static void SaveAll(ICollection<ISaveable> entities) //interfejs
        {
            var dataLines = new string[entities.Count]; // ICollection.Count
            var metadataLines = new string[entities.Count];

            int i = 0 ;
            foreach (ISaveable entity in entities) // IEnumerable
            {
                dataLines[i] = entity.Serialize(); // ISaveable
                metadataLines[i] = entity.GetType()?.FullName;
                i++;
            }
                
            File.WriteAllLines(DataFile, dataLines);
            File.WriteAllLines(MetadataFile, metadataLines);
        }

        public static List<ISaveable> Load()
        {
            var result = new List<ISaveable>();
            var dataLines = File.ReadAllLines(DataFile);
            var metadataLines = File.ReadAllLines(MetadataFile);

            for (int i = 0; i < dataLines.Length; i++)
            {
                var data = dataLines[i];
                var metadata = metadataLines[i];
                var entity = (ISaveable) Activator.CreateInstance(Type.GetType(metadata));
                entity.Deserialize(data);
                result.Add(entity);
            }
            
            return result;
        }
    }


}