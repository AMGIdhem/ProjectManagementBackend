using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IUserServices
    {
        List<User> GetUsers();
        User GetUser(string id);
        User AddUser(User user);
        void DeleteUser(string id);
        User UpdateUser(User user);
        User Login(string email, string password);
    }
}
