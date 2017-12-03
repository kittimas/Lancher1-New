using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult test()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM test123";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<test>();
            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    //var post_m = new ThreeTableViewModel();
                    var post_m = new test();
                    post_m.idpost = Convert.ToInt32(dr.GetString(0));
                    post_m.namepost = dr.GetString(1);


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

        public ActionResult testtt()
        {
            string Name_Post5 = Request.Form["Name_Post5"];


            string email = Session["email"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "INSERT INTO test123(idpost,namepost)"
                            + "VALUES" + "('" + Name_Post5 + "')";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();

            return RedirectToAction("", "");
        }
    }
}