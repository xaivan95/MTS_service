using MTS_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationContext = MTS_service.Model.ApplicationContext;

namespace MTS_service.Control
{
    public class Authorization
    {
        public static User Authorizations(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var user = db.Users.Where(x => x.Login.ToLower().Equals(login.ToLower())).Where(x => x.Password.Equals(password)).ToList();
                if (user.Count > 0) return user.First();
            }
            return null;
        }
    }
}
