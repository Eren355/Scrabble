using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  // dosya işlemleri için gerekli kütüphane
namespace ÖDEV
{
    public  class Sözlük
    {
        // oluştur 
        // kelime var mı 

        // C:\Users\ASUS\Desktop\DERS\1.SINIF\PROGRAMLAMA 2\ÇALIŞMA\ÖDEV  dosya yolu 

        
        
            List<string> kelimeler = new List<string>();

            public void Olustur(string dosyaYolu)
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu);

                foreach (string satir in satirlar)
                {
                    kelimeler.Add(satir.Trim().ToLower());      //Trim ile başındaki ve sonundaki boşlukları kaldırıyoruz ToLower ile küçük büyük harf farkını kaldırıyoruz
            }
            }

            public bool KelimeVarMi(string kelime)
            {
                return kelimeler.Contains(kelime.ToLower());
            }
        

    }
}
