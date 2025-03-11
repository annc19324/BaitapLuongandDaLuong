using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//6.Viết một chương trình để triển khai một trình
//thu thập dữ liệu web đồng thời thu thập dữ liệu nhiều trang web
//cùng lúc bằng các luồng. 
namespace BaitapLuongandDaLuong
{
    class Bai6_ThuThapDuLieu
    {
        public static void Run()
        {
            string[] urls = { "https://www.facebook.com/", "https://www.instagram.com/" };
            Thread[] threads = new Thread[urls.Length];

            for (int i = 0; i < urls.Length; i++)
            {
                int index = i;
                threads[i] = new Thread(() =>
                {
                    HttpClient client = new HttpClient();
                    string content = client.GetStringAsync(urls[index]).Result;
                    Console.WriteLine($"Nội dung:\n {urls[index]}: {content.Substring(0, 100)}...");
                });
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();
        }

    }
}
