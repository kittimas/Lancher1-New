using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;

namespace Lancher.Controllers
{
    public class PostController : Controller
    {

        // GET: Post


        public ActionResult Post()
        {
            string email = Session["email"].ToString();
            string idpost = Request.Form["111"];

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT post.* FROM post WHERE PostEmailID = '" + email + "'";
            //string strSQL = "SELECT post.* , posting.EmailID , posting.PostID FROM posting inner join user on posting.EmailID = user.EmailID inner join post on posting.PostID = post.PostID WHERE posting.PostID = '" + idpost + "' OR post.PostEmailID = '" + email + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<post_model>();
            //var model = new List<ThreeTableViewModel>();
            string keepphoto = Session["Photo"].ToString();
            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                
                while (dr.Read())
                {
                    //var post_m = new ThreeTableViewModel();
                    var post_m = new post_model();
                    post_m.PostID = dr.GetString(0);
                    post_m.Title = dr.GetString(1);
                    post_m.PostMoney = dr.GetString(5);
                    post_m.PostDescrip = dr.GetString(2);
                    post_m.PostMany = dr.GetString(3);
                    post_m.TypePost = dr.GetString(4);
                    post_m.DeadlinePost =Convert.ToDateTime(dr.GetString(6));

                    //post_m.EmailID = dr["EmailID"].ToString();
                    //three.EmailID = dr.GetString(0);
                    //ViewBag.EmailID = post_m.EmailID;

                    post_m.ImagUser = keepphoto;
                    Session["Photo"] = post_m.ImagUser;
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

        //public ActionResult SubPost()
        //{
        //    string idpost = Request.Form["111"];

        //    MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
        //    string strSQL = "SELECT post.* , posting.EmailID , posting.PostID FROM posting inner join user on posting.EmailID = user.EmailID inner join post on posting.PostID = post.PostID WHERE posting.PostID = '" + idpost + "'";
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand(strSQL, con);
        //    var model = new List<ThreeTableViewModel>();
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    try
        //    {

        //        while (dr.Read())
        //        {
        //            var post_m = new ThreeTableViewModel();

        //            post_m.EmailID = dr["EmailID"].ToString();

        //            model.Add(post_m);

        //        }
        //        return View(model);
        //    }
        //    catch
        //    {

        //    }

        //    return View(model);
        //}


        public ActionResult PostCode()
        {
            string idpost = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string Name_Post5 = Request.Form["Name_Post5"];
            string Des = Request.Form["Des"];
            string many = Request.Form["many"];
            string typepost = Request.Form["typepost"];
            string Pucket = Request.Form["Pucket"];
            string deadline = Request.Form["deadline"];

            string email = Session["email"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "INSERT INTO post(PostID ,Title ,PostDescrip ,PostMany ,TypePost ,MoneyPost ,DeadlinePost ,PostEmailID )"
                            + "VALUES" + "('" + idpost + "','" + Name_Post5 + "','" + Des + "','" + many + "','" + typepost + "','" + Pucket + "','" + deadline + "','" + email + "')";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Post", "Post");
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult change(posting post)
        {
            var model = new List<posting>();
            string usdsa = Request.Form["111"];
            Session["111"] = usdsa;
            return RedirectToAction("join", "join");
        }


    }
}