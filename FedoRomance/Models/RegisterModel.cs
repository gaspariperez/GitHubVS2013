using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FedoRomance.Web.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Visible { get; set; }

        public bool BoolValue
        {
            get { return Visible == 1; }
            set { Visible = value ? 1 : 0; }
        }
    }
}