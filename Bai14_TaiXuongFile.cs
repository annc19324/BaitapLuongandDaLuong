using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai14_TaiXuongFile
    {
        public static void Run()
        {
            string[] urls = { "https://example.com/file1.txt", "https://example.com/file2.txt" };

            Parallel.ForEach(urls, url =>
            {
                HttpClient client = new HttpClient();
                byte[] data = client.GetByteArrayAsync(url).Result;
                Console.WriteLine($"Đã tải xuống {url} - {data.Length} bytes");
            });
        }
    }
}