using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//8. Viết một chương trình để tạo và bắt đầu nhiều luồng
//tăng biến đếm được chia sẻ đồng thời.
namespace BaitapLuongandDaLuong
{
    class Bai8_LuongTangBien
    {
        private static int counter = 0;

        public static void Run()
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(() =>
                {
                    counter++;
                });
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();
            Console.WriteLine($"Giá trị cuối cùng của counter: {counter}");
        }
    }
}
