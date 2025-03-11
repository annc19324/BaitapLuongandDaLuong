using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai13_InTenLuong
    {
        public static void Run()
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(PrintThreadName);
                threads[i].Name = $"Luồng {i + 1}";
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        private static void PrintThreadName()
        {
            Console.WriteLine($"Tên luồng: {Thread.CurrentThread.Name}");
        }
    }
}