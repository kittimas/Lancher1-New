using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            string email = Session["email"].ToString();
            string Photo = Session["Photo"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE EmailID = '" + email + "'" ;

            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();
            MySqlDataReader rd = cmd.ExecuteReader();
            //rd.Read();

            //cmd.ExecuteNonQuery();

            try
            {
                while (rd.Read())
                {
                    var User = new user();

                    User.FirstName = rd.GetString(2);
                    User.LastName = rd.GetString(3);
                    User.FacebookName = rd.GetString(4);
                    User.Education = rd.GetString(8);
                    User.ImgUser = Photo;
                    ViewBag.showImag = User.ImgUser;

                    model.Add(User);
                    //ViewBag.Add(User);

                    //surname = rd.GetString(3); 
                }

            }
            catch { }


            return View(model);
        }
    }
}