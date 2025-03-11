using System;
using System.Linq;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai3_SapXep
    {
        static int[] array = { 9, 3, 5, 1, 8, 2, 4, 6, 7, 0 };

        public static void Run()
        {
            int mid = array.Length / 2;  // Xác định vị trí giữa của mảng
            int[] left = array.Take(mid).ToArray();   // Lấy nửa đầu mảng
            int[] right = array.Skip(mid).ToArray();  // Lấy nửa sau mảng

            // Luồng 1: Sắp xếp nửa đầu của mảng
            Thread leftThread = new Thread(() =>
            {
                Console.WriteLine("Bắt đầu sắp xếp nửa đầu mảng...");
                Array.Sort(left);
                Console.WriteLine("Nửa đầu đã sắp xếp: " + string.Join(", ", left));
            });

            // Luồng 2: Sắp xếp nửa sau của mảng
            Thread rightThread = new Thread(() =>
            {
                Console.WriteLine("Bắt đầu sắp xếp nửa sau mảng...");
                Array.Sort(right);
                Console.WriteLine("Nửa sau đã sắp xếp: " + string.Join(", ", right));
            });

            // Bắt đầu chạy hai luồng
            leftThread.Start();
            rightThread.Start();

            // Chờ cả hai luồng hoàn thành
            leftThread.Join();
            rightThread.Join();

            // Gộp hai mảng đã sắp xếp
            array = Merge(left, right);

            Console.WriteLine("Mảng sau khi sắp xếp: " + string.Join(", ", array));
        }

        // Hàm trộn hai mảng đã sắp xếp
        static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                merged[k++] = (left[i] < right[j]) ? left[i++] : right[j++];
            }

            while (i < left.Length) merged[k++] = left[i++];
            while (j < right.Length) merged[k++] = right[j++];

            return merged;
        }
    }
}
