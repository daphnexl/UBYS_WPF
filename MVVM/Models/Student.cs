using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBYS_WPF.MVVM.Models
{
    internal class Student : User
    {

        public string OgrenciNo { get; set; }
        public string Bolum { get; set; }
        public int Sinif { get; set; }


        public Student() { }
        public Student(int id, string ad, string soyad, string eposta, string telefon, DateTime dogumTarihi, string ogrenciNo, string bolum, int sinif) : base(id, ad, soyad, eposta, telefon, dogumTarihi)
        {
            OgrenciNo = ogrenciNo;
            Bolum = bolum;
            Sinif = sinif;
        }
        public override string ToString()
        {
            return $"{Ad} {Soyad} - {OgrenciNo}";
        }
    }
}