using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class donation
    {
        public System.DateTime dateOfDonation { get; set; }
        public int idEvent { get; set; }
        public int idMember { get; set; }
        public Nullable<float> amount { get; set; }
        public virtual member member { get; set; }
        public virtual @event @event { get; set; }
    }
}
