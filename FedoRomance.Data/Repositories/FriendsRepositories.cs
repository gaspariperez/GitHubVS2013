using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data
{
    public class FriendsRepositories
    {
        //public static List<FriendRequest> getFriendRequestsForUser(int id)
        //{
        //    using (var context = new DateSiteDBEntities())
        //    {
        //        var friendrequests = context.FriendRequests.Where(x => x.Receiver == id);
        //        return friendrequests.ToList();
        //    }
        //}


        //public static void AcceptFriendRequestForUser(int UserId, int FriendId)
        //{
        //    using (var context = new DateSiteDBEntities())
        //    {
        //        var friends = new ContactList
        //        {
        //            FriendID = FriendId,
        //            UserID = UserId

        //        };
        //        var friends2 = new ContactList
        //        {
        //            FriendID = UserId,
        //            UserID = FriendId
        //        };
        //        RemoveFriendRequest(UserId, FriendId, context);
        //        context.ContactLists.Add(friends);
        //        context.ContactLists.Add(friends2);
        //        context.SaveChanges();
        //    }
        //}

        public static User GetUser(int id) {
            using (var context = new DatabaseEntities()) {

                return context.Users.FirstOrDefault(x => x.UID == id);
            }

        }


        public static List<User> getContactListForUser(int id)
        {
            using (var context = new DatabaseEntities())
            {
                var contactListForUser = context.Friends.Where(x => x.UID == id);
                var contactList = new List<User>();

                foreach (var item in contactListForUser)
                {
                    contactList.Add(GetUser(item.FID));
                }

                return contactList;
            }

        }



        //public static void SendFriendRequest(int receiverId, int senderId)
        //{
        //    using (var context = new DateSiteDBEntities())
        //    {
        //        var friendrequest = new FriendRequest
        //        {
        //            Sender = senderId,
        //            Receiver = receiverId
        //        };
        //        context.FriendRequests.Add(friendrequest);
        //        context.SaveChanges();
        //    }
        //}

        //public static bool CheckIfAlreadyFriendsOrIfFriendRequestIsPending(int userId, int wallownerId)
        //{
        //    using (var context = new DateSiteDBEntities())
        //    {
        //        bool IsValid = false;
        //        if (
        //            context.FriendRequests.FirstOrDefault(x => x.Sender == userId && x.Receiver == wallownerId
        //                                                       ||
        //                                                       x.Sender == wallownerId && x.Receiver == userId) != null
        //            )
        //        {
        //            return IsValid;
        //        }
        //        else if (context.ContactLists.FirstOrDefault(x => x.UserID == userId && x.FriendID == wallownerId) ==
        //                 null)
        //        {
        //            IsValid = true;
        //        }

        //        return IsValid;

        //    }
























        }
    }
