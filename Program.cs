using System;
using System.Text;
using System.Threading;
using BaitapLuongandDaLuong;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
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
            Console.WriteLine("10. Đồng bộ hóa quyền truy cập vào tài nguyên chia sẻ");
            Console.WriteLine("11. Đồng bộ hóa thời điểm bắt đầu và kết thúc của nhiều luồng");
            Console.WriteLine("12. Truy cập đọc-ghi đồng thời vào tài nguyên chia sẻ");
            Console.WriteLine("13. Tạo nhiều luồng và in tên của chúng");
            Console.WriteLine("14. Tải xuống nhiều tệp đồng thời bằng luồng");
            Console.WriteLine("15. Tìm và in các số chẵn và lẻ từ 30 đến 50");
            Console.WriteLine("16. Tính giai thừa của một số bằng nhiều luồng");
            Console.WriteLine("17. Sắp xếp hợp nhất đa luồng");
            Console.WriteLine("18. Sắp xếp nhanh đa luồng");
            Console.WriteLine("19. Thực hiện các yêu cầu HTTP đồng thời bằng luồng");
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
                case 10: Bai10_DongBoHoa.Run(); break;
                case 11: Bai11_DongBoHoaThoiDiem.Run(); break;
                case 12: Bai12_TruyCapDocGhi.Run(); break;
                case 13: Bai13_InTenLuong.Run(); break;
                case 14: Bai14_TaiXuongFile.Run(); break;
                case 15: Bai15_ChanLe30Den50.Run(); break;
                case 16: Bai16_GiaiThua.Run(); break;
                case 17: Bai17_MergeSort.Run(); break;
                case 18: Bai18_QuickSort.Run(); break;
                case 19: Bai19_YeuCauHTTP.Run(); break;
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