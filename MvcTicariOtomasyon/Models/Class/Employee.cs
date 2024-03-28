using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Class
{
    public class Employee
    {
        [Key]
        public int PersonelID { get; set; }
        [Display(Name ="Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name = "Personel Soyadı")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Görsel")]
        public string PersonelGorsel { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public int DepartmanID { get; set; }
        public virtual Department Department { get; set; }
    }
}