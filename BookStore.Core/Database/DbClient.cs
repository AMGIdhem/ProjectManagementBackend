using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Ticket> _tickets;
        private readonly IMongoCollection<Project> _projects;
        private readonly IMongoCollection<User> _users;

        public DbClient(IOptions<ProjectManagementDbConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_name);
            _tickets = database.GetCollection<Ticket>(bookstoreDbConfig.Value.Tickets_Collection_name);
            _projects = database.GetCollection<Project>(bookstoreDbConfig.Value.Projects_Collection_name);
            _users = database.GetCollection<User>(bookstoreDbConfig.Value.Users_Collection_name);

        }
        public IMongoCollection<Ticket> GetTicketsCollection() => _tickets;
        public IMongoCollection<Project> GetProjectsCollection() => _projects;
        public IMongoCollection<User> GetUsersCollection() => _users;
    }
}
