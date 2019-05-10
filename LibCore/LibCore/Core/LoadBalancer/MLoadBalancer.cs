using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{

    public class MLoadBalancer
    {
        public ObjectId _id { get; set; }
        [BsonIgnoreIfNull]
        public FlowService FlowService { get; set; }
        [BsonIgnoreIfNull]
        public ContactoService ContactoService { get; set; }

    }

    public class Server
    {
        [BsonIgnoreIfNull]
        public string url { get; set; }
        [BsonIgnoreIfNull]
        public string status { get; set; }
    }

    public class Db
    {
        [BsonIgnoreIfNull]
        public string url { get; set; }
        [BsonIgnoreIfNull]
        public string status { get; set; }
    }

    public class FlowService
    {
        [BsonIgnoreIfNull]
        public Server server { get; set; }
        [BsonIgnoreIfNull]
        public Db db { get; set; }
    }

    public class ContactoService
    {
        [BsonIgnoreIfNull]
        public Server server { get; set; }
        [BsonIgnoreIfNull]
        public Db db { get; set; }
    }

}