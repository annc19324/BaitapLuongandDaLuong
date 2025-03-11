using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 4. Viết một chương trình thực hiện phép nhân ma trận bằng nhiều luồng. 
namespace BaitapLuongandDaLuong
{
    class Bai4_PhepNhanMaTran
    {
        static int[,] A = { { 1, 2 }, { 3, 4 } };
        static int[,] B = { { 5, 6 }, { 7, 8 } };
        static int[,] C = new int[2, 2];

        public static void Run()
        {
            Thread[] threads = new Thread[2];

            for (int i = 0; i < 2; i++)
            {
                int row = i;
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 2; j++)
                    {
                        C[row, j] = 0;
                        for (int k = 0; k < 2; k++)
                            C[row, j] += A[row, k] * B[k, j];
                    }
                });
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();

            Console.WriteLine("Kết quả nhân ma trận:");
            for (int i = 0; i < 2; i++)
                Console.WriteLine($"{C[i, 0]} {C[i, 1]}");
        }
    }
}
