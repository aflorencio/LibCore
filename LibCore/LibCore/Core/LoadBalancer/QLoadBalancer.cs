using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public class QLoadBalancer
    {
        public MLoadBalancer GetBalancerInfo()
        {
            try
            {
                var _client = new MongoClient(Properties.Settings.Default.ip);
                var _database = _client.GetDatabase(Properties.Settings.Default.database);
                var _loadBalancerCollection = _database.GetCollection<MLoadBalancer>(Properties.Settings.Default.collection);

                var filter = Builders<MLoadBalancer>.Filter.Eq("_id", ObjectId.Parse(Properties.Settings.Default.id));
                var data = _loadBalancerCollection.Find(filter).FirstOrDefault();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}