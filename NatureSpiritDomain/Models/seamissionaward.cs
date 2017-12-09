using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class seamissionaward
    {
        public int idSeaMissionAward { get; set; }
        public string Destination { get; set; }
        public Nullable<double> altitude { get; set; }
        public Nullable<System.DateTime> endStart { get; set; }
        public string goal { get; set; }
        public Nullable<double> longitude { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public string warning { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public Nullable<int> sailor_id_Member { get; set; }
        public virtual member member { get; set; }
        public virtual member member1 { get; set; }
    }
}
