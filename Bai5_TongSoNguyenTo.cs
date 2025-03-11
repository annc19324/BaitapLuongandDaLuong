using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//5. Viết một chương trình tính tổng của tất cả các số nguyên tố
//lên đến một giới hạn nhất định bằng nhiều luồng. 
namespace BaitapLuongandDaLuong
{
    class Bai5_TongSoNguyenTo
    {
        public static void Run()
        {
            int limit = 100;
            int sum = 0;
            object lockObj = new object();

            Thread evenThread = new Thread(() =>
            {
                for (int i = 2; i <= limit; i += 2)
                {
                    if (IsPrime(i))
                    {
                        lock (lockObj) sum += i;
                    }
                }
            });

            Thread oddThread = new Thread(() =>
            {
                for (int i = 3; i <= limit; i += 2)
                {
                    if (IsPrime(i))
                    {
                        lock (lockObj) sum += i;
                    }
                }
            });

            evenThread.Start();
            oddThread.Start();

            evenThread.Join();
            oddThread.Join();

            Console.WriteLine($"Tổng số nguyên tố: {sum}");
        }

        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
