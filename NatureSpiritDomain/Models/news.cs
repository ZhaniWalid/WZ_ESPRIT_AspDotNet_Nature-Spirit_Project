using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatureSpiritData.Models
{
    public partial class news
    {
        public news()
        {
            this.membernews = new List<membernew>();
        }

        [Key]
        public int idNews { get; set; }
        [Required(ErrorMessage = "Title Is Required.")]
        public string title { get; set; }
        [Required(ErrorMessage = "Description Is Required.")]
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

