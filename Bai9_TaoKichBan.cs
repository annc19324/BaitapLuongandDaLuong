using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//9. Viết một chương trình để tạo một kịch bản nhà sản xuất
//-người tiêu dùng bằng cách sử dụng các phương thức wait()
//và notify() để đồng bộ hóa luồng. 
namespace BaitapLuongandDaLuong
{
    class Bai9_TaoKichBan
    {
        public static void Run()
        {
            Queue<int> queue = new Queue<int>();
            object lockObj = new object();

            Thread producer = new Thread(() =>
            {
                lock (lockObj)
                {
                    queue.Enqueue(new Random().Next(10));
                    Console.WriteLine("Sản xuất sản phẩm");
                    Monitor.Pulse(lockObj);
                }
            });

            Thread consumer = new Thread(() =>
            {
                lock (lockObj)
                {
                    while (queue.Count == 0) Monitor.Wait(lockObj);
                    Console.WriteLine($"Tiêu thụ sản phẩm: {queue.Dequeue()}");
                }
            });

            producer.Start();       
            consumer.Start();

            producer.Join();
            consumer.Join();
        }
    }
}
