//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FedoRomance.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Users1 = new HashSet<User>();
            this.Users = new HashSet<User>();
        }
    
        public int UID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public int Visible { get; set; }
        public int Logged { get; set; }
    
        public virtual ICollection<User> Users1 { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
