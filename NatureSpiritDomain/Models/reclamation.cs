using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class reclamation
    {
        public reclamation()
        {
            this.comments = new List<comment>();
            this.members = new List<member>();
            this.photography_competition = new List<photography_competition>();
        }

        public string DTYPE { get; set; }
        public int id_Reclamation { get; set; }
        public Nullable<System.DateTime> Date_Reclamation { get; set; }
        public string Description_Reclamation { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Nullable<int> idReclamtionMember { get; set; }
        public string Picture { get; set; }
        public Nullable<int> idReclamationPicture { get; set; }
        public string Comment { get; set; }
        public Nullable<int> idReclamationComment { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public Nullable<int> member_id_Member { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual member member { get; set; }
        public virtual member member1 { get; set; }
        public virtual ICollection<member> members { get; set; }
        public virtual ICollection<photography_competition> photography_competition { get; set; }
    }
}
