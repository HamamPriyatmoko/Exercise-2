using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    class Program
    {
        int[] arr = new int[20];
        int cmp_count = 0;
        int mov_count = 0;
        int i ;


        int n;

        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array :");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                    break;
                else
                    Console.WriteLine("\nArray can have maximum 20 elements");
            }
            Console.WriteLine("\n==========================");
            Console.WriteLine("Enter array elements");
            Console.WriteLine("\n==========================");

            //get array elements
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
        }

        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        public void q_sort(int low, int high)
        {
            char ch;
            do
            {
                int pivot, i, hp;
                if (low > high)
                    return;

                //Partition the list into two parts:
                // one containing elements less that or equal to pivot
                // outher containning elements greather than pivot
                i = low + 1;
                hp = high;

                pivot = arr[low];

                while (i <= hp)
                {
                    //Search for an element greater than pivot
                    while ((arr[i] <= pivot) && (i <= high))
                    {
                        i++;
                        cmp_count++;
                    }
                    cmp_count++;

                    //Search for an element lens than or equal to pivot
                    while ((arr[hp] > pivot) && (i >= low))
                    {
                        hp--;
                        cmp_count++;
                    }
                    cmp_count++;

                    //Search forn an element less than or equal to pivot
                    if (i < hp) // if the greater element is on the left of the element
                    {
                        //Swap the element at index i with the element at index j
                        swap(i, j);
                        mov_count++;
                    }
                }
                if (low < j)
                {
                    swap(low, j);
                    mov_count++;
                }
                // sort the list on the left of the pivot using quick sort
                q_sort(low, j - 1);

                //Sort the list on the right of pivot using quick sort
                q_sort(j + 1, high);
                ch = char.Parse(Console.ReadLine().ToUpper());
            } while ((ch == 'y'));
        }
        int getSize()
        {
            return n;
        }

        void BinarySearch()
        {
            char ch;
            do
            {
                //accept the number to be searched
                Console.Write("\nEnter the element you want to search : ");
                int item = Convert.ToInt32(Console.ReadLine());

                //apply binary search
                int lowerbound = 0;
                int upperbound = 0;

                //obtain the index of the middle element
                int mid = (lowerbound + upperbound) / 2;
                int ctr = 1;

                //loop to search for the element in the array 
                while ((item != arr[mid]) && (ctr <= upperbound))
                {
                    if (item == arr[mid])
                        lowerbound = mid + 1;
                    else
                        upperbound = mid - 1;
                    mid = (lowerbound + upperbound) / 2;
                    ctr++;
                }
                if (item == arr[mid])
                    Console.WriteLine("\n" + item.ToString() + "found at position" + (mid + 1).ToString());
                else
                    Console.WriteLine("\n" + item.ToString() + " Not found in the array\n");
                Console.WriteLine("\nNumber of comparasion : " + ctr);

                Console.Write("\nContinur search (y/n): ");
                ch = char.Parse(Console.ReadLine().ToUpper());
            } while ((ch == 'y'));
        }
        static void Main(string[] args)
        {
            Program mylist = new Program();
            int pilihanmenu;
            char ch;
            do
            {
                do
                {
                    Console.WriteLine("Menu Option");
                    Console.WriteLine("==================");
                    Console.WriteLine("1. binary search");
                    Console.WriteLine("2. q_sort");
                    Console.WriteLine("3. exit");
                    Console.WriteLine("Enter your choice (1,2,3) : ");
                    pilihanmenu = Convert.ToInt32(Console.ReadLine());
                    switch (pilihanmenu)
                    {
                        case 1:
                            Console.WriteLine("");
                            Console.WriteLine("....................");
                            Console.WriteLine("Binary Search");
                            Console.WriteLine("....................");
                            mylist.input();
                            mylist.BinarySearch();
                            break;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("....................");
                            Console.WriteLine("q_sort ");
                            Console.WriteLine("....................");
                            mylist.input();
                            mylist.q_sort();
                            break;
                        case 3:
                            Console.WriteLine("Exit");
                            break;
                    }
                    Console.WriteLine("\nPilih menu lagi? (y/n): ");
                    ch = char.Parse(Console.ReadLine().ToLower());
                    Console.Clear();
                } while (ch == 'y');
                //to exit from the console
                Console.WriteLine("\n\nPress return to exit. ");
                Console.ReadLine();
            } while (pilihanmenu != 3);
        }
    }

}