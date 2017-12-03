using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class joinController : Controller
    {
        // GET: join

        public ActionResult join()
        {

            string idpost = Session["111"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT post.* , posting.EmailID , posting.PostID FROM posting inner join user on posting.EmailID = user.EmailID inner join post on posting.PostID = post.PostID WHERE posting.PostID = '" + idpost + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);

            var model = new List<ThreeTableViewModel>();

            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    var post_m = new ThreeTableViewModel();

                    post_m.PostID = dr.GetString(0);


                    post_m.EmailID = dr["EmailID"].ToString();

                    model.Add(post_m);
                    //model1.Add(three);
                }
                return View(model);
            }
            catch
            {

            }

            return View(model);

        }
    }
}