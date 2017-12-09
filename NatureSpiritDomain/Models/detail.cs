using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class detail
    {
        public int Id_Member { get; set; }
        public int Id_Product { get; set; }
        public System.DateTime date_Of_Purchase { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Total_amount { get; set; }
        public Nullable<bool> state { get; set; }
        public virtual member member { get; set; }
        public virtual product product { get; set; }
    }
}
