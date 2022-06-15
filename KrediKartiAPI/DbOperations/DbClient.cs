using KrediKartiAPI.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KrediKartiAPI.DbOperations
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<CreditCard> _cards;
        public DbClient(IOptions<CreditCardDbConfig> creditCardDbConfig)
        {
            var client = new MongoClient(creditCardDbConfig.Value.Connection_String);
            var database = client.GetDatabase(creditCardDbConfig.Value.Database_Name);
            _cards = database.GetCollection<CreditCard>(creditCardDbConfig.Value.CreditCards_Collection_Name);
        }

        public IMongoCollection<CreditCard> GetCreditCardsCollection()
        {
            return _cards;
        }
    }
}
