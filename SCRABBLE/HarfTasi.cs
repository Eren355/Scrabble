using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ÖDEV
{
    public  class HarfTasi
    {
        //özellikler ve yazılması

        public string harf;
        public int sayisi;
        public int puanı;

        public void Yaz()   // YAZMA işlemi taslarıyaz metodunda sadece pdfte burası var diye yazzdım  bu metodu kullanmadım
        {
            Console.WriteLine("{0}:{1}",harf,puanı);
            
        }

       


    }
}
