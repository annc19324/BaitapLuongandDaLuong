using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;

namespace BaitapLuongandDaLuong
{
    class Bai14_TaiXuongFile
    {
        public static void Run()
        {
            //14.Viết một chương trình để tải xuống nhiều tệp đồng thời bằng luồng. 
            string[] urls = {
                "https://images.unsplash.com/photo-1506744038136-46273834b3fb",
                "https://images.unsplash.com/photo-1470071459604-3b5ec3a7fe05"
            };

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath); 
            }

            // Sử dụng Parallel.ForEach để tải tệp đồng thời từ mỗi URL trong mảng
            Parallel.ForEach(urls, url =>
            {
                try
                {
                    HttpClient client = new HttpClient();
                    // Tải tệp từ URL dưới dạng mảng byte (dữ liệu nhị phân)
                    byte[] data = client.GetByteArrayAsync(url).Result;
                    string fileName = Path.GetFileName(url);

                    string filePath = Path.Combine(directoryPath, fileName);

                    File.WriteAllBytes(filePath, data);

                    Console.WriteLine($"Đã tải và lưu {fileName} vào {filePath} - {data.Length} bytes");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Lỗi khi tải xuống {url}: {e.Message}");
                }
            });
        }
    }
}
