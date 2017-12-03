using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Lancher.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Lancher.Controllers
{
    public class adViewUserController : Controller
    {
        public ActionResult Ban()
        {
            string Id = Request.Form["111"];
            string Status = Request.Form["Statuss"].ToString();
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");//

            string strSQL = "UPDATE user SET Mistake = '" + Status + "' WHERE EmailID = '" + Id + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("adViewUser", "adViewUser");

            //return View("adViewUser");
        }
        // GET: adViewUser
        public ActionResult adViewUser()
        {

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE StatusUser != '"+"Admin"+"'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    var User = new user();
                    User.EmailID = dr.GetString(0);
                    User.Mistake = dr.GetString(11);
                    model.Add(User);

                }
                con.Clone();
            }
            catch
            {

            }

            return View(model);

            
        }

        public ActionResult adViewUserUpdate()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();
            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    var post_m = new user();

                    post_m.EmailID = dr.GetString(0);
                    post_m.Password = dr.GetString(1);
                    post_m.FirstName = dr.GetString(2);
                    post_m.LastName = dr.GetString(3);
                    post_m.FacebookName = dr.GetString(4);
                    post_m.Height = dr.GetString(5);
                    post_m.Weight = dr.GetString(6);
                    post_m.BirthDay = Convert.ToDateTime(dr.GetString(7));
                    post_m.Education = dr.GetString(8);
                    post_m.ImgUser = dr.GetString(9);
                    post_m.StatusUser = dr.GetString(10);

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

        public ActionResult sqlserver()
        {

            return View();
        }

        //public ActionResult addserver()
        //{
        //    string p_name = Request.Form["title"];
            
        //    string p_text = Request.Form["description"];

        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FH9A82H\SQLEXPRESS;Initial Catalog=lancherdb;Integrated Security=True");
        //    string strSQLserver = "INSERT INTO posthome(p_name,p_text)"
        //        + "VALUES" + "('" + p_name + "','" + p_text + "')";
        //    con.Open();
        //    SqlCommand cmdSqlserver = new SqlCommand(strSQLserver, con);
        //    cmdSqlserver.ExecuteNonQuery();
        //    return View();
        //}



        
    }
}