using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class photography_competition
    {
        public int id_PhotoCompetition { get; set; }
        public Nullable<System.DateTime> Date_Of_Capture { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public Nullable<int> journalist_id_Member { get; set; }
        public Nullable<int> member_id_Member { get; set; }
        public Nullable<int> reclamationPicture_id_Reclamation { get; set; }
        public virtual member member { get; set; }
        public virtual member member1 { get; set; }
        public virtual member member2 { get; set; }
        public virtual reclamation reclamation { get; set; }
    }
}
