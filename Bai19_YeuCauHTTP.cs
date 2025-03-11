using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai19_YeuCauHTTP
    {
        public static void Run()
        {
            string[] urls = { "https://example.com", "https://example.org", "https://example.net" };

            Parallel.ForEach(urls, url =>
            {
                HttpClient client = new HttpClient();
                string content = client.GetStringAsync(url).Result;
                Console.WriteLine($"Dữ liệu từ {url}: {content.Length} ký tự");
            });
        }
    }
}