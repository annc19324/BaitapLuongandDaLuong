using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. Viết một chương trình để tạo một luồng cơ bản
//in ra "Hello, World!" khi được thực thi.
namespace BaitapLuongandDaLuong
{
    class Bai1_HelloWord
    {
        public static void Run()
        {
            Thread thread = new Thread(() => 
            Console.WriteLine("Hello, World!")); // thực thi hành động 
            thread.Start(); // kích hoạt luồng thread 
            thread.Join();
        }
    }
}
