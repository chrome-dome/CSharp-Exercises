using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Workshop.CSharp.ExercisesA.xAlgExercises1
{
    //    suma dwóch

    //    dodawanie:
    //    składnik + składnik = suma

    //Mając tablicę liczb całkowitych(składników) i sumę, zwróć indeksy dwóch składników tak, aby sumowały się do podanej sumy.
    //Możesz założyć, że każde wejście będzie miało dokładnie jedno rozwiązanie i nie możesz użyć tego samego elementu dwa razy.
    //Odpowiedź możesz zwrócić w dowolnej kolejności.

    //Przykład 1:
    //Wejście: nums = [2, 7, 11, 15], target = 9
    //Wyjście: [0,1]
    //Wyjaśnienie: nums[0] + nums[1] == 9, zwracamy[0, 1].
    //Przykład 2:
    //Wejście: nums = [3, 2, 4], target = 6 Wyjście: [1,2]
    //Przykład 3:
    //Wejście: nums = [3, 3], target = 6 Wyjście: [0,1]


    public class SolutionAd1
    {
        public int[] TwoSum(int[] nums, int target)
        {

            int s1idx = 0;
            int s2idx = 1;
            bool found = false;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                s1idx = i;

                for (var j = i + 1; j < nums.Length; j++)
                {
                    s2idx = j;

                    if (nums[s1idx] + nums[s2idx] == target)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == true)
                {
                    break;
                }
            }

            return found ? new[] { s1idx, s2idx } : Array.Empty<int>();

        }

        public static void Test()
        {
            var ex1 = new SolutionAd1();

            var nums1 = new[] { 2, 7, 11, 15 };
            var target1 = 9;
            var result1 = ex1.TwoSum(nums1, target1);

            Console.WriteLine($"[0,1] == [{string.Join(",", result1)}]");


            var nums2 = new[] { 3, 2, 4 };
            var target2 = 6;
            var result2 = ex1.TwoSum(nums2, target2);

            Console.WriteLine($"[1,2] == [{string.Join(",", result2)}]");

            var nums3 = new[] { 3, 3 };
            var target3 = 6;
            var result3 = ex1.TwoSum(nums3, target3);

            Console.WriteLine($"[0,1] == [{string.Join(",", result3)}]");
        }

    }




    //plus jeden

    //Na wejściu otrzymasz dużą liczbę całkowitą reprezentowaną jako cyfry znajdujące się w tablicy liczb całkowitych, gdzie każda cyfra[i] jest i-tą cyfrą liczby całkowitej.
    //Cyfry są uporządkowane od najbardziej znaczącej do najmniej znaczącej w kolejności od lewej do prawej.Duża liczba całkowita nie zawiera żadnych wiodących zer.
    //Zwiększ dużą liczbę całkowitą o jeden i zwróć wynikową tablicę cyfr.

    //Przykład 1:
    //Wejście: digits = [1, 2, 3]
    //Wyjście: [1,2,4]
    //Wyjaśnienie: Tablica reprezentuje liczbę 123. Inkrementujemy liczbę o 1 co daje: 123 + 1 = 124. Rezultat wygląda następująco[1, 2, 4].

    //Przykład 2:
    //Wejście: digits = [4, 3, 2, 1]
    //Wyjście: [4,3,2,2]
    //Wyjaśnienie: Tablica reprezentuje liczbę 4321. Inkrementujemy liczbę o 1 co daje: 4321 + 1 = 4322. Rezultat wygląda następująco[4, 3, 2, 2].

    //Przykład 3:
    //Wejście: digits = [9]
    //Wyjście: [1,0]
    //Wyjaśnienie: Tablica reprezentuje liczbę 9. Inkrementujemy liczbę o 1 co daje: 9 + 1 = 10. Rezultat wygląda następująco[1, 0].


    public class SolutionAd2
    {
        public int[] PlusOne(int[] digits)
        {

            var result = digits;
            var shouldAddOne = true;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (shouldAddOne)
                {
                    var ud = digits[i] + 1;

                    if (ud > 9)
                    {
                        digits[i] = 0;

                        if (i == digits.Length - 1)
                        {
                            result = new[] { 1 }.Concat(digits).ToArray();
                        }
                    }
                    else
                    {
                        digits[i] = ud;
                        shouldAddOne = false;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;

        }

        public static void Test()
        {
            var ex = new SolutionAd2();

            var digits1 = new[] { 1, 2, 3 };
            var result1 = ex.PlusOne(digits1);

            Console.WriteLine($"[1,2,4] == [{string.Join(",", result1)}]");


            var digits2 = new[] { 4, 3, 2, 1 };
            var result2 = ex.PlusOne(digits2);

            Console.WriteLine($"[4,3,2,2] == [{string.Join(",", result2)}]");

            var digits3 = new[] { 9 };
            var result3 = ex.PlusOne(digits3);

            Console.WriteLine($"[1,0] == [{string.Join(",", result3)}]");
        }

    }



    //trójkąt pascala

    //Na wejściu otrzymasz liczbę całkowitą numRows, na jej podstawie zwróć numRows wierszy z trójkąta Pascala.
    //W trójkącie Pascala każda liczba jest sumą dwóch liczb bezpośrednio nad nią:

    //Przykład 1:
    //Wejście: numRows = 5
    //Wyjście: [[1], [1,1], [1,2,1], [1,3,3,1], [1,4,6,4,1]]
    //Przykład 2:
    //Wejście: numRows = 1 Wyjście: [[1]]


    public class SolutionAd3
    {
        public List<List<int>> Generate(int numRows)
        {
            var result = new List<List<int>>() { new List<int> { 1 } };

            for (int i = 1; i < numRows; i++)
            {
                var row = new List<int>(i);

                for (int j = 0; j <= i; j++)
                {
                    var prevRow = result[result.Count - 1];
                    if (j - 1 < 0 || prevRow.Count <= j)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        var left = prevRow[j - 1];
                        var right = prevRow[j];

                        row.Add(left + right);
                    }

                }

                result.Add(row);
            }

            return result;
        }

        public static void Test()
        {
            var ex = new SolutionAd3();

            var numRows1 = 5;
            var result1 = ex.Generate(numRows1);

            Console.Write($"[[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1],] == [");
            foreach (var row in result1)
            {
                Console.Write($"[{string.Join(",", row)}],");
            }
            Console.WriteLine("]\n");

            var numRows2 = 1;
            var result2 = ex.Generate(numRows2);


            Console.Write($"[[1]] == [");
            foreach (var row in result2)
            {
                Console.Write($"[{string.Join(",", row)}]");
            }
            Console.WriteLine("]");


        }
    }


    //ile liczb jest mniejszych niż aktualna liczba

    //Mając tablicę nums, dla każdego nums[i] sprawdź, ile liczb w tablicy jest od niej mniejszych.Oznacza to, że dla każdej liczby[i] musisz policzyć liczbę prawidłowych j takich, że j != i oraz nums[j] < nums[i].
    //Zwróć odpowiedź w tablicy.

    //Przykład 1:
    //Wejście: nums = [8, 1, 2, 2, 3]
    //Wyjście: [4,0,1,1,3]
    //Wyjaśnienie:
    //Dla nums[0]= 8 istnieją 4 mniejsze liczby niż ona sama (1, 2, 2 i 3). Dla nums[1] = 1 nie istnieje mniejsza liczba.
    //Dla nums[2]= 2 istnieje jedna mniejsza liczba (1).
    //Dla nums[3] = 2 istnieje jedna mniejsza liczba(1).
    //Dla nums[4] = 3 istnieją 3 mniejsze liczby(1, 2 and 2).

    //Przykład 2:
    //Wejście: nums = [6,5,4,8] Wyjście: [2,1,0,3]
    //        Przykład 3:
    //Wejście: nums = [7,7,7,7] Wyjście: [0,0,0,0]


    public class SolutionAd4
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                var left = nums[i];

                for (int j = 0; j < nums.Length; j++)
                {
                    var right = nums[j];
                    if (i != j && left > right)
                    {
                        sum++;
                    }
                }

                result[i] = sum;
            }

            return result;
        }

        public static void Test()
        {
            var ex = new SolutionAd4();

            var result1 = ex.SmallerNumbersThanCurrent(new[] { 8, 1, 2, 2, 3 });

            Console.WriteLine($"[4, 0, 1, 1, 3] = [{string.Join(", ", result1)}]");


            var result2 = ex.SmallerNumbersThanCurrent(new[] { 6, 5, 4, 8 });

            Console.WriteLine($"[2, 1, 0, 3] = [{string.Join(", ", result2)}]");

            var result3 = ex.SmallerNumbersThanCurrent(new[] { 7, 7, 7, 7 });

            Console.WriteLine($"[0, 0, 0, 0] = [{string.Join(", ", result3)}]");
        }
    }


    //pierwszy unikalny znak w łańcuchu

    //Mając łańcuch s, znajdź w nim pierwszy niepowtarzający się znak i zwróć jego indeks.Jeśli nie istnieje, zwróć -1.

    //Przykład 1:
    //Wejście: s = "letmein" Wyjście: 0

    //Przykład 2:
    //Wejście: s = " lifeislovepoem" Wyjście: 2

    //Przykład 3:
    //Wejście: s = "aabb" Wyjście: -1


    public class SolutionAd5
    {
        public int FirstUniqChar(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var isUnique = true;

                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == s[i] && j != i)
                    {
                        isUnique = false;
                        break;
                    }
                }

                if (isUnique)
                {
                    return i;
                }
            }

            return -1;
        }


        public static void Test()
        {
            var ex = new SolutionAd5();

            var result1 = ex.FirstUniqChar("letmein");
            Console.WriteLine($"0 == {result1}");

            var result2 = ex.FirstUniqChar("lifeislovepoem");
            Console.WriteLine($"2 == {result2}");

            var result3 = ex.FirstUniqChar("aabb");
            Console.WriteLine($"-1 == {result3}");
        }
    }


    //jest podciągiem

    //Mając dwa łańcuchy s i t, zwróć true, jeśli s jest podciągiem t, lub false w przeciwnym razie.
    //Podciągiem ciągu nazywamy ciąg, który jest tworzony z oryginalnego ciągu przez usunięcie niektórych(może być żadnych) znaków bez naruszania względnych pozycji pozostałych znaków.
    //(tj. „ace” jest podciągiem „abcde”, podczas gdy „aec” nie jest).

    //Przykład 1:
    //Wejście: s = "abc", t = "ahbgdc" Wyjście: true

    //Przykład 2:
    //Wejście: s = "axc", t = "ahbgdc"
    // Wyjście: false


    public class SolutionAd6
    {
        public bool IsSubsequence(string s, string t)
        {
            var sIdx = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (s[sIdx] == t[i])
                {
                    sIdx++;
                    if (sIdx == s.Length)
                        return true;
                }
            }

            return false;
        }


        public static void Test()
        {
            var ex = new SolutionAd6();

            var result1 = ex.IsSubsequence("abc", "ahbgdc");
            Console.WriteLine($"True == {result1}");

            var result2 = ex.IsSubsequence("axc", "ahbgdc");
            Console.WriteLine($"False == {result2}");
        }
    }


    //liczba kroków aby zmniejszyć liczbę do zera

    //Zwróć liczbę kroków, aby zmniejszyć liczbę do zera.
    //W jednym kroku, jeśli aktualna liczba jest parzysta, musisz podzielić ją przez 2, w przeciwnym razie musisz odjąć od niej 1.

    //Przykład 1:
    //Wejście: num = 14
    //Wyjście: 6
    //Wyjaśnienie:
    //Krok 1) 14 jest parzyste; dzielimy przez 2 otrzymujemy 7. Krok 2) 7 jest nie parzyste; odejmujemy 1 otrzymujemy 6. Krok 3) 6 jest parzyste; dzielimy przez 2 otrzymujemy 3. Krok 4) 3 jest nie parzyste; odejmujemy 1 otrzymujemy 2. Krok 5) 2 jest parzyste; dzielimy przez 2 otrzymujemy 1. Krok 6) 1 jest nie parzyste; odejmujemy 1 otrzymujemy 0.

    //Przykład 2:
    //Wejście: num = 8 Wyjście: 4
    //Przykład 3:
    //Wejście: num = 123 Wyjście: 12

    public class SolutionAd7
    {
        public int NumberOfSteps(int num)
        {
            var numOfSteps = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num--;
                }

                numOfSteps++;
            }

            return numOfSteps;
        }


        public static void Test()
        {
            var ex = new SolutionAd7();

            var result1 = ex.NumberOfSteps(14);
            Console.WriteLine($"6 == {result1}");

            var result2 = ex.NumberOfSteps(8);
            Console.WriteLine($"4 == {result2}");

            var result3 = ex.NumberOfSteps(123);
            Console.WriteLine($"12 == {result3}");
        }
    }


}

