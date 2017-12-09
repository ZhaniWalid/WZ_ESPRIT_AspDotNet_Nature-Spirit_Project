using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureSpiritServices.Interfaces;
using NatureSpiritData.Models;
using System.Web.Services;


namespace NatureSpiritServices.Implements
{
    public class ChartNewsMemberServices : IChartNewsMemberServices
    {
        public  IEnumerable ListdataChart()
        {
            using (SqlConnection con = new SqlConnection
                 (ConfigurationManager.ConnectionStrings["baseContext"].ToString()))
            {
                string Query = @"SELECT  
                                pm.PlanName,  
                                SUM(p.PaymentAmount) AS PaymentAmount  
                                FROM PaymentDetails p   
                                INNER JOIN PlanMaster PM ON p.PlanID = PM.PlanID   
                                GROUP BY PM.PlanName";
                // this is query which in in stored procedure  

                SqlCommand command = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<membernew> l = new List<membernew>();
               // l.Add(reader);
              
               // var list= con.Query<membernew>("Usp_Getdata").AsEnumerable();
                //var list2 = con.;

                // List of type Outputclass which it will return .  
                return l;
            }
        }

        [WebMethod]
        public static List<object> GetChartNewsMemberData()
        {
            string query = "SELECT title_selected_news , count(like_dislike) As nbLikes";
            query += " FROM membernews WHERE like_dislike = 0 or like_dislike = 1 GROUP BY date_Of_Comment";
            string constr = ConfigurationManager.ConnectionStrings["base"].ConnectionString;
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
            { 
            "title_selected_news", "nbLikes"
            });
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                            {
                        sdr["title_selected_news"], sdr["nbLikes"]
                            });
                        }
                    }
                    con.Close();
                    return chartData;
                }
            }
        }

    }
}
