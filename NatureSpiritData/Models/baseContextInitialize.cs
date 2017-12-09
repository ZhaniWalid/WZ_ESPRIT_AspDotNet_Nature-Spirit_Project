using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritDomain.Models;

namespace NatureSpiritData.Models
{
   public class baseContextInitialize : DropCreateDatabaseAlways<baseContext>
    {  
        protected override void Seed(baseContext context)
        {
        
           /* List<admin> list_members = new List<admin>
            {  
                new admin() { id_Member = 1 , Last_Name = "Zhani", First_Name = "Walid",Date_Birth=new DateTime(1992,08,03) ,Email = "walid.zhani@esprit.tn",Login="edzio",Password = "edzio"}
            };
               
            context.members.AddRange(list_members);
            context.SaveChanges();
               
            base.Seed(context);*/  
        }

    }
}
