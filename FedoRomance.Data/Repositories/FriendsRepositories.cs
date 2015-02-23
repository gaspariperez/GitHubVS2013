using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FedoRomance.Data.Repositories 

{

    public class FriendsRepositories 

    {
        //Hämtar en användares vänner//
        public static List<Friend> GetFriends(int userId) 
        {
            using (var context = new DatabaseEntities()) 
            {
                var result = context.Friends
                    .Where(x => x.Accepted == true && (x.FID == userId || x.UID == userId))
                    .Include(x => x.User)
                    .Include(x => x.User1)
                    .ToList();

                return result;

            }
        }

        public static void AddFriend(Friend model) {
            using (var context = new DatabaseEntities()) {
                context.Friends.Add(model);
                context.SaveChanges();
            }

        }

        //Uppdaterar Friends.accepted till true för att bekräfta en vänskap
        public static void UpdateFriendConfirmed(int uid, int fid) {
            using (var context = new DatabaseEntities()) {
                Friend f = context.Friends
                    .FirstOrDefault(x => (x.FID == fid && x.UID == uid) || (x.UID == fid && x.FID == uid));


                f.Accepted = true;
                context.SaveChanges();
            }
        }


        public static List<Friend> CheckFriendsRequests(int userId) {

            using (var context = new DatabaseEntities()) {
                var result = context.Friends
                    .Where(x => x.Accepted == false && (x.FID == userId || x.UID == userId))
                    .Include(x => x.User)
                    .Include(x => x.User1)
                    .ToList();

                return result;

            }
        }

        //Hämtar relation mellan två användare//
        public static Friend GetFriendship(int uid, int fid) {
            using (var context = new DatabaseEntities())
            {
                Friend f = context.Friends
                    .FirstOrDefault(x => (x.FID == fid && x.UID == uid) || (x.UID == fid && x.FID == uid));

                return f;
            }
        }


        //Används till visningen i layout//
        public static int GetPendingRequests(int uid)
        {
            using (var context = new DatabaseEntities())
            {
                int pendingFriends = context.Friends
                    .Count(friend => friend.FID == uid && !friend.Accepted);

                return pendingFriends;
            }
        }
    }

}
