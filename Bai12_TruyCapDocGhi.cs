using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai12_TruyCapDocGhi
    {
        private static int sharedResource = 0;
        private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        public static void Run()
        {
            Thread writer = new Thread(Write);
            Thread reader = new Thread(Read);

            writer.Start();
            reader.Start();

            writer.Join();
            reader.Join();
        }

        private static void Write()
        {
            for (int i = 0; i < 10; i++)
            {
                rwLock.EnterWriteLock();
                sharedResource = i;
                Console.WriteLine($"Ghi: {i}");
                rwLock.ExitWriteLock();
                Thread.Sleep(100);
            }
        }

        private static void Read()
        {
            for (int i = 0; i < 10; i++)
            {
                rwLock.EnterReadLock();
                Console.WriteLine($"Đọc: {sharedResource}");
                rwLock.ExitReadLock();
                Thread.Sleep(100);
            }
        }
    }
}