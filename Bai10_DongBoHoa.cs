using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai10_DongBoHoa
    {
        private static int sharedResource = 0;
        private static object lockObject = new object();

        public static void Run()
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(AccessResource);
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Giá trị cuối cùng của tài nguyên chia sẻ: {sharedResource}");
        }

        private static void AccessResource()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (lockObject)
                {
                    sharedResource++;
                }
            }
        }
    }
}