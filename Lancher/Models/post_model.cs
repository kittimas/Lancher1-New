using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lancher.Models
{
    public class post_model
    {
        public string PostID { get; set; }
        public string Title { get; set; }
        public string PostDescrip { get; set; }
        public string PostMany { get; set; }
        public string TypePost { get; set; }
        public string PostMoney { get; set; }
        public DateTime DeadlinePost { get; set; }
        public string PostEmailID { get; set; }

        public string ImagUser { get; set; }

        public string SubUser { get; set; }

    }
}