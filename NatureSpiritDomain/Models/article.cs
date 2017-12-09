using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class article
    {
        public article()
        {
            this.comments = new List<comment>();
        }

        public int id_Article { get; set; }
        public string Image { get; set; }
        public string Subject { get; set; }
        public Nullable<int> journalist_id_Member { get; set; }
        public virtual member member { get; set; }
        public virtual ICollection<comment> comments { get; set; }
    }
}
