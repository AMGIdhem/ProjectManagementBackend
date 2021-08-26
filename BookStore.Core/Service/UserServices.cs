using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<User> _users;
        public UserServices(IDbClient dbClient)
        {
            _users = dbClient.GetUsersCollection();
        }
        public User AddUser(User user)
        {
            user.UserStatus = "activated";
            _users.InsertOne(user);
            return user;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public User GetUser(string id) => _users.Find(user => user.Id == id).First();

        public List<User> GetUsers()
        {
            return _users.Find(user => true).ToList();
        }

        public User Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _users.Find(user => true).ToList().SingleOrDefault(x => (x.Email == email && x.Password == password));

            if (user == null)
                return null;

            return user;


        }

        public User UpdateUser(User user)
        {
            GetUser(user.Id);
            _users.ReplaceOne(u => u.Id == user.Id, user);
            return user;
        }
    }
}
