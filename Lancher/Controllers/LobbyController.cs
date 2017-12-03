using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Lancher.Controllers
{
    [Route("[controller]/[action]")]
    public class LobbyController : Controller
    {

        public ActionResult Lobby()
        {
            string email = Session["email"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            //SqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM post";

            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<post_model>();
            string keepphoto = Session["Photo"].ToString();
            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    var post_m = new post_model();
                    post_m.PostID = dr.GetString(0);
                    post_m.Title = dr.GetString(1);
                    post_m.PostDescrip = dr.GetString(2);
                    post_m.PostMany = dr.GetString(3);
                    post_m.TypePost = dr.GetString(4);
                    post_m.PostMoney = dr.GetString(5);
                    post_m.DeadlinePost = Convert.ToDateTime(dr.GetString(6));
                    post_m.PostEmailID = dr.GetString(7);

                    post_m.ImagUser = keepphoto;
                    ViewBag.showImag = post_m.ImagUser;

                    model.Add(post_m);
                }
                return View(model);
            }
            catch
            {

            }
            return View(model);
        }

        public ActionResult LobbyCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult jub()
        {
            string postid = Request.Form["111"];
            string email = Session["email"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "INSERT INTO posting(PostID , EmailID)"
                + "VALUES" + "('" + postid + "','" + email + "')";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Jabb", "Myjob");


        }

    }
}