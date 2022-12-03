using Workshop.Common;

namespace Workshop.CSharp.Introduction.ExercisesB
{
    [TestClass]
    public class IntroductionExercises
    {
        /// <summary>
        /// Zaimplementowac ponizsza metode w nastepujacy sposob:
        /// "
        ///  Podaj liczbe a: ...
        ///  Podaj liczbe b: ...
        ///  Wynik a + b =  ...
        /// "
        /// Uwaga: skorzystac z metody int.Parse do zamiany string na int.
        /// </summary>
        /// 
        [TestMethod]
        public void ConsoleDialog() {

            //moja wersja
            //Console.WriteLine("Podaj pierwszą liczbę:");
            //var firstNumber = Convert.ToInt32(Console.ReadLine());
       
            //Console.WriteLine("Podaj drugą liczbę:");
            //var secondNumber = Convert.ToInt32(Console.ReadLine());

            //var wynik = firstNumber + secondNumber;

            //Console.WriteLine($"Po dodaniu wynik dwóch liczb wynisi: {wynik}");


            Console.WriteLine("Podaj pierwszą liczbę:");
            string a = Console.ReadLine();

            Console.WriteLine("Podaj drugą liczbę:");
            string b = Console.ReadLine();

            Console.WriteLine("Wynik a + b = " + (int.Parse(a) + int.Parse(b)));
        }

        /// <summary>
        /// Zaimplementowac ponizsza metode tak ze wywoluje w petli metode 'ConsoleDialog' poprzedzajac kazda 
        /// iteracje pytaniem "Czy liczyc dalej? : ". Jesli uzytkownik odpowie "nie" to petla jest przerywana.
        /// </summary>
        [TestMethod]
        public void ConsoleDialogInLoop() {


            //moje rozwiązanie
            //bool stopCounting = true;

            //while (stopCounting)
            //{
            //    Console.WriteLine("Czy liczyć dalej?");
            //    var endCounting = Console.ReadLine();

            //    if (endCounting == "nie")
            //    {
            //        stopCounting = false;
            //    }
            //}


            bool endCounting = false;

            while (!endCounting)
            {
                Console.WriteLine("Czy liczyć dalej?");
                endCounting = Console.ReadLine() == "nie";

                if (!endCounting)
                {
                    ConsoleDialog();
                }
            }

        }

        /// <summary>
        /// Napisac metode 'SumPositiveNumbers' liczaca sume liczb dodatnich znajdujacej sie przekazanej tablicy.
        /// 
        /// Napisac kod testujacy metode.
        /// </summary>   
        [TestMethod]
        public void SumPositiveNumbersRunner() {

            //tutaj algorytm testujący, zadeklarowana testowa tablica i wywołana metoda i wyświetlony wynik

            var intArray = new int[] { 3, 10, -9, 8, 3, 0};

            int result = SumPositiveNumbers(intArray);

            Console.WriteLine("Powinno wyjść " + 24 + " a wyszło " + result);

            //3+10+8+3=24

        }

        public int SumPositiveNumbers(params int[] numbersArray) {

            //właściwy algorytm w tej metodzie do użycia zewnątrzengo

            var wynik = 0;

            foreach (var item in numbersArray)
            {
                if (item>=0)
                {
                    wynik +=item;
                }
            }

            return wynik;

            //UWAGA: dodając warunek do if pamiętać że dodajemy pojedynczy element tablicy (item) a nie całą tablicę(numbersArray[item])!!!tak samo jak do wyniku dodajemy osobną wartość JEDNEGO elementu tablicy...inaczej, dostajemy "System.IndexOutOfRangeException". Przez niedopatrzenie i pośpiech łatwo wrzucić tablicę, więc skupienie!!!

        }

    }
}
