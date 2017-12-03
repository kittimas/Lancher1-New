using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class HomerController : Controller
    {
        // GET: Homer

        public ActionResult FirstPage()
        {

            string email = Session["email"].ToString();


            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE EmailID = '" + email + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var User = new user();
            User.StatusUser = dr.GetString(10);
            User.ImgUser = dr.GetString(9);

            ViewBag.sdsdsdsd = User.StatusUser;
            Session["Photo"] = User.ImgUser;

            if (Session["Photo"].ToString().Length == 0)
            {
                Session["Photo"] = "2017112.png";
            }


            model.Add(User);

            return View(model);
        }

        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return RedirectToAction("adViewUser", "adViewUser");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Loginn", "Loginn");
        }

    }
}