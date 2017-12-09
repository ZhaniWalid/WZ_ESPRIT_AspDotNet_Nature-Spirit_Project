using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Models
{
    public class ProductModels
    {

        public int id_Product { get; set; }
        public int Availability { get; set; }
        public Nullable<double> Price { get; set; }
        public string Type_Product { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public virtual ICollection<detail> details { get; set; }
        public virtual member member { get; set; }
    }
}