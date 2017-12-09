using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NatureSpiritData.Models;

namespace NatureSpiritMVC.Models
{
    public class MemberNewsModels
    {
        public int Id_Member { get; set; }
        public int Id_News { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime date_Of_Comment { get; set; }
        public string title_selected_news { get; set; }
        public string description_selected_news { get; set; }
        public string Comment { get; set; }
        public int like_dislike { get; set; }

        public int State_News { get; set; }
        public virtual member member { get; set; }
        public virtual news news { get; set; }
    }
}