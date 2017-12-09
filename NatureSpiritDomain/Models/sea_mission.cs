using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class sea_mission
    {
        public sea_mission()
        {
            this.mission_sailor = new List<mission_sailor>();
        }

        public int id_SeaMission { get; set; }
        public string Destination { get; set; }
        public string Goal { get; set; }
        public int Ship_Number { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public virtual member member { get; set; }
        public virtual ICollection<mission_sailor> mission_sailor { get; set; }
    }
}
