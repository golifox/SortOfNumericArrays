using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    class ArraySort
    {
        public ArraySort() //конструктор
        {
        }
        public int[] a;
        private static void swap(ref int x, ref int y)
        {
            int temp = x; x = y; y = temp;
        }
        public void SelectSort(int[] a, ref int sr, ref int obm)
        {
            int max;
            int length = a.Length;
            for (int i = 0; i < length - 1; i++)
            {
                max = i;
                for (int j = i + 1; j < length; j++)
                {
                    sr++;
                    if (a[j] > a[max])
                    {
                        max = j;
                    }
                }
                sr++;
                if (max != i)
                {
                    swap(ref a[i], ref a[max]);
                    obm++;
                }
            }
        }
        public void InsertSort(int[] a, ref int sr, ref int obm)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int cur = a[i];
                int j = i;
                while (j > 0 && cur > a[j - 1])
                {
                    sr++;
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = cur;
            }
            sr++;
        }
        public void BubbleSort(int[] a, ref int sr, ref int obm)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    sr++;
                    if (a[j] < a[j + 1])
                    {

                        swap(ref a[j], ref a[j + 1]);
                        obm++;
                    }
                }
            }
        }

        public void quicksort(int[] array, int start, int end, ref int sr, ref int obm) //БЫСТРАЯ СОРТИРОВКА
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end, ref sr, ref obm);
            quicksort(array, start, pivot - 1, ref sr, ref obm);
            quicksort(array, pivot + 1, end, ref sr, ref obm);
        }

        int partition(int[] array, int start, int end, ref int sr, ref int obm)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                sr++;
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                    obm++;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }


        public void RSort(int[] arr, ref int sr, ref int obm) //РЕКУРСИВНАЯ СОРТИРОВКА ВЫБОРОМ
        {
            Sort(arr, 0, ref sr, ref obm);
        }

        void Sort(int[] arr, int start, ref int sr, ref int obm)
        {
            if (start == arr.Length)
                return;

            int min = start;
            for (int i = start + 1; i < arr.Length; i++)
            {
                sr++;
                if (arr[i] < arr[min])
                {
                    min = i;
                    obm++;
                }
            }


            int tmp = arr[start];
            arr[start] = arr[min];
            arr[min] = tmp;
            obm++;

            Sort(arr, start + 1, ref sr, ref obm);
        }
    }
}