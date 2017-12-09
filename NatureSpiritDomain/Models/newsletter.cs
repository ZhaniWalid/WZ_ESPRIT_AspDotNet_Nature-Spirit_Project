using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class newsletter
    {
        public newsletter()
        {
            this.members = new List<member>();
        }

        public int id_Newsletter { get; set; }
        public string News_Contents { get; set; }
        public string News_Subject { get; set; }
        public int User_Registration_Number { get; set; }
        public virtual ICollection<member> members { get; set; }
    }
}
