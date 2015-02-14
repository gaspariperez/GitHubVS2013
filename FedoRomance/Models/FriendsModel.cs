using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FedoRomance.Data;

namespace FedoRomance.Web.Models {
    public class FriendsModel {

        public Friend Friend { get; set; }
        public List<Friend> FriendsList { get; set; }
    }
}