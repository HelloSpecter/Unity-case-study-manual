using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 常用排序巩固__0413
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] arr0 = new int[5] { 1, 4, 2, 8, 5 };
            program.Print(arr0);

            int[] arr = (int[])arr0.Clone();
            program.BubbleSort(arr);
            Console.WriteLine("BubbleSort");
            program.Print(arr);

            arr = (int[])arr0.Clone();
            program.QuickSort1(arr);
            Console.WriteLine("QuickSort1");
            program.Print(arr);

            arr = (int[])arr0.Clone();
            program.QuickSort2(arr);
            Console.WriteLine("QuickSort2");
            program.Print(arr);

            arr = (int[])arr0.Clone();
            program.HeapSort(arr);
            Console.WriteLine("HeapSort");
            program.Print(arr);


            Console.ReadKey();
        }

        public void Print(int[] arr)
        {
            Console.WriteLine("arr is : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        public void Swap(int[] arr, int i, int j)
        {
            int temp;
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public void BubbleSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }
            bool isSwap = false;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                        isSwap = true;
                    }
                }
                if (!isSwap)
                {
                    break;
                }
            }
        }


        /// <summary>
        /// Normal
        /// </summary>
        /// <param name="arr"></param>
        public void QuickSort1(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }

            quickSort1(arr, 0, arr.Length - 1);

        }

        private void quickSort1(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int middle;
            middle = partition(arr, start, end);
            quickSort1(arr, start, middle - 1);
            quickSort1(arr, middle + 1, end);


        }

        private int partition(int[] arr, int start, int end)
        {
            int piv = arr[start];
            int lt = start + 1;
            int rt = end;
            while (lt < rt)
            {
                while (lt < rt && arr[lt] <= piv)
                {
                    lt++;
                }
                while (lt < rt && arr[rt] >= piv)
                {
                    rt--;
                }
                if (lt < rt)
                {
                    Swap(arr, lt, rt);
                    lt++;
                    rt--;
                }
            }
            if (lt == rt && arr[rt] > piv)
            {
                rt--;
            }
            Swap(arr, rt, start);
            return rt;
        }

        /// <summary>
        /// 3向切分
        /// </summary>
        /// <param name="arr"></param>
        public void QuickSort2(int[] arr)
        {
            if (arr.Length<=1)
            {
                return;
            }
            quickSort2(arr, 0, arr.Length - 1);
        }

        private void quickSort2(int[] arr, int start, int end)
        {
            if (start>=end)
            {
                return;
            }
            int lt, rt;
            partition3way(arr, start, end, out lt, out rt);
            quickSort2(arr, start, lt - 1);
            quickSort2(arr, rt + 1, end);


        }

        private void partition3way(int[] arr, int start, int end,out int lt , out int rt)
        {
            lt = start;
            rt = end;
            int i = start + 1;
            int piv = arr[start];
            while (i<=rt)
            {
                if (arr[i]<piv)
                {
                    Swap(arr, i, lt);
                    lt++;
                    i++;
                }
                else if(arr[i]>piv)
                {
                    Swap(arr, i, rt);
                    rt--;
                }
                else
                {
                    i++;
                }
            }

        }



        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="arr"></param>
        public void HeapSort(int[] arr)
        {
            buildHeap(arr);
            for (int i = arr.Length-1; i >0 ; i--)
            {
                Swap(arr, 0, i);
                maxHeap(arr, 0, i);
            }
        }
        private void buildHeap(int[] arr)
        {
            for (int i = arr.Length/2 -1; i >= 0; i--)
            {
                maxHeap(arr, i, arr.Length);
            }
        }
        private void maxHeap(int[] arr,int root,int size)
        {
            int lt = 2 * root + 1;
            int rt = lt + 1;
            int max = root;
            if (rt < size&&arr[rt]>arr[max])
            {
                max = rt;
            }
            if (lt < size&&arr[lt]>arr[max])
            {
                max = lt;
            }
            if (max!=root)
            {
                Swap(arr, max, root);
                maxHeap(arr, max, size);
            }
        }
    }
}
