using System;
using System.Threading;

namespace BaitapLuongandDaLuong
{
    class Bai12_TruyCapDocGhi
    {
        // 12. Viết một chương trình để truy cập
        // đọc-ghi đồng thời vào một tài nguyên được chia sẻ.

        private static int sharedResource = 0;

        // Khóa đồng bộ hóa cho việc truy cập đọc-ghi đồng thời
        private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        public static void Run()
        {
            // Tạo và khởi động các luồng: một luồng ghi và một luồng đọc
            Thread writer = new Thread(Write);
            Thread reader = new Thread(Read);

            // Bắt đầu luồng ghi và luồng đọc
            writer.Start();
            reader.Start();

            // Chờ các luồng hoàn thành công việc của chúng
            writer.Join();
            reader.Join();
        }

        private static void Write()
        {
            for (int i = 0; i < 10; i++)
            {
                // Bắt đầu chế độ ghi (chỉ có một luồng ghi tại thời điểm này)
                rwLock.EnterWriteLock();  

                sharedResource = i;  
                Console.WriteLine($"Ghi: {i}");

                rwLock.ExitWriteLock();  // Thoát chế độ ghi, cho phép các luồng khác truy cập tài nguyên

                // Tạm dừng một chút trước khi tiếp tục vòng lặp
                Thread.Sleep(100);
            }
        }

        // Phương thức đọc từ tài nguyên chia sẻ
        private static void Read()
        {
            for (int i = 0; i < 10; i++)
            {
                rwLock.EnterReadLock();  

                Console.WriteLine($"Đọc: {sharedResource}");  // In giá trị tài nguyên chia sẻ

                rwLock.ExitReadLock();  // Thoát chế độ đọc

                // Tạm dừng một chút trước khi tiếp tục vòng lặp
                Thread.Sleep(100);
            }
        }
    }
}
