using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Class
{
    public class Product
    {
        [Key]
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public string UrunMarka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set;}
        public decimal SatisFiyat { get; set;}
        public bool Durum { get; set;}
        public string UrunGorsel { get; set;}
        public Category Category { get; set; }
        public SalesTransaction SalesTransaction { get; set; }

    }
}