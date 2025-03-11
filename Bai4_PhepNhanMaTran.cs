using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai4_PhepNhanMaTran
    {
        static int[,] A = { { 1, 2 }, { 3, 4 } }; // Ma trận A (2x2)
        static int[,] B = { { 5, 6 }, { 7, 8 } }; // Ma trận B (2x2)
        static int[,] C = new int[2, 2]; // Ma trận kết quả C (2x2)

        public static void Run()
        {
            int rows = A.GetLength(0); // Số hàng của A
            int cols = B.GetLength(1); // Số cột của B

            Thread[,] threads = new Thread[rows, cols]; // Mảng luồng để tính từng phần tử của ma trận C

            // Duyệt từng phần tử của ma trận kết quả C
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int row = i, col = j; // Cần dùng biến local để tránh lỗi capture biến vòng lặp
                    threads[i, j] = new Thread(() =>
                    {
                        C[row, col] = 0;
                        for (int k = 0; k < A.GetLength(1); k++) // Duyệt qua các phần tử hàng của A và cột của B
                        {
                            C[row, col] += A[row, k] * B[k, col];
                        }
                        Console.WriteLine($"Tính xong C[{row},{col}] = {C[row, col]}");
                    });
                    threads[i, j].Start();
                }
            }

            // Chờ tất cả các luồng hoàn thành
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    threads[i, j].Join();

            // In kết quả ma trận C
            Console.WriteLine("\nKết quả nhân ma trận:");
            for (int i = 0; i < rows; i++)
                Console.WriteLine($"{C[i, 0]} {C[i, 1]}");
        }
    }
}
