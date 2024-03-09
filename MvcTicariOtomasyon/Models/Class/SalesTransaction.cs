using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Class
{
    public class SalesTransaction
    {
        [Key] 
        public int SatisID { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunID { get; set; }
        public int CariID { get; set; }
        public int PersonelID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}