using System;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai18_QuickSort
    {
        public static void Run()
        {
            int[] arr = { 5, 3, 8, 1, 9, 2 };
            QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Mảng sau khi sắp xếp:");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                Parallel.Invoke(
                    () => QuickSort(arr, left, pivot - 1),
                    () => QuickSort(arr, pivot + 1, right)
                );
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }

            Swap(ref arr[i + 1], ref arr[right]);
            return i + 1;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}