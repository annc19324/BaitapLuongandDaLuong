using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BaitapLuongandDaLuong
{
    class Bai19_YeuCauHTTP
    {
        public static void Run()
        {
            //19.Viết một chương trình thực hiện các yêu cầu HTTP đồng thời bằng luồng.
            string[] urls = { "https://facebook.com", "https://youtube.com", "https://instagram.com" };

            Parallel.ForEach(urls, url =>
            {
                HttpClient client = new HttpClient();
                string content = client.GetStringAsync(url).Result;
                Console.WriteLine($"Dữ liệu từ {url}: {content.Length} ký tự");
            });
        }
    }
}