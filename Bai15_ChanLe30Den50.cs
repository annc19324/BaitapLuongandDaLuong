using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai15_ChanLe30Den50
    {
        public static void Run()
        {
            //15.Viết một chương trình tạo hai luồng
            //để tìm và in các số chẵn và lẻ từ 30 đến 50.
            Thread evenThread = new Thread(() =>
            {
                for (int i = 30; i <= 50; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine($"Số chẵn: {i}");
                }
            });

            Thread oddThread = new Thread(() =>
            {
                for (int i = 30; i <= 50; i++)
                {
                    if (i % 2 != 0)
                        Console.WriteLine($"Số lẻ: {i}");
                }
            });

            evenThread.Start();
            oddThread.Start();

            evenThread.Join();
            oddThread.Join();
        }
    }
}