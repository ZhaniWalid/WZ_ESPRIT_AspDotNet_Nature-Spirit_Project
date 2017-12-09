using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class @event
    {
        public @event()
        {
            this.agenda = new List<agendum>();
            this.donations = new List<donation>();
            this.participations = new List<participation>();
        }

        public int id_Event { get; set; }
        public Nullable<System.DateTime> Date_Event { get; set; }
        public string Description_Event { get; set; }
        public string Location_Event { get; set; }
        public string NameEvent { get; set; }
        public string TypeEvent { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public virtual ICollection<agendum> agenda { get; set; }
        public virtual ICollection<donation> donations { get; set; }
        public virtual ICollection<participation> participations { get; set; }
        public virtual member member { get; set; }
    }
}
