using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Resume { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserAssignedId { get; set; }
        public String status { get; set; }

    }
}
