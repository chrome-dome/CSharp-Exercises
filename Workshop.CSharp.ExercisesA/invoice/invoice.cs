using System;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework.Constraints;
using Workshop.Common;
using Workshop.CSharp.ExercisesA.invoice;


//Klient posiada sklep z ubraniami, chcemy zaprojektować mu system do wysyłanie faktur i zarządzania magazynem (zacznijmy od faktury :) ):

//Klasa Faktura { Items: List<Item>, CreationDate: DateTime, PaymentDate: DateTime, InvoiceNumber: int, CompanyAddress: Address, Status: Status, Sum: decimal, Vat: decimal, Total: decimal }
//Klasa Address { Street:string, PostalCode:string, City: string}
//Klasa Item reprezentująca pojedynczy wpis na fakturze { Id: int, Name: string, Quantity: int, Price: decimal, Sum: decimal} (faktura zawiera listę Itemów np. 2x spodnie i 3x czapka)

//a) Data wystawienia i numer faktury musi być zawsze podany przy tworzeniu, resztę mogę ustawić później. Jeśli na starcie nie podam Vat'u to ustawi się automatycznie na 23%. Wartość Sum jest tylko do odczytu i zawiera sumę elementów na fakturze. Wartość total zwraca sumę powiększoną o Vat.

//b) InvoiceNumber nie może być ujemny.

//c) Faktura może znajdować się w 4 stanach "Status": (Pending(oczekuje na zapłacenie), Outstanding(nie zapłacona po terminie), Cancelled(anulowana), Paid)

//d) Faktura powinna zawierać metodę 'bool CheckIfOutstanding()' która sprawdzi czy faktura nie jest już po czasie i jeśli jest to zmieni jej status.

//e) Faktura powinna zawierać metodę CancelInvoice() oraz InvoicePaid(), która odpowiednio zmieni status faktury na Cancel, jeśli status został ustawiony na Cancel to wywołanie metody CheckIfOutstanding() nie powinno zmienić już statusu na żaden inny oraz zwrócić wartość false. W przypadku InvoicePaid() ustawiamy status na Paid i również chcemy aby CheckIfOutstanding() nie zmieniło statusu.

//f) Nie da się dodawać elementów bezpośrednio do Item, można to zrobić tylko metodą void AddItem(Item item), wewnątrz dodajemy element oraz uaktualniamy sumę (Sum:decimal na el. faktura)

//g) Element faktury musi posiadać nazwę, ilość i cenę od samego początku.
//h) Element faktury posiada właściwość Sum, który jest tylko do odczytu i liczy się dynamicznie, wartość jest wyliczana w momencie wywołania właściwości Sum.

//i) Cena oraz ilość nie może być ujemna.

//j) Item zawiera statyczną metodę int decimal SumItems(int[] items) która zwróci całkowitą sumę elementów (ilość * cena dla każdego z el.)

//k) Faktura zawiera statyczną metodę która przyjmuje fakturę przechodzi po jej elementach i próbuje ją zoptymalizować, tzn. jeśli na fakturze mamy elementy [ {Id: 1, Name: "spodnie"}, { Id: 2, Name: "spodnie"}, { Id: 3, Name: "czapka"}, { Id: 4, Name: "spodnie"} ] to dostaniemy wynik który jest słownikiem: { "spodnie": [1, 2, 4], "czapka":[3]}

//l) Napisać kod testujący.

//Rozwiązanie powyższego ćwiczenia można dodać do repozytorium do którego mam dostęp, można stworzyć nowy folder w projekcie i tam dodać potrzebne klasy.


namespace Workshop.CSharp.ExercisesA.invoice
{
    class Faktura
    {
        public List<Item> Items { get; private set; } = new List<Item>();
        public DateTime CreationDate { get; set; }
        public DateTime PaymentDate { get; set; }

        private int _invoiceNumber;
        public int InvoiceNumber
        {
            get { return _invoiceNumber; }
            set
            {
                if (value > 0)
                {
                    _invoiceNumber = value;
                }
            }
        }


        public Address CompanyAddress { get; set; }
        public Status PaymentStatus { get; private set; }
        public decimal Sum { get; private set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }

        public Faktura(DateTime creationDate, int invoiceNumber, decimal vat = 0.23m)
        {
            CreationDate = creationDate;
            InvoiceNumber = invoiceNumber;
            Vat = vat;
        }

        bool CheckIfOutstanding()
        {
            if (DateTime.Now > PaymentDate && PaymentStatus != Status.Paid && PaymentStatus != Status.Cancelled)
            {
                PaymentStatus = Status.Outstanding;
                return true;
            }

            return false;
        }

        public void CancellInvoice()
        {
            PaymentStatus = Status.Cancelled;
        }

        public void InvoicePaid()
        {
            PaymentStatus = Status.Paid;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
            Sum += item.Sum;
            Total += item.Sum + (item.Sum * Vat);
        }

    }

    enum Status
    {
        Pending,
        Outstanding,
        Cancelled,
        Paid
    }

    class Address
    {

        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

    }


    class Item
    {

        public int Id { get; set; }
        public string Name { get; set; }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity > 0)
                {
                    _quantity = value;
                }
            }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                if (_price > 0)
                {
                    _price = value;
                }
            }
        }


        public decimal Sum
        {
            get
            {
                return Quantity * Price;
            }
        }

        public Item(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = (int)price;
        }

        public static decimal SumItems(Item[] items)
        {
            decimal sum = 0;
            foreach (var item in items)
            {
                sum += item.Quantity * item.Price;
            }

            return sum;
        }

    }
}

