using System;
using NUnit.Framework.Internal;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Workshop.CSharp.ExercisesA.xAlgExercises3
{

    //Usuń element

    //Mając tablicę liczb całkowitych nums i liczbę całkowitą val, usuń wszystkie wystąpienia val w tablicy nums.
    //Względna kolejność elementów może ulec zmianie.
    //Ponieważ nie jest możliwa zmiana długości, umieścić wynik w pierwszej części tablicy nums.
    //Bardziej formalnie, jeśli po usunięciu duplikatów jest k elementów, to pierwsze k elementów liczb powinno zawierać wynik końcowy.

    //Przykład 1:
    //Wejście: nums = [3, 2, 2, 3], val = 3 Wyjście: 2, nums = [2, 2, _, _]
    //Wyjaśnienie: Metoda powinna zwrócić ilość pozostałych elementów, k = 2, tablica po wypisaniu powinna zawierać dwa elementy ‘2’ na początku tablicy.
    //Nie ma znaczenia co będzie w pozostałych elementach.

    //Przykład 2:
    //Wejście: nums = [0, 1, 2, 2, 3, 0, 4, 2], val = 2 Wyjście: 5, nums = [0, 1, 4, 0, 3, _, _, _]
    //Wyjaśnienie: Metoda powinna zwrócić ilość pozostałych elementów k = 5, tablica po wypisaniu powinna zawierać pięć elementów 0, 0, 1, 3, and 4. (kolejność nie ma znaczenia)
    //Nie ma znaczenia co będzie w pozostałych elementach.


 public class SolutionC
    {
        public void Main(string[] args)
        {
            int[] array = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };


            RemoveElement(array, 2);
        }


        public int RemoveElement(int[] nums, int val) {

            int l = nums.Length;
            int k = 0;
            for (int i = 0; i < l; i++)
            {
                if (nums[i] != val)
                {
                    if (i != k)
                        nums[k] = nums[i];
                    k++;
                }
                else if (i + 1 < l && nums[i + 1] != val)
                    nums[k] = nums[i + 1];
            }
            return k;
        }
    }


    //Usuń duplikaty z posortowanej tablicy

    //Mając tablicę posortowanych liczb całkowitych nums w kolejności rosnącej, usuń duplikaty, tak aby każdy unikalny element pojawiał się tylko raz.Względna kolejność elementów powinna być taka sama.
    //Ponieważ nie jest możliwa zmiana długości tablicy należy umieścić wynik w pierwszej części tablicy nums.Bardziej formalnie, jeśli po usunięciu duplikatów jest k elementów, to pierwsze k elementów z nums powinno zawierać wynik końcowy.Nie ma znaczenia, co zostawisz poza pierwszymi
    //  k elementami.
    //Zwróć k po umieszczeniu wyniku końcowego w pierwszych k polach liczb.

    //Przykład 1:
    //Wejście: nums = [1, 1, 2] Wyjście: 2, nums = [1, 2, _]
    //Wyjaśnienie: Metoda powinna zwrócić ilość pozostałych elementów, k = 2, tablica po wypisaniu powinna zawierać dwa wynikowe elementy na początku tablicy.
    //Nie ma znaczenia co będzie w pozostałych elementach.

    //Przykład 2:
    //Wejście: nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4] Wyjście: 5, nums = [0, 1, 2, 3, 4, _, _, _, _, _]
    //Wyjaśnienie: Metoda powinna zwrócić ilosć pozostałych elementów, k = 5, tablica po wypisaniu powinna zawierać pięć wynikowych elementów na początku tablicy, odpowiednio 0, 1, 2, 3 i 4.
    //Nie ma znaczenia co będzie w pozostałych elementach.


 public class SolutionC2
    {
        public int RemoveDuplicates(int[] nums) {

            if (nums.Length == 0)
            {
                return 0;
            }

              var count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    count++;
                    nums[count - 1] = nums[i];
                }
            }

            return count;
        }
        
    }


    //Połącz dwie posortowane listy

    //Połącz dwie listy w jedną posortowaną listę.

    //Przykład 1:
    //Wejście: list1 = [1,2,4], list2 = [1,3,4] Wyjście: [1,1,2,3,4,4]

    //    Przykład 2:
    //Wejście: list1 = [], list2 = [] Wyjście: []

    //    Przykład 3:
    //Wejście: list1 = [], list2 = [0] Wyjście: [0]


    public class SolutionC3
    {

        public IEnumerable<int> MergeTwoLists(List<int> list1, List<int> list2)
        {
            return list1;
            //??????????????????????
        }
    }



}

