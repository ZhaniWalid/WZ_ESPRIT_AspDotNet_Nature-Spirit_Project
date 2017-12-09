using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Models
{
    public class NewsModels
    {
        [Key]
        public int idNews { get; set; }
        public string title { get; set; } 
        public string description { get; set; }
        public string picture { get; set; }
        public byte[] video { get; set; }
        public int like { get; set; }
        public string comment { get; set; }
        [ForeignKey("admin_id_Member")]
        public virtual member member { get; set; }
        public Nullable<int> admin_id_Member { get; set; }
        [ForeignKey("topic_idTopic")]
        public virtual topic topic { get; set; }
        public Nullable<int> topic_idTopic { get; set; }
        public virtual ICollection<membernew> membernews { get; set; }   
    }
}