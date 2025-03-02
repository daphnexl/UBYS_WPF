using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace UBYS_WPF.MVVM.Models
{
    internal class User
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public DateTime DogumTarihi { get; set; }

        public User() { }
        public User(int id, string ad, string soyad, string eposta, string telefon, DateTime dogumTarihi)
        {
            Id = id;
            Ad = ad;
            Soyad = soyad;
            Eposta = eposta;
            Telefon = telefon;
            DogumTarihi = dogumTarihi;
        }

        public override string ToString()
        {
            return $"{Ad} {Soyad}";
        }
    }
}
