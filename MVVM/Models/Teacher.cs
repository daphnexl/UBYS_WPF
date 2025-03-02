using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.MVVM.Models
{
    internal class Teacher : User
    {

        public string Unvan { get; set; }
        public string Bolum { get; set; }

        public Teacher() { }
        public Teacher(int id, string ad, string soyad, string eposta, string telefon, DateTime dogumTarihi, string unvan, string bolum)
            : base(id, ad, soyad, eposta, telefon, dogumTarihi)
        {

            Unvan = unvan;
            Bolum = bolum;
        }

        public override string ToString()
        {
            return $"{Unvan} {Ad} {Soyad} ";
        }
    }
}
