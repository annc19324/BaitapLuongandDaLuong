using System;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai17_MergeSort
    {
        public static void Run()
            //Viết một chương trình để triển khai
            //thuật toán sắp xếp hợp nhất(merge sort) đa luồng.
        {
            int[] arr = { 5, 3, 8, 1, 9, 2 };
            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine("Mảng sau khi sắp xếp:");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                Parallel.Invoke(
                    () => MergeSort(arr, left, mid),
                    () => MergeSort(arr, mid + 1, right)
                );

                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            while (i <= mid)
                temp[k++] = arr[i++];

            while (j <= right)
                temp[k++] = arr[j++];

            for (i = left, k = 0; i <= right; i++, k++)
                arr[i] = temp[k];
        }
    }
}