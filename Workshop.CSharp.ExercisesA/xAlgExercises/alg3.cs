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

        class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        class MergeTwoList
        {
            static void Main(string[] args)
            {
                ListNode l1 = new ListNode();
                l1.val = 1;
                l1.next = new ListNode(2, new ListNode(4, null));

                ListNode l2 = new ListNode();
                l2.val = 1;
                l2.next = new ListNode(3, new ListNode(4, null));
                var recOutput = MergeTwoLinkedList(l1, l2);
                while (recOutput != null)
                {
                    Console.WriteLine(recOutput.val);
                    recOutput = recOutput.next;
                }
                Console.WriteLine();
                var output = MergeTwoLists(l1, l2);
                while (output != null)
                {
                    Console.WriteLine(output.val);
                    output = output.next;
                }
            }

             static ListNode MergeTwoLinkedList(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val < l2.val)
                return new ListNode(l1.val, MergeTwoLinkedList(l1.next, l2));
            else
                return new ListNode(l2.val, MergeTwoLinkedList(l1, l2.next));
        }

            static ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                ListNode output = new ListNode();
                ListNode current = output;
                while (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        current.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        current.next = l2;
                        l2 = l2.next;
                    }
                    current = current.next;
                }

                current.next = l1 == null ? l2 : l1;
                return output.next;
            }
        }

        //public IEnumerable<int> MergeTwoLists(List<int> list1, List<int> list2) {
        //    ???????????????
        //}

    }

}

