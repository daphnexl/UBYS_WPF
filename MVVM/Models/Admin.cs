using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.MVVM.Models
{
    internal class Admin : User
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public List<string> Yetkiler { get; set; }

        public Admin()
        {
            Yetkiler = new List<string>();
        }

        public Admin(int id, string ad, string soyad, string eposta, string telefon, DateTime dogumTarihi, string kullaniciAdi, string sifre)
            : base(id, ad, soyad, eposta, telefon, dogumTarihi)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            Yetkiler = new List<string>(); // Başlangıçta boş bir yetki listesi
        }


        public void YetkiEkle(string yetki)
        {
            if (!Yetkiler.Contains(yetki))
            {
                Yetkiler.Add(yetki);
            }
        }


        public bool YetkisiVarMi(string yetki)
        {
            return Yetkiler.Contains(yetki);
        }

        public override string ToString()
        {
            return $"{Ad} {Soyad} - Sistem Yöneticisi ({KullaniciAdi})";
        }
    }
}
