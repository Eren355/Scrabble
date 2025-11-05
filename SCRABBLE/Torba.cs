using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ÖDEV
{
    public class Torba
    {// doldur
     // karıstır
     // harf cek
     // bos mu 
        
        List<HarfTasi> Harf = new List<HarfTasi>();
        int cekilenH = 0;

        public void doldur()
        {
            
            string[] harfler = { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z", "*" };
            int[] sayısı = { 12, 2, 2, 2, 2, 8, 1, 1, 1, 1, 4, 7, 1, 7, 7, 4, 5, 3, 1, 1, 6, 3, 2, 5, 3, 2, 1, 2, 2, 2 };
            int[] puanlar = { 1, 3, 4, 4, 3, 1, 7, 5, 8, 5, 2, 1, 10, 1, 1, 2, 1, 2, 7, 5, 1, 2, 4, 1, 2, 3, 7, 3, 4, 0 };



            int k = 0;

            for (int i = 0;i<30;i++   )
                for (int j = 0;j<sayısı[i];j++)
                {
                    Harf.Add(new HarfTasi());
                    Harf[k].puanı=puanlar[i];
                    Harf[k].harf=harfler[i];            
                    k++;
                }

            
            }

         public void karıştır()
        {
            
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int rIndis = random.Next(0, Harf.Count);
                HarfTasi gecici = Harf[i];
                Harf[i] = Harf[rIndis];
                Harf[rIndis] = gecici;

            }
        }

        public HarfTasi harfCek()
        {
            if (bosMu()==false)
            {
                return Harf[cekilenH++];
            }
            return null;  // taş yoksa null döndürür
        }



        public bool bosMu()
        {
            return Harf.Count==0; // hiç taş yoksa eleman sayısı 0 ise boştur .Count eleman sayısı 
        }



































    }
}
