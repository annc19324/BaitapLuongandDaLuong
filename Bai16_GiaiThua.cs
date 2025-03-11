using System;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai16_GiaiThua
    {
        public static void Run()
        {
            int number = 5;
            long result = 1;

            Parallel.For(1, number + 1, i =>
            {
                Interlocked.Multiply(ref result, i); // Đảm bảo tính toán an toàn với nhiều luồng
            });

            Console.WriteLine($"Giai thừa của {number} là: {result}");
        }
    }
}