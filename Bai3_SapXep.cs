using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//3. Viết một chương trình sắp xếp một mảng các số nguyên bằng nhiều luồng. 
namespace BaitapLuongandDaLuong
{
    class Bai3_SapXep
    {
        static int[] array = { 9, 3, 5, 1, 8, 2, 4, 6, 7, 0 };

        public static void Run()
        {
            Thread sortThread = new Thread(() =>
            {
                Array.Sort(array);
            });

            sortThread.Start();
            sortThread.Join();

            Console.WriteLine("Mảng sau khi sắp xếp: " + string.Join(", ", array));
        }
    }
}
