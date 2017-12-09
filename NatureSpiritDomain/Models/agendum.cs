using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class agendum
    {
        public int Id_Event { get; set; }
        public int Id_Member { get; set; }
        public System.DateTime date_Event { get; set; }
        public virtual member member { get; set; }
        public virtual @event @event { get; set; }
    }
}
