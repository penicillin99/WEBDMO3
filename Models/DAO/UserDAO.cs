using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class UserDAO
    {

        WebDbContext db = null;
        public UserDAO()
        {
            db = new WebDbContext();
        }

        // Check login 
        public bool CheckLogin(string username, string password)
        {
            var res = db.MANAGERs.Count(x => x.username == username && x.password == password);
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // insert user
        public int InsertUser(MANAGER user)
        {
            db.MANAGERs.Add(user);
            db.SaveChanges();
            return user.id;
        }

        // Get id by username

        public MANAGER GetIdByUsername(string username)
        {
            return db.MANAGERs.SingleOrDefault(x => x.username == username);
        }

    }
}
