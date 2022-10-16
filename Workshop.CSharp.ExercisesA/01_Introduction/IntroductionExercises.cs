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
        [TestMethod]
        public void ConsoleDialog() {

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

            bool endCounting = false;

            while (!endCounting)
            {
                Console.WriteLine("Czy liczyć dalej?");
                endCounting = Console.ReadLine() == "nie";

                if (!endCounting) {
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

            int[] array = new int[] { 3, 10, -9, 8, 3};

            int result = SumPositiveNumbers(array);

            Console.WriteLine("Powinno wyjść " + 24 + " a wyszło " + result);

            //3+10+8+3=24

        }

        public int SumPositiveNumbers(int[] numbers) {

            int sum = 0;

            foreach (var number in numbers)
            {
                if (number>0)
                {
                    sum += number;
                }
            }

            return sum;
            //właściwy algorytm w tej metodzie

        }

    }
}
