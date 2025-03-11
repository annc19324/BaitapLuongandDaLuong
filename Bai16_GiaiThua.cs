using System;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai16_GiaiThua
    {
        private static object lockObject = new object();

        public static void Run()
            //16. Viết một chương trình
            //để tính giai thừa của một số bằng nhiều luồng.
        {
            int number = 5;
            long result = 1;

            Parallel.For(1, number + 1, i =>
            {
                lock (lockObject)
                {
                    result *= i; 
                }
            });

            Console.WriteLine($"Giai thừa của {number} là: {result}");
        }
    }
}