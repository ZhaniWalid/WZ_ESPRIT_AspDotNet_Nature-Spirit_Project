using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class mission_sailor
    {
        public int Id_Member { get; set; }
        public int Id_SeaMission { get; set; }
        public System.DateTime end_Date { get; set; }
        public System.DateTime start_Date { get; set; }
        public Nullable<bool> state { get; set; }
        public virtual member member { get; set; }
        public virtual sea_mission sea_mission { get; set; }
    }
}
