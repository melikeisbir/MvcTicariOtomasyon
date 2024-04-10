using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Class
{
    public class CargoDetail
    {
        public int KargoDetayID { get; set; }
        public string Aciklama { get; set; }
        public string TakipKodu { get; set; }
        public string Personel { get; set; }
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}