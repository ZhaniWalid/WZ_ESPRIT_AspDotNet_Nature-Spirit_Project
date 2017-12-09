using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class comment
    {
        public System.DateTime Date_Of_Comment { get; set; }
        public int Id_Article { get; set; }
        public int Id_Member { get; set; }
        public string Comment1 { get; set; }
        public Nullable<int> reclamationComment_id_Reclamation { get; set; }
        public virtual article article { get; set; }
        public virtual reclamation reclamation { get; set; }
        public virtual member member { get; set; }
    }
}
