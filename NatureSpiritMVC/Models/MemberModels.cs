using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Models
{
    public class MemberModels
    {
        public string DTYPE { get; set; }
        [Key]
        public int id_Member { get; set; }
        public Nullable<System.DateTime> Date_Birth { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Profil_Picture { get; set; }
        // public string Role { get; set; }
        public Nullable<float> balance { get; set; }
        public string Num_Journalist_Card { get; set; }
        public string Num_Sailor { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public Nullable<int> newsletter_id_Newsletter { get; set; }
        public Nullable<int> reclamationMember_id_Reclamation { get; set; }
        public virtual ICollection<account> accounts { get; set; }
        public virtual ICollection<agendum> agenda { get; set; }
        public virtual ICollection<alert> alerts { get; set; }
        public virtual ICollection<alert> alerts1 { get; set; }
        public virtual ICollection<article> articles { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<detail> details { get; set; }
        public virtual ICollection<donation> donations { get; set; }
        public virtual ICollection<donationtheory> donationtheories { get; set; }
        public virtual ICollection<@event> events { get; set; }
        public virtual ICollection<participation> participations { get; set; }
        public virtual newsletter newsletter { get; set; }
        public virtual ICollection<topic> topics { get; set; }
        public virtual ICollection<news> news { get; set; }
        public virtual ICollection<seamissionaward> seamissionawards { get; set; }
        public virtual ICollection<member> member1 { get; set; }
        public virtual member member2 { get; set; }
        public virtual ICollection<photography_competition> photography_competition { get; set; }
        public virtual ICollection<membernew> membernews { get; set; }
        public virtual ICollection<reclamation> reclamations { get; set; }
        public virtual ICollection<reclamation> reclamations1 { get; set; }
        public virtual ICollection<product> products { get; set; }
        public virtual reclamation reclamation { get; set; }
        public virtual ICollection<photography_competition> photography_competition1 { get; set; }
        public virtual ICollection<photography_competition> photography_competition2 { get; set; }
        public virtual ICollection<seamissionaward> seamissionawards1 { get; set; }
        public virtual ICollection<mission_sailor> mission_sailor { get; set; }
        public virtual ICollection<sea_mission> sea_mission { get; set; }    
    }
}