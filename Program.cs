using System;
using System.Threading;
using BaitapLuongandDaLuong;

class Program
{
    static void Main()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Chọn chương trình để chạy:");
            Console.WriteLine("1. Hello World với Thread");
            Console.WriteLine("2. In số chẵn lẻ bằng 2 Thread");
            Console.WriteLine("3. Sắp xếp mảng bằng nhiều Thread");
            Console.WriteLine("4. Nhân ma trận bằng nhiều Thread");
            Console.WriteLine("5. Tổng các số nguyên tố bằng nhiều Thread");
            Console.WriteLine("6. Trình thu thập dữ liệu Web bằng Thread");
            Console.WriteLine("7. Giao dịch ngân hàng đồng thời");
            Console.WriteLine("8. Biến đếm chia sẻ với nhiều Thread");
            Console.WriteLine("9. Mô hình nhà sản xuất - người tiêu dùng");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập số lựa chọn: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng nhập lại.");
                Thread.Sleep(2000);
                continue;
            }

            switch (choice)
            {
                case 1: Bai1_HelloWord.Run(); break;
                case 2: Bai2_ChanLe.Run(); break;
                case 3: Bai3_SapXep.Run(); break;
                case 4: Bai4_PhepNhanMaTran.Run(); break;
                case 5: Bai5_TongSoNguyenTo.Run(); break;
                case 6: Bai6_ThuThapDuLieu.Run(); break;
                case 7: Bai7_TaoTaiKhoanNganHang.Run(); break;
                case 8: Bai8_LuongTangBien.Run(); break;
                case 9: Bai9_TaoKichBan.Run(); break;
                case 0: Console.WriteLine("Thoát chương trình..."); break;
                default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nNhấn Enter để tiếp tục...");
                Console.ReadLine();
            }
        } while (choice != 0);
    }
}
