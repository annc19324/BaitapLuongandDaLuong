using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//7. Viết một chương trình tạo một tài khoản ngân hàng
//với các khoản tiền gửi và rút tiền đồng thời bằng các luồng.
namespace BaitapLuongandDaLuong
{
    class Bai7_TaoTaiKhoanNganHang
    {
        public static void Run()
        {
            BankAccount account = new BankAccount();
            Thread t1 = new Thread(() => account.NapTien(500));
            Thread t2 = new Thread(() => account.RutTien(300));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }

    class BankAccount
    {
        private int balance = 1000;
        public void NapTien(int amount)
        {
                balance += amount;
                Console.WriteLine($"Nạp {amount}, số dư: {balance}");
        }

        public void RutTien(int amount) 
        {
                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine($"Rút {amount}, số dư: {balance}");
                }
                else
                    Console.WriteLine("Không đủ tiền.");
        }
    }

}
