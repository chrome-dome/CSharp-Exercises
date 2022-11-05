using System;
namespace Workshop.CSharp.ExercisesA.hospital
{

    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DoB { get; set; }
        public string Identifier { get; set; }
    }

    internal sealed class Patient: Person
    {
        public string MainDiagnosis { get; set; }
    }

    public interface IBadge
    {
        string GetBadge();
    }

    abstract class Pracitioner:Person, IBadge
    {
        public string Licence { get; set; }
        public DateTime DateOfEmployment { get; set; }
        protected string Phone { get; set; }
        public string Prefix { get; set; }

        public abstract string GetPhone(Person person);

        public virtual string GetBadge()
        {
            return $"Practioner {Prefix} {Name} {Surname}";
        }
    }

    class Doctor : Pracitioner
    {
        public override string GetPhone(Person person)
        {
            Console.WriteLine($"{person.Name} {person.Surname} odczytał numer lekarza {Name} {Surname}");
            return Phone;
        }

        public override string GetBadge()
        {
            return $"Lekarz {Prefix} {Name} {Surname}";
        }
    }

    class Nurse : Pracitioner
    {

        public bool CanWritePrescription{ get; set; }

        public override string GetPhone(Person person)
        {

            Console.WriteLine($"{person.Name} {person.Surname} odczytał numer pielęgniarki {Name} {Surname}");
            return Phone;
        }

        public override string GetBadge()
        {
            return $"Pielęgniarka {Prefix} {Name} {Surname}";
        }
    }

    public static class HospitalUtils
    {
        public static void Print(Person[] people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} {person.Surname} {person.Identifier}");
            }
        }

        public static void GenerateBadge(IBadge[] badges)
        {
            foreach (var badge in badges)
            {
                Console.WriteLine($"{badge.GetBadge()}");
            }
        }


        public static void Test()
        {
            var pawel = new Patient() { Name = "Paweł", Surname = "Sabuk", Identifier = "6664334" };
            var janina = new Nurse() { Name = "Janina", Surname = "Nowak", Identifier = "6434334" };
            var reinerd = new Doctor() { Name = "Reinard", Surname = "Kooperfield", Identifier = "0004334", Prefix = "dr" };

            HospitalUtils.Print(new Person[] { pawel, janina, reinerd });
            HospitalUtils.GenerateBadge(new IBadge[] { janina, reinerd });
        }


    }



}

