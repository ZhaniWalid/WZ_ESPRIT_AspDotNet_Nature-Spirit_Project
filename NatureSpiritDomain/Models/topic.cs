using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatureSpiritData.Models
{
    public partial class topic
    {
        public topic()
        {
            this.news = new List<news>();
        }

        [Key]
        public int idTopic { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string typeTopic { get; set; }
        [ForeignKey("admin_id_Member")]
        public virtual member member { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        public virtual ICollection<news> news { get; set; }
    }
}
