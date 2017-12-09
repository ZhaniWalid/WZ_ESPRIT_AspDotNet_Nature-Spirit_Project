using System;
using System.Collections.Generic;

namespace NatureSpiritData.Models
{
    public partial class donationtheory
    {
        public int id_Donation_Theory { get; set; }
        public Nullable<double> Amount_of_money { get; set; }
        public Nullable<System.DateTime> Date_of_transfert { get; set; }
        public Nullable<int> member_id_Member { get; set; }
        public virtual member member { get; set; }
    }
}
