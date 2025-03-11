using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai11_DongBoHoaThoiDiem
    {
        private static Barrier barrier = new Barrier(3);

        public static void Run()
        {
            Thread thread1 = new Thread(DoWork);
            Thread thread2 = new Thread(DoWork);
            Thread thread3 = new Thread(DoWork);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
        }

        private static void DoWork()
        {
            Console.WriteLine($"Luồng {Thread.CurrentThread.ManagedThreadId} đang chuẩn bị...");
            barrier.SignalAndWait(); // Đồng bộ hóa thời điểm bắt đầu
            Console.WriteLine($"Luồng {Thread.CurrentThread.ManagedThreadId} đang làm việc...");
            barrier.SignalAndWait(); // Đồng bộ hóa thời điểm kết thúc
            Console.WriteLine($"Luồng {Thread.CurrentThread.ManagedThreadId} đã hoàn thành.");
        }
    }
}