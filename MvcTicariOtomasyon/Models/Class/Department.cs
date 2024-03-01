using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Class
{
    public class Department
    {
        [Key]
        public int DepartmanID { get; set; }
        public string DepartmanAd { get; set; }
    }
}