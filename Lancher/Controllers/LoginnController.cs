using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class LoginnController : Controller
    {
        // GET: Loginn
        public ActionResult Loginn()
        {

            //LancherMaxEntities db = new LancherMaxEntities();
            
            return View();
        }

        [HttpPost]
        public ActionResult Signin()
        {
            string email = Request.Form["email_user"];
            string pass = Request.Form["password_user"];
            
            if (email != null && pass != null)
            {
                MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
                string strSQL = "SELECT * FROM user WHERE EmailID = '" + email + "' AND Password = '" + pass + "' AND Mistake = '"+"Active"+"'";

                con.Open();
                MySqlCommand cmd = new MySqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();

                var obj = cmd.ExecuteScalar();
                try
                {
                    Session["email"] = obj.ToString();
                    return RedirectToAction("FirstPage", "Homer");
                }
                catch
                {
                    ViewBag.Ty = "Failded";
                    return RedirectToAction("Loginn", "Loginn");
                }

            }
            else
            {
                
            }
            return View();
        }

        public ActionResult Reee()
        {
            //sssssss
            return RedirectToAction("Register", "Register");
        }
    }


}