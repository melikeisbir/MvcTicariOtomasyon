using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Class
{
    public class Category
    {
        [Key]
        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public ICollection<Product> Products { get; set; } //bire çok ilişki için
    }
}