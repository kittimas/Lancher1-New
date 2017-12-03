using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lancher.Models
{
    public class user
    {
        public string EmailID { get; set; }
        public string PostID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacebookName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public DateTime BirthDay { get; set; }
        public string Education { get; set; }

        public string ImgUser { get; set; }
        public string StatusUser { get; set; }
        public string Mistake { get; set; }
    }
}