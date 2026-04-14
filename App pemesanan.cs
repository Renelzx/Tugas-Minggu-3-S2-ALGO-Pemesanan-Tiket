using System;
using System.Collections.Generic;

namespace TiketOnlineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int hargaPerTiket = 50000;
            Dictionary<string, int> riwayatUser = new Dictionary<string, int>();

            Console.WriteLine("=== Aplikasi Tiket Online ===");
            Console.WriteLine("Ketik 'EXIT' pada nama pengguna untuk keluar secara normal.");

            while (true)
            {
                Console.WriteLine("\n---------------------------------------------------");
                Console.Write("Masukkan Nama Pengguna: ");
                string inputNama = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(inputNama)) continue;
                if (inputNama.ToUpper() == "EXIT")
                {
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi. Sampai jumpa!");
                    break;
                }

                if (!riwayatUser.ContainsKey(inputNama))
                {
                    riwayatUser[inputNama] = 0;
                }

                if (riwayatUser[inputNama] >= 5)
                {
                    Console.WriteLine($"\n[SECURITY ALERT] User '{inputNama}' terdeteksi mencoba transaksi ke-6!");
                    Console.WriteLine("Aplikasi akan ditutup otomatis karena melanggar batas limit...");
                    System.Threading.Thread.Sleep(2000); 
                    return; 
                }

                int urutanTransaksi = riwayatUser[inputNama] + 1;
                Console.WriteLine($"Halo {inputNama}, transaksi Anda ke-{urutanTransaksi}/5.");
                Console.Write("Masukkan jumlah tiket (1-5): ");

                if (int.TryParse(Console.ReadLine(), out int jumlahBeli) && jumlahBeli >= 1 && jumlahBeli <= 5)
                {
                    double totalHarga = jumlahBeli * hargaPerTiket;
                    double diskon = 0;
                    string jenisDiskon = "Tidak ada";

                    if (jumlahBeli == 5) 
                    {
                    diskon = totalHarga * 0.10; 
                    jenisDiskon = "10% (Bulk Purchase)";
                    }
                    else if (riwayatUser[inputNama] >= 3) 
                    {
                    diskon = totalHarga * 0.05; 
                    jenisDiskon = "5% (Loyalty Promo)";
                    }
                    else 
                    {
                    diskon = 0;
                    jenisDiskon = "Tidak ada";
                    }

                    double totalBayar = totalHarga - diskon;
                    riwayatUser[inputNama]++; 

                    Console.WriteLine("\n--- STRUK PEMBELIAN ---");
                    Console.WriteLine($"User         : {inputNama}");
                    Console.WriteLine($"Jumlah Tiket : {jumlahBeli}");
                    Console.WriteLine($"Diskon       : Rp {diskon} ({jenisDiskon})");
                    Console.WriteLine($"TOTAL BAYAR  : Rp {totalBayar}");
                    Console.WriteLine("-----------------------");
                }
                else
                {
                    Console.WriteLine("Gagal: Input tidak valid (Hanya 1-5 tiket).");
                }
            }
        }
    }
}