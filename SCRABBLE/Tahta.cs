using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖDEV
{
    public class Tahta
    {
        // oluşturma,
        // çizme,
        // geçerlilik (yatay, dikey, temas vs) fonksiyonları,
        // tahtaya girilen harflerden alternatif kelime lokasyonlarının bulunması ve puanlanması fonksiyonları,
        // hücrelerin güncellenmesi:


        TahtaHücresi[,] hücreler = new TahtaHücresi[15, 15];
        public int ilkhamlekontrol = 0;
        
        public void olustur()
        {


            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    hücreler[i, j] = new TahtaHücresi();

                    // Hücrelerin katsayılarını belirleme
                    if ((j == 2 && i == 0) || (j == 12 && i == 0) || (j == 0 && i == 2) || (j == 14 && i == 2) || (j == 0 && i == 12) || (j == 14 && i == 12) || (j == 2 && i == 14) || (j == 12 && i == 14))
                        hücreler[i, j].katsayi = "K3";

                    else if ((j == 5 && i == 0) || (j == 9 && i == 0) || (j == 6 && i == 1) || (j == 8 && i == 1) || (j == 0 && i == 5) || (j == 5 && i == 5) || (j == 9 && i == 5) || (j == 14 && i == 5) || (j == 1 && i == 6) || (j == 6 && i == 6) || (j == 8 && i == 6) || (j == 13 && i == 6) || (j == 6 && i == 8) || (j == 8 && i == 8) || (j == 1 && i == 8) || (j == 13 && i == 8) || (j == 0 && i == 9) || (j == 5 && i == 9) || (j == 9 && i == 9) || (j == 14 && i == 9) || (j == 6 && i == 13) || (j == 8 && i == 13) || (j == 5 && i == 14) || (j == 9 && i == 14))
                        hücreler[i, j].katsayi = "H2";

                    else if ((j == 7 && i == 2) || (j == 3 && i == 3) || (j == 11 && i == 3) || (j == 2 && i == 7) || (j == 12 && i == 7) || (j == 3 && i == 11) || (j == 11 && i == 11) || (j == 7 && i == 12))
                        hücreler[i, j].katsayi = "K2";

                    else if ((j == 1 && i == 1) || (j == 13 && i == 1) || (j == 4 && i == 4) || (j == 10 && i == 4) || (j == 4 && i == 10) || (j == 10 && i == 10) || (j == 1 && i == 13) || (j == 13 && i == 13))
                        hücreler[i, j].katsayi = "H3";
                    else if (j == 7 && i == 7)
                        hücreler[i, j].katsayi = "*";
                    else
                        hücreler[i, j].katsayi = "";

                    hücreler[i, j].doluMu = false; // başlangıçta tüm hücreler boş
                    hücreler[i, j].harf = ""; 
                    
                }
            }

        }

        public void TahtaCiz()
        {
            // Üst kenar çizgisi
            for (int i = 0; i < 17; i++)
            {
                if (i == 0)
                    Console.Write("   ");
                else if (i <= 15)
                    Console.Write("+---");
                else
                    Console.WriteLine("+");
            }

            // Sütun numaraları
            Console.Write("   ");
            for (int j = 0; j < 15; j++)
            {
                if (j < 10)
                    Console.Write("| " + j + " ");
                else
                    Console.Write("|" + j + " ");
            }
            Console.WriteLine("|");

            // Üst çerçeve
            Console.Write("---");
            for (int j = 0; j < 15; j++)
                Console.Write("+---");
            Console.WriteLine("+");

            for (int i = 0; i < 15; i++)
            {
                // Satır numarası
                if (i < 10)
                    Console.Write(" " + i + " ");
                else
                    Console.Write(i + " ");

                for (int j = 0; j < 15; j++)
                {
                    Console.Write("|");

                    if (hücreler[i, j].doluMu==true)
                    {
                        Console.Write(" " + hücreler[i, j].harf + " ");
                    }
                    else if (hücreler[i, j].doluMu == false && hücreler[i, j].katsayi == "H2")
                        Console.Write("H2 ");
                    else if (hücreler[i, j].doluMu == false && hücreler[i, j].katsayi == "H3")
                        Console.Write("H3 ");
                    else if (hücreler[i, j].doluMu == false && hücreler[i, j].katsayi == "K2")
                        Console.Write("K2 ");
                    else if (hücreler[i, j].doluMu == false && hücreler[i, j].katsayi == "K3")
                        Console.Write("K3 ");
                    else if (hücreler[i, j].doluMu == false && hücreler[i, j].katsayi == "*")
                        Console.Write("***");
                    else
                        Console.Write("   ");
                }

                Console.WriteLine("|");

                // Alt çizgi
                Console.Write("---");
                for (int j = 0; j < 15; j++)
                    Console.Write("+---");
                Console.WriteLine("+");
            }
        }

       
        public bool GecerlilikKontrolu(int bassatir, int bassutun, int sonsatır, int sonsutun, string kelime) // true ise geçerli   temas ve kelime uzunluğu kontrolü
        {

            bool temasVar = false;
            int a = bassatir;
            int b = bassutun;
            int c = sonsatır;
            int d = sonsutun;
            string k = kelime;

          



            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (hücreler[i, j].doluMu == false)
                        ilkhamlekontrol++;


                }
            }

            if (ilkhamlekontrol == 225 && a == c && (k.Length == d - b + 1))  //ilk hamle 
            { 
                return true;
            }

            if (ilkhamlekontrol == 225 && b == d && (k.Length == c - a + 1))  //ilk hamle 
            {
                return true;
            }

            if (ilkhamlekontrol != 225 && a == c && (k.Length == d - b + 1)) // yatay kelime       k.Lenght ile kelime uzunluğu kontrolü yaptık 
            {
                for (int j = b; j <= d; j++)
                {
                    // hücre etrafını kelime uzunluğu kadar  kontrol
                    if (a > 0 && hücreler[a - 1, j].doluMu == true) temasVar = true;
                    if (a < 14 && hücreler[a + 1, j].doluMu == true) temasVar = true;
                    if (j > 0 && hücreler[a, j - 1].doluMu == true) temasVar = true;
                    if (j < 14 && hücreler[a, j + 1].doluMu == true) temasVar = true;
                }
            }
            else if (ilkhamlekontrol != 225 && b == d && (k.Length == c - a + 1)) // dikey kelime      
            {
                for (int i = a; i <= c; i++)
                {
                    if (i > 0 && hücreler[i - 1, b].doluMu) temasVar = true;
                    if (i < 14 && hücreler[i + 1, b].doluMu) temasVar = true;
                    if (b > 0 && hücreler[i, b - 1].doluMu) temasVar = true;
                    if (b < 14 && hücreler[i, b + 1].doluMu) temasVar = true;
                }
            }


            if (temasVar == true)
                return true;
            else                       // çapraz giriş vardır 
            {
                return false;


            }

        }


      /*  public void HucreGuncelle()
        {
            hücreler[5, 5].harf = "A";
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    
                    Koordinat[,] k = new Koordinat[15,15];
                   
                    if (hücreler[i, j].doluMu==true)
                    {
                        k[i, j] = new Koordinat();
                        k[i,j].x = (j+1) * 4; // sütun aralığı 
                        k[i,j].y = (i+1) * 2; // satır aralığı

                        Console.SetCursorPosition(k[i, j].x, k[i, j].y);     // yılan oyunundaki gibi SetCursorPosition ile konumlandırdık
                        Console.Write(hücreler[i, j].harf);
                    }
                }
            }
        }*/
      

        public string KelimeyiOlustur(int basSatir, int basSutun, int sonSatir, int sonSutun, string girilenKelime)
        {
            string tamKelime = "";

            // öncelikli harf atama atama yapmadan sözlük kontrolü olmaz 
            int index = 0;

            if (basSatir == sonSatir) // yatay
            {
                for (int j = basSutun; j <= sonSutun; j++)
                {
                    if (hücreler[basSatir, j].doluMu==false) // Hücre boşsa yerleştir
                    {
                        hücreler[basSatir, j].harf = girilenKelime[index].ToString();
                        hücreler[basSatir, j].doluMu = true;
                        hücreler[basSatir, j].katsayi = ""; 
                    }
                    index++;
                }
            }
            else if (basSutun == sonSutun) // dikey
            {
                for (int i = basSatir; i <= sonSatir; i++)
                {
                    if (!hücreler[i, basSutun].doluMu)
                    {
                        hücreler[i, basSutun].harf = girilenKelime[index].ToString();
                        hücreler[i, basSutun].doluMu = true;
                        
                    }
                    index++;
                }
            }
           


            if (basSatir == sonSatir) // yatay kelime
            {
                // sola doğru tamamla
                int j = basSutun;
                while (j > 0 && hücreler[basSatir, j - 1].doluMu == true)
                {
                    j--;
                }

                // soldan sağa doğru oku
                while (j < 15 && (hücreler[basSatir, j].doluMu == true || (j >= basSutun && j <= sonSutun)))
                {
                    if (hücreler[basSatir, j].doluMu == true)
                        tamKelime += hücreler[basSatir, j].harf;
                    else
                        tamKelime += girilenKelime[j - basSutun]; // yazılmak istenen harfi ekle
                    j++;
                }
            }
            else if (basSutun == sonSutun) // dikey kelime
            {
                int i = basSatir;
                while (i > 0 && hücreler[i - 1, basSutun].doluMu)
                {
                    i--;
                }

                while (i < 15 && (hücreler[i, basSutun].doluMu || (i >= basSatir && i <= sonSatir)))
                {
                    if (hücreler[i, basSutun].doluMu)
                        tamKelime += hücreler[i, basSutun].harf;
                    else
                        tamKelime += girilenKelime[i - basSatir];
                    i++;
                }
            }

            
            return tamKelime;
        }

        public void KelimeSil(int basSatir, int basSutun, int bitSatir, int bitSutun, string kelime)
        {
            int x = basSatir;
            int y = basSutun;

            for (int i = 0; i < kelime.Length; i++)
            {
                hücreler[x, y].harf = "";
                hücreler[x, y].doluMu = false;

                // yön yatay mı dikey mi?
                if (basSatir == bitSatir)
                {
                    y++;  // yatay
                }
                else if (basSutun == bitSutun)
                {
                    x++;  // dikey
                }
                
            }
        }

        public int PuanHesapla(int basSatir, int basSutun, int bitSatir, int bitSutun, string kelime)
        {
            int toplamPuan = 0;
            int kelimeCarpani = 1;

            int x = basSatir;
            int y = basSutun;

            for (int i = 0; i < kelime.Length; i++)
            {
                string harf = kelime[i].ToString().ToUpper();

              
                Oyuncu oyuncu = new Oyuncu();
                string katsayi = hücreler[x, y].katsayi;
                int  harfpuanı=0;  
                
                // 1, 3, 4, 4, 3, 1, 7, 5, 8, 5, 2, 1, 10, 1, 1, 2, 1, 2, 7, 5, 1, 2, 4, 1, 2, 3, 7, 3, 4, 0 };

                if (harf == "A") harfpuanı = 1;
                else if (harf == "B") harfpuanı = 3;
                else if (harf == "C") harfpuanı = 4;
                else if (harf == "Ç") harfpuanı = 4;
                else if (harf == "D") harfpuanı = 3;
                else if (harf == "E") harfpuanı = 1;
                else if (harf == "F") harfpuanı = 7;
                else if (harf == "G") harfpuanı = 5;
                else if (harf == "Ğ") harfpuanı = 8;
                else if (harf == "H") harfpuanı = 5;
                else if (harf == "I") harfpuanı = 2;
                else if (harf == "İ") harfpuanı = 1;
                else if (harf == "J") harfpuanı = 10;
                else if (harf == "K") harfpuanı = 1;
                else if (harf == "L") harfpuanı = 1;
                else if (harf == "M") harfpuanı = 2;
                else if (harf == "N") harfpuanı = 1;
                else if (harf == "O") harfpuanı = 2;
                else if (harf == "Ö") harfpuanı = 7;
                else if (harf == "P") harfpuanı = 5;
                else if (harf == "R") harfpuanı = 1;
                else if (harf == "S") harfpuanı = 2;
                else if (harf == "Ş") harfpuanı = 4;
                else if (harf == "T") harfpuanı = 1;
                else if (harf == "U") harfpuanı = 2;
                else if (harf == "Ü") harfpuanı = 3;
                else if (harf == "V") harfpuanı = 7;
                else if (harf == "Y") harfpuanı = 3;
                else if (harf == "Z") harfpuanı = 4;
                else if (harf == "*") harfpuanı = 0;





                if (katsayi == "H2")
                    harfpuanı *= 2;
                else if (katsayi == "H3")
                    harfpuanı *= 3;
                else if (katsayi == "K2")
                    kelimeCarpani *= 2;
                else if (katsayi == "K3")
                    kelimeCarpani *= 3;

                toplamPuan += harfpuanı;

                // yön kontrolü
                if (basSatir == bitSatir)
                    y++; // yatay
                else if (basSutun == bitSutun)
                    x++; // dikey
               
            }

            return toplamPuan * kelimeCarpani;
        }



    }

































}


