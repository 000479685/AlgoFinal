// See https://aka.ms/new-console-template for more information
using System.Security.AccessControl;

namespace AlgoFinal
{
    //AIDEN WU 000479685

    public unsafe class SingleLinkedListIntNode
    {
        public SingleLinkedListIntNode* next { get; set; }
        public int value;        

        public SingleLinkedListIntNode(int i)
        {
            value = i;
        }

        public unsafe void SetNext(SingleLinkedListIntNode* target)
        {
            next = target; 
        }
    }    

    public class Program
    {
        //QUESTION 1
        public static int ReverseInteger(int insertedInt)
        {            
            bool flag = insertedInt > 0;

            int temp = flag ? insertedInt : -1 * insertedInt;

            int final = 0;

            while (temp != 0)
            {
                int remainder = temp % 10;
                final = final * 10 + remainder;
                temp = (temp - remainder) / 10;
            }

            return final * (flag ? 1 : -1);
        }

        //QUESTION 2
        public static int FindTargetIndex(int[] insertedIntArr, int targetInt)
        {
            if(insertedIntArr.Contains(targetInt))
            {
                return Array.IndexOf(insertedIntArr, targetInt);
            }
            else
            {
                int left = 0;
                int right = insertedIntArr.Length - 1;
                

                while (true)
                {
                    int middle = (left + right) / 2;                                                          

                    if (insertedIntArr[middle] < targetInt)
                    {
                        //Potential failure case if the search already reached the end of the array somehow
                        if(middle == insertedIntArr.Length - 1)
                        {
                            return middle;
                        }

                        if (insertedIntArr[middle + 1] > targetInt)
                        {
                            return middle + 1;
                        }
                        left = middle + 1;                        
                    }
                    // When the middle number is greater
                    else
                    {
                        //Potential failure case if the search reached the bottom of the array somehow
                        if(middle == 0)
                        {
                            return middle;
                        }

                        if (insertedIntArr[middle - 1] > targetInt)
                        {
                            return middle;
                        }

                        right = middle - 1;
                        
                    }
                }
            }                        
        }

        //QUESTION 3
        public static unsafe void DeleteNodeOfLinkedList(ref SingleLinkedListIntNode target)
        {            
            target = *target.next;            
        }

        //QUESTION 4        
        public static int FindSmallestDuplicateInArray(int[] targetArr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int item in targetArr)
            {
                if (map.ContainsKey(item))
                {
                    map[item] += 1;
                }
                else
                {
                    map[item] = 1;
                }
            }
            

            int[] duplicatesOnly = map.Keys.Where(c => map[c] > 1).ToArray();
            Array.Sort(duplicatesOnly);
            return duplicatesOnly[0];
        }

        public static unsafe void Main(string[] args)
        {
            Console.WriteLine("====== Algo Final ======");
            Console.WriteLine("\n====== Question 1 ======\n REVERSE INTEGER");
            int q1Input1 = 123;
            int q1Input2 = -456;
            Console.WriteLine($"Input : {q1Input1} | Output : {ReverseInteger(q1Input1)}");
            Console.WriteLine($"Input : {q1Input2} | Output : {ReverseInteger(q1Input2)}");            

            Console.WriteLine("\n====== Question 2 ======\n FIND TARGET INTENDED INDEX");
            int[] q2Input1 = { 1, 3, 5, 6 };

            Console.WriteLine($"Input : [ {String.Join(", ", q2Input1)} ], 5 | Output : {FindTargetIndex(q2Input1, 5)}");
            Console.WriteLine($"Input : [ {String.Join(", ", q2Input1)} ], 2 | Output : {FindTargetIndex(q2Input1, 2)}");                       

            Console.WriteLine("\n====== Question 3 ======");
            SingleLinkedListIntNode q3Node1 = new SingleLinkedListIntNode(4);
            SingleLinkedListIntNode q3Node2 = new SingleLinkedListIntNode(5);
            SingleLinkedListIntNode q3Node3 = new SingleLinkedListIntNode(1);
            SingleLinkedListIntNode q3Node4 = new SingleLinkedListIntNode(9);            

            q3Node1.SetNext(&q3Node2);
            q3Node2.SetNext(&q3Node3);
            q3Node3.SetNext(&q3Node4);

            SingleLinkedListIntNode head = q3Node1;
            while (true)
            {
                Console.WriteLine(head.value);

                if(head.next == null)
                {
                    break;
                }

                head = *head.next;
            }

            Console.WriteLine("----");
            DeleteNodeOfLinkedList(ref q3Node2);
            head = q3Node1;
            while (true)
            {
                Console.WriteLine(head.value);

                if (head.next == null)
                {
                    break;
                }

                head = *head.next;
            }

            SingleLinkedListIntNode q3Node5 = new SingleLinkedListIntNode(4);
            SingleLinkedListIntNode q3Node6 = new SingleLinkedListIntNode(5);
            SingleLinkedListIntNode q3Node7 = new SingleLinkedListIntNode(1);
            SingleLinkedListIntNode q3Node8 = new SingleLinkedListIntNode(9);

            q3Node5.SetNext(&q3Node6);
            q3Node6.SetNext(&q3Node7);
            q3Node7.SetNext(&q3Node8);


            Console.WriteLine("----");
            head = q3Node5;
            while (true)
            {
                Console.WriteLine(head.value);

                if (head.next == null)
                {
                    break;
                }

                head = *head.next;
            }

            Console.WriteLine("----");
            DeleteNodeOfLinkedList(ref q3Node5);
            head = q3Node5;
            while (true)
            {
                Console.WriteLine(head.value);

                if (head.next == null)
                {
                    break;
                }

                head = *head.next;
            }

            Console.WriteLine("\n====== Question 4 ======");
            int[] q4Arr1 = { 4, 10, 5, 1, 11, 5, 1, 4, 1 };
            int[] q4Arr2 = {1,10,1,-1,10,-1};

            Console.WriteLine(FindSmallestDuplicateInArray(q4Arr1));
            Console.WriteLine(FindSmallestDuplicateInArray(q4Arr2));

            /*
             * MULTIPLE CHOICE
             * 
             * Which type of search is efficient on a sorted array?
             * B) Binary Search
             * 
             * What is the time complexity of inserting a new node at the beginning of a singly linked list?
             * A) O(1)
             * 
             * In a binary search tree (BST), the left child of a node is always:
             * B) Smaller than the node
             * 
             * Which traversal of a BST visits nodes in ascending order?
             * A) Pre-order
             * 
             * In a doubly linked list, what does the prev pointer in the first node point to?
             * B) Null
             */
        }
    }
}