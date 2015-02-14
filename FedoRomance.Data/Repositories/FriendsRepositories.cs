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

        // GET: /Friends List-Result by Users Id

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

        // SET: /Add new friend request
        public static void AddFriend(Friend model) {
            using (var context = new DatabaseEntities()) {
                context.Friends.Add(model);
                context.SaveChanges();
            }

        }

        // UPDATE: /Confirm friend as friend
        public static void UpdateFriendConfirmed(int id) {
            using (var context = new DatabaseEntities()) {
                Friend f = context.Friends
                    .FirstOrDefault(x => x.RelationID == id);

                f.Accepted = true;
                context.SaveChanges();
            }
        }

        // GET: /Get a list of requesting friends
        public static List<Friend> CheckFriendsRequests(int userId) {

            using (var context = new DatabaseEntities()) {
                var result = context.Friends
                    .Where(x => x.Accepted == false && x.FID == userId)
                    .Include(x => x.User)
                    .Include(x => x.User1)
                    .ToList();

                return result;

            }
        }

    }

}
