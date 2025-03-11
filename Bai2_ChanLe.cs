using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. Viết một chương trình tạo ra hai luồng để tìm
//và in ra các số chẵn và lẻ từ 1 đến 20. 
namespace BaitapLuongandDaLuong
{
    class Bai2_ChanLe
    {
        public static void Run()
        {
            Thread evenThread = new Thread(() =>
            {
                StringBuilder Sochan = new StringBuilder("Số chẵn: ");
                for (int i = 0; i <= 20; i ++)
                {
                    if(i%2==0)
                    {
                        Sochan.Append(i + " ");
                    }
                }
                Console.WriteLine(Sochan.ToString().Trim());
            });

            Thread oddThread = new Thread(() =>
            {
                StringBuilder oddNumbers = new StringBuilder("Số lẻ: ");
                for (int i = 0; i <= 20; i ++)
                {
                    if(i%2 !=0)
                    {
                        oddNumbers.Append(i + " ");
                    }
                }
                Console.WriteLine(oddNumbers.ToString().Trim());
            });

            evenThread.Start();
            oddThread.Start();

            evenThread.Join();
            oddThread.Join();
        }
    }
}
