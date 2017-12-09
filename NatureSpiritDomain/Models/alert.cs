using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class alert
    {
        public int id_Alert { get; set; }
        public Nullable<System.DateTime> Alert_Date { get; set; }
        public string Alert_Description { get; set; }
        public string Alert_Location { get; set; }
        public string Alert_Subject { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public Nullable<int> member_id_Member { get; set; }
        public virtual member member { get; set; }
        public virtual member member1 { get; set; }
    }
}
