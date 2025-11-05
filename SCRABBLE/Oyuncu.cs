using ÖDEV;
using System;

using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖDEV
{
    public class Oyuncu
    {
        public string adi;
        public string soyadi;
        public int yasi;
        public int puan=0;

        public List<HarfTasi> taslar = new List<HarfTasi>();   // her oyuncunun kendi taşı 
        
        // 1. BilgileriniGir
        public void BilgileriniGir()
        {
            Console.Write("Oyuncu Adı: ");
            adi = Console.ReadLine();

           Console.Write("Oyuncu Soyadı: ");
            soyadi = Console.ReadLine();

            Console.Write("Yaşı: ");
            yasi = Convert.ToInt32(Console.ReadLine());

           
        }

        // 2. TaslariniYaz
        public void TaslariniYaz()
        {
            Console.Write(adi + " taşları: ");
            Console.WriteLine("");
            foreach (var tas in taslar)
            {
                Console.WriteLine(tas.harf + " : "+tas.puanı);
            }
            Console.WriteLine();
        }

        // 3. tasEkle
        public void TasEkle(Torba torba)      
        {
            while (taslar.Count < 7 && torba.bosMu()==false)
                taslar.Add(torba.harfCek());
        }

        // 4. tasCikar
        public void TasCikar(string kelime)
        {
            for (int i = 0; i < kelime.Length; i++)
            {
                for (int j = 0; j < taslar.Count; j++)
                {
                    if (taslar[j].harf == kelime[i].ToString())
                    {
                        taslar.RemoveAt(j);
                        j = taslar.Count; // döngüyü bitir 
                                          // çünkü bu harften sadece bir tane sileceğiz
                    }
                }
            }
        }


        // 5. girilenHarflereSahipMi
        public bool GirilenHarflereSahipMi(string kelime)
        {
            
            List<string> eldekiHarfler = new List<string>();
            int harfSayısı = 0;
            for (int i = 0; i < taslar.Count; i++)
            {
                eldekiHarfler.Add(taslar[i].harf);  
            }

            // 2. Kelimedeki her harfi sırayla kontrol et
            for (int i = 0; i < kelime.Length; i++)
            {
                string harf = kelime[i].ToString();   //kelime[i] harfini char olarak alır String() ile stringe çevirdim 

                if (eldekiHarfler.Contains(harf)) 
                {
                    harfSayısı++;
                    eldekiHarfler.Remove(harf);   // harfi kullandık, çıkar
                }
                
            }

            // Tüm harfler varsa true 
           if (harfSayısı==kelime.Length) 
                {
                return true;

                }
           return false;
        }


        // 6. tasiBittiMi
        public bool TasiBittiMi()
        {
            return taslar.Count == 0;
        }

        // 7. puaniniGuncelle
        public void PuaniniGuncelle(int ekPuan)           
        {
           puan += ekPuan;
        }

        public void PuanYaz()
        {
            Console.WriteLine($"{adi} puanı : {puan}  ");


        }
    
}
}
