using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register


        [HttpPost]
        public ActionResult Regis()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string name = Request.Form["name"];
            string surname = Request.Form["surname"];
            string facebook = Request.Form["facebook"];
            string Height = Request.Form["Height"];
            string Weight = Request.Form["Weight"];
            string Education = Request.Form["Education"];
            string filename = Request.Form["File1"];
            string birth = Request.Form["bday"];
            
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "INSERT INTO user(EmailID ,Password ,FirstName ,LastName ,FacebookName ,Height ,Weight ,Education ,StatusUser ,ImgUser ,BirthDay )"
                     + "VALUES" + "('" + email + "','" + password + "','" + name + "','" + surname + "','" + facebook + "','" + Height + "','" + Weight + "','" + Education + "','" + "User" + "','" + filename + "','" + birth + "')";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Loginn","Loginn");
        }

        public ActionResult Register()
        {
            return View();
        }


    }
}