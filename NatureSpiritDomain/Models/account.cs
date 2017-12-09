using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class account
    {
        public int id_Account { get; set; }
        public Nullable<double> Credit { get; set; }
        public int Rib_Number { get; set; } 
        public Nullable<int> member_id_Member { get; set; }
        public virtual member member { get; set; }
    }
}
