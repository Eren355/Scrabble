using System;

namespace ÖDEV
{
    internal class Oyun
    {



        public void oynat()
        {
            Oyuncu oyuncu1 = new Oyuncu();
            Oyuncu oyuncu2 = new Oyuncu();

            Torba torba = new Torba();      // her oyuncuiçin ayrı ayrı torb yok
            torba.doldur();
            torba.karıştır();

            Tahta tahta = new Tahta();
            tahta.olustur();

            oyuncu1.BilgileriniGir();
            oyuncu1.TasEkle(torba);

            oyuncu2.BilgileriniGir();
            oyuncu2.TasEkle(torba);

            Console.Clear();

            tahta.TahtaCiz();

            oyuncu1.TaslariniYaz();
            oyuncu2.TaslariniYaz();

            oyuncu1.PuanYaz();
            oyuncu2.PuanYaz();
            Sözlük sözlük = new Sözlük();
            string dosyaYolu = @"C:\Users\ASUS\Desktop\DERS\1.SINIF\PROGRAMLAMA 2\ÇALIŞMA\ÖDEV\sozluk.txt";

            sözlük.Olustur(dosyaYolu);


            bool oyunBittiMi = true;
            int oyuncuSırası = 0;
            while (oyunBittiMi == true)
            {
               
                
                
                
                
                //// 1.oyuncu
                if (oyuncuSırası % 2 == 0)
                {
                    bool devamEt = true;
                    Console.WriteLine();

                    Console.WriteLine($" Sıradaki Oyuncu : {oyuncu1.adi}");
                    oyuncu1.TasEkle(torba);

                    Console.WriteLine("girmek istediğiniz kelimeyi ve koordinatları girin ");
                    Console.Write("Kelime:");
                    string kelime = Console.ReadLine();
                    Console.Write("Başlangıç Satırı: ");
                    int basSatir = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Başlangıç Sütunu: ");
                    int basSutun = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Bitiş Satırı: ");
                    int bitSatir = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Bitiş Sütunu: ");
                    int bitSutun = Convert.ToInt32(Console.ReadLine());

                    if (oyuncu1.GirilenHarflereSahipMi(kelime) == false)
                    {
                        Console.WriteLine("Girilen harfler oyuncunun taşlarında yok!");
                        devamEt = false;

                    }

                    
                    if (oyuncu1.TasiBittiMi() == true)
                    {
                        Console.WriteLine("Oyuncunun taşları bitti!");
                        devamEt = false;
                        oyunBittiMi = false;
                        Console.ReadLine();


                    }

                    else if (devamEt == true && tahta.GecerlilikKontrolu(basSatir, basSutun, bitSatir, bitSutun, kelime) == false)
                    {
                        if (basSatir!=bitSatir && basSutun!=bitSutun)
                        {
                            Console.WriteLine(" çapraz giriş !!! ");
                        }


                         else   Console.WriteLine("Kelime uzunluğu ile koordinat uyuşmazlığı   !!! ");
                        devamEt = false;
                        Console.ReadLine();

                    }
                    else if (devamEt == true && sözlük.KelimeVarMi(tahta.KelimeyiOlustur(basSatir, basSutun, bitSatir, bitSutun, kelime)) == true)   // kelime sözlükte varsa  
                    {
                        oyuncu1.TasCikar(kelime);

                        oyuncu1.TasEkle(torba);

                        Console.ReadLine();

                        int a = tahta.PuanHesapla(basSatir, basSutun, bitSatir, bitSutun, kelime);
                       oyuncu1.PuaniniGuncelle(a);
                    
                    
                    }
                    else if (devamEt == true)
                    {
                        Console.ReadLine();
                        tahta.KelimeSil(basSatir, basSutun, bitSatir, bitSutun, kelime);
                        Console.WriteLine("Sözlük bulunamadı!!");

                    }
                    oyuncuSırası++;
                    

                    Console.Clear();
                    

                    Console.WriteLine();

                    tahta.TahtaCiz();

                    oyuncu1.TaslariniYaz();
                    Console.WriteLine();

                    oyuncu2.TaslariniYaz();

                    Console.WriteLine();

                    oyuncu1.PuanYaz();
                    oyuncu2.PuanYaz();
                    Console.WriteLine();
                }







                /////////2. oyuncu 

                if (oyuncuSırası % 2 == 1)
                {
                    bool devamEt = true;
                    Console.WriteLine();

                    Console.WriteLine($" Sıradaki Oyuncu : {oyuncu2.adi}");
                    oyuncu2.TasEkle(torba);

                    Console.WriteLine("girmek istediğiniz kelimeyi ve koordinatları girin ");
                    Console.Write("Kelime:");
                    string kelime = Console.ReadLine();
                    Console.Write("Başlangıç Satırı: ");
                    int basSatir = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Başlangıç Sütunu: ");
                    int basSutun = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Bitiş Satırı: ");
                    int bitSatir = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Bitiş Sütunu: ");
                    int bitSutun = Convert.ToInt32(Console.ReadLine());

                   if (oyuncu2.GirilenHarflereSahipMi(kelime) == false)
                    {
                        Console.WriteLine("Girilen harfler oyuncunun taşlarında yok!");
                        devamEt = false;

                    }


                    if (oyuncu2.TasiBittiMi() == true)
                    {
                        Console.WriteLine("Oyuncunun taşları bitti!");
                        oyunBittiMi = false;
                        devamEt = false;

                    }

                    else if (devamEt == true && tahta.GecerlilikKontrolu(basSatir, basSutun, bitSatir, bitSutun, kelime) == false)
                    {
                        Console.WriteLine("Kelime uzunluğu ile koordinat uyuşmazlığı  veya çapraz giriş !!! ");
                        devamEt = false;
                        Console.ReadLine();
                    }
                    else if (devamEt == true && sözlük.KelimeVarMi(tahta.KelimeyiOlustur(basSatir, basSutun, bitSatir, bitSutun, kelime)) == true)   // kelime sözlükte varsa  
                    {

                        oyuncu2.TasCikar(kelime);
                        oyuncu2.TasEkle(torba);

                        int a = tahta.PuanHesapla(basSatir, basSutun, bitSatir, bitSutun, kelime);
                        oyuncu2.PuaniniGuncelle(a);
                        Console.ReadLine();

                    }
                    else if (devamEt == true)
                    {
                        tahta.KelimeSil(basSatir, basSutun, bitSatir, bitSutun, kelime);
                        Console.WriteLine("Sözlük bulunamadı!!");
                    }
                    oyuncuSırası++;
                   


                }
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine();

                tahta.TahtaCiz();

                oyuncu1.TaslariniYaz();
                Console.WriteLine();

                oyuncu2.TaslariniYaz();

                Console.WriteLine();

                oyuncu1.PuanYaz();
                oyuncu2.PuanYaz();

                Console.WriteLine();







            }
        }



































    }
}
