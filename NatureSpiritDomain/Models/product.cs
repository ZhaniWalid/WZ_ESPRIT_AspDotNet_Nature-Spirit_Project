using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class product
    {
        public product()
        {
            this.details = new List<detail>();
        }

        public int id_Product { get; set; }
        public int Availability { get; set; }
        public Nullable<double> Price { get; set; }
        public string Type_Product { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public virtual ICollection<detail> details { get; set; }
        public virtual member member { get; set; }
    }
}
