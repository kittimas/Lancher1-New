using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;
namespace Lancher.Controllers
{
    public class MyjobController : Controller
    {
        public ActionResult Jabb()
        {
            string email = Session["email"].ToString();
            string Photo = Session["Photo"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT post.* , posting.EmailID , posting.PostID FROM posting inner join user on posting.EmailID = user.EmailID inner join post on posting.PostID = post.PostID WHERE posting.EmailID = '" + email + "' ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<ThreeTableViewModel>();
            string keepphoto = Session["Photo"].ToString();
            MySqlDataReader dr = cmd.ExecuteReader();

            ViewBag.showImag = keepphoto;

            try
            {   
                while (dr.Read())
                {
                    var Threepost_m = new ThreeTableViewModel();
                    Threepost_m.PostID = dr.GetString(0);
                    Threepost_m.Title = dr.GetString(1);
                    Threepost_m.PostDescrip = dr.GetString(2);
                    Threepost_m.PostMany = dr.GetString(3);
                    Threepost_m.TypePost = dr.GetString(4);
                    Threepost_m.PostMoney = dr.GetString(5);
                    Threepost_m.DeadlinePost = Convert.ToDateTime(dr.GetString(6));
                    Threepost_m.PostEmailID = dr.GetString(7);

                    ViewBag.showImag = keepphoto;

                    model.Add(Threepost_m);
                }

            }
            catch { }


            return View(model);
        }

        public ActionResult Jubb()
        {
            return View();
        }

        public ActionResult deletejob()
        {
            string email = Session["email"].ToString();
            string flfll = Request.Form["111"];

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "DELETE FROM posting WHERE EmailID='"+ email +"'  && PostID = '"+ flfll + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);

            cmd.ExecuteNonQuery();


            return RedirectToAction("Jabb", "Myjob");
        }
    }
}