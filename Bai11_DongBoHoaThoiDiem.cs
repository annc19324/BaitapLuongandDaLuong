using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai11_DongBoHoaThoiDiem
    {
        // 11. Viết một chương trình để đồng bộ hóa
        // thời điểm bắt đầu và kết thúc của nhiều luồng.

        // Sử dụng Barrier để đồng bộ hóa thời điểm bắt đầu và kết thúc
        // Barrier sẽ đồng bộ hóa nhiều luồng và đảm bảo rằng tất cả các luồng
        // phải chờ nhau tại các điểm đồng bộ được chỉ định.
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
            barrier.SignalAndWait(); 
            Console.WriteLine($"Luồng {Thread.CurrentThread.ManagedThreadId} đang làm việc...");
            barrier.SignalAndWait(); 
            Console.WriteLine($"Luồng {Thread.CurrentThread.ManagedThreadId} đã hoàn thành.");
        }
    }
}
