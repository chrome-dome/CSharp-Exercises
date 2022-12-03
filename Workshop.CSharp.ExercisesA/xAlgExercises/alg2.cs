using System;
using System.Collections;

namespace Workshop.CSharp.ExercisesA.xAlgExercises2
{
    //Rzymskie na arabskie

    //Cyfry rzymskie są reprezentowane przez siedem różnych symboli: I, V, X, L, C, D i M.
    //Symbol Value I1 V5
    //X 10
    //L 50
    //C 100 D 500 M 1000

    //Na przykład 2 jest zapisane jako II cyfrą rzymską - dwie jedynki dodawane razem. 12 jest zapisane jako XII, czyli po prostu X + II.Liczba 27 jest zapisana jako XXVII, czyli XX + V + II.
    //Cyfry rzymskie są zwykle pisane od największej do najmniejszej od lewej do prawej.Jednak cyfra dla czterech to nie IIII.Zamiast tego liczba cztery jest zapisana jako IV. Ponieważ jedynka jest przed piątką, odejmujemy ją, tworząc cztery. Ta sama zasada dotyczy liczby dziewięć, która jest zapisana jako IX.Istnieje sześć przypadków, w których stosuje się odejmowanie:
    //I można umieścić przed V (5) i X(10), aby uzyskać 4 i 9.
    //X można umieścić przed L(50) i C(100), aby uzyskać 40 i 90.
    //C można umieścić przed D(500) i M(1000), aby uzyskać 400 i 900. Podaną liczbę rzymską przekształć na liczbę całkowitą.

    //Przykład 1:
    //Wejście: s = "III" Wyjście: 3 Wyjaśnienie: III = 3.

    //Przykład 2:
    //Wejście: s = "LVIII"
    //Wyjście: 58
    //Wyjaśnienie: L = 50, V= 5, III = 3.

    //Przykład 3:
    //Wejście: s = "MCMXCIV"
    //Wyjście: 1994
    //Wyjaśnienie: M = 1000, CM = 900, XC = 90 and IV = 4.


    public class SolutionAd1B
    {
        public virtual int value(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            if (r == 'C')
                return 100;
            if (r == 'D')
                return 500;
            if (r == 'M')
                return 1000;
            return -1;
        }

        public int RomanToInt(string s)
        {

            int i;
            int n;
            int answer = 0;
            int p = 0;
            n = s.Length - 1;
            for (i = n; i >= 0; i--)
            {
                // p = value(A[i]);
                if (value(s[i]) >= p)
                {
                    answer = answer + value(s[i]);
                }
                else
                {
                    answer = answer - value(s[i]);
                }
                p = value(s[i]);
            }
            return answer;
        }

        class Program
        {
            public static void Main(string[] args)
            {
                SolutionAd1B ob = new SolutionAd1B();
                string str = "MCMX";//1910

                Console.WriteLine("Converted value of {0} is: " + ob.RomanToInt(str), str);
                Console.Read();

            }
        }
    }




    //Znajdź pozycję

    //Mając posortowaną tablicę różnych liczb całkowitych i wartość docelową, zwróć indeks, jeśli cel zostanie znaleziony.Jeśli nie, zwróć indeks tam, gdzie byłby, gdyby został wstawiony w kolejności.

    //Przykład 1:
    //Wejście: nums = [1,3,5,6], target = 5 Wyjście: 2

    //Przykład 2:
    //Wejściet: nums = [1,3,5,6], target = 2 Wyjście: 1

    //Przykład 3:
    //Wejście: nums = [1,3,5,6], target = 7 Wyjście: 4


    public class SolutionB2
    {
        public void Main(string[] args)
        {

            int[] numbers = new int[] { 1, 3, 5, 6 };
            while (true)
            {
                Console.WriteLine("Insert number:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine($"Answer : {SearchInsert(numbers.ToArray(), target)}");
            }
            Console.Read();
        }


        public int SearchInsert(int[] nums, int target)
        {
            int end = nums.Length;
            int begin = -1;
            int answer = 0;
            while (true)
            {
                answer = (begin + end) / 2;
                if (nums[answer] == target)
                {
                    return answer;
                }
                else if (nums[answer] > target)
                {
                    end = answer;
                }
                else
                {
                    begin = (begin + end) / 2;
                }
                if (begin > end)
                {
                    answer = begin;
                    break;
                }
                if (begin == end || end - begin == 1)
                {
                    answer = end;
                    break;
                }
            }
            return answer;
        }
    }


    //Najdłuższy wspólny prefiks

    //Napisz funkcję, która znajdzie najdłuższy wspólny prefiks wśród tablicy ciągów znaków.Jeśli nie ma wspólnego prefiksu, zwróć pusty ciąg „”.

    //Przykład 1:
    //Wejście: strs = ["flower","flow","flight"]
    //    Wyjście: "fl"

    //Przykład 2:
    //Wejście: strs = ["dog","racecar","car"] Wyjście: ""
    //Wyjaśnienie: Nie ma wspólnego przedrostka.


    public class SolutionB3
    {
        public void LongestCommonPrefix(string[] strs)
        {
            Console.WriteLine("Common prefix is");
            returnPrefix();
        }

        public static void returnPrefix()
        {
            String[] InputStrings = new String[3] { "flower", "flow", "flight" };
            //String[] InputStrngs2 = new String[3] { "dog", "racecar", "car" };

            var prefix = InputStrings[0];
            for (int i = 1; i < InputStrings.Length; i++)
            {
                while (InputStrings[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }

                if (prefix=="0")
                {
                    Console.WriteLine("");
                }
            }
            Console.WriteLine(prefix);
            Console.Read();
        }
    }

}
