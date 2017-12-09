using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using NatureSpiritData.Models;
using NatureSpiritMVC.Models;
using Newtonsoft.Json;

namespace NatureSpiritMVC.Controllers.ChartNewsMember
{
    public class StatNewsController : Controller
    {
        // GET: Stat
        
        public ActionResult Index()
        {
            using (var db = new baseContext())
            {
                var result = db.membernews.ToList();
                var resultat1=   result.GroupBy(u => u.Id_News);
    
                List< MemberStatsModels> list=new List<MemberStatsModels>();
                foreach (var membernew in resultat1)
                {
                    String title = "";
                    int countLike = 0;
                    int countDislike = 0;
                 foreach (var membernew1 in membernew)
                 {
                     if (membernew1.like_dislike == 0)
                         countDislike = countDislike + 1;
                     else
                     {
                         countLike = countLike + 1;
                     }
                     title = membernew1.title_selected_news;
                 }
                    list.Add(new MemberStatsModels {title_selected_news = title ,like_count = countLike,dislikke_count = countDislike });
                }

                return View(list);
            }
        }

        public ContentResult JSON()
        {
            using (var db = new baseContext())
            {
           //     var result = (from tags in db.membernews
            //                  orderby tags.date_Of_Comment ascending
             //                 select new { tags.title_selected_news, tags.like_dislike }).ToList();
                double count = 50, y = 10;

                Random random = new Random(DateTime.Now.Millisecond);

                List<DataPoint> dataPoints;

                dataPoints = new List<DataPoint>();

                for (int i = 0; i < count; i++)
                {
                    y = y + (random.Next(0, 20) - 10);

                    dataPoints.Add(new DataPoint(i, y));
                }

                JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

                return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
            }


        }
        [DataContract]

        internal class DataPoint
        {
            public DataPoint(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "x")]
            public Nullable<double> X = null;

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
        }
    }
}
  